using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace ConveyorController
{

    static class Server
    {

        const int ConnectionTestTime = 100;
        const int ReconnectDelayTime = 100;

        static byte[] ioOptionValues;
        static int connectionTestCount = 0;
        static MainForm mainForm;
        static NetworkStream stream = null;
        static StreamReader reader = null;
        static StreamWriter writer = null;
        static TcpClient client = null;

        static bool _connected = false; public static bool connected { get { return _connected; } private set { _connected = value; } }

        public static void init(MainForm mainForm)
        {
            Server.mainForm = mainForm;
            new Thread(receiveThreadMain).Start();
            uint uintType = 0;
            ioOptionValues = new byte[Marshal.SizeOf(uintType) * 3];
            BitConverter.GetBytes((uint)1).CopyTo(ioOptionValues, 0);
            BitConverter.GetBytes((uint)5000).CopyTo(ioOptionValues, Marshal.SizeOf(uintType));
            BitConverter.GetBytes((uint)1000).CopyTo(ioOptionValues, Marshal.SizeOf(uintType) * 2);
        }

        static void receiveThreadMain()
        {
            connectServer();
            while (true)
            {
                try
                {
                    if (connectionTestCount++ > ConnectionTestTime)
                    {
                        connectionTestCount = 0;
                        writer.WriteLine("");
                    }
                    if (client.Connected && stream.DataAvailable)
                    {
                        connectionTestCount = 0;
                        string message = reader.ReadLine();
                        Console.WriteLine(string.Format("Receive message: '{0}'", message));
                        if (message != "")
                        {
                            try
                            {
                                message = message.ToLower();
                                if (message == "auto_start")
                                    mainForm.artificialIntelligenceForm.try_auto_start();
                                else if (message == "auto_stop")
                                    mainForm.artificialIntelligenceForm.try_auto_stop();
                                else if (!ArtificialIntelligence.running)
                                {
                                    string methodName = message.Substring(0, 2);
                                    methodName += message[4] == 'u' ? "C" : message.Substring(4, 1).ToUpper();
                                    int parameter = message[2] - 0x30 - 1;
                                    Console.WriteLine(string.Format("Call method: '{0}' with parameter '{1}'", methodName, parameter));
                                    typeof(ConveyorBasicController).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { parameter });
                                }
                            }
                            catch
                            {
                            }
                        }
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("{\"ch\":[");
                        foreach (ConveyorChState x in ConveyorBasicController.ChStatus)
                        {
                            stringBuilder.Append((int)x).Append(",");
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append("],\"cr\":[");
                        foreach (ConveyorCrState x in ConveyorBasicController.CrStatus)
                        {
                            stringBuilder.Append((int)x).Append(",");
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append("],\"mr\":").Append((int)ConveyorBasicController.mrState).Append(",\"st\":[");
                        foreach (ConveyorStState x in ConveyorBasicController.StStatus)
                        {
                            stringBuilder.Append((int)x).Append(",");
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        stringBuilder.Append("]}");
                        writer.WriteLine(stringBuilder.ToString());
                    }
                }
                catch (Exception e)
                {
                    connected = false;
                    Console.WriteLine(e);
                    Console.WriteLine("Server disconnected");
                    Thread.Sleep(200);
                    connectServer();
                }
                Thread.Sleep(50);
            }
        }

        static void connectServer()
        {
            while (true)
            {
                try
                {
                    connectionTestCount = 0;
                    Console.WriteLine("Connecting to server");
                    client = new TcpClient(Config.serverAddress, Config.serverPort);
                    client.Client.IOControl(IOControlCode.KeepAliveValues, ioOptionValues, null);
                    stream = client.GetStream();
                    reader = new StreamReader(stream);
                    writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    connected = true;
                    Console.WriteLine("Server connect success");
                    break;
                }
                catch
                {
                    Console.WriteLine("Server connect fail");
                    Thread.Sleep(Config.reconnectTime);
                }
            }
        }

    }

}

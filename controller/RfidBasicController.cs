using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using nsAlienRFID;

namespace ConveyorController
{

    abstract class RfidBasicController
    {

        static clsReader reader;

        static bool _connected = false; public static bool connected { get { return _connected; } private set { _connected = value; } }

        public static void init()
        {
            reader = new clsReader();
            connect();
        }

        static void connect()
        {
            reader.InitOnCom(2);
            if (reader.Connect() == "Connected") {
                reader.AcquireMode = "Global Scroll";
                connected = true;
            }
        }


        public static string read()
        {
            string result = null;
            if (!connected)
            {
                connect();
            }
            if (connected)
            {
                try
                {
                    string tag = reader.TagList;
                    tag = new Regex("(?<=Tag:)([\\dA-F]{4} ?){6}").Match(tag).ToString();
                    if (tag != "")
                    {
                        result = tag;
                        Console.WriteLine("RFID tag detected : {0}", result);
                    }
                }
                catch {
                    connected = false;
                }
            }
            return result;
        }

    }

}

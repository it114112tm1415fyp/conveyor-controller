using AxDAQDILib;
using AxDAQDOLib;
using System;
using System.Threading;

namespace ConveyorController
{

    abstract class ConveyorBasicController
    {

        public const int BitNum = 32;
        /// <summary>
        /// Changeover Number
        /// </summary>
        public const int ChNum = 4;
        /// <summary>
        /// Crossover Number
        /// </summary>
        public const int CrNum = 2;
        public const int EmergencyStopNum = 4;
        public const int SenserNum = 8;
        /// <summary>
        /// Stopper Number
        /// </summary>
        public const int StNum = 8;

        /// <summary>
        /// Changeover Status
        /// </summary>
        public readonly static ConveyorChState[] ChStatus = new ConveyorChState[ChNum];
        /// <summary>
        /// Crossover Status
        /// </summary>
        public readonly static ConveyorCrState[] CrStatus = new ConveyorCrState[CrNum];
        /// <summary>
        /// Stopper Status
        /// </summary>
        public readonly static ConveyorStState[] StStatus = new ConveyorStState[StNum];

        protected readonly static bool[] Input = new bool[BitNum];
        protected readonly static bool[] Output = new bool[BitNum];

        /// <summary>
        /// Device Input
        /// </summary>
        readonly static AxDAQDI[] DI = new AxDAQDI[2];
        /// <summary>
        /// Device Output
        /// </summary>
        readonly static AxDAQDO[] DO = new AxDAQDO[2];

        /// <summary>
        /// Main Roller Status
        /// </summary>
        public static ConveyorMRState mrState;

        static Thread refreshDataThread;

        public static bool[] input
        {
            get
            {
                bool[] result = new bool[Input.Length];
                Array.Copy(Input, result, Input.Length);
                return result;
            }
        }
        public static bool[] output
        {
            get
            {
                bool[] result = new bool[Output.Length];
                Array.Copy(Output, result, Output.Length);
                return result;
            }
        }

        public static void init(MainForm form)
        {
            DI[0] = form._daqdi1;
            DI[1] = form._daqdi2;
            DO[0] = form._daqdo1;
            DO[1] = form._daqdo2;
            Output[(int) ConveyorOutputDevice.ChangeoverPower] = true;
            Output[(int) ConveyorOutputDevice.CrossoverPower] = true;
            refreshDataThread = new Thread(refreshDataThreadMain);
            refreshDataThread.Start();
        }

        /// <summary>
        /// changeoverBackward
        /// </summary>
        public static void chB(int n)
        {
            ChStatus[n] &= ~ConveyorChState.Forward;
            ChStatus[n] |= ConveyorChState.Backward;
        }

        /// <summary>
        /// changeoverChange
        /// </summary>
        public static void chC(int n)
        {
            ChStatus[n] ^= ConveyorChState.Up;
        }

        /// <summary>
        /// changeoverDown
        /// </summary>
        public static void chD(int n)
        {
            ChStatus[n] &= ~ConveyorChState.Up;
        }

        /// <summary>
        /// changeoverForward
        /// </summary>
        public static void chF(int n)
        {
            ChStatus[n] &= ~ConveyorChState.Backward;
            ChStatus[n] |= ConveyorChState.Forward;
        }

        /// <summary>
        /// changeoverStop
        /// </summary>
        public static void chS(int n)
        {
            ChStatus[n] &= ConveyorChState.Up;
        }

        /// <summary>
        /// changeoverUp
        /// </summary>
        public static void chU(int n)
        {
            ChStatus[n] |= ConveyorChState.Up;
        }

        /// <summary>
        /// crossoverBackward
        /// </summary>
        public static void crB(int n)
        {
            CrStatus[n] = ConveyorCrState.Backward;
        }

        /// <summary>
        /// crossoverForward
        /// </summary>
        public static void crF(int n)
        {
            CrStatus[n] = ConveyorCrState.Forward;
        }

        /// <summary>
        /// corssoverStop
        /// </summary>
        public static void crS(int n)
        {
            CrStatus[n] = ConveyorCrState.Stop;
        }

        /// <summary>
        /// mainRollerAnticlockwise
        /// </summary>
        public static void mrA(int n)
        {
            mrState = ConveyorMRState.Anticlockwise;
        }

        /// <summary>
        /// mainRollerClockwise
        /// </summary>
        public static void mrC(int n)
        {
            mrState = ConveyorMRState.Clockwise;
        }

        /// <summary>
        /// mainRollerStop
        /// </summary>
        public static void mrS(int n)
        {
            mrState = ConveyorMRState.Stop;
        }

        public static void resetAll()
        {
            mrState = ConveyorMRState.Stop;
            for (int t = 0; t < ChNum; t++)
            {
                ChStatus[t] = ConveyorChState.Down;
            }
            for (int t = 0; t < CrNum; t++)
            {
                CrStatus[t] = ConveyorCrState.Stop;
            }
            for (int t = 0; t < StNum; t++)
            {
                StStatus[t] = ConveyorStState.Down;
            }
        }

        /// <summary>
        /// stopperChange
        /// </summary>
        public static void stC(int n)
        {
            StStatus[n] ^= ConveyorStState.Up;
        }

        /// <summary>
        /// stopperDown
        /// </summary>
        public static void stD(int n)
        {
            StStatus[n] = ConveyorStState.Down;
        }

        public static void stop()
        {
            refreshDataThread.Abort();
            for (int t = 0; t < BitNum; t++)
            {
                Input[t] = false;
                Output[t] = false;
            }
            receiveInput();
            sendOutput();
            foreach (AxDAQDI x in DI)
            {
                try
                {
                    x.CloseDevice();
                }
                catch { }
            }
            foreach (AxDAQDO x in DO)
            {
                try
                {
                    x.CloseDevice();
                }
                catch { }
            }
        }

        /// <summary>
        /// stopperUp
        /// </summary>
        public static void stU(int n)
        {
            StStatus[n] = ConveyorStState.Up;
        }

        static void receiveInput()
        {
            for (int t1 = 0; t1 < DI.Length; t1++)
            {
                for (short t2 = 0; t2 < 2; t2++)
                {
                    DI[t1].OpenDevice();
                    DI[t1].Port = t2;
                    short byteInput = DI[t1].ByteInput();
                    for (int t3 = 0; t3 < 8; t3++)
                    {
                        Input[t1 * 16 + t2 * 8 + t3] = byteInput % 2 == 1;
                        byteInput /= 2;
                    }
                    DI[t1].CloseDevice();
                }
            }
        }

        static void sendOutput()
        {
            for (int t1 = 0; t1 < DO.Length; t1++)
            {
                for (short t2 = 0; t2 < 2; t2++)
                {
                    DO[t1].OpenDevice();
                    DO[t1].Port = t2;
                    DO[t1].Mask = 0xFF;
                    short byteOutput = 0;
                    for (int t3 = 0; t3 < 8; t3++)
                    {
                        if (Output[t1 * 16 + t2 * 8 + t3])
                            byteOutput += (short)(1 << t3);
                    }
                    DO[t1].ByteOutput(byteOutput);
                    DO[t1].CloseDevice();
                }
            }
        }

        static void setOutput()
        {
            if (Output[(int) ConveyorOutputDevice.EmergencyStop])
            {
                if (Input[(int) ConveyorInputDevice.EmergencyStopReset])
                {
                    Output[(int) ConveyorOutputDevice.EmergencyStop] = false;
                    Console.WriteLine("{0} Emergency Reset: Button Reset was pressed", DateTime.Now);
                }
                return;
            }
            if (!(Input[(int) ConveyorInputDevice.EmergencyStop1] && Input[(int) ConveyorInputDevice.EmergencyStop2] && input[(int) ConveyorInputDevice.EmergencyStop3] && Input[(int) ConveyorInputDevice.EmergencyStop4]))
            {
                for (int t = 0; t < BitNum; t++)
                    Output[t] = false;
                mrState = ConveyorMRState.Stop;
                for (int t = 0; t < ChStatus.Length; t++)
                    ChStatus[t] = ConveyorChState.Down;
                for (int t = 0; t < CrStatus.Length; t++)
                    CrStatus[t] = ConveyorCrState.Stop;
                for (int t = 0; t < StStatus.Length; t++)
                    StStatus[t] = ConveyorStState.Down;
                Output[28] = true;
                Console.WriteLine("{0} Emergency Stop: Button ES{1} was pressed", DateTime.Now, !Input[(int) ConveyorInputDevice.EmergencyStop1] ? 1 : !Input[(int) ConveyorInputDevice.EmergencyStop2] ? 2 : !Input[(int) ConveyorInputDevice.EmergencyStop3] ? 3 : 4);
                return;
            }
            switch (mrState)
            {
                case ConveyorMRState.Stop:
                    Output[(int) ConveyorOutputDevice.MainRollerClockwise] = false;
                    Output[(int) ConveyorOutputDevice.MainRollerAnticlockwise] = false;
                    break;
                case ConveyorMRState.Clockwise:
                    Output[(int) ConveyorOutputDevice.MainRollerClockwise] = true;
                    Output[(int) ConveyorOutputDevice.MainRollerAnticlockwise] = false;
                    break;
                case ConveyorMRState.Anticlockwise:
                    Output[(int) ConveyorOutputDevice.MainRollerClockwise] = false;
                    Output[(int) ConveyorOutputDevice.MainRollerAnticlockwise] = true;
                    break;
            }
            for(int t = 0; t < ChNum; t++) {
                switch (ChStatus[t] & (ConveyorChState) 0x00000001)
                {
                    case ConveyorChState.Down:
                        Output[12 + t] = false;
                        break;
                    case ConveyorChState.Up:
                        Output[12 + t] = true;
                        break;
                }
                switch (ChStatus[t] & unchecked((ConveyorChState) 0xFFFFFFFE))
                {
                    case ConveyorChState.Down:
                        Output[4 + t] = false;
                        Output[8 + t] = false;
                        break;
                    case ConveyorChState.Forward:
                        Output[4 + t] = t >= 2;
                        Output[8 + t] = t <= 1;
                        break;
                    case ConveyorChState.Backward:
                        Output[4 + t] = t <= 1;
                        Output[8 + t] = t >= 2;
                        break;
                }
            }
            for (int t = 0; t < CrNum; t++)
            {
                switch (CrStatus[t])
                {
                    case ConveyorCrState.Stop:
                        Output[0 + t] = false;
                        Output[2 + t] = false;
                        break;
                    case ConveyorCrState.Forward:
                        Output[0 + t * 2 + t] = true;
                        Output[2 - t * 2 + t] = false;
                        break;
                    case ConveyorCrState.Backward:
                        Output[0 + t * 2 + t] = false;
                        Output[2 - t * 2 + t] = true;
                        break;
                }
            }
            for (int t = 0; t < StNum; t++)
            {
                switch (StStatus[t])
                {
                    case ConveyorStState.Down:
                        Output[16 + t] = false;
                        break;
                    case ConveyorStState.Up:
                        Output[16 + t] = true;
                        break;
                }
            }
        }

        static void refreshDataThreadMain()
        {
            while (true)
            {
                receiveInput();
                setOutput();
                sendOutput();
                Thread.Sleep(Config.workingUnit);
            }
        }

    }

}

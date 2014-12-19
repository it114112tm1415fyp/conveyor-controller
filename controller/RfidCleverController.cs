using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConveyorController
{

    abstract class RfidCleverController : RfidBasicController
    {

        public delegate void DetectDelegate(string rfid_tag);

        public static DetectDelegate onDetectRfid;

        public new static void init()
        {
            new Thread(callDelegateThreadMain).Start();
            onDetectRfid = NoAction._string;
        }

        public static void cleanDelegate()
        {
            onDetectRfid = NoAction._string;
        }

        static void callDelegateThreadMain()
        {
            while (true)
            {
                string tag = RfidBasicController.read();
                if (tag != null)
                    onDetectRfid(tag);
                Thread.Sleep(Config.workingUnit);
            }
        }

    }

}

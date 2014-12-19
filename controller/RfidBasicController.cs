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

        public static void init()
        {
            reader = new clsReader();
            reader.InitOnCom(2);
            if (reader.Connect() == "Connected")
                reader.AcquireMode = "Global Scroll";
        }

        public static string read()
        {
            string result = null;
            if (reader.IsConnected)
            {
                string tag = reader.TagList;
                tag = new Regex("(?<=Tag:)([\\dA-F]{4} ?){6}").Match(tag).ToString();
                if (tag != "")
                {
                    result = tag;
                    Console.WriteLine("RFID tag detected : {0}", result);
                }
            }
            return result;
        }

    }

}

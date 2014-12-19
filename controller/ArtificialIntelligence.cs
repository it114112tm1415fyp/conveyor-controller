using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConveyorController
{
    static class ArtificialIntelligence
    {

        public const int PrepareTime = 800;
        /// <summary>
        /// wating time between two actions 
        /// </summary>
        public const int TimeA = 120;
        /// <summary>
        /// time needs from the goods is scanned to it hit on stopper when it is
        /// transporting on main roller via the sensor 
        /// </summary>
        public const int TimeB = 800;
        /// <summary>
        /// time needs for goods to move to crossover roller
        /// </summary>
        public const int TimeC = 1400;
        public const int Time8 = 5000;
        public const int Time2 = 7600;
        public const int Time7 = 10200;
        public const int Time3 = 15300;
        public const int Time5 = 20700;
        public const int Time4 = 23400;
        public const int Time6 = 26000;
        public const int Time1 = 31550;

        public readonly static object[] Locker = new object[Enum.GetValues(typeof(ConveyorPart)).Length];
        public readonly static int[] ChQueue = { 3, 2, 0, 1 };
        public readonly static int[] ChTime = { 5000, 10200, 20700, 26000 };
        public readonly static int[] ChSenser = { 8, 7, 5, 6 };
        public readonly static int[] SeQueue = { 8, 2, 7, 3, 5, 4, 6, 1 };
        public readonly static List<GoodOnConveyor> Goods = new List<GoodOnConveyor>();
        public readonly static List<string>[] Down = { new List<string>(), new List<string>(), new List<string>(), new List<string>() };
        public readonly static List<string>[] Up = { new List<string>(), new List<string>(), new List<string>(), new List<string>() };

        readonly static int[] UploadCount = new int[4];

        public static void start()
        {
            Goods.Clear();
            for (int t = 0; t < ChQueue.Length; t++)
            {
                Up[t].Clear();
                Down[t].Clear();
                UploadCount[t] = 0;
            }
            for (int t = 0; t < Locker.Length; t++)
            {
                Locker[t] = new object();
            }
            Up[0].Add("AD83 1100 45CB 1D70 0E00 005E");
            Up[1].Add("AD83 1100 45CB 516F 0E00 0065");
            Up[2].Add("AD83 1100 45CC CD7E 1600 0096");
            Up[3].Add("AD83 1100 45CC E57C 1600 0099");
            ConveyorBasicController.mrC(0);
            ConveyorCleverController.OnSenserTriggerOn[0] = onSenser0TriggerOn;
            ConveyorCleverController.onEveryWorkingUnit = onEveryWorkingUnit;
            ConveyorCleverController.OnOutputOn[(int)ConveyorOutputDevice.MainRollerClockwise] = onMainRollerClockwise;
            RfidCleverController.onDetectRfid = onDetectRfid;
            //ConveyorCleverController.onSenserTriggerOn = onSenserTriggerOn;
        }

        public static void stop()
        {
            ConveyorBasicController.mrS(0);
            ConveyorCleverController.cleanDelegate();
            RfidCleverController.cleanDelegate();
        }

        /*static void onSenserTriggerOn(int senserId)
        {
            Console.WriteLine("{0} :--: {1}", senserId, Goods[0].position);
        }*/

        static void onSenser0TriggerOn(int senserId)
        {
            Goods.Add(new GoodOnConveyor());
        }

        static void onMainRollerClockwise(int bitId, bool on)
        {
            foreach (GoodOnConveyor x in Goods)
            {
                x.position += Config.workingUnit;
            }
            Goods.RemoveAll(goodPositionBiggerThanTime1);
        }

        static void onEveryWorkingUnit(int unitTime)
        {
            for (int t = 0; t < ChQueue.Length; t++)
            {
                goodPositionBetweenSpecificNumber__minLimit = ChTime[t] - PrepareTime;
                goodPositionBetweenSpecificNumber__maxLimit = goodPositionBetweenSpecificNumber__minLimit + unitTime;
                GoodOnConveyor good = Goods.Find(goodPositionBetweenSpecificNumber);
                if (good != null)
                {
                    stringIsSpecificString__specificString = good.rfid_tag;
                    if (Up[t].Exists(stringIsSpecificString))
                    {
                        Goods.Remove(good);
                        uploadGood(ChQueue[t]);
                    }
                }
            }
        }

        static void onDetectRfid(string tag)
        {
            goodRfidTagIsSpecificTag__specificTag = tag;
            if (!Goods.Exists(goodRfidTagIsSpecificTag))
            {
                GoodOnConveyor good = Goods.Find(goodRfidTagIsNull);
                if (good != null)
                {
                    good.rfid_tag = tag;
                }
            }
        }

        static void uploadGood(int chId)
        {
            if (UploadCount[chId] == 0 || UploadCount[(chId + 2) % 4] == 0)
                new Thread(uploadGoodThreadMain).Start(new object[] { chId });
        }

        static void uploadGoodThreadMain(object po)
        {
            chHoldNextGoodThreadMain(po);
            safeUploadGoodThreadMain(po);
            chResetThreadMain(po);
        }

        static void chHoldNextGood(int chId)
        {
            new Thread(chHoldNextGoodThreadMain).Start(new object[] { chId });
        }

        static void chHoldNextGoodThreadMain(object po)
        {
            object[] pa = (object[])po;
            int chId = (int)pa[0];
            int stId = (int)chId * 2 + (chId <= 1 ? 1 : 0);
            int inputBitIndex = (int)ConveyorInputDevice.Senser5 + chId;
            ConveyorCleverController.waitForInput(inputBitIndex, false, 1);
            ConveyorCleverController.waitForInput(inputBitIndex, true, 1);
            ConveyorBasicController.stU(stId);
            ConveyorCleverController.waitForMainRoller(ConveyorMRState.Clockwise, TimeB);
            ConveyorBasicController.mrS(chId);
            ConveyorBasicController.chU(chId);
            ConveyorCleverController.waitForChangeover(chId, ConveyorChState.Up, TimeA);
        }

        static void safeUploadGood(int chId)
        {
            new Thread(safeUploadGoodThreadMain).Start(new object[] { chId });
        }

        static void safeUploadGoodThreadMain(object po)
        {
            object[] pa = (object[])po;
            int chId = (int)pa[0];
            int crId = chId % 2;
            lock (Locker[(int)ConveyorPart.Crossover1 + crId])
            {
                Console.WriteLine(UploadCount[chId]);
                Console.WriteLine(UploadCount[(chId + 2) % 4]);
                if (UploadCount[(chId + 2) % 4] > 0)
                {
                    if (UploadCount[chId] == 0)
                    {
                        if (chId >= 2)
                        {
                            ConveyorBasicController.crB(crId);
                            ConveyorCleverController.waitForCrossover(crId, ConveyorCrState.Backward, TimeC);
                        }
                        else
                        {
                            ConveyorBasicController.crF(crId);
                            ConveyorCleverController.waitForCrossover(crId, ConveyorCrState.Forward, TimeC);
                        }
                    }
                    else
                        return;
                }
                ConveyorBasicController.crS(crId);
                ConveyorCleverController.waitForCrossover(crId, ConveyorCrState.Stop, TimeA);
                unsafeUploadGoodThreadMain(po);
            }
        }

        static void unsafeUploadGood(int chId)
        {
            new Thread(unsafeUploadGoodThreadMain).Start(new object[] { chId });
        }

        static void unsafeUploadGoodThreadMain(object po)
        {
            object[] pa = (object[])po;
            int chId = (int)pa[0];
            int crId = chId % 2;
            UploadCount[chId]++;
            if (chId >= 2)
            {
                ConveyorBasicController.chF(chId);
                ConveyorBasicController.crF(crId);
                ConveyorCleverController.waitForCrossover(crId, ConveyorCrState.Forward, TimeC);
            }
            else
            {
                ConveyorBasicController.chB(chId);
                ConveyorBasicController.crB(crId);
                ConveyorCleverController.waitForCrossover(crId, ConveyorCrState.Backward, TimeC);
            }
            ConveyorBasicController.chS(chId);
            ConveyorBasicController.crS(crId);
        }

        static void throwGood(int chId)
        {
            new Thread(throwGoodThreadMain).Start(new object[] { chId });
        }

        static void throwGoodThreadMain(object po)
        {
            object[] pa = (object[])po;
            int chId = (int)pa[0];
            int crId = chId % 2;
            if (chId >= 2)
            {
                ConveyorBasicController.chB(chId);
                ConveyorCleverController.waitForChangeover(chId, ConveyorChState.Up | ConveyorChState.Backward, TimeC);
            }
            else
            {
                ConveyorBasicController.chF(chId);
                ConveyorCleverController.waitForChangeover(chId, ConveyorChState.Up | ConveyorChState.Forward, TimeC);
            }

            ConveyorBasicController.chS(chId);
            ConveyorBasicController.stD(chId * 2 + (chId <= 1 ? 1 : 0));
            ConveyorBasicController.chD(chId);
            ConveyorBasicController.mrC(0);
        }

        static void chReset(int chId)
        {
            new Thread(chResetThreadMain).Start(new object[] { chId });
        }

        static void chResetThreadMain(object po)
        {
            object[] pa = (object[])po;
            int chId = (int)pa[0];
            ConveyorBasicController.stD(chId * 2 + (chId <= 1 ? 1 : 0));
            ConveyorBasicController.chD(chId);
            ConveyorBasicController.mrC(0);
        }

        static string stringIsSpecificString__specificString;

        static bool stringIsSpecificString(string s)
        {
            return s == stringIsSpecificString__specificString;
        }

        static int goodPositionBetweenSpecificNumber__minLimit;
        static int goodPositionBetweenSpecificNumber__maxLimit;

        static bool goodPositionBetweenSpecificNumber(GoodOnConveyor good)
        {
            return good.position >= goodPositionBetweenSpecificNumber__minLimit && good.position < goodPositionBetweenSpecificNumber__maxLimit;
        }

        static bool goodPositionBiggerThanTime1(GoodOnConveyor good)
        {
            return good.position > Time1;
        }

        static bool goodRfidTagIsNull(GoodOnConveyor good)
        {
            return good.rfid_tag == null;
        }

        static string goodRfidTagIsSpecificTag__specificTag;

        static bool goodRfidTagIsSpecificTag(GoodOnConveyor good)
        {
            return good.rfid_tag == goodRfidTagIsSpecificTag__specificTag;
        }

    }
}

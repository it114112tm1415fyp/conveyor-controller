using LitJson;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ConveyorController
{
    class Allocation : ArtificialIntelligenceInterface
    {

        public delegate void OnRemoveOldGood(GoodOnConveyor good);
        public delegate void OnDetectNewGood(GoodOnConveyor good);
        public delegate void OnDetectRfid(GoodOnConveyor good);
        public delegate void OnReceiveGoodDetails(Good good, HandleMethod handleMethod);
        public delegate void OnReceiveErrorMessage(string reason);

        // sangleton instance
        public readonly static Allocation instance = new Allocation();

        public readonly static Dictionary<string, Good> GoodDetails = new Dictionary<string, Good>();

        const string urlGetGoodDetails = "http://it114112tm1415fyp1.redirectme.net:6083/allocation/get_goods_details";

        public static OnDetectNewGood onDetectNewGood;
        public static OnDetectRfid onDetectRfid;
        public static OnReceiveGoodDetails onReceiveGoodDetails;
        public static OnReceiveErrorMessage onReceiveErrorMessage;
        public static OnRemoveOldGood onRemoveOldGood;

        public void onGoodDetected(GoodOnConveyor good)
        {
            if (onDetectNewGood != null)
                onDetectNewGood(good);
        }

        public void onRfidScanned(GoodOnConveyor good)
        {
            new Thread(onRfidScannedThreadMain).Start(new object[] { good });
            if (onDetectRfid != null)
                onDetectRfid(good);
        }

        public void onRfidScannedThreadMain(object po)
        {
            object[] pa = (object[])po;
            GoodOnConveyor goodOnConveyor = (GoodOnConveyor)pa[0];
            // parameters deserialization finished
            string rfidTag = goodOnConveyor.rfidTag;
            Good good;
            if (GoodDetails.ContainsKey(rfidTag))
            {
                good = GoodDetails[rfidTag];
            }
            else
            {
                Console.WriteLine("Post get goods details : {0}", rfidTag);
                NameValueCollection parameters = new NameValueCollection();
                parameters["rfid"] = goodOnConveyor.rfidTag;
                string result = Encoding.Default.GetString(new WebClient().UploadValues(urlGetGoodDetails, parameters));
                Console.WriteLine("Receive goods details of {0} : {1}", rfidTag, result);
                if ((bool)JsonMapper.ToObject(result)["success"])
                {
                    good = JsonMapper.ToObject<Good>(result);
                    good.rfid_tag = rfidTag;
                    GoodDetails.Add(rfidTag, good);
                }
                else
                {
                    Console.Beep();
                    //ArtificialIntelligence.stop();
                    return;
                }
            }
            if (!ArtificialIntelligence.GoodsHandleMethod.ContainsKey(rfidTag))
            {
                HandleMethod handleMethod = new HandleMethod(exitPoint(good), false);
                ArtificialIntelligence.GoodsHandleMethod.Add(rfidTag, handleMethod);
                if (onReceiveGoodDetails != null)
                    onReceiveGoodDetails(good, handleMethod);
            }
        }

        public int exitPoint(Good good)
        {
            if (good.next_stop.type == "Store")
            {
                if (good.next_stop.id > 3)
                    return 3;
                return good.next_stop.id;
            }
            else
                return 0;
        }

        public void onGoodLifeCycleFinished(GoodOnConveyor good)
        {
            if (onRemoveOldGood != null)
                onRemoveOldGood(good);
        }

        public void onStartFailed(string reason)
        {
            if (onReceiveErrorMessage != null)
                onReceiveErrorMessage(reason);
        }

    }
}

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
        public delegate void OnReceiveGoodDetails(Good good);
        public delegate void OnReceiveErrorMessage(string reason);

        // sangleton instance
        public readonly static Allocation instance = new Allocation();

        public readonly static Dictionary<string, Good> GoodDetails = new Dictionary<string, Good>();

        const string urlGetGoodDetails = "http://it114112tm1415fyp1.redirectme.net:6083/allocation/get_good_details";

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
            if (!GoodDetails.ContainsKey(rfidTag))
            {
                Console.WriteLine("Post get goods details : {0}", rfidTag);
                NameValueCollection parameters = new NameValueCollection();
                parameters["rfid"] = goodOnConveyor.rfidTag;
                string result = Encoding.Default.GetString(new WebClient().UploadValues(urlGetGoodDetails, parameters));
                Console.WriteLine("Receive goods details of {0} : {1}", rfidTag, result);
                if ((bool)JsonMapper.ToObject(result)["success"])
                {
                    Good good = JsonMapper.ToObject<Good>(result);
                    good.rfidTag = rfidTag;
                    GoodDetails.Add(rfidTag, good);
                    HandleMethod handleMethod = new HandleMethod(good.store, false);
                    ArtificialIntelligence.GoodsHandleMethod.Add(rfidTag, handleMethod);
                    if (onReceiveGoodDetails != null)
                        onReceiveGoodDetails(good);
                }
                else
                    ArtificialIntelligence.stop();
            }
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

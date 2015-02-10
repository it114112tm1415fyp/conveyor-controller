using LitJson;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading;

namespace ConveyorController
{
    class Allocation : ArtificialIntelligenceInterface
    {

        const string urlGetGoodDetails = "http://it114112tm1415fyp1.redirectme.net:6083/allocation/get_good_details";

        // sangleton instance
        public readonly static Allocation instance = new Allocation();

        public readonly static Dictionary<string, Good> GoodDetails = new Dictionary<string, Good>();

        public void onGoodDetected(GoodOnConveyor good)
        {
            new Thread(onGoodDetectedThreadMain).Start(new object[] { good });
        }

        public void onGoodDetectedThreadMain(object po)
        {
            object[] pa = (object[])po;
            GoodOnConveyor goodOnConveyor = (GoodOnConveyor)pa[0];
            // parameters deserialization finished
            string rfidTag = goodOnConveyor.rfidTag;
            Good good;
            if (GoodDetails.ContainsKey(rfidTag))
            {
                good = GoodDetails[goodOnConveyor.rfidTag];
            }
            else
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters["rfid"] = goodOnConveyor.rfidTag;
                string result = Encoding.Default.GetString(new WebClient().UploadValues(urlGetGoodDetails, parameters));
                if ((bool)JsonMapper.ToObject(result)["success"])
                {
                    good = JsonMapper.ToObject<Good>(result);
                    good.rfidTag = rfidTag;
                    GoodDetails.Add(rfidTag, good);
                }
                else
                {
                    ArtificialIntelligence.stop();
                    return;
                }
            }
            if (!ArtificialIntelligence.GoodsHandleMethod.ContainsKey(rfidTag))
                ArtificialIntelligence.GoodsHandleMethod.Add(rfidTag, new HandleMethod(good.store, false));
        }

    }
}

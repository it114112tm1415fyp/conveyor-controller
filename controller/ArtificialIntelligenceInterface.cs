using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorController
{
    interface ArtificialIntelligenceInterface
    {

        void onGoodDetected(GoodOnConveyor good);
        void onRfidScanned(GoodOnConveyor good);
        void onGoodLifeCycleFinished(GoodOnConveyor good);
        void onStartFailed(string reason);

    }
}

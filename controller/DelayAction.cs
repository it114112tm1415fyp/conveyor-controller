using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConveyorController
{

    sealed class DelayAction
    {

        public readonly DelayActionWaitingDevice WaitingDevice;
        public readonly object WaitingValue;
        public readonly int DeviceIndex;
        public readonly Thread Thread;

        public int waitingTime;

        public DelayAction(DelayActionWaitingDevice waitingDevice, int deviceIndex, object waitingValue, int waitingTime, Thread thread)
        {
            DeviceIndex = deviceIndex;
            WaitingDevice = waitingDevice;
            WaitingValue = waitingValue;
            Thread = thread;
            this.waitingTime = waitingTime;
        }

    }

}

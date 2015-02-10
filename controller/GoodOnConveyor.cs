using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorController
{
    class GoodOnConveyor
    {
        public string rfidTag;
        public int position;

        public GoodOnConveyor()
        {
        }

        public GoodOnConveyor(string rfidTag, int position)
        {
            this.rfidTag = rfidTag;
            this.position = position;
        }

        public override string ToString()
        {
            return string.Format("tag:{0}, position:{1}", rfidTag, position);
        }
        
    }
}

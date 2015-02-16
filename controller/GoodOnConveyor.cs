using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorController
{
    public class GoodOnConveyor
    {
        public bool left;
        public int position;
        public string rfidTag;

        public GoodOnConveyor() { }

        public GoodOnConveyor(string rfidTag, int position)
        {
            this.left = false;
            this.rfidTag = rfidTag;
            this.position = position;
        }

        public override string ToString()
        {
            return string.Format("tag:{0}, position:{1}", rfidTag, position);
        }
        
    }
}

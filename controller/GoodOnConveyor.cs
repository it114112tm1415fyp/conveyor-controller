using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorController
{
    class GoodOnConveyor
    {
        public string rfid_tag;
        public int position;

        public GoodOnConveyor()
        {
        }

        public GoodOnConveyor(string rfid_tag, int position)
        {
            this.rfid_tag = rfid_tag;
            this.position = position;
        }

        public override string ToString()
        {
            return string.Format("tag:{0}, position:{1}", rfid_tag, position);
        }
        
    }
}

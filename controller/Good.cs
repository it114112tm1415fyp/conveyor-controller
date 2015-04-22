using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorController
{
    public struct Good
    {
        public bool flammable;
        public bool fragile;
        public DateTime created_at;
        public double weight;
        public string id;
        public int order_id;
        public int store;
        public NextStop next_stop;
        public string departure;
        public string destination;
        public string rfid_tag;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConveyorController
{
    public struct Good
    {
        public bool flammable;
        public bool fragile;
        public DateTime order_time;
        public double weight;
        public int id;
        public int order;
        public int store;
        public string departure;
        public string destination;
        public string rfidTag;
    }
}

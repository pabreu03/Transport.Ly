using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Ly.Classes
{
    class Order
    {
        public Order() { }

        public Order(string orderNumber)
        {
            OrderNumber = orderNumber;
        }

        public string OrderNumber;
        public string OrderNumber_ { get; set; }
    }
}

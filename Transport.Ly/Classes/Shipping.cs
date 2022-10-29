using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Ly.Classes
{
    class Shipping
    {
        public Shipping() { }

        public Shipping(Order shippingOrder, Flight shippingFlight)
        {
            ShippingOrder = shippingOrder;
            ShippingFlight = shippingFlight;
        }

        public Order ShippingOrder = new Order();
        public Flight ShippingFlight = new Flight();

        public Order ShippingOrder_ { get; set; }
        public Flight ShippingFlight_ { get; set; }
    }
}

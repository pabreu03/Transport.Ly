using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Transport.Ly.Classes
{
    class OrderSchedule
    {
        public void OrderItinerary(List<Shipping> shippings)
        {
            ShippingProcess process = new ShippingProcess();
            var orderedShippings = shippings.OrderBy(x => x.ShippingOrder.OrderNumber).ToList();

            foreach(var s in orderedShippings)
            {
                if (s.ShippingFlight.FlightNumber != 0)
                {
                    Console.WriteLine("order: " + s.ShippingOrder.OrderNumber +
                                    ", flightNumber: " + s.ShippingFlight.FlightNumber +
                                    ", departure: " + s.ShippingFlight.DepartureAirport.AirportAcronym +
                                    ", arrival: " + s.ShippingFlight.ArrivalAirport.AirportAcronym +
                                    ", day: " + s.ShippingFlight.Day);
                }
                else
                {
                    Console.WriteLine("order: " + s.ShippingOrder.OrderNumber +
                                    ", flightNumber: not scheduled");
                }
            }
        }
    }
}

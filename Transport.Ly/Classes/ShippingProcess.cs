using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Transport.Ly.Classes
{
    class ShippingProcess
    {
        public List<Shipping> ShippingItinerary (List<jsonOrder> jsonOrder, List<Flight> flights, int MaxBoxes)
        {
            SupportingMethods supporting = new SupportingMethods();
            List<Shipping> shippings = new List<Shipping>();

            var airports = supporting.GetDistinctAirports(jsonOrder);
            var days = supporting.GetListDays(flights);
            int cont = 0, d = 0;

            for (int i = 0; i < airports.Count; i++)
            {   
                //Searching if the flight has been programed
                var match = flights.FirstOrDefault(x => x.ArrivalAirport.AirportAcronym.Contains(airports[i]));
                cont = 0; d = 0;

                if (match != null)
                {
                    var selectedAiports = jsonOrder.Where(x => x.OrderDestination.Destination == airports[i]).ToList();
                    
                    for(int j = 0; j < selectedAiports.Count; j++)
                    {
                        if(cont < MaxBoxes && d < days.Count)
                        {
                            Shipping orderShipping = new Shipping();
                            orderShipping.ShippingOrder.OrderNumber = selectedAiports[j].ID;
                            orderShipping.ShippingFlight.ArrivalAirport.AirportAcronym = selectedAiports[j].OrderDestination.Destination;
                            orderShipping.ShippingFlight.Day = days[d];
                            orderShipping.ShippingFlight.FlightNumber = flights.FirstOrDefault(x => x.Day == days[d] && x.ArrivalAirport.AirportAcronym == selectedAiports[j].OrderDestination.Destination).FlightNumber;
                            orderShipping.ShippingFlight.DepartureAirport.AirportAcronym = flights.FirstOrDefault(x => x.Day == days[d] && x.ArrivalAirport.AirportAcronym == selectedAiports[j].OrderDestination.Destination).DepartureAirport.AirportAcronym;

                            shippings.Add(orderShipping);
                            cont++;
                        }
                        else
                        {
                            cont = 0;
                            d++;
                        }
                    }

                    d = 0;
                }
                else
                {
                    var notScheduled = jsonOrder.Where(x => x.OrderDestination.Destination.Contains(airports[i])).ToList();

                    for (int z = 0; z < notScheduled.Count; z++)
                    {
                        if (notScheduled != null)
                        {
                            Shipping orderNotSchedule = new Shipping();
                            orderNotSchedule.ShippingOrder.OrderNumber = notScheduled[z].ID;
                            orderNotSchedule.ShippingFlight.ArrivalAirport.AirportAcronym = notScheduled[z].OrderDestination.Destination;
                            orderNotSchedule.ShippingFlight.FlightNumber = 0;

                            shippings.Add(orderNotSchedule);
                        }
                    }
                }
                
            }

            return shippings;
        }
    }

    class SupportingMethods
    {
        public List<string> GetDistinctAirports(List<Flight> flights)
        {
            return flights.Select(x => x.ArrivalAirport.AirportAcronym).Distinct().ToList();
        }
        public List<string> GetDistinctAirports(List<jsonOrder> orders)
        {
            return orders.Select(x => x.OrderDestination.Destination).Distinct().ToList();
        }
        public List<int> GetListDays(List<Flight> flights)
        {
            return flights.Select(x => x.Day).Distinct().ToList();
        }
        
    }
}

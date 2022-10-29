using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transport.Ly.Classes
{
    class FlightSchedule
    {
        public void LoadFlightSchedule(List<Flight> flights)
        {
            foreach(var flight in flights)
            {
                Console.WriteLine("Flight: " + flight.FlightNumber + 
                                  ", departure: " + flight.DepartureAirport.AirportAcronym + 
                                  ", arrival: " + flight.ArrivalAirport.AirportAcronym + 
                                  ", day: " + flight.Day);
            }
        }

        public void LoadFlightScheduleScenario(List<Flight> flights)
        {
            SupportingMethods supporting = new SupportingMethods();
            var days = supporting.GetListDays(flights);

            for (int i = 0; i < days.Count; i++)
            {
                Console.WriteLine("Day " + days[i].ToString() + ": ");

                for(int j = 0; j < flights.Count; j++)
                {
                    if (flights[j].Day == days[i])
                    {
                        Console.WriteLine("Flight " + flights[j].FlightNumber +
                                        ": " + flights[j].DepartureAirport.AirportName +
                                        " (" + flights[j].DepartureAirport.AirportAcronym +
                                        ") to " + flights[j].ArrivalAirport.AirportName +
                                        " (" + flights[j].ArrivalAirport.AirportAcronym + ") ");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Ly.Classes
{
    class Flight
    {
        public Flight() { }

        public Flight(int flightNumber, Airport departureAirport, Airport arrivalAirport, int day)
        {
            FlightNumber = flightNumber;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            Day = day;
        }

        public int FlightNumber;
        public Airport DepartureAirport = new Airport();
        public Airport ArrivalAirport = new Airport();
        public int Day;

        public int FlightNumber_ { get { return FlightNumber; } set { FlightNumber = value; } }
        public Airport DepartureAirport_ { get; set; }
        public Airport ArrivalAirport_ { get; set; }
        public int Day_ { get { return Day; } set { Day = value; } }
    }
}

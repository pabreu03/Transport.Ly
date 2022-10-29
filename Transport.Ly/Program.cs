using System;
using System.Collections.Generic;
using Transport.Ly.Classes;

namespace Transport.Ly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------WELCOME TO TRANSPORT.LY-------------------");
            Console.WriteLine("------------------Created by Patricia Abreu-------------------");
            Console.WriteLine("");

            Airport yul = new Airport("YUL", "Montreal");
            Airport yyz = new Airport("YYZ", "Toronto");
            Airport yyc = new Airport("YYC", "Calgary");
            Airport yvr = new Airport("YVR", "Vancouver");

            Flight flight1 = new Flight(1, yul, yyz, 1);
            Flight flight2 = new Flight(2, yul, yyc, 1);
            Flight flight3 = new Flight(3, yul, yvr, 1);

            Flight flight4 = new Flight(4, yul, yyz, 2);
            Flight flight5 = new Flight(5, yul, yyc, 2);
            Flight flight6 = new Flight(6, yul, yvr, 2);

            List<Flight> flights = new List<Flight>() { flight1, flight2, flight3, flight4, flight5, flight6 };

            FlightSchedule schedule = new FlightSchedule();
            schedule.LoadFlightScheduleScenario(flights);

            Console.WriteLine("");
            Console.WriteLine("USER STORY #1");
            schedule.LoadFlightSchedule(flights);

            ProcessJson processJson = new ProcessJson();
            var json = processJson.ReadJson(@"C:\Users\Miguel\source\repos\Transport.Ly\Transport.Ly\json\coding-assigment-orders.json");
            var jsonOrders = processJson.ConvertJsonToObject(json);

            ShippingProcess shippingProcess = new ShippingProcess();
            var itinerary = shippingProcess.ShippingItinerary(jsonOrders, flights, 20);
            OrderSchedule orderSchedule = new OrderSchedule();

            Console.WriteLine("");
            Console.WriteLine("USER STORY #2");
            orderSchedule.OrderItinerary(itinerary);
        }
    }
}

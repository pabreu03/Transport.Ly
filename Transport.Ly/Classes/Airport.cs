using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Ly.Classes
{
    class Airport
    {
        public Airport() { }

        public Airport(string aiportAcronym, string airportName)
        {
            AirportAcronym = aiportAcronym;
            AirportName = airportName;
        }

        public string AirportAcronym;
        public string AirportName;

        public string AirportAcronym_
        {
            get { return string.IsNullOrEmpty(AirportAcronym) ? "YUL" : AirportAcronym; }
            set { AirportAcronym = value; } 
        }
        public string AirportName_
        {
            get { return string.IsNullOrEmpty(AirportName) ? "Montreal" : AirportName; }
            set { AirportName = value; }
        }

    }
}

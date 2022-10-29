using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Ly.Classes
{
    class jsonOrder
    {
        public jsonOrder() { }
        public string ID;
        public jsonDestination OrderDestination = new jsonDestination();

        public string ID_ { get { return ID; } set { ID = value; } }
        public jsonDestination OrderDestination_ { get; set; }
    }
}

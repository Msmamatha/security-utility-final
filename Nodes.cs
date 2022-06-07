using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WirelessNodeSimulation
{
    
        public class Nodes1
        {

            public int nodeIdField;

            public int nodeXField;

            public int nodeYField;
            public Nodes1(int X, int Y, int ID)
            {
                nodeIdField = ID;
                nodeXField = X;
                nodeYField = Y;
            }
        }
    
}

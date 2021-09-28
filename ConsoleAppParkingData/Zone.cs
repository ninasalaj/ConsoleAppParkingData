using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppParkingData
{
    public class Zone
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; } 
        public bool VariablePrice { get; set; }
        public string Color { get; set; }
        public string UnselectedColor { get; set; }
        public string TextColor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppParkingData
{
    public class Zone
    {
        public string name { get; set; }
        public List<Value> Values { get; set; } 
        public bool variablePrice { get; set; }
        public string color { get; set; }
        public string unselectedColor { get; set; }
        public string textColor { get; set; }
    }
}

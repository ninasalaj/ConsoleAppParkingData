using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppParkingData
{
    public class ParkingCity
    {
        public string name { get; set; }
        public string companyId { get; set; }
        public List<Zone> Zones { get; set; }
    }
}

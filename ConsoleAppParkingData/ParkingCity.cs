using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppParkingData
{
    public class ParkingCity
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public List<Zone> Zones { get; set; }
    }
}

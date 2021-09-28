using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppParkingData
{
    public class Ticket
    {
        public int Quantity { get; set; }
        public string Id { get; set; }
        public decimal Value { get; set; }
        public decimal Price { get; set; }
        public char Unit { get; set; }
    }
}

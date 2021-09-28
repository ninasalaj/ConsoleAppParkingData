using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace ConsoleAppParkingData
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"parkingData.json");
            var parkingCity = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingCity>>(json);
            foreach (var i in parkingCity)
            {
                Console.WriteLine(i.Name);
            }
        }
    }
}

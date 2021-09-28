using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppParkingData
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"parkingData.json");
            var parkingCities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingCity>>(json);

            Console.WriteLine("Odaberite opciju");
            Console.WriteLine("1 - pretraga");
            var option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Console.WriteLine("Unesite naziv grada");
                    var searchString = Console.ReadLine();

                    var city = parkingCities.Where(x => x.Name == searchString).FirstOrDefault();
                    if(city == null)
                        Console.WriteLine("Grad nije pronađen");
                    else Console.WriteLine(city.Name);
                break;
            }

            /*
            foreach (var parkingCity in parkingCities)
            {
                Console.WriteLine(parkingCity.Name);
            }*/
        }
    }
}

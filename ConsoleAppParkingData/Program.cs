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
            Console.WriteLine("2 - ispis gradova");
            Console.WriteLine("3 - ispis gradova abecedno uzlazno");
            Console.WriteLine("4 - ispis gradova abecedno silazno");
            var option = Convert.ToInt32(Console.ReadLine());

            var cities = new List<ParkingCity>();
            switch(option)
            {
                case 1:
                    Console.WriteLine("Unesite naziv grada");
                    var searchString = Console.ReadLine();

                    var city = parkingCities.Where(x => x.Name.Contains(searchString)).ToList();
                    //if(city == null)
                    //    Console.WriteLine("Grad nije pronađen");
                    //else Console.WriteLine(city.Name);
                break;
                case 2:
                    foreach (var parkingCity in parkingCities) 
                    {
                        Console.WriteLine("{0}, companyId: {1}, broj zona: {2} ", parkingCity.Name, parkingCity.CompanyId, parkingCity.Zones.Count);
                    }

                    break;
                case 3:
                    cities = GetSorteredCities(parkingCities);

                    break;
                case 4:
                    cities = parkingCities.OrderByDescending(x => x.Name).ToList();
                    foreach (var parkingCity in cities)
                    {
                        Console.WriteLine(parkingCity.Name);
                    }
                    break;
            }
            Console.WriteLine();
            var maxZonesCity = parkingCities.OrderByDescending(x => x.Zones.Count).First();
            Console.WriteLine($"Grad s najvise zona je {maxZonesCity.Name}");
            Console.WriteLine();
            Console.WriteLine("Ispis gradova po broju zona uzlazno: ");
            cities = parkingCities.OrderBy(x => x.Zones.Count).ToList();
            foreach(var parkingCity in cities)
            {
                Console.WriteLine(parkingCity.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Unesite naziv zone");
            var searchZone = Console.ReadLine();
            cities = parkingCities.Where(s => s.Zones.Any(x =>x.Name==searchZone)).ToList();
            if (cities.Count == 0)
                Console.WriteLine("Gradovi s tom zonom ne postoje.");
            else
            {
                foreach (var city in cities)
                {
                    Console.WriteLine(city.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Gradovi koji počinju sa slovom V i imaju više od 2 zone:");
            cities = parkingCities.Where(x => x.Name[0] == 'V' && x.Zones.Count > 2).ToList();
            foreach (var city in cities)
            {
                Console.WriteLine(city.Name);
            }

         
            /*
            foreach (var parkingCity in parkingCities)
            {
                Console.WriteLine(parkingCity.Name);
            }*/


        }

        public static List<ParkingCity> GetSorteredCities(List<ParkingCity> parkingCities)
        {
            var cities = parkingCities.OrderBy(x => x.Name).ToList();
            //foreach (var parkingCity in cities)
            //{
            //    Console.WriteLine(parkingCity.Name);
            //}

            return cities;
        }

    }
}

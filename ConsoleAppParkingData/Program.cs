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
            Console.WriteLine("1 - pretraga grada");
            Console.WriteLine("2 - ispis svih gradova");
            Console.WriteLine("3 - ispis gradova abecedno uzlazno");
            Console.WriteLine("4 - ispis gradova abecedno silazno");
            Console.WriteLine("5 - ispis gradova po broju zona uzlazno");
            Console.WriteLine("6 - pretraga zone");
            Console.WriteLine("7 - ispis gradova koji pocinju sa \"V\" i imaju vise od dvije zone");
            var option = Convert.ToInt32(Console.ReadLine());

            var cities = new List<ParkingCity>();
            switch(option)
            {
                case 1:
                    Console.WriteLine("Unesite naziv grada");
                    var searchString = Console.ReadLine();
                    cities = GetSearchedCities(parkingCities, searchString);
                    CitiesOutput(cities);
                break;
                case 2:
                    foreach (var parkingCity in parkingCities) 
                    {
                        Console.WriteLine($"{parkingCity.Name}, companyId: {parkingCity.CompanyId}, broj zona: {parkingCity.Zones.Count} ");
                    }

                    break;
                case 3:
                    cities = GetSorteredCities(parkingCities);
                    CitiesOutput(cities);
                    break;
                case 4:
                    cities = GetDescendinglySorteredCities(parkingCities);
                    CitiesOutput(cities);
                    break;
                case 5:
                    cities = GetSorteredCitiesByNumberOfZones(parkingCities);
                    CitiesOutput(cities);
                    break;
                case 6:
                    Console.WriteLine("Unesite naziv zone");
                    var searchZone = Console.ReadLine();
                    cities = GetCitiesSearchedByZone(parkingCities, searchZone);
                    CitiesOutput(cities);
                    break;
                case 7:
                    cities = GetFilteredCities(parkingCities);
                    CitiesOutput(cities);
                    break;
                default:
                    Console.WriteLine("Opcija ne postoji");
                    break;
            }
            
            
        }
        public static List<ParkingCity> GetSearchedCities(List<ParkingCity> parkingCities,string searchString)
        {
            var cities = parkingCities.Where(x => x.Name.Contains(searchString)).ToList();
            return cities;
        }

        public static List<ParkingCity> GetSorteredCities(List<ParkingCity> parkingCities)
        {
            var cities = parkingCities.OrderBy(x => x.Name).ToList();
            return cities;
        }

        public static List<ParkingCity> GetDescendinglySorteredCities(List<ParkingCity> parkingCities)
        {
            var cities = parkingCities.OrderByDescending(x => x.Name).ToList();
            return cities;
        }

        public static List<ParkingCity> GetSorteredCitiesByNumberOfZones(List<ParkingCity> parkingCities)
        {
            var cities = parkingCities.OrderBy(x => x.Zones.Count).ToList();
            return cities;
        }

        public static List<ParkingCity> GetCitiesSearchedByZone(List<ParkingCity> parkingCities, string searchZone)
        {
            var cities = parkingCities.Where(s => s.Zones.Any(x => x.Name == searchZone)).ToList();
            return cities;
        }
        public static List<ParkingCity> GetFilteredCities(List<ParkingCity> parkingCities)
        {
            var cities = parkingCities.Where(x => x.Name[0] == 'V' && x.Zones.Count > 2).ToList();
            return cities;
        }
        public static void CitiesOutput(List<ParkingCity> cities)
        {
            if (cities.Count == 0)
                Console.WriteLine("Ne postoji.");
            else
            {
                foreach (var city in cities)
                {
                    Console.WriteLine(city.Name);
                }
                Console.WriteLine();
            }

        }
    }
}

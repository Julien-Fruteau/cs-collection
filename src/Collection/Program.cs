using System;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            string projectPath = @"C:\Users\20012454\myRepo\cs\collection";
            string filePath = projectPath + @"\test\Collection.Test\var\cities.csv";
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            //When
            cityManager.GetNFirstLocation(10);

            foreach (var city in cityManager.Location)
            {
                Console.WriteLine($"Population of {city.Name.PadRight(10)} : {city.Population.ToString("N").PadLeft(15)}");
            }
        }
    }
}

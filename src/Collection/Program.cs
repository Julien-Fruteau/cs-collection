using System;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));

            cityManager.GetNFirstLocation(10);

            foreach (var city in cityManager.Location)
            {
                Console.WriteLine($"Population of {city.Name.PadRight(10)} : {city.Population.ToString("N").PadLeft(15)}");
            }
        }
    }
}

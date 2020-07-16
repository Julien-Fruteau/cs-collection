using System;
using System.Collections.Generic;
using Xunit;

namespace Collection.Test
{
    public class TestCollection
    {
        [Fact]
        public void InstantiateArrayv1()
        {
            string[] weekDays = new string[] { "Monday", "Tuesday" };

            Assert.Equal("Monday", weekDays[0]);
            Assert.Equal("Tuesday", weekDays[1]);
        }

        [Fact]
        public void InstantiateArrayv2()
        {
            string[] weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            Assert.Equal("Monday", weekDays[0]);
            Assert.Equal("Friday", weekDays[4]);
        }

        public string GetRootPath()
        {
            if (OperatingSystem.isMacOS())
            {
                return @"/Users/julien/MEGA/Documents/Dev/cs/cs-collection";
            }
            else {
                return @"C:\Users\20012454\myRepo\cs\collection";
            }
        }

        [Fact]
        public void TestCsvReaderReadNFirstLines()
        {
            string filePath = GetRootPath() + @"/test/Collection.Test/var/population.csv";
            IFileReader fileReader = new CsvReader(filePath, true, ',');
            City[] countries = new City[10];
            //When
            // IEnumerable<string> fileLines = fileReader.ReadNFirstLines(10);
            foreach (var item in fileReader.ReadNFirstLines(10))
            {
                Console.WriteLine($"{item} deleted");
                
            }
        }

        [Fact]
        public void TestCityManager()
        {
            //Given
            string filePath = GetRootPath() + @"/test/Collection.Test/var/population.csv";
            CityManager CityManager = new CityManager(new CsvReader(filePath, true, ','));

            //When
            CityManager.GetNFirstLocation(10);
            //Then
            Assert.Equal("lille", CityManager.Location[0].Name);
            Assert.Equal(42, CityManager.Location[3].Code);
        }

        [Fact]
        public void ReadFile()
        {
            //Given
            string filePath = GetRootPath() + @"/test/Collection.Test/var/population.csv";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            //When
            //Then
            Assert.NotNull(lines);
            Assert.False(lines.Length == 0);
        }

        [Fact]
        public void CompareStringLenght()
        {
            //Given
            string a = "this is a string";
            string b = "this is a longer string";
            //When
            int resA = a.Length.CompareTo(b.Length);
            int resB = b.Length.CompareTo(a.Length);
            //Then
            Assert.Equal(-1, resA);
            Assert.Equal(1, resB);
        }
    }
}

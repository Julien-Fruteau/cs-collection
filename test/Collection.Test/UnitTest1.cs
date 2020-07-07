using System;
using System.Collections.Generic;
using Xunit;

namespace Collection.Test
{
    public class UnitTest1
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

        [Fact]
        public void TestCsvReaderReadNFirstLines()
        {
            //Given
            string projectPath = @"C:\Users\20012454\myRepo\cs\collection";
            string filePath = projectPath + @"\test\Collection.Test\var\cities.csv";
            IFileReader fileReader = new CsvReader(filePath, true, ',');
            List<string> line = new List<string>();
            int totLines = 10;
            //When
            foreach (string curLine in fileReader.ReadNFirstLines(totLines))
            {
                line.Add(curLine);
            }
            //Then
            Assert.Equal(10, line.Count);
            Assert.NotEqual("name,code,region,population", line[0]);
            Assert.Equal("lille,59,nord,1000000", line[0]);
            Assert.Equal("bordeaux,33,gironde,249000", line[totLines - 1]);
        }

        [Fact]
        public void TestLocationManager()
        {
            //Given
            string projectPath = @"C:\Users\20012454\myRepo\cs\collection";
            string filePath = projectPath + @"\test\Collection.Test\var\cities.csv";
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            //When
            cityManager.GetNFirstLocation(10);
            //Then
            Assert.Equal("lille", cityManager.Location[0].Name);
            Assert.Equal(42, cityManager.Location[3].Code);
        }

        [Fact]
        public void ReadFile()
        {
            //Given
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\20012454\Documents\RFI\workspace\tmp\oms-stock-even-preprod_metrics.txt");
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

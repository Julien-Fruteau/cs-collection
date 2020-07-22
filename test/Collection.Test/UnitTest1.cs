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
        public void InstantiateListv1()
        {
        //Given
            List<string> weekDays = new List<string> {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
        //When

        //Then
            Assert.Equal("Monday", weekDays[0]);
        }

        [Fact]
        public void TestCsvReaderReadNFirstLines()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
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
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            //When
            cityManager.GetNFirstLocation(10);
            //Then
            Assert.Equal("lille", cityManager.Location[0].Name);
            Assert.Equal(42, cityManager.Location[3].Code);
        }

        [Fact]
        public void TestCsvReaderReadAllLines()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            IFileReader csvReader = new CsvReader(filePath, true, ',');
            int count = 0;
            string lastLine = "";
            //When
            foreach (var line in csvReader.ReadAllLines())
            {
                count++;
                lastLine = line;
            }
            //Then
            Assert.Equal(11, count);
            Assert.Equal("clermont ferrand,63,puy de dome,169000", lastLine);
        }

        [Fact]
        public void TestListInsert()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            //When
        
            //Then
        }

        [Fact]
        public void ReadFile()
        {
            //Given
            string[] lines = System.IO.File.ReadAllLines(TestFile.GetTestFilePath());
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

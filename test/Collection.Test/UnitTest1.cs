using System;
using System.Collections.Generic;
using System.Linq;
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
        public void TestCityManagerGetAllLines()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            //When
            cityManager.GetAllLocation();
            //Then
            Assert.Equal("lille", cityManager.Location[0].Name);
            Assert.Equal("clermont ferrand", cityManager.Location[10].Name);
        }

        [Fact]
        public void TestListInsert()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            //When
            int myIndex = cityManager.Location.FindIndex(x => x.Population <= 1_500_000);
            cityManager.Location.Insert(myIndex, new City("lilliput", 99, "Somewhere", 2_000_000));
            //Then
            Assert.Equal("lilliput", cityManager.Location[0].Name);

        }

        [Fact]
        public void TestSortCities()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            //When
            cityManager.Location.Sort((x, y) => (x.Population.CompareTo(y.Population)));
            //Then
            Assert.Equal("noumea", cityManager.Location[0].Name);
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

        [Fact]
        public void TestInstantiateDict()
        {
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            Dictionary<string, ILocation> cities = new Dictionary<string, ILocation>();

            foreach (var city in cityManager.Location)
            {
                cities.Add(city.Name.Substring(0, 3).ToUpper(), city);
            }

            Assert.Equal("lille", cities["LIL"].Name);
            Assert.Equal("toulouse", cities["TOU"].Name);
        }

        [Fact]
        public void TestInstantiateDictV2()
        {
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            Dictionary<string, ILocation> cities = new Dictionary<string, ILocation> 
            {
                {cityManager.Location[0].Name.Substring(0, 3).ToUpper(), cityManager.Location[0]},
                {cityManager.Location[1].Name.Substring(0, 3).ToUpper(), cityManager.Location[1]}    
            };
            

            Assert.Equal("lille", cities["LIL"].Name);
            Assert.Equal("paris", cities["PAR"].Name);
        }

        [Fact]
        public void TestEnumDict()
        {
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetNFirstLocation(2);
            Dictionary<string, ILocation> cities = new Dictionary<string, ILocation>();

            foreach (var city in cityManager.Location)
            {
                cities.Add(city.Name.Substring(0, 3).ToUpper(), city);
            }

            int i = 0;
            foreach (var item in cities)
            {
                switch (i)
                {
                    case 0:
                        Assert.Equal("LIL", item.Key);
                        Assert.Equal("lille", item.Value.Name);
                        break;
                    case 1:
                        Assert.Equal("PAR", item.Key);
                        Assert.Equal("paris", item.Value.Name);
                        break;
                }
                i++;
            }
            
            i = 0;
            foreach (var item in cities.Values)
            {
                switch (i)
                {
                    case 0:
                        Assert.Equal("lille", item.Name);
                        break;
                    case 1:
                        Assert.Equal("paris", item.Name);
                        break;
                }
                i++;
            }
        }

        [Fact]
        public void TestDictAddSameKeyThrowsError()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetNFirstLocation(1);
            string key = cityManager.Location[0].Name.Substring(0, 3).ToUpper();
            ILocation city = cityManager.Location[0];
            // When
            Dictionary<string, ILocation> cities = new Dictionary<string, ILocation>
            {
                {key, city}
            };
            //Then
            Assert.Throws<System.ArgumentException>(delegate {cities.Add(key, city);});
        }

        [Fact]
        public void TestDictLookUpMissingKeyThrowsError()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetNFirstLocation(1);
            string key = cityManager.Location[0].Name.Substring(0, 3).ToUpper();
            ILocation city = cityManager.Location[0];
            // When
            Dictionary<string, ILocation> cities = new Dictionary<string, ILocation>
            {
                {key, city}
            };
            //Then
            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(delegate {Console.WriteLine(cities["TOT"]);});
        }

        [Fact]
        public void TestDictTryGetValue()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetNFirstLocation(1);
            string key = cityManager.Location[0].Name.Substring(0, 3).ToUpper();
            ILocation city = cityManager.Location[0];
            // When
            Dictionary<string, ILocation> cities = new Dictionary<string, ILocation>
            {
                {key, city}
            };
            bool exists = cities.TryGetValue("TOT", out ILocation aCity);
            //Then
            Assert.False(exists);
        }

        [Fact]
        public void TestRegionManagerGetNFirstRegion()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            RegionManager regionManager = new RegionManager(new CsvReader(filePath, true, ','));
            //When
            regionManager.GetNFirstRegion(2);
        //Then
            Assert.Equal("nord", regionManager.Region[59]);
        }

        [Fact]
        public void TestRegionManagerGetAllRegion()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            RegionManager regionManager = new RegionManager(new CsvReader(filePath, true, ','));
            //When
            regionManager.GetAllRegion();
            //Then
            Assert.Equal("puy de dome", regionManager.Region[63]);
            Assert.Equal(11, regionManager.Region.Count);
        }

        [Fact]
        public void InheritanceAndChildInstantiation()
        {
        //Given
            Inheritance inheritance = new Inheritance();
            Child child = new Child();
        //When
        //Then
            Assert.Equal("Inheritance : called from Inheritance", inheritance.GetClassName());
            Assert.Equal("Child : called from Child", child.GetClassName());
        }

        [Fact]
        public void InheritanceAndChildInstantiationFromInheritance()
        {
            //Given
            Inheritance inheritance = new Inheritance();
            Inheritance child = new Child();
            //When
            //Then
            Assert.Equal("Inheritance : called from Inheritance", inheritance.GetClassName());
            Assert.Equal("Child : called from Child", child.GetClassName());
        }

        [Fact]
        public void InheritanceAndChildInstantiationFromIBase()
        {
            //Given
            IBase inheritance = new Inheritance();
            IBase child = new Child();
            //When
            //Then
            Assert.Equal("Inheritance : called from Inheritance", inheritance.GetClassName());
            Assert.Equal("Child : called from Child", child.GetClassName());
        }

        [Fact]
        public void TestLINQ_Take_Demo()
        {
            //Given
            int testLen = 0;
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            //When
            foreach (var item in cityManager.Location.Take(5))
                testLen++;
            //Then
            Assert.Equal(5, testLen);
        }

        [Fact]
        public void TestLINQ_OrderBy_Demo()
        {
            //Given
            List<ILocation> expected = new List<ILocation>() {
                new City("bordeaux",33,"gironde",249000),
                new City("clermont ferrand",63,"puy de dome",169000),
                new City("lille",59,"nord",1000000)
            };
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            //Then
            int i = 0;
            foreach (var item in cityManager.Location.OrderBy(x => x.Name).Take(3))
            {
                Assert.Equal(expected[i].Name, item.Name);
                i++;
            }
        }

        [Fact]
        public void TestLINQ_Where_Demo()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            //When
            IEnumerable<ILocation> getItems = cityManager.Location.Where(x => x.Name.Contains(' '));
            //Then
            Assert.Equal(1, getItems.Count());
            Assert.Equal("clermont ferrand", getItems.First().Name);
        }

        [Fact]
        public void TestLINQ_Where_Demo2()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            //When
            var getItems = cityManager.Location.Where(x => !x.Name.Contains(' '));
            //Then
            Assert.Equal(10, getItems.Count());
        }

        [Fact]
        public void TestLINQ_Query_Syntax_Demo()
        {
            //Given
            string filePath = TestFile.GetTestFilePath();
            ILocationManager cityManager = new CityManager(new CsvReader(filePath, true, ','));
            cityManager.GetAllLocation();
            //When
            var getItems = from city in cityManager.Location
                           where !city.Name.Contains(' ')
                           select city;
            //Then
            Assert.Equal(10, getItems.Count());
        }
    }
}

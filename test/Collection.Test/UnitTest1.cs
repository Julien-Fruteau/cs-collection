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
        string filePath = projectPath + @"\test\Collection.Test\var\population.csv";
        IFileReader fileReader = new CsvReader(filePath, true, ',');
        Country[] countries = new Country[10];
        //When
        // IEnumerable<string> fileLines = fileReader.ReadNFirstLines(10);
        foreach (var item in fileReader.ReadNFirstLines(10))
        {
            Console.WriteLine($"{item} deleted");
            
        }
        //Then
    }

    [Fact]
    public void TestCountryManager()
    {
        //Given
        string projectPath = @"C:\Users\20012454\myRepo\cs\collection";
        string filePath = projectPath + @"\test\Collection.Test\var\population.csv";
        CountryManager countryManager = new CountryManager(new CsvReader(filePath, true, ','));
        countryManager.GetNFirstCountries(10);
        // countryManager.GetNFirstCountries(10);
        //When

        //Then
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

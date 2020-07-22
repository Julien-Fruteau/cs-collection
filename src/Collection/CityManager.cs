using System;
using System.Collections.Generic;

namespace Collection
{
    public interface ILocationManager
    {
        IFileReader FileReader { get; }
        List<ILocation> Location { get; }
        void GetNFirstLocation(int lines);
        void GetAllLocation();
        ILocation GetLocationFromLine(string line);
    }

    public class CityManager : ILocationManager
    {
        private IFileReader _fileReader;
        public IFileReader FileReader { get => _fileReader; }
        private List<ILocation> _location;
        public List<ILocation> Location { get => _location; }

        public CityManager(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void GetNFirstLocation(int totLines)
        {
            _location = new List<ILocation>();

            int index = 0;
            foreach (string line in FileReader.ReadNFirstLines(totLines))
            {
                _location.Add(GetLocationFromLine(line));
                index++;
            }
        }

        public ILocation GetLocationFromLine(string line)
        {
            string[] spl = line.Split(FileReader.GetDelimiter());
            return new City(spl[0], int.Parse(spl[1]), spl[2], int.Parse(spl[3]));
        }

        public void GetAllLocation()
        {
            GetNFirstLocation(FileReader.TotLines);
        }
    }
}
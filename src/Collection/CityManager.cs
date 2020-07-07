using System;
using System.Collections.Generic;

namespace Collection
{
    public interface ILocationManager
    {
        IFileReader FileReader { get; }
        ILocation[] Location { get; }

        void GetNFirstLocation(int lines);
    }

    public class CityManager : ILocationManager
    {
        private IFileReader _fileReader;
        public IFileReader FileReader { get => _fileReader; }
        private ILocation[] _location;
        public ILocation[] Location { get => _location; }

        public CityManager(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void GetNFirstLocation(int lines)
        {
            _location = new City[lines];

            int index = 0;
            foreach (string line in FileReader.ReadNFirstLines(lines))
            {
                string[] spl = line.Split(FileReader.GetDelimiter());
                _location[index] = new City(spl[0], int.Parse(spl[1]), spl[2], int.Parse(spl[3]));
                index++;
            }
        }
    }
}
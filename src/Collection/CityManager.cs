namespace Collection
{
    public class LocationManager
    {
        IFileReader _fileReader;

        private City[] _locations;

        public City[] Locations { get => _locations;}

        public LocationManager(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void GetNFirstLocation(int lines)
        {
            _locations = new City[lines];
            int index = 0;
            foreach (string line in _fileReader.ReadNFirstLines(lines))
            {
               string[] spl = line.Split(_fileReader.GetDelimiter());
               _locations[index] = new City(spl[0], int.Parse(spl[1]), spl[2], int.Parse(spl[3]));
               index++;
            }
        }
    }
}
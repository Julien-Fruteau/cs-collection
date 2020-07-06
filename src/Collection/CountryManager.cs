namespace Collection
{
    public class CountryManager
    {
        IFileReader _fileReader;
        
        private Country[] _countries;

        public CountryManager(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void GetNFirstCountries(int lines)
        {
            _countries = new Country[lines];
            int index = 0;
            foreach (string line in _fileReader.ReadNFirstLines(lines))
            {
                string[] spl = line.Split(_fileReader.GetDelimiter());
               _countries[index] = new Country(spl[0], spl[1], spl[2], int.Parse(spl[3]));
               index++;
            }
        }
    }
}
using System.Collections.Generic;

namespace Collection
{
    public class RegionManager : CityManager
    {
        private Dictionary<int, string> _region;
        public Dictionary<int, string> Region { get => _region; set => _region = value; }
    
        public RegionManager(IFileReader fileReader) : base(fileReader)
        {
        }

        public void GetNFirstRegion(int totLines)
        {
            GetNFirstLocation(totLines);
            _region = new Dictionary<int, string>();
            foreach (var item in Location)
            {
                Region.Add(item.Code, item.Region);
            }
        }

        public void GetAllRegion()
        {
            GetNFirstRegion(FileReader.TotLines);
        }
    }
}
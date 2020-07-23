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
}
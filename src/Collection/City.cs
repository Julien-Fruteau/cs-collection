namespace Collection
{
    public class City : ILocation
    {
        public string Name { get; }
        public int Code { get; }
        public string Region { get; }
        public int Population { get; }
        public City(string name, int code, string region, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = population;
        }

    }
}
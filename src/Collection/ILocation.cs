namespace Collection
{
    public interface ILocation
    {
        string Name { get; }
        int Code { get; }
        string Region { get; }
        int Population { get; }
    }
}
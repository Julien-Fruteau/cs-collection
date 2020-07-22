using System.Collections.Generic;

namespace Collection
{
    public interface IFileReader
    {
        int TotLines {get;}
        IEnumerable<string> ReadNFirstLines(int lines);
        IEnumerable<string> ReadAllLines();
        char GetDelimiter();
    }
}
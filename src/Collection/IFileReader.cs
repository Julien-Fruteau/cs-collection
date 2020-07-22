using System.Collections.Generic;

namespace Collection
{
    public interface IFileReader
    {
        IEnumerable<string> ReadNFirstLines(int lines);
        IEnumerable<string> ReadAllLines();
        char GetDelimiter();
        // int GetHeaderOffset();
    }
}
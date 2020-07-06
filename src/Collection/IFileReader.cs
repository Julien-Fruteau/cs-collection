using System.Collections.Generic;

namespace Collection
{
    public interface IFileReader
    {
        IEnumerable<string> ReadNFirstLines(int lines);
        char GetDelimiter();
        // int GetHeaderOffset();
    }
}
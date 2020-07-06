using System;
using System.Collections.Generic;
using System.IO;

namespace Collection
{
    public class CsvReader : IFileReader
    {
        private string _filePath;
        private bool _header;
        private char _delimiter;

        public CsvReader(string filePath, bool header, char delimiter)
        {
            if (! File.Exists(filePath)) throw new ArgumentException($"{filePath} does not exits");
            _filePath = filePath;
            _header = header;
            _delimiter = delimiter;
        }

        public IEnumerable<string> ReadNFirstLines(int lines)
        {
            int curLine = 0;
            string line;
            int offset = _header? 1: 0;

            using (StreamReader sr = File.OpenText(_filePath))
            {
                while (curLine < lines + offset && (line = sr.ReadLine()) != null)
                {
                    if (curLine >= offset) yield return line;
                    curLine++;
                }
            }
        }

        // public int GetHeaderOffset()
        // {
        //     return _header? 1: 0;
        // }

        public char GetDelimiter()
        {
            return _delimiter;
        }
    }
}
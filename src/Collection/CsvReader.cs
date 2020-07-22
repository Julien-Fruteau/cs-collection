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
        private int _totLines;

        public CsvReader(string filePath, bool header, char delimiter)
        {
            if (! File.Exists(filePath)) throw new ArgumentException($"{filePath} does not exits");
            _filePath = filePath;
            _header = header;
            _delimiter = delimiter;
            _totLines = GetFileTotLines();

        }

        public int GetFileTotLines()
        {
            string[] lines = File.ReadAllLines(_filePath);
            return lines.Length;
        }

        public IEnumerable<string> ReadNFirstLines(int totLines)
        {
            int curLine = 0;
            string line;
            int offset = _header? 1: 0;

            using (StreamReader sr = File.OpenText(_filePath))
            {
                while (curLine < totLines + offset && (line = sr.ReadLine()) != null)
                {
                    if (curLine >= offset) yield return line;
                    curLine++;
                }
            }
        }

        public IEnumerable<string> ReadAllLines()
        {
            foreach (string line in ReadNFirstLines(_totLines))
            {
                yield return line;
            }
            // string[] lines = File.ReadAllLines(_filePath);
            // foreach (string line in lines)
            // {
            //     yield return line;
            // }
        }

        public char GetDelimiter()
        {
            return _delimiter;
        }
    }
}
namespace Collection
{
    public static class TestFile
    {
        public static string GetTestFilePath()
        {
            string rootPath;
            if (OperatingSystem.isMacOS())
            {
                rootPath = @"/Users/julien/MEGA/Documents/Dev/cs/cs-collection";
            }
            else {
                rootPath = @"C:\Users\20012454\myRepo\cs\collection";
            }
            return rootPath + @"/test/Collection.Test/var/cities.csv";
        }
    }
}
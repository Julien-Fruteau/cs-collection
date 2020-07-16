using System.Runtime.InteropServices;

namespace Collection
{
    public static class OperatingSystem
    {
        public static bool isWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool isMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static bool isLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}
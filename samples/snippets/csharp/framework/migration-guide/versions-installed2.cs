using System;
using Microsoft.Win32;

public class VersionTest
{
    public static void Main()
    {
        GetVersionFromEnvironment();
    }

    private static void GetVersionFromEnvironment()
    {
        Console.WriteLine($"Version: {Environment.Version}");
    }
}

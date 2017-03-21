using System;
using System.Collections;
using System.Configuration;

class DisplayLocationInfo
{
    static void Main(string[] args)
    {
        Configuration config = 
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        ConfigurationLocationCollection myLocationCollection = config.Locations;
        foreach (ConfigurationLocation myLocation in myLocationCollection)
        {
            Console.WriteLine("Location Path: {0}", myLocation.Path);
            Configuration myLocationConfiguration = myLocation.OpenConfiguration();
            Console.WriteLine("Location Configuration File Path: {0}",
                myLocationConfiguration.FilePath);
        }
        Console.WriteLine("Done...");
        Console.ReadLine();
    }
}
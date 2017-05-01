//<Snippet1>
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
            //<Snippet2>
            Console.WriteLine("Location Path: {0}", myLocation.Path);
            //</Snippet2>
            //<Snippet3>
            Configuration myLocationConfiguration = myLocation.OpenConfiguration();
            Console.WriteLine("Location Configuration File Path: {0}",
                myLocationConfiguration.FilePath);
            //</Snippet3>
        }
        Console.WriteLine("Done...");
        Console.ReadLine();
    }
}
//</Snippet1>
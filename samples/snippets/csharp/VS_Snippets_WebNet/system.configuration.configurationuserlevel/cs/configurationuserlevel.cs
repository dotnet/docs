// <Snippet1>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;


public class UsingConsoleConfigElement
{

    static void GetConfigurationFile()
    {

        try
        {
            // Get the current application configuration file.
            Configuration config =
              ConfigurationManager.OpenExeConfiguration(
               ConfigurationUserLevel.None);

            Console.WriteLine(config.FilePath);

        }
        catch (ConfigurationErrorsException e)
        {
            Console.WriteLine("[Exception error: {0}]",
                e.ToString());
        }


    }

    // Get the roaming configuration file associated 
    // with the current user.
    static void GetRoamingConfigurationFile()
    {


        try
        {
            // Get the roaming configuration 
            // that applies to the current user.
            Configuration roamingConfig =
              ConfigurationManager.OpenExeConfiguration(
               ConfigurationUserLevel.PerUserRoaming);

            Console.WriteLine(roamingConfig.FilePath);

        }
        catch (ConfigurationErrorsException e)
        {
            Console.WriteLine("[Exception error: {0}]",
                e.ToString());
        }


    }

    static void Main(string[] args)
    {
        Console.Write("Roaming configuration file: ");
        GetRoamingConfigurationFile();
        Console.WriteLine();
        Console.Write("Configuration file: ");
        GetConfigurationFile();
        Console.WriteLine("Enter any key to exit");
        Console.ReadLine();
    }
}

// </Snippet1>

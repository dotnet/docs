// <Snippet21>
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;
using System.Text;


namespace ConfigurationStringSettings
{

    class ConfigurationStringSettings
    {

        static void DisplayConnectionStrings()
        {
            // Set the path of the config file.
            // Make sure that you have a Web site on the
            // same server called TestConfig. 
            string configPath = "/TestConfig";

            // Get the Web application configuration object.
            Configuration config =
              WebConfigurationManager.OpenWebConfiguration(configPath);

           
            // Get the conectionStrings section.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;

            Console.WriteLine("Display configuration strings.");

            for (int i = 0; i <
                ConfigurationManager.ConnectionStrings.Count; i++)
            {
                ConnectionStringSettings cs =
                    csSection.ConnectionStrings[i];

                Console.WriteLine("  Connection String: \"{0}\"",
                    cs.ConnectionString);

                Console.WriteLine("#{0}", i);
                Console.WriteLine("  Name: {0}", cs.Name);


                Console.WriteLine("  Provider Name: {0}",
                    cs.ProviderName);

            }

        }
        
        
        static void Main(string[] args)
        {
            try
            {   // Display connection strings.
                DisplayConnectionStrings();
            }
            catch (Exception e)
            {
                // Unknown error.
                Console.WriteLine(e.ToString());
            }

            // Display and wait.
            Console.WriteLine("Enter any key to exit.");
            Console.ReadLine();
        }
    }
}
// </Snippet21>
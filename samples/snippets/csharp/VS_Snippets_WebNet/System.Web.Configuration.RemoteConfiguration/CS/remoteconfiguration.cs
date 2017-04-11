// <Snippet1>
using System;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Specialized;

namespace Samples.AspNet
{
    // This example dDemonstrates how to access and modify remote 
   // configuration files
    public class RemoteConfiguration
    {

        // The application entry point.
        public static void Main(string[] args)
        {
            // This string  contains the name of 
            // the remote server.
            string machineName = string.Empty;

            // Get the user's input.
            if (args.Length > 0)
            {
                // Get the name of the remote server.
                // The machine name must be in the format
                // accepted by the operating system.
                machineName = args[0];

                // Get the user name and password.
                if (args.Length > 1)		
                {                
                    string userName = args[1];
                    string password = string.Empty;
                    if (args.Length > 2)
                        password = args[2];

                    // Update the site configuration.
                    UpdateConfiguration(machineName, userName, 
                        password);
                }
                else
                { 
                    // Update the site configuration.
                    UpdateConfiguration(machineName);
                }
            }
            else
            {
                Console.WriteLine("Enter a valid server name.");
            }
        }

        // Update the configuration file using the credentials
        // of the user running this application then
        // call the routine that reads the configuration 
        // settings.
        // Note that the system issues an error if the user
        // does not have administrative privileges on the server.
        public static void UpdateConfiguration(string machineName)
        {
            try
            {
                Console.WriteLine("MachineName:  [{0}]", machineName);
                Console.WriteLine("UserDomainName:  [{0}]", 
                    Environment.UserDomainName);
                Console.WriteLine("UserName:  [{0}]", 
                    Environment.UserName);

                // Get the configuration.
                Configuration config = 
                    WebConfigurationManager.OpenWebConfiguration(
                    "/", "Default Web Site", null, machineName);
                
                // Add a new key/value pair to appSettings.
                string count = 
                    config.AppSettings.Settings.Count.ToString();
                config.AppSettings.Settings.Add("key_" + count, "value_" + count);
                // Save to the file,
                config.Save();
                
                // Read the new appSettings.
                ReadAppSettings(config);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

     	 // Update the configuration file using the credentials
     	 // of the passed user. Tthen,
   	 // call the routine that reads the configuration settings.
        // Note that the system issues an error if the user
        // does not have administrative privileges on the server.
        public static void UpdateConfiguration(string machineName, 
            string userName, string password)
        {
            try
            {
                Console.WriteLine("MachineName:  [{0}]", machineName);
                Console.WriteLine("UserName:  [{0}]", userName);
                Console.WriteLine("Password:  [{0}]", password);

                // Get the configuration.
                Configuration config = 
                    WebConfigurationManager.OpenWebConfiguration(
                    "/", "Default Web Site", null, 
                    machineName, userName, password);


                // Add a new key/value pair to appSettings
                string count =
                    config.AppSettings.Settings.Count.ToString();
                config.AppSettings.Settings.Add("key_" + count, "value_" + count);

	         // Save changes to the file.
                config.Save();

                // Read the new appSettings.
                ReadAppSettings(config);
              
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        // Read the appSettings on the remote server.
        public static void ReadAppSettings(
            Configuration config)
        {
            try
            {
                Console.WriteLine("--- Printing appSettings at [{0}] ---", 
                    config.FilePath);
                Console.WriteLine("Count: [{0}]", 
                    config.AppSettings.Settings.Count);
                foreach (string key in config.AppSettings.Settings.AllKeys)
                {
                    Console.WriteLine("  [{0}] = [{1}]", 
                        key, config.AppSettings.Settings[key].Value);
                }
                Console.WriteLine();

            }           
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }

}
// </Snippet1>
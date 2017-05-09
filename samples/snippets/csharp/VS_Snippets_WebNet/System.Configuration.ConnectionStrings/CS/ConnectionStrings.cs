using System;
using System.Configuration;
using System.Text;

namespace Samples.AspNet
{
    class ConnectionStrings
    {

        // <Snippet1>
        // Create a connectionn string element and add it to
        // the connection strings section.
        static ConnectionStrings()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the current connection strings count.
            int connStrCnt = 
                ConfigurationManager.ConnectionStrings.Count;
 
            // Create the connection string name. 
            string csName = 
                "ConnStr" + connStrCnt.ToString();

            // Create a connection string element and
            // save it to the configuration file.
           
            // Create a connection string element.
            ConnectionStringSettings csSettings =
                    new ConnectionStringSettings(csName,
                    "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" +
                    "Initial Catalog=aspnetdb", "System.Data.SqlClient");

            // Get the connection strings section.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;

            // Add the new element.
            csSection.ConnectionStrings.Add(csSettings);
                
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);
            
        }
        // </Snippet1>

        // <Snippet2>
        static void ShowConnectionStrings()
        {
             // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // <Snippet3>
            // Get the conectionStrings section.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            
            for (int i = 0; i < 
                ConfigurationManager.ConnectionStrings.Count; i++)
            {
                ConnectionStringSettings cs = 
                    csSection.ConnectionStrings[i];
                
                // <Snippet4>
                Console.WriteLine("  Connection String: \"{0}\"",
                    cs.ConnectionString);
                // </Snippet4>

                Console.WriteLine("#{0}", i);
                // <Snippet5>
                Console.WriteLine("  Name: {0}", cs.Name);
                // </Snippet5>
             
                
                // <Snippet6>
                Console.WriteLine("  Provider Name: {0}", 
                    cs.ProviderName);
                // </Snippet6>
                
            }
            // </Snippet3>

        }
        // </Snippet2>
        

        // <Snippet7>
        // Add a connection string to the connection
        // strings section and store it in the
        // configuration file.
        static void AddConnectionStrings()
        {
           
            // Get the count of the connection strings.
            int connStrCnt = 
                ConfigurationManager.ConnectionStrings.Count;
            
            // Define the string name.
            string csName = "ConnStr" + 
                connStrCnt.ToString();

            // Get the configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            
            // <Snippet8>
            // Add the connection string.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            csSection.ConnectionStrings.Add(
                new ConnectionStringSettings(csName,
                    "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" +
                    "Initial Catalog=aspnetdb", "System.Data.SqlClient"));
            // </Snippet8>

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            Console.WriteLine("Connection string added.");

        }
        // </Snippet7>


        // <Snippet9>
        // Clear connection strings collection.
        static void ClearConnectionStrings()
        {

            // Get the configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            // Clear the connection strings collection.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            csSection.ConnectionStrings.Clear();
           
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            Console.WriteLine("Connection strings cleared.");


        }
        // </Snippet9>

        //<Snippet10>
        static void GetIndex()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                // Clear the connection strings collection.
                ConnectionStringsSection csSection =
                    config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection =
                 csSection.ConnectionStrings;

                // Get the connection string setting element
                // with the specified name.
                ConnectionStringSettings cs =
                    csCollection["ConnStr0"];

                // Get its index;
                int index = csCollection.IndexOf(cs);

                Console.WriteLine(
                     "Connection string settings index: {0}", 
                     index.ToString());

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet10>


        //<Snippet11>
        static void RemoveConnectionStrings()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                // Clear the connection strings collection.
                ConnectionStringsSection csSection =
                    config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection =
                 csSection.ConnectionStrings;

                // Get the connection string setting element
                // with the specified name.
                ConnectionStringSettings cs =
                    csCollection["ConnStr0"];

                // Remove it.
                if (cs != null)
                {
                    // Remove the element.
                    csCollection.Remove(cs);

                    // Save the configuration file.
                    config.Save(ConfigurationSaveMode.Modified);
                    
                    Console.WriteLine(
                     "Connection string settings removed.");
                }
                else
                    Console.WriteLine(
                        "Connection string settings does not exist.");

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet11>

        //<Snippet12>
        static void RemoveConnectionStrings2()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                // Clear the connection strings collection.
                ConnectionStringsSection csSection =
                    config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection =
                 csSection.ConnectionStrings;

                // Remove the element.
                    csCollection.Remove("ConnStr0");
               

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);

                Console.WriteLine(
                     "Connection string settings removed.");
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet12>

        //<Snippet13>
        static void RemoveConnectionStrings3()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                // Clear the connection strings collection.
                ConnectionStringsSection csSection =
                    config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection =
                 csSection.ConnectionStrings;

                // Remove the element.
                csCollection.RemoveAt(0);

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified);
                
                Console.WriteLine(
                     "Connection string settings removed.");
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet13>

        //<Snippet14>
        static void GetItems()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                // Clear the connection strings collection.
                ConnectionStringsSection csSection =
                    config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection =
                 csSection.ConnectionStrings;

                // Get the connection string setting element
                // with the specified index.
                ConnectionStringSettings cs =
                    csCollection[0];

                Console.WriteLine(
                     "cs: {0}", cs.Name);

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet14>

        //<Snippet15>
        static void GetItems2()
        {

            try
            {
                System.Configuration.Configuration config =
                 ConfigurationManager.OpenExeConfiguration(
                 ConfigurationUserLevel.None);

                // Clear the connection strings collection.
                ConnectionStringsSection csSection =
                    config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection =
                 csSection.ConnectionStrings;

                // Get the connection string setting element
                // with the specified name.
                ConnectionStringSettings cs =
                    csCollection["ConnStr0"];
               
                Console.WriteLine(
                    "cs: {0}", cs.Name);

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        //</Snippet15>

        static void Main(string[] args)
        {
            
            // Display current connection strings.
            // ShowConnectionStrings();

            // ClearConnectionStrings();

            // AddConnectionStrings();

            // GetItems();
            // GetIndex();

            RemoveConnectionStrings2();

        }
    }
}

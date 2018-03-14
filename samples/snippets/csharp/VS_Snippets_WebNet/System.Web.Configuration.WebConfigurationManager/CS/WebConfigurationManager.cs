// <Snippet1>
using System;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Specialized;
using System.Collections;
using System.Text;

namespace Samples.Aspnet
{
    class UsingWebConfigurationManager
    {


        // Methods to access a section at runtime. 


        // <Snippet2>

        // Show how to use the GetSection(string). 
        // to access the connectionStrings section.
        static void GetConnectionStringsSection()
        {

            // Get the connectionStrings section.
            ConnectionStringsSection connectionStringsSection =
                WebConfigurationManager.GetSection("connectionStrings")
                as ConnectionStringsSection;

            // Get the connectionStrings key,value pairs collection.
            ConnectionStringSettingsCollection connectionStrings =
                connectionStringsSection.ConnectionStrings;
           
            // Get the collection enumerator.
            IEnumerator connectionStringsEnum =
                connectionStrings.GetEnumerator();

            // Loop through the collection and 
            // display the connectionStrings key, value pairs.
            int i = 0;
            Console.WriteLine("[Display the connectionStrings]");
            while (connectionStringsEnum.MoveNext())
            {
                string name = connectionStrings[i].Name;
                Console.WriteLine("Name: {0} Value: {1}",
                name, connectionStrings[name]);
                i += 1;
            }

            Console.WriteLine();
        }

        // </Snippet2>


      
        // <Snippet5>

       // Show the use of GetSection(string, string). 
       // to access the connectionStrings section.
        static void GetSection2()
        {

            try
            {
                // Get the connectionStrings section for the 
                // specified Web app. This GetSection overload
                // can olny be called from within a Web application.
                ConnectionStringsSection connectionStringsSection =
                    WebConfigurationManager.GetSection("connectionStrings",
                    "/configTest") as ConnectionStringsSection;

                // Get the connectionStrings key,value pairs collection
                ConnectionStringSettingsCollection connectionStrings =
                    connectionStringsSection.ConnectionStrings;

                // Get the collection enumerator.
                IEnumerator connectionStringsEnum =
                    connectionStrings.GetEnumerator();

                // Loop through the collection and 
                // display the connectionStrings key, value pairs.
                int i = 0;
                Console.WriteLine("[Display connectionStrings]");
                while (connectionStringsEnum.MoveNext())
                {
                    string name = connectionStrings[i].Name;
                    Console.WriteLine("Name: {0} Value: {1}",
                    name, connectionStrings[name]);
                    i += 1;
                }
                Console.WriteLine();
            }

            catch (InvalidOperationException e)
            {
                string errorMsg = e.ToString();
                Console.WriteLine(errorMsg);
            }
        }

        // </Snippet5>

        // <Snippet6>

       // Show the use of GetWebApplicationSection(string). 
       // to get the connectionStrings section.
        static void GetWebApplicationSection()
        {

            // Get the default connectionStrings section,
            ConnectionStringsSection connectionStringsSection =
                WebConfigurationManager.GetWebApplicationSection(
                "connectionStrings") as ConnectionStringsSection;

            // Get the connectionStrings key,value pairs collection.
            ConnectionStringSettingsCollection connectionStrings =
                connectionStringsSection.ConnectionStrings;

            // Get the collection enumerator.
            IEnumerator connectionStringsEnum =
                connectionStrings.GetEnumerator();

            // Loop through the collection and 
            // display the connectionStrings key, value pairs.
            int i = 0;
            Console.WriteLine("[Display connectionStrings]");
            while (connectionStringsEnum.MoveNext())
            {
                string name = connectionStrings[i].Name;
                Console.WriteLine("Name: {0} Value: {1}",
                name, connectionStrings[name]);
                i += 1;
            }

            Console.WriteLine();
        }

        // </Snippet6>

        // <Snippet7>

        // Show the use of the ConnectionString property
        // to get the connection strings.
        static void GetConnectionStrings()
        {

            // Get the connectionStrings key,value pairs collection.
            ConnectionStringSettingsCollection connectionStrings =
                WebConfigurationManager.ConnectionStrings
                as ConnectionStringSettingsCollection;

            // Get the collection enumerator.
            IEnumerator connectionStringsEnum =
                connectionStrings.GetEnumerator();

            // Loop through the collection and 
            // display the connectionStrings key, value pairs.
            int i = 0;
            Console.WriteLine("[Display connectionStrings]");
            while (connectionStringsEnum.MoveNext())
            {
                string name = connectionStrings[i].Name;
                Console.WriteLine("Name: {0} Value: {1}",
                name, connectionStrings[name]);
                i += 1;
            }

            Console.WriteLine();
        }

        // </Snippet7>

        // <Snippet8>

   
        // Show the use of the AppSettings property
        // to get the application settings. 
        static void GetAppSettings()
        {

            // Get the appSettings key,value pairs collection.
            NameValueCollection appSettings =
                WebConfigurationManager.AppSettings
                as NameValueCollection;

            // Get the collection enumerator.
            IEnumerator appSettingsEnum =
                appSettings.GetEnumerator();

            // Loop through the collection and 
            // display the appSettings key, value pairs.
            int i = 0;
            Console.WriteLine("[Display appSettings]");
            while (appSettingsEnum.MoveNext())
            {
                string key = appSettings.AllKeys[i].ToString();
                Console.WriteLine("Key: {0} Value: {1}",
                key, appSettings[key]);
                i += 1;
            }

            Console.WriteLine();
        }

        // </Snippet8>


        // Methods to access configuration files 
        // not at runtime. These methods are
        // used to edit configuration files.


        // <Snippet9>

        // Show how to use OpenMachineConfiguration().
        // It gets the machine.config file on the current 
        // machine and displays section information. 
        static void OpenMachineConfiguration1()
        {
            // Get the machine.config file on the current machine.
            System.Configuration.Configuration config =
                    WebConfigurationManager.OpenMachineConfiguration();

            // Loop to get the sections. Display basic information.
            Console.WriteLine("Name, Allow Definition");
            int i = 0;
            foreach (ConfigurationSection section in config.Sections)
            {
                Console.WriteLine(
                    section.SectionInformation.Name + "\t" +
                section.SectionInformation.AllowExeDefinition);
                i += 1;

            }
            Console.WriteLine("[Total number of sections: {0}]", i);

            // Display machine.config path.
            Console.WriteLine("[File path: {0}]", config.FilePath); 

        }

        // </Snippet9>

        // <Snippet10>

        // Show how to use OpenMachineConfiguration(string).
        // It gets the machine.config file applicabe to the
        // specified resource and displays section 
        // basic information. 
        static void OpenMachineConfiguration2()
        {
            // Get the machine.config file applicabe to the
            // specified reosurce.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenMachineConfiguration("configTest");

            // Loop to get the sections. Display basic information.
            Console.WriteLine("Name, Allow Definition");
            int i = 0;
            foreach (ConfigurationSection section in config.Sections)
            {
                Console.WriteLine(
                    section.SectionInformation.Name + "\t" +
                section.SectionInformation.AllowExeDefinition);
                i += 1;

            }
            Console.WriteLine("[Total number of sections: {0}]", i);

            // Display machine.config path.
            Console.WriteLine("[File path: {0}]", config.FilePath);

        }

        // </Snippet10>

        // <Snippet11>

        // Show how to use OpenMachineConfiguration(string, string).
        // It gets the machine.config file on the specified server and
        // applicabe to the specified reosurce and displays section 
        // basic information. 
        static void OpenMachineConfiguration3()
        {
            // Get the machine.config file applicabe to the
            // specified reosurce and on the specified server.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenMachineConfiguration("configTest", 
                "myServer");

            // Loop to get the sections. Display basic information.
            Console.WriteLine("Name, Allow Definition");
            int i = 0;
            foreach (ConfigurationSection section in config.Sections)
            {
                Console.WriteLine(
                    section.SectionInformation.Name + "\t" +
                section.SectionInformation.AllowExeDefinition);
                i += 1;

            }
            Console.WriteLine("[Total number of sections: {0}]", i);

            // Display machine.config path.
            Console.WriteLine("[File path: {0}]", config.FilePath);

        }

        // </Snippet11>

        // <Snippet12>

        // Show how to use OpenMachineConfiguration(string, string).
        // It gets the machine.config file on the specified server,
        // applicabe to the specified reosurce, for the specified user
        // and displays section basic information. 
        static void OpenMachineConfiguration4()
        {
            // Get the current user token.
            IntPtr userToken =
                  System.Security.Principal.WindowsIdentity.GetCurrent().Token;

            // Get the machine.config file applicabe to the
            // specified reosurce, on the specified server for the
            // specified user.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenMachineConfiguration("configTest",
                "myServer", userToken);

            // Loop to get the sections. Display basic information.
            Console.WriteLine("Name, Allow Definition");
            int i = 0;
            foreach (ConfigurationSection section in config.Sections)
            {
                Console.WriteLine(
                    section.SectionInformation.Name + "\t" +
                section.SectionInformation.AllowExeDefinition);
                i += 1;

            }
            Console.WriteLine("[Total number of sections: {0}]", i);

            // Display machine.config path.
            Console.WriteLine("[File path: {0}]", config.FilePath);

        }

        // </Snippet12>

        // <Snippet13>

        // Show how to use OpenMachineConfiguration(string, string).
        // It gets the machine.config file on the specified server,
        // applicabe to the specified reosurce, for the specified user
        // and displays section basic information. 
        static void OpenMachineConfiguration5()
        {
            // Set the user id and password.
            string user =
                  System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // Substitute with actual password.
            string password = "userPassword";

            // Get the machine.config file applicabe to the
            // specified reosurce, on the specified server for the
            // specified user.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenMachineConfiguration("configTest",
                "myServer", user, password);

            // Loop to get the sections. Display basic information.
            Console.WriteLine("Name, Allow Definition");
            int i = 0;
            foreach (ConfigurationSection section in config.Sections)
            {
                Console.WriteLine(
                    section.SectionInformation.Name + "\t" +
                section.SectionInformation.AllowExeDefinition);
                i += 1;

            }
            Console.WriteLine("[Total number of sections: {0}]", i);

            // Display machine.config path.
            Console.WriteLine("[File path: {0}]", config.FilePath);

        }

        // </Snippet13>

        // <Snippet14>

        // Show how to use OpenWebConfiguration(string).
        // It gets he appSettings section of a Web application 
        // runnig on the local server. 
        static void OpenWebConfiguration1()
        {
            // Get the configuration object for a Web application
            // running on the local server. 
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenWebConfiguration("/configTest") 
                as System.Configuration.Configuration; 

            // Get the appSettings.
            KeyValueConfigurationCollection appSettings =
                 config.AppSettings.Settings;


            // Loop through the collection and
            // display the appSettings key, value pairs.
            Console.WriteLine("[appSettings for app at: {0}]", "/configTest");
            foreach (string key in appSettings.AllKeys)
            {
                Console.WriteLine("Name: {0} Value: {1}",
                key, appSettings[key].Value);
            }

            Console.WriteLine();
        }

        // </Snippet14>

        // <Snippet15>

        // Show how to use OpenWebConfiguration(string, string).
        // It gets he appSettings section of a Web application 
        // runnig on the local server. 
        static void OpenWebConfiguration2()
        {
            // Get the configuration object for a Web application
            // running on the local server. 
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenWebConfiguration("/configTest", 
                "Default Web Site")
                as System.Configuration.Configuration;

            // Get the appSettings.
            KeyValueConfigurationCollection appSettings =
                 config.AppSettings.Settings;


            // Loop through the collection and
            // display the appSettings key, value pairs.
            Console.WriteLine(
                "[appSettings for app at: /configTest");
            Console.WriteLine(" and site: Default Web Site]");

            foreach (string key in appSettings.AllKeys)
            {
                Console.WriteLine("Name: {0} Value: {1}",
                key, appSettings[key].Value);
            }

            Console.WriteLine();
        }

        // </Snippet15>

        // <Snippet16>

        // Show how to use OpenWebConfiguration(string, string, string).
        // It gets he appSettings section of a Web application 
        // runnig on the local server. 
        static void OpenWebConfiguration3()
        {
            // Get the configuration object for a Web application
            // running on the local server. 
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenWebConfiguration(
                "/configTest", "Default Web Site", null)
                as System.Configuration.Configuration;

            // Get the appSettings.
            KeyValueConfigurationCollection appSettings =
                 config.AppSettings.Settings;

            // Loop through the collection and
            // display the appSettings key, value pairs.
            Console.WriteLine(
                "[appSettings for app at: /configTest");
            Console.WriteLine(" site: Default Web Site");
            Console.WriteLine(" and locationSubPath: null]");
            
            foreach (string key in appSettings.AllKeys)
            {
                Console.WriteLine("Name: {0} Value: {1}",
                key, appSettings[key].Value);
            }

            Console.WriteLine();
        }

        // </Snippet16>


        // <Snippet17>

        // Show how to use OpenWebConfiguration(string, string, 
        // string, string).
        // It gets he appSettings section of a Web application 
        // running on the specified server. 
        // If the server is remote your application must have the
        // required access rights to the configuration file. 
        static void OpenWebConfiguration4()
        {
            // Get the configuration object for a Web application
            // running on the specified server.
            // Null for the subPath signifies no subdir. 
            System.Configuration.Configuration config =
                   WebConfigurationManager.OpenWebConfiguration(
                    "/configTest", "Default Web Site", null, "myServer")
                   as System.Configuration.Configuration;
            
            // Get the appSettings.
            KeyValueConfigurationCollection appSettings =
                 config.AppSettings.Settings;


            // Loop through the collection and
            // display the appSettings key, value pairs.
            Console.WriteLine("[appSettings for Web app on server: myServer]");
            foreach (string key in appSettings.AllKeys)
            {
                Console.WriteLine("Name: {0} Value: {1}",
                key, appSettings[key].Value);
            }

            Console.WriteLine();
        }

        // </Snippet17>


        // <Snippet18>

        // Show how to use OpenWebConfiguration(string, string, 
        // string, string, string, string).
        // It gets he appSettings section of a Web application 
        // running on a remote server. 
        // If the server is remote your application must have the
        // required access rights to the configuration file. 
        static void OpenWebConfiguration5()
        {
            // Get the current user.
            string user =
                System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            
            // Assign the actual password.
            string password = "userPassword";

            // Get the configuration object for a Web application
            // running on a remote server.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenWebConfiguration(
                "/configTest", "Default Web Site", null, "myServer",
                user, password) as System.Configuration.Configuration;

            // Get the appSettings.
            KeyValueConfigurationCollection appSettings =
                 config.AppSettings.Settings;


            // Loop through the collection and
            // display the appSettings key, value pairs.
            Console.WriteLine(
                "[appSettings for Web app on server: myServer user: {0}]", user);
            foreach (string key in appSettings.AllKeys)
            {
                Console.WriteLine("Name: {0} Value: {1}",
                key, appSettings[key].Value);
            }

            Console.WriteLine();
        }
        // </Snippet18>

        // <Snippet19>

        // Show how to use OpenWebConfiguration(string, string, 
        // string, string, IntPtr).
        // It gets he appSettings section of a Web application 
        // running on a remote server. 
        // If the serve is remote your application shall have the
        // requires access rights to the configuration file. 
        static void OpenWebConfiguration6()
        {

            IntPtr userToken = 
                System.Security.Principal.WindowsIdentity.GetCurrent().Token;
           
            string user = 
                System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            
            // Get the configuration object for a Web application
            // running on a remote server.
            System.Configuration.Configuration config =
                WebConfigurationManager.OpenWebConfiguration(
                "/configTest", "Default Web Site", null, 
                "myServer", userToken) as System.Configuration.Configuration;

            // Get the appSettings.
            KeyValueConfigurationCollection appSettings =
                 config.AppSettings.Settings;

            // Loop through the collection and
            // display the appSettings key, value pairs.
            Console.WriteLine(
                "[appSettings for Web app on server: myServer user: {0}]", user);
            foreach (string key in appSettings.AllKeys)
            {
                Console.WriteLine("Name: {0} Value: {1}",
                key, appSettings[key].Value);
            }

            Console.WriteLine();
        }
        // </Snippet19>

        // <Snippet20>

        // Utility to map virtual directories to physical ones.
        // In the current physical directory maps 
        // a physical sub-directory with its virtual directory.
        // A web.config file is created for the
        // default and the virtual directory at the appropriate level.
        // You must create a physical directory called config at the
        // level where your app is running.
        static WebConfigurationFileMap CreateFileMap()
        {

            WebConfigurationFileMap fileMap =
                   new WebConfigurationFileMap();

            // Get he physical directory where this app runs.
            // We'll use it to map the virtual directories
            // defined next. 
            string physDir = Environment.CurrentDirectory;

            // Create a VirtualDirectoryMapping object to use
            // as the root directory for the virtual directory
            // named config. 
            // Note: you must assure that you have a physical subdirectory
            // named config in the curremt physical directory where this
            // application runs.
            VirtualDirectoryMapping vDirMap = 
                new VirtualDirectoryMapping(physDir + "\\config", true);

            // Add vDirMap to the VirtualDirectories collection 
            // assigning to it the virtual directory name.
            fileMap.VirtualDirectories.Add("/config", vDirMap);

            // Create a VirtualDirectoryMapping object to use
            // as the default directory for all the virtual 
            // directories.
            VirtualDirectoryMapping vDirMapBase =
                new VirtualDirectoryMapping(physDir, true, "web.config");

            // Add it to the virtual directory mapping collection.
            fileMap.VirtualDirectories.Add("/", vDirMapBase);

# if DEBUG  
            // Test at debug time.
            foreach (string key in fileMap.VirtualDirectories.AllKeys)
            {
                Console.WriteLine("Virtual directory: {0} Physical path: {1}",
                fileMap.VirtualDirectories[key].VirtualDirectory, 
                fileMap.VirtualDirectories[key].PhysicalDirectory);
            }
# endif 

            // Return the mapping.
            return fileMap;

        }

        // </Snippet20>

        // <Snippet21>

        // Show how to use the OpenMappedWebConfiguration(
        // WebConfigurationFileMap, string)
        static void OpenMappedWebConfiguration1()
        {

            // Create the configuration directories mapping.
            WebConfigurationFileMap fileMap = 
                CreateFileMap();

            try
            {

                // Get the Configuration object for the mapped
                // virtual directory.
                System.Configuration.Configuration config =
                    WebConfigurationManager.OpenMappedWebConfiguration(fileMap, 
                    "/config");

                // Define a nique key for the creation of 
                // an appSettings element entry.
                int appStgCnt = config.AppSettings.Settings.Count;
                string asName = "AppSetting" + appStgCnt.ToString();

                // Add a new element to the appSettings.
                config.AppSettings.Settings.Add(asName,
                    DateTime.Now.ToLongDateString() + " " +
                    DateTime.Now.ToLongTimeString());

                // Save to the configuration file.
                config.Save(ConfigurationSaveMode.Modified);
              
                // Display new appSettings.
                Console.WriteLine("Count:  [{0}]", config.AppSettings.Settings.Count);
                foreach (string key in config.AppSettings.Settings.AllKeys)
                { 
                    Console.WriteLine("[{0}] = [{1}]", key, 
                        config.AppSettings.Settings[key].Value);
                }
                
            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.ToString());
            }

            Console.WriteLine();
        }

        // </Snippet21>

        // <Snippet22>

        // Show how to use the OpenMappedWebConfiguration(
        // WebConfigurationFileMap, string, string).
        static void OpenMappedWebConfiguration2()
        {

            // Create the configuration directories mapping.
            WebConfigurationFileMap fileMap =
                CreateFileMap();

            try
            {

                // Get the Configuration object for the mapped
                // virtual directory.
                System.Configuration.Configuration config = 
                    WebConfigurationManager.OpenMappedWebConfiguration(
                    fileMap, "/config", "config");
                
                // Define a nique key for the creation of 
                // an appSettings element entry.
                int appStgCnt = config.AppSettings.Settings.Count;
                string asName = "AppSetting" + appStgCnt.ToString();

                // Add a new element to the appSettings.
                config.AppSettings.Settings.Add(asName,
                    DateTime.Now.ToLongDateString() + " " +
                    DateTime.Now.ToLongTimeString());

                // Save to the configuration file.
                config.Save(ConfigurationSaveMode.Modified);

                // Display new appSettings.
                Console.WriteLine("Count:  [{0}]", 
                    config.AppSettings.Settings.Count);
                foreach (string key in config.AppSettings.Settings.AllKeys)
                {
                    Console.WriteLine("[{0}] = [{1}]", key,
                        config.AppSettings.Settings[key].Value);
                }

            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.ToString());
            }

            Console.WriteLine();
        }

        // </Snippet22>

        // <Snippet23>

        // Show how to use the OpenMappedWebConfiguration(
        // WebConfigurationFileMap, string, string, string).
        static void OpenMappedWebConfiguration3()
        {

            // Create the configuration directories mapping.
            WebConfigurationFileMap fileMap =
                CreateFileMap();

            try
            {

                // Get the Configuration object for the mapped
                // virtual directory.
                System.Configuration.Configuration config =
                    WebConfigurationManager.OpenMappedWebConfiguration(
                    fileMap, "/config", "config", "config");

                // Define a nique key for the creation of 
                // an appSettings element entry.
                int appStgCnt = config.AppSettings.Settings.Count;
                string asName = "AppSetting" + appStgCnt.ToString();

                // Add a new element to the appSettings.
                config.AppSettings.Settings.Add(asName,
                    DateTime.Now.ToLongDateString() + " " +
                    DateTime.Now.ToLongTimeString());

                // Save to the configuration file.
                config.Save(ConfigurationSaveMode.Modified);

                // Display new appSettings.
                Console.WriteLine("Count:  [{0}]", 
                    config.AppSettings.Settings.Count);
                foreach (string key in config.AppSettings.Settings.AllKeys)
                {
                    Console.WriteLine("[{0}] = [{1}]", key,
                        config.AppSettings.Settings[key].Value);
                }

            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.ToString());
            }

            Console.WriteLine();
        }

        // </Snippet23>

        static void Main(string[] args)
        {

            string selection = string.Empty;

            if (args.Length == 0)
            {
                Console.WriteLine("Enter a selection from 0 to 18");
                return;
            }

            selection = args[0];

            switch (selection)
            {
                case "0":
                    GetConnectionStringsSection();
                    break;
                
                case "1":
                    GetSection2();
                    break;

                case "2":
                    GetWebApplicationSection();
                    break;


                case "3":
                    OpenMachineConfiguration1();
                    break;

                case "4":
                    OpenMachineConfiguration2();
                    break;

                case "5":
                    OpenMachineConfiguration3();
                    break;

                case "6":
                    OpenMachineConfiguration4();
                    break;

                case "7":
                    OpenMachineConfiguration5();
                    break;

                case "8":
                    OpenWebConfiguration1();
                    break;

                case "9":
                    OpenWebConfiguration2();
                    break;
                
                case "10":
                    OpenWebConfiguration3();
                    break;
                
                case "11":
                    OpenWebConfiguration4();
                    break;
                
                case "12":
                    OpenWebConfiguration5();
                    break;
                
                case "13":
                    OpenWebConfiguration6();
                    break;

                case "14":
                    OpenMappedWebConfiguration1();
                    break;

                case "15":
                    OpenMappedWebConfiguration2();
                    break;

                case "16":
                    OpenMappedWebConfiguration3();
                    break;

                case "17":
                    GetAppSettings();
                    break;
                
                case "18":
                    GetConnectionStrings();
                    break;


                default:
                    Console.WriteLine("Unknown selection");
                    break;
            }

            Console.Read();
            
        }
    }
}
// </Snippet1>
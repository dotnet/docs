
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
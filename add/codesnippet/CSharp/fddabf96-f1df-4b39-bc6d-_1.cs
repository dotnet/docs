
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

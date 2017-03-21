
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

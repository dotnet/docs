
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

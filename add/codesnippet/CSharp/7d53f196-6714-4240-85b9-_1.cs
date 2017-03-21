            // Add the connection string.
            ConnectionStringsSection csSection =
                config.ConnectionStrings;
            csSection.ConnectionStrings.Add(
                new ConnectionStringSettings(csName,
                    "LocalSqlServer: data source=127.0.0.1;Integrated Security=SSPI;" +
                    "Initial Catalog=aspnetdb", "System.Data.SqlClient"));
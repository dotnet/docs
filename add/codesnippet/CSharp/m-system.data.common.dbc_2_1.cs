        static void Main()
        {
            try
            {
                DbConnectionStringBuilder builder =
                    new DbConnectionStringBuilder();
                builder.Add("Data Source", "ServerName");
                builder.Add("Initial Catalog", "TheDatabase");
                builder.Add("User ID", "UserName");
                builder.Add("Password", "*******");
                builder.Add("Command Logging", false);

                // Overwrite the existing "User ID" value.
                builder.Add("User ID", "NewUserName");

                // The following code would trigger 
                // an ArgumentNullException:
                // builder.Add(null, "Some Value");

                Console.WriteLine(builder.ConnectionString);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Null key values are not allowed.");
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
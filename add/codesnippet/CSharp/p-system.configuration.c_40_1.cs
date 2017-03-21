                    ConnectionStringsSection
                        conStrSection =
                        config.ConnectionStrings as ConnectionStringsSection;
                    Console.WriteLine("Section name: {0}",
                        conStrSection.SectionInformation.SectionName);

                    try
                    {
                        if (conStrSection.ConnectionStrings.Count != 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Using ConnectionStrings property.");
                            Console.WriteLine("Connection strings:");

                            // Get the collection elements.
                            foreach (ConnectionStringSettings connection in
                              conStrSection.ConnectionStrings)
                            {
                                string name = connection.Name;
                                string provider = connection.ProviderName;
                                string connectionString = connection.ConnectionString;

                                Console.WriteLine("Name:               {0}",
                                  name);
                                Console.WriteLine("Connection string:  {0}",
                                  connectionString);
                                Console.WriteLine("Provider:            {0}",
                                   provider);
                            }
                        }
                    }
                    catch (ConfigurationErrorsException e)
                    {
                        Console.WriteLine("Using ConnectionStrings property: {0}",
                            e.ToString());
                    }
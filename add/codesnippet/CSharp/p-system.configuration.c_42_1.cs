                    try
                    {
                        AppSettingsSection appSettings =
                            config.AppSettings as AppSettingsSection;
                        Console.WriteLine("Section name: {0}",
                                appSettings.SectionInformation.SectionName);

                        // Get the AppSettings section elements.
                        Console.WriteLine();
                        Console.WriteLine("Using AppSettings property.");
                        Console.WriteLine("Application settings:");
                        // Get the KeyValueConfigurationCollection 
                        // from the configuration.
                        KeyValueConfigurationCollection settings =
                          config.AppSettings.Settings;

                        // Display each KeyValueConfigurationElement.
                        foreach (KeyValueConfigurationElement keyValueElement in settings)
                        {
                            Console.WriteLine("Key: {0}", keyValueElement.Key);
                            Console.WriteLine("Value: {0}", keyValueElement.Value);
                            Console.WriteLine();
                        }
                    }
                    catch (ConfigurationErrorsException e)
                    {
                        Console.WriteLine("Using AppSettings property: {0}",
                            e.ToString());
                    }
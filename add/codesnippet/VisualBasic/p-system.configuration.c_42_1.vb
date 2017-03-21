                    Try
                        Dim appSettings As AppSettingsSection = TryCast(config.AppSettings, AppSettingsSection)
                        Console.WriteLine("Section name: {0}", appSettings.SectionInformation.SectionName)

                        ' Get the AppSettings section elements.
                        Console.WriteLine()
                        Console.WriteLine("Using AppSettings property.")
                        Console.WriteLine("Application settings:")
                        ' Get the KeyValueConfigurationCollection 
                        ' from the configuration.
                        Dim settings As KeyValueConfigurationCollection = config.AppSettings.Settings

                        ' Display each KeyValueConfigurationElement.
                        For Each keyValueElement As KeyValueConfigurationElement In settings
                            Console.WriteLine("Key: {0}", keyValueElement.Key)
                            Console.WriteLine("Value: {0}", keyValueElement.Value)
                            Console.WriteLine()
                        Next keyValueElement
                    Catch e As ConfigurationErrorsException
                        Console.WriteLine("Using AppSettings property: {0}", e.ToString())
                    End Try
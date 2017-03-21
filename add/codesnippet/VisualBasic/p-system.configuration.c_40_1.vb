                    Dim conStrSection As ConnectionStringsSection = TryCast(config.ConnectionStrings, ConnectionStringsSection)
                    Console.WriteLine("Section name: {0}", conStrSection.SectionInformation.SectionName)

                    Try
                        If conStrSection.ConnectionStrings.Count <> 0 Then
                            Console.WriteLine()
                            Console.WriteLine("Using ConnectionStrings property.")
                            Console.WriteLine("Connection strings:")

                            ' Get the collection elements.
                            For Each connection As ConnectionStringSettings In conStrSection.ConnectionStrings
                                Dim name As String = connection.Name
                                Dim provider As String = connection.ProviderName
                                Dim connectionString As String = connection.ConnectionString

                                Console.WriteLine("Name:               {0}", name)
                                Console.WriteLine("Connection string:  {0}", connectionString)
                                Console.WriteLine("Provider:            {0}", provider)
                            Next connection
                        End If
                    Catch e As ConfigurationErrorsException
                        Console.WriteLine("Using ConnectionStrings property: {0}", e.ToString())
                    End Try
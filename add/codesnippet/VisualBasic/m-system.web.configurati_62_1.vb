                    ' Remove the URL at the 
                    ' specified index from the collection.
                    urlMappings.RemoveAt(0)

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
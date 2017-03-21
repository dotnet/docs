                    ' Remove the URL with the
                    ' specified name from the collection
                    ' (if exists).
                    urlMappings.Remove("~/home.aspx")

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
                    ' Create a new UrlMapping object.
                    urlMapping = New UrlMapping( _
                    "~/home.aspx", "~/default.aspx?parm1=1")

                    ' Add the urlMapping to 
                    ' the collection.
                    urlMappings.Add(urlMapping)

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
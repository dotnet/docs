                    ' Create a UrlMapping object.
                    urlMapping = New UrlMapping( _
                    "~/home.aspx", "~/default.aspx?parm1=1")

                    ' Remove it from the collection
                    ' (if exists).
                    urlMappings.Remove(urlMapping)

                    ' Update the configuration file.
                    If Not urlMappingSection.IsReadOnly() Then
                        configuration.Save()
                    End If
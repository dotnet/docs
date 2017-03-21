                For Each propertyItem As PropertyInformation In configSection.ElementInformation.Properties
                    ' Assign  domain name.
                    If propertyItem.Name = "domain" Then
                        propertyItem.Value = "MyDomain"
                    End If

                    If propertyItem.Value <> Nothing Then
                        ' Enable SSL for cookie exchange.
                        If propertyItem.Name = "cookieRequireSSL" Then
                            propertyItem.Value = True
                        End If

                        Dim nameValConfigElement As New NameValueConfigurationElement(propertyItem.Name.ToString(), propertyItem.Value.ToString())

                        ' Add a NameValueConfigurationElement
                        ' to the collection.

                        myNameValConfigCollection.Add(nameValConfigElement)
                    End If
                Next
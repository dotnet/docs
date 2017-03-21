                foreach (PropertyInformation propertyItem in
                  configSection.ElementInformation.Properties)
                {
                    // Assign  domain name.
                    if (propertyItem.Name == "domain")
                        propertyItem.Value = "MyDomain";

                    if (propertyItem.Value != null)
                    {
                        // Enable SSL for cookie exchange.
                        if (propertyItem.Name == "cookieRequireSSL")
                            propertyItem.Value = true;

                        NameValueConfigurationElement nameValConfigElement =
                            new NameValueConfigurationElement
                                (propertyItem.Name.ToString(), propertyItem.Value.ToString());

                        // Add a NameValueConfigurationElement
                        // to the collection.
                        myNameValConfigCollection.Add(nameValConfigElement);
                       
                    }
                }
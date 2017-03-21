                        // Get the urlMappings section.
                        UrlMappingsSection urlMappings =
                            systemWeb.UrlMappings;
                        // Read section information.
                        info =
                            urlMappings.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
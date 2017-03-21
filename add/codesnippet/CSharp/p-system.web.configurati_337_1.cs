                        // Get the protocols section.
                        DefaultSection protocols =
                            systemWeb.Protocols;
                        // Read section information.
                        info =
                            protocols.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
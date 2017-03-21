                        // Get the authentication section.
                        AuthenticationSection authentication =
                            systemWeb.Authentication;
                        // Read section information.
                        info =
                            authentication.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                          "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                          name, declared, type);
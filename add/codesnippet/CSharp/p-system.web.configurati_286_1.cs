                        // Get the authorization section.
                        AuthorizationSection authorization =
                            systemWeb.Authorization;
                        // Read section information.
                        info =
                            authorization.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
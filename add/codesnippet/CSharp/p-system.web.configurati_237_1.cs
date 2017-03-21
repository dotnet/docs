                        // Get the httpModules section.
                        HttpModulesSection httpModules =
                            systemWeb.HttpModules;
                        // Read section information.
                        info =
                            httpModules.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // Get the httpRuntime section.
                        HttpRuntimeSection httpRuntime =
                            systemWeb.HttpRuntime;
                        // Read section information.
                        info =
                            httpRuntime.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
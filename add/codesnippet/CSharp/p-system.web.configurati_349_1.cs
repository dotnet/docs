                        // Get the hostingEnvironment section.
                        HostingEnvironmentSection hostingEnvironment =
                            systemWeb.HostingEnvironment;
                        // Read section information.
                        info =
                            hostingEnvironment.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
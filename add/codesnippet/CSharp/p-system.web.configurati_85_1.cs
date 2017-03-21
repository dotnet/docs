                        // Get the webServices section.
                        WebServicesSection webServices =
                            systemWeb.WebServices;
                        // Read section information.
                        info =
                            webServices.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
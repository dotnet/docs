                        // Get the webControls section.
                        WebControlsSection webControls =
                            systemWeb.WebControls;
                        // Read section information.
                        info =
                            webControls.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
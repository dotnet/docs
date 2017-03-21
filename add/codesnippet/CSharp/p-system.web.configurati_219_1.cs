                        // Get the mobileControls section.
                        ConfigurationSection mobileControls =
                            systemWeb.MobileControls;
                        // Read section information.
                        info =
                            mobileControls.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
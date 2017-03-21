                        // Get the globalization section.
                        GlobalizationSection globalization =
                            systemWeb.Globalization;
                        // Read section information.
                        info =
                            globalization.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // Get the customerrors section.
                        CustomErrorsSection customerrors =
                            systemWeb.CustomErrors;
                        // Read section information.
                        info =
                            customerrors.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
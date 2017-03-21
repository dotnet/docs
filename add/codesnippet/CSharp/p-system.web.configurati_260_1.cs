                        // Get the clientTarget section.
                        ClientTargetSection clientTarget =
                            systemWeb.ClientTarget ;
                        // Read section information.
                        info =
                            clientTarget.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
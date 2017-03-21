                        // Get the processModel section.
                        ProcessModelSection processModel =
                            systemWeb.ProcessModel;
                        // Read section information.
                        info =
                            processModel.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
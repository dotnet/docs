                        // Get the machineKey section.
                        MachineKeySection machineKey =
                            systemWeb.MachineKey;
                        // Read section information.
                        info =
                            machineKey.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
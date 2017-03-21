                        // Get the sessionState section.
                        SessionStateSection sessionState =
                            systemWeb.SessionState;
                        // Read section information.
                        info =
                            sessionState.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // Get the trust section.
                        TrustSection trust =
                            systemWeb.Trust;
                        // Read section information.
                        info =
                            trust.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
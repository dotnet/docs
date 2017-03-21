                        // Get the securityPolicy section.
                        SecurityPolicySection securityPolicy =
                            systemWeb.SecurityPolicy;
                        // Read section information.
                        info =
                            securityPolicy.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
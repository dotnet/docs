                        // Get the roleManager section.
                        RoleManagerSection roleManager =
                            systemWeb.RoleManager;
                        // Read section information.
                        info =
                            roleManager.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
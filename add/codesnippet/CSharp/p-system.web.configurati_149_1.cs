                        // Get the profile section.
                        ProfileSection profile =
                            systemWeb.Profile;
                        // Read section information.
                        info =
                            profile.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
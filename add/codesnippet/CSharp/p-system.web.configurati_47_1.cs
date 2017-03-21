                        // Get the pages section.
                        PagesSection pages =
                            systemWeb.Pages;
                        // Read section information.
                        info =
                            pages.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
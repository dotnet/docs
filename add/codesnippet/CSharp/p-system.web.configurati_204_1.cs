                        // Get the siteMap section.
                        SiteMapSection siteMap =
                            systemWeb.SiteMap;
                        // Read section information.
                        info =
                            siteMap.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // Get the webParts section.
                        WebPartsSection webParts =
                            systemWeb.WebParts;
                        // Read section information.
                        info =
                            webParts.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
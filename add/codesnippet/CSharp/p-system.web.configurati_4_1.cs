                        // Get the xhtmlConformance section.
                        XhtmlConformanceSection xhtmlConformance =
                            systemWeb.XhtmlConformance;
                        // Read section information.
                        info =
                            xhtmlConformance.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
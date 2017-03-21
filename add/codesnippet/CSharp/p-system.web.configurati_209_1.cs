                        // Get the httpCookies section.
                        HttpCookiesSection httpCookies =
                            systemWeb.HttpCookies;
                        // Read section information.
                        info =
                            httpCookies.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
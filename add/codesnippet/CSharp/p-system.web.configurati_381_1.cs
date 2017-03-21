                        // Get the membership section.
                        MembershipSection membership =
                            systemWeb.Membership;
                        // Read section information.
                        info =
                            membership.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
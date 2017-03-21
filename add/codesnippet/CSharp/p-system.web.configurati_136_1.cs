                        // Get the deployment section.
                        DeploymentSection deployment =
                            systemWeb.Deployment;
                        // Read section information.
                        info =
                            deployment.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
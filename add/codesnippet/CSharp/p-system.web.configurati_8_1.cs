
                        // Get the .<sqlCacheDependency> section
                        SqlCacheDependencySection sqlCacheDependency =
                            cachingSectionGroup.SqlCacheDependency;

                        // Display one of its attributes.
                        msg = String.Format(
                        "Sql cache dependency enabled: {0}\n",
                        sqlCacheDependency.Enabled.ToString());

                        Console.Write(msg);


                        // Get the .<outputCache> section
                        OutputCacheSection outputCache =
                            cachingSectionGroup.OutputCache;

                        // Display one of its properties.
                        msg = String.Format(
                        "Enable output cache: {0}\n",
                        outputCache.EnableOutputCache.ToString());

                        Console.Write(msg);

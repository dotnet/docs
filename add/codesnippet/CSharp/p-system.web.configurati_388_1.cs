
                        // Get the <cache> section.
                        CacheSection cache =
                            cachingSectionGroup.Cache;
                       
                        // Display one of its properties.
                        msg = String.Format(
                        "Cache disable expiration: {0}\n",
                        cache.DisableExpiration);

                        Console.Write(msg);

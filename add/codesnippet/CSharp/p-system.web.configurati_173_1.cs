
                        // Get the .<outputCacheSettings> section
                        OutputCacheSettingsSection outputCacheSettings=
                            cachingSectionGroup.OutputCacheSettings;

                        // Display the number of existing 
                        // profiles.
                        int profilesCount = 
                            outputCacheSettings.OutputCacheProfiles.Count;
                        msg = String.Format(
                        "Number of profiles: {0}\n",
                        profilesCount.ToString());

                        Console.Write(msg);

        // Show how to use LockAttributes.
        // It locks and unlocks all the urls elements.
        static void LockAttributes()
        {

            try
            {
                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;

                if (myUrlsSection == null)
                    Console.WriteLine("Failed to load UrlsSection.");
                else
                {

                    IEnumerator elemEnum =
                         myUrlsSection.Urls.GetEnumerator();

                    int i = 0;
                    while (elemEnum.MoveNext())
                    {

                        // Get the current element.
                        ConfigurationElement element =
                            myUrlsSection.Urls[i];

                        // Get the lock attributes collection of 
                        // the current element.
                        ConfigurationLockCollection lockAttributes =
                            element.LockAttributes;

                        // Add or remove the lock on the attributes.
                        if (lockAttributes.Contains("name"))
                            lockAttributes.Remove("name");
                        else
                            lockAttributes.Add("name");

                        if (lockAttributes.Contains("url"))
                            lockAttributes.Remove("url");
                        else
                            lockAttributes.Add("url");

                        if (lockAttributes.Contains("port"))
                            lockAttributes.Remove("port");
                        else
                            lockAttributes.Add("port");


                        // Get the locket attributes.
                        string lockedAttributes =
                            lockAttributes.AttributeList;

                        Console.WriteLine(
                            "Element {0} Locked attributes list: {1}",
                            i.ToString(), lockedAttributes);

                        i += 1;

                        config.Save(ConfigurationSaveMode.Full);

                    }

                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[LockAttributes: {0}]",
                    e.ToString());
            }

        }
        // Show how to use LockAllAttributesExcept.
        // It locks and unlocks all urls elements 
        // except the port.
        static void LockAllAttributesExcept()
        {

            try
            {
                // Get current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;

                if (myUrlsSection == null)
                    Console.WriteLine(
                        "Failed to load UrlsSection.");
                else
                {

                    IEnumerator elemEnum =
                         myUrlsSection.Urls.GetEnumerator();

                    int i = 0;
                    while (elemEnum.MoveNext())
                    {

                        // Get current element.
                        ConfigurationElement element =
                            myUrlsSection.Urls[i];

                        // Get current element lock all attributes.
                        ConfigurationLockCollection lockAllAttributesExcept =
                            element.LockAllAttributesExcept;

                        // Add or remove the lock on all attributes 
                        // except port.
                        if (lockAllAttributesExcept.Contains("port"))
                            lockAllAttributesExcept.Remove("port");
                        else
                            lockAllAttributesExcept.Add("port");


                        string lockedAttributes =
                            lockAllAttributesExcept.AttributeList;

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
                Console.WriteLine(
                    "[LockAllAttributesExcept: {0}]",
                    e.ToString());
            }

        }
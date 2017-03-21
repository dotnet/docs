        // Show how to use LockElements
        // It locks and unlocks the urls element.
        static void LockElements()
        {

            try
            {
                // Get the configuration file.
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
                    // Get MyUrls section LockElements collection.
                    ConfigurationLockCollection lockElements =
                        myUrlsSection.LockElements;

                    // Get MyUrls section LockElements collection 
                    // enumerator.
                    IEnumerator lockElementEnum =
                         lockElements.GetEnumerator();

                    // Position the collection index.
                    lockElementEnum.MoveNext();

                    if (lockElements.Contains("urls"))
                        // Remove the lock on the urls element.
                        lockElements.Remove("urls");
                    else
                        // Add the lock on the urls element.
                        lockElements.Add("urls");

                    // Save the change.
                    config.Save(ConfigurationSaveMode.Full);

                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[LockElements: {0}]",
                    err.ToString());
            }
        }

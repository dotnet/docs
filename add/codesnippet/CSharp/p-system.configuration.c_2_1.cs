        // Show how to use LockAllElementsExcept.
        // It locks and unlocks all the MyUrls elements 
        // except urls.
        static void LockAllElementsExcept()
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
                    ConfigurationLockCollection lockElementsExcept =
                        myUrlsSection.LockAllElementsExcept;

                    // Get MyUrls section LockElements collection 
                    // enumerator.
                    IEnumerator lockElementEnum =
                         lockElementsExcept.GetEnumerator();

                    // Position the collection index.
                    lockElementEnum.MoveNext();

                    if (lockElementsExcept.Contains("urls"))
                        // Remove the lock on all the ther elements.
                        lockElementsExcept.Remove("urls");
                    else
                        // Add the lock on all the other elements 
                        // but urls element.
                        lockElementsExcept.Add("urls");


                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[LockAllElementsExcept: {0}]",
                    err.ToString());
            }
        }
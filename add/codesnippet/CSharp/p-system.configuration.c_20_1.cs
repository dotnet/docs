        // Show how to set LockItem
        // It adds a new UrlConfigElement to 
        // the collection.
        static void LockItem()
        {
            string name = "Contoso";
            string url = "http://www.contoso.com/";
            int port = 8080;

            try
            {
                // Get the current configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrls =
                   config.Sections["MyUrls"] as UrlsSection;


                // Create the new  element.
                UrlConfigElement newElement =
                    new UrlConfigElement(name, url, port);

                // Set its lock.
                newElement.LockItem = true;

                // Save the new element to the 
                // configuration file.
                if (!myUrls.ElementInformation.IsLocked)
                {

                    myUrls.Urls.Add(newElement);

                    config.Save(ConfigurationSaveMode.Full);

                    // This is used to obsolete the cached 
                    // section and read the updated 
                    // bersion from the configuration file.
                    ConfigurationManager.RefreshSection("MyUrls");
                }
                else
                    Console.WriteLine(
                        "Section was locked, could not update.");

            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[LockItem: {0}]",
                    e.ToString());
            }

        }
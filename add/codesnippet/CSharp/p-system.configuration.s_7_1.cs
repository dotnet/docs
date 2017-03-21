        // Create a section whose name is 
        // MyUrls that contains a nested collection as 
        // defined by the UrlsSection class.
        static void CreateSection()
        {
            string sectionName = "MyUrls";

            try
            {

                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                UrlsSection urlsSection;

                // Create the section whose name attribute 
                // is MyUrls in <configSections>.
                // Also, create the related target section 
                // MyUrls in <configuration>.
                if (config.Sections[sectionName] == null)
                {
                    urlsSection = new UrlsSection();

                    // Change the default values of 
                    // the simple element.
                    urlsSection.Simple.Name = "Contoso";
                    urlsSection.Simple.Url = "http://www.contoso.com";
                    urlsSection.Simple.Port = 8080;

                    config.Sections.Add(sectionName, urlsSection);
                    urlsSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[CreateSection: {0}]",
                    e.ToString());
            }


        }
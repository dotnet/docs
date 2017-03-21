        static public SectionInformation 
            GetSectionInformation()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            
            SectionInformation sInfo = 
                section.SectionInformation;

            return sInfo;

        }
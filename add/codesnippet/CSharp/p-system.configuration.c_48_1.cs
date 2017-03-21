        static public ElementInformation
            GetElementInformation()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");

            // Get the element.
            UrlConfigElement url = section.Simple;

            ElementInformation eInfo =
                url.ElementInformation;

            return eInfo;

        }
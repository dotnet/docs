        static public void IsElementLocked()
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

            bool isLocked =
                url.ElementInformation.IsLocked;
            Console.WriteLine("Url element is locked? {0}",
                isLocked.ToString());

        }
        static public void IsElementPresent()
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

            bool isPresent =
                url.ElementInformation.IsPresent;
            Console.WriteLine("Url element is present? {0}",
                isPresent.ToString());


        }
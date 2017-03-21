        static public void GetElementType()
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

            // Get the element type.
            Type elType =
                url.ElementInformation.Type;

            Console.WriteLine("Url element type: {0}",
                            elType.ToString());

        }
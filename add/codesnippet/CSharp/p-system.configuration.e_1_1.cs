        static public void GetElementSource()
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

            // Get the element source file.
            string sourceFile =
                url.ElementInformation.Source;

            Console.WriteLine("Url element source file: {0}",
                            sourceFile);
            
        }
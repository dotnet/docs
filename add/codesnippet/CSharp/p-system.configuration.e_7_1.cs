        static public void GetElementLineNumber()
        {
            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            // Get the section.
            UrlsSection section = 
                (UrlsSection)config.GetSection("MyUrls");

            // Get the collection element.
            UrlsCollection urls = section.Urls;

            int ln =
                urls.ElementInformation.LineNumber;
            Console.WriteLine("Urls element line number: {0}",
                ln.ToString());

        }
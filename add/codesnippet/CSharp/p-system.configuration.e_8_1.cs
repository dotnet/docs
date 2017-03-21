        static public void IsElementCollection()
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

            // Get the collection element.
            UrlsCollection urls = section.Urls;

            bool isCollection =
                url.ElementInformation.IsCollection;
            Console.WriteLine("Url element is a collection? {0}",
                isCollection.ToString());

            isCollection =
               urls.ElementInformation.IsCollection;
            Console.WriteLine("Urls element is a collection? {0}",
                isCollection.ToString());
          
        }
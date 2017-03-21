        static public void GetElementErrors()
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

            // Get the errors.
            ICollection errors = 
                url.ElementInformation.Errors;
            Console.WriteLine("Number of errors: {0)",
                errors.Count.ToString());
            
        }
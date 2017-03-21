        static public void GetElementValidator()
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
            ConfigurationValidatorBase elValidator =
                url.ElementInformation.Validator;

            Console.WriteLine("Url element validator: {0}",
                            elValidator.ToString());

        }
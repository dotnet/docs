        static public void GetElementProperties()
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

            // Get the element properties.
            PropertyInformationCollection properties =
                url.ElementInformation.Properties;

            foreach (PropertyInformation prop in properties)
            {
                Console.WriteLine(
                    "Name: {0} Type: {1}", prop.Name,
                    prop.Type.ToString());
            }
           
        }
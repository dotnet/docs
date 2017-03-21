        // Show how to use IsReadOnly.
        // It loops to see if the elements are read only. 
        static void ReadOnlyElements()
        {
            try
            {
                // Get the configuration file.
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

                // Get the MyUrls section.
                UrlsSection myUrlsSection =
                    config.GetSection("MyUrls") as UrlsSection;


                UrlsCollection elements = myUrlsSection.Urls;


                IEnumerator elemEnum =
                    elements.GetEnumerator();

                int i = 0;
                Console.WriteLine(elements.Count.ToString());

                while (elemEnum.MoveNext())
                {
                    Console.WriteLine("The element {0} is read only: {1}",
                     elements[i].Name,
                     elements[i].IsReadOnly().ToString());
                    i += 1;
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[ReadOnlyElements: {0}]",
                    err.ToString());
            }

        }
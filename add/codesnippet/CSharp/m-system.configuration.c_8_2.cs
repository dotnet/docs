        // Show how to use IsModified.
        // This method modifies the port property
        // of the url element named Microsoft and
        // saves the modification to the configuration
        // file. This in turn will cause the overriden
        // UrlConfigElement.IsModified() mathod to be called. 
        static void ModifyElement()
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
                while (elemEnum.MoveNext())
                {
                    if (elements[i].Name == "Microsoft")
                    {
                        elements[i].Port = 1010;
                        bool readOnly = elements[i].IsReadOnly();
                        break;
                    }
                    i += 1;
                }

                if (!myUrlsSection.ElementInformation.IsLocked)
                {

                    config.Save(ConfigurationSaveMode.Full);

                    // This to obsolete the MyUrls cached 
                    // section and read the updated version
                    // from the configuration file.
                    ConfigurationManager.RefreshSection("MyUrls");
                }
                else
                    Console.WriteLine(
                        "Section was locked, could not update.");
            }

            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("[ModifyElement: {0}]",
                    err.ToString());
            }

        }

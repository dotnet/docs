        static public void UnProtectSection()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);


            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");


            // Unprotect (decrypt)the section.
            section.SectionInformation.UnprotectSection();

            // Force the section information to be written to
            // the configuration file.
            section.SectionInformation.ForceDeclaration(true);

            // Save the decrypted section.
            section.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Full);

            // Display the decrypted configuration 
            // section. 
            string sectionXml =
                section.SectionInformation.GetRawXml();

            Console.WriteLine("Decrypted section:");
            Console.WriteLine(sectionXml);

        }
        static public void ProtectSection()
        {

            // Get the current configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);


            // Get the section.
            UrlsSection section =
                (UrlsSection)config.GetSection("MyUrls");


            // Protect (encrypt)the section.
            section.SectionInformation.ProtectSection(
                "RsaProtectedConfigurationProvider");

            // Save the encrypted section.
            section.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Full);

            // Display decrypted configuration 
            // section. Note, the system
            // uses the Rsa provider to decrypt
            // the section transparently.
            string sectionXml =
                section.SectionInformation.GetRawXml();

            Console.WriteLine("Decrypted section:");
            Console.WriteLine(sectionXml);

        }
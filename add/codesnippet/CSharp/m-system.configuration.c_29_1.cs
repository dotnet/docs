        static void Remove()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                CustomSection customSection =
                    config.GetSection(
                    "CustomSection") as CustomSection;


                if (customSection != null)
                {
                    config.Sections.Remove("CustomSection");
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
                else
                    Console.WriteLine(
                        "CustomSection does not exists.");

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
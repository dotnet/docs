        static void AddSection()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                CustomSection customSection =
                    new CustomSection();


                string index =
                    config.Sections.Count.ToString();

                customSection.FileName =
                    "newFile" + index + ".txt";

                string sectionName = "CustomSection" + index;

                TimeSpan ts = new TimeSpan(0, 15, 0);
                customSection.MaxIdleTime = ts;
                customSection.MaxUsers = 100;

                config.Sections.Add(sectionName, customSection);
                customSection.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
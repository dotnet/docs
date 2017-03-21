        static void GetItems()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionCollection sections =
                    config.Sections;


                ConfigurationSection section1 =
                    sections["runtime"];

                ConfigurationSection section2 =
                    sections[0];

                Console.WriteLine(
                     "Section1: {0}", section1.SectionInformation.Name);

                Console.WriteLine(
                    "Section2: {0}", section2.SectionInformation.Name);

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

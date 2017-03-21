        static public void GetParentSection()
        {
            SectionInformation sInfo = 
                GetSectionInformation();

            ConfigurationSection parentSection =
                sInfo.GetParentSection();

            Console.WriteLine("Parent section : {0}",
                parentSection.SectionInformation.Name);

        }
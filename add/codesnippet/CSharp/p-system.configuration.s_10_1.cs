        static public void GetSectionName()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionName = sInfo.SectionName;
            Console.WriteLine("Section type: {0}", sectionName);

        }
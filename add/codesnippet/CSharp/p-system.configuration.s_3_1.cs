        static public void GetSectionType()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionType = sInfo.Type;
            Console.WriteLine("Section type: {0}", sectionType);

        }
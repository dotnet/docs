        static public void GetSectionXml()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionXml =
                sInfo.GetRawXml();

            Console.WriteLine("Section xml:");
            Console.WriteLine(sectionXml);

        }
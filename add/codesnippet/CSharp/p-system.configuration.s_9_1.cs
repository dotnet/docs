        static public void GetSectionNameProperty()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            string sectionNameProperty = sInfo.Name;
            Console.WriteLine("Section name: {0}", 
                sectionNameProperty);

        }
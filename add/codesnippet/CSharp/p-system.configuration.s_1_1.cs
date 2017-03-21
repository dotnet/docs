        static public void RestartOnExternalChanges()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            bool restartOnChange = 
                sInfo.RestartOnExternalChanges;
            Console.WriteLine("Section type: {0}", 
                restartOnChange.ToString());

        }
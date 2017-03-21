        static public void GetInheritInChildApps()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            bool inheritInChildApps =
                sInfo.InheritInChildApplications;
            Console.WriteLine("Inherit in child apps: {0}",
                inheritInChildApps.ToString());

        }
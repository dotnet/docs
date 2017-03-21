        static public void GetProtectionProvider()
        {
            SectionInformation sInfo =
                GetSectionInformation();

            ProtectedConfigurationProvider pp = 
                sInfo.ProtectionProvider;
            if (pp == null)
                Console.WriteLine("Protection provider is null");
            else
                Console.WriteLine("Protection provider: {0}", 
                    pp.ToString());

        }
        // Display elements of the TrustLevels collection property.
        for (int i = 0; i < configSection.TrustLevels.Count; i++) 
        {
          Console.WriteLine();
          Console.WriteLine("TrustLevel {0}:", i);
          Console.WriteLine("Name: {0}", 
            configSection.TrustLevels.Get(i).Name);
          Console.WriteLine("Type: {0}", 
            configSection.TrustLevels.Get(i).PolicyFile);
        }

        // Add a TrustLevel element to the configuration file.
        configSection.TrustLevels.Add(new TrustLevel("myTrust", "mytrust.config"));
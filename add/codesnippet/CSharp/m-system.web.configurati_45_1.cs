        // Display item details of the collection.
        for (int i = 0; i < TrustLevelCollection1.Count; i++)
        {
          Console.WriteLine("Collection item {0}", i);
          Console.WriteLine("Name: {0}", 
            TrustLevelCollection1.Get(i).Name);
          Console.WriteLine("PolicyFile: {0}", 
            TrustLevelCollection1.Get(i).PolicyFile);
          Console.WriteLine();
        }
        // Get all current Namespaces in the collection.
        for (int i = 0; i < pagesSection.Namespaces.Count; i++)
        {
          Console.WriteLine(
              "Namespaces {0}: '{1}'", i,
              pagesSection.Namespaces[i].Namespace);
        }
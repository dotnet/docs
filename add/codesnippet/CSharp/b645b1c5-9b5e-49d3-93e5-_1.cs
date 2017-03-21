      // Get Import by Index.
      Import myImport = myServiceDescription.Imports[myServiceDescription.Imports.Count-1];
      Console.WriteLine("Import by Index...");
      if (myImportCollection.Contains(myImport))
      {
         Console.WriteLine("Import Namespace '"
                  + myImport.Namespace + "' is found in 'ImportCollection'.");
         Console.WriteLine("Index of '" + myImport.Namespace + "' in 'ImportCollection' = "
                                                   + myImportCollection.IndexOf(myImport));
         Console.WriteLine("Deleting Import from 'ImportCollection'...");
         myImportCollection.Remove(myImport);
         if(myImportCollection.IndexOf(myImport) == -1)
            Console.WriteLine("Import is successfully removed from Import Collection.");
      }
      // Get Import Collection.
      ImportCollection myImportCollection = myServiceDescription.Imports;
      Console.WriteLine("Total Imports in the document = " + myServiceDescription.Imports.Count);
      // Print 'Import' properties to console.
      for(int i =0; i < myImportCollection.Count; ++i)
         Console.WriteLine("\tImport Namespace :{0} Import Location :{1} "
                                       ,myImportCollection[i].Namespace
                                       ,myImportCollection[i].Location);
      ' Get Import by Index.
      Dim myImport As Import = _
            myServiceDescription.Imports(myServiceDescription.Imports.Count - 1)
      Console.WriteLine("Import by Index...")
      If myImportCollection.Contains(myImport) Then
         Console.WriteLine("Import Namespace '" + myImport.Namespace + _
                           "' is found in 'ImportCollection'.")
         Console.WriteLine("Index of '" + myImport.Namespace + _
                           "' in 'ImportCollection' = " + _
                           myImportCollection.IndexOf(myImport).ToString())
         Console.WriteLine("Delete Import from 'ImportCollection'...")
         myImportCollection.Remove(myImport)
         If myImportCollection.IndexOf(myImport) = - 1 Then
            Console.WriteLine("Import is successfully removed from Import Collection.")
         End If
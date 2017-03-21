      ' Get Import Collection.
      Dim myImportCollection As ImportCollection = myServiceDescription.Imports
      Console.WriteLine("Total Imports in the document = " + _
                        myServiceDescription.Imports.Count.ToString())
      ' Print 'Import' properties to console.
      Dim i As Integer
      For i = 0 To myImportCollection.Count - 1
         Console.WriteLine(ControlChars.Tab + _
                           "Import Namespace :{0} Import Location :{1} ", _
                           myImportCollection(i).Namespace, _
                           myImportCollection(i).Location)
      Next i
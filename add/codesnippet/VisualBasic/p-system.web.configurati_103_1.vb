        ' Get all current Namespaces in the collection.
        Dim i As Int16
        For i = 0 To pagesSection.Namespaces.Count - 1
          Console.WriteLine( _
           "Namespaces {0}: '{1}'", i, _
           pagesSection.Namespaces(i).Namespace)
        Next
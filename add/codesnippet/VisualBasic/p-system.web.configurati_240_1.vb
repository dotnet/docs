        ' Get the AutoImportVBNamespace property.
        Console.WriteLine( _
         "AutoImportVBNamespace: '{0}'", _
         pagesSection.Namespaces.AutoImportVBNamespace)

        ' Set the AutoImportVBNamespace property.
        pagesSection.Namespaces.AutoImportVBNamespace = True

        ' Get all current Namespaces in the collection.
        Dim i As Int16
        For i = 0 To pagesSection.Namespaces.Count - 1
          Console.WriteLine( _
           "Namespaces {0}: '{1}'", i, _
           pagesSection.Namespaces(i).Namespace)
        Next

        ' Create a new NamespaceInfo object.
        Dim namespaceInfo As System.Web.Configuration.NamespaceInfo = _
         New System.Web.Configuration.NamespaceInfo("System")

        ' Set the Namespace property.
        namespaceInfo.Namespace = "System.Collections"

        ' Execute the Add Method.
        pagesSection.Namespaces.Add(namespaceInfo)

        ' Add a NamespaceInfo object using a constructor.
        pagesSection.Namespaces.Add( _
         New System.Web.Configuration.NamespaceInfo( _
         "System.Collections.Specialized"))

        ' Execute the RemoveAt method.
        pagesSection.Namespaces.RemoveAt(0)

        ' Execute the Clear method.
        pagesSection.Namespaces.Clear()

        ' Execute the Remove method.
        pagesSection.Namespaces.Remove("System.Collections")

        ' Get the current AutoImportVBNamespace property value.
        Console.WriteLine( _
         "Current AutoImportVBNamespace value: '{0}'", _
         pagesSection.Namespaces.AutoImportVBNamespace)

        ' Set the AutoImportVBNamespace property to false.
        pagesSection.Namespaces.AutoImportVBNamespace = False
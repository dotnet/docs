        ' Create a new NamespaceInfo object.
        Dim namespaceInfo As System.Web.Configuration.NamespaceInfo = _
         New System.Web.Configuration.NamespaceInfo("System")

        ' Set the Namespace property.
        namespaceInfo.Namespace = "System.Collections"

        ' Execute the Add Method.
        pagesSection.Namespaces.Add(namespaceInfo)
        // Create a new NamespaceInfo object.
        System.Web.Configuration.NamespaceInfo namespaceInfo =
            new System.Web.Configuration.NamespaceInfo("System");

        // Set the Namespace property.
        namespaceInfo.Namespace = "System.Collections";

        // Execute the Add Method.
        pagesSection.Namespaces.Add(namespaceInfo);
        // Get the AutoImportVBNamespace property.
        Console.WriteLine("AutoImportVBNamespace: '{0}'",
            pagesSection.Namespaces.AutoImportVBNamespace.ToString());

        // Set the AutoImportVBNamespace property.
        pagesSection.Namespaces.AutoImportVBNamespace = true;
 
        // Get all current Namespaces in the collection.
        for (int i = 0; i < pagesSection.Namespaces.Count; i++)
        {
          Console.WriteLine(
              "Namespaces {0}: '{1}'", i,
              pagesSection.Namespaces[i].Namespace);
        }

        // Create a new NamespaceInfo object.
        System.Web.Configuration.NamespaceInfo namespaceInfo =
            new System.Web.Configuration.NamespaceInfo("System");

        // Set the Namespace property.
        namespaceInfo.Namespace = "System.Collections";

        // Execute the Add Method.
        pagesSection.Namespaces.Add(namespaceInfo);

        // Add a NamespaceInfo object using a constructor.
        pagesSection.Namespaces.Add(
            new System.Web.Configuration.NamespaceInfo(
            "System.Collections.Specialized"));

        // Execute the RemoveAt method.
        pagesSection.Namespaces.RemoveAt(0);

        // Execute the Clear method.
        pagesSection.Namespaces.Clear();

        // Execute the Remove method.
        pagesSection.Namespaces.Remove("System.Collections");

        // Get the current AutoImportVBNamespace property value.
        Console.WriteLine(
            "Current AutoImportVBNamespace value: '{0}'",
            pagesSection.Namespaces.AutoImportVBNamespace);

        // Set the AutoImportVBNamespace property to false.
        pagesSection.Namespaces.AutoImportVBNamespace = false;
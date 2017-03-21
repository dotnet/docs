            dim namespaceManager as New XmlNamespaceManager(xmlDoc.NameTable)

            Dim productsNodeList As XmlNodeList
            productsNodeList = xmlDoc.SelectNodes("//.", namespaceManager)

            xmlTransform.LoadInput(productsNodeList)
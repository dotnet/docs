            XmlNamespaceManager namespaceManager;
            namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);

            XmlNodeList productsNodeList;
            productsNodeList = xmlDoc.SelectNodes("//.", namespaceManager);

            xmlTransform.LoadInput(productsNodeList);
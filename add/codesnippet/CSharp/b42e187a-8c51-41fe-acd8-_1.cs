        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        XPathNavigator node = navigator.SelectSingleNode("//bk:title", manager);
        Console.WriteLine(node.InnerXml);
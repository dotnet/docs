        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim node As XPathNavigator = navigator.SelectSingleNode("//bk:title", manager)
        Console.WriteLine(node.InnerXml)
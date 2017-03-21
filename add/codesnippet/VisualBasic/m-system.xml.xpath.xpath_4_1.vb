        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim childNodes As XmlDocument = New XmlDocument()
        childNodes.Load(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))
        Dim childNodesNavigator As XPathNavigator = childNodes.CreateNavigator()

        navigator.InsertAfter(childNodesNavigator)

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
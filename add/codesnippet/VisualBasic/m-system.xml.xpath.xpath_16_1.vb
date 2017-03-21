        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim pages As XmlReader = XmlReader.Create(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))

        navigator.ReplaceSelf(pages)

        Console.WriteLine("Position after delete: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
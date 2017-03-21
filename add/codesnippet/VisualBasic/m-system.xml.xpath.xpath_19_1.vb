        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim pages As XmlReader = XmlReader.Create(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))

        navigator.PrependChild(pages)

        Console.WriteLine(navigator.OuterXml)
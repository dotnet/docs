        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim writer As XmlWriter = XmlWriter.Create("contosoBook.xml")
        navigator.WriteSubtree(writer)

        writer.Close()
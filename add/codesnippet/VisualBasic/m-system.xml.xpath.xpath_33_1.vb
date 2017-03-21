        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim reader As XmlReader = navigator.ReadSubtree()

        While reader.Read()
            Console.WriteLine(reader.ReadInnerXml())
        End While

        reader.Close()
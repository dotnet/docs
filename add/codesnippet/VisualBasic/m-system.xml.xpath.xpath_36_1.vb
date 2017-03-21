        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim pages As XmlWriter = navigator.InsertAfter()
        pages.WriteElementString("pages", "100")
        pages.Close()

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
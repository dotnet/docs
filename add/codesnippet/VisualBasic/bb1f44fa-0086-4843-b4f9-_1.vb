        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim total As Double = CType(navigator.Evaluate("sum(descendant::bk:book/bk:price)", manager), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())

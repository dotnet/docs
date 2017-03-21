        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim query As XPathExpression = navigator.Compile("sum(descendant::book/price)")

        Dim total As Double = CType(navigator.Evaluate(query), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())

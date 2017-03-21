        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim total As Double = CType(navigator.Evaluate("sum(descendant::book/price)"), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())

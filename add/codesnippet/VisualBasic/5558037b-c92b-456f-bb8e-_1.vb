        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim nodes As XPathNodeIterator = navigator.Select("//book")
        Dim query As XPathExpression = nodes.Current.Compile("sum(descendant::price)")

        Dim total As Double = CType(navigator.Evaluate(query, nodes), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())
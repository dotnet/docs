        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim nodes As XPathNodeIterator = navigator.Select("/bookstore/book")
        nodes.MoveNext()
        Dim nodesNavigator As XPathNavigator = nodes.Current

        Dim nodesText As XPathNodeIterator = nodesNavigator.SelectDescendants(XPathNodeType.Text, False)

        While nodesText.MoveNext()
            Console.WriteLine(nodesText.Current.Value)
        End While
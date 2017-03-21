        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim nodes As XPathNodeIterator = navigator.Select("/bk:bookstore/bk:book/bk:price", manager)
        ' Move to the first node bk:price node.
        If (nodes.MoveNext()) Then
            ' Now nodes.Current points to the first selected node.
            Dim nodesNavigator As XPathNavigator = nodes.Current

            ' Select all the descendants of the current price node.
            Dim nodesText As XPathNodeIterator = nodesNavigator.SelectDescendants(XPathNodeType.Text, False)

            While nodesText.MoveNext()
                Console.WriteLine(nodesText.Current.Value)
            End While
        End If
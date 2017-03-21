        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim query As XPathExpression = navigator.Compile("//title")

        Dim node As XPathNavigator = navigator.SelectSingleNode(query)
        Console.WriteLine(node.InnerXml)
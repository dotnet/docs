        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim node As XPathNavigator = navigator.SelectSingleNode("//title")
        Console.WriteLine(node.InnerXml)
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing("price", "http://www.contoso.com/books")
        Dim boundary As XPathNavigator = navigator.Clone()

        navigator.MoveToRoot()

        While navigator.MoveToFollowing(XPathNodeType.Text, boundary)
            Console.WriteLine(navigator.OuterXml)
        End While
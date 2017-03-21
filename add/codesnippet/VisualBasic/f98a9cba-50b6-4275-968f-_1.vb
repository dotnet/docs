        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing(XPathNodeType.Element)

        Console.WriteLine("Position: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
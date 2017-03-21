        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing("price", "http://www.contoso.com/books")

        Console.WriteLine("Position: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
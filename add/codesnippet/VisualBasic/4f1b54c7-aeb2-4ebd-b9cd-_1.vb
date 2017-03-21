        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing("book", "http://www.contoso.com/books")
        Dim boundary As XPathNavigator = navigator.Clone()
        boundary.MoveToFollowing("first-name", "http://www.contoso.com/books")

        navigator.MoveToFollowing("price", "http://www.contoso.com/books", boundary)

        Console.WriteLine("Position (after boundary): {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)

        navigator.MoveToFollowing("title", "http://www.contoso.com/books", boundary)

        Console.WriteLine("Position (before boundary): {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
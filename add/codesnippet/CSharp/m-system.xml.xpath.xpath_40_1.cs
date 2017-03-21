        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToFollowing("price", "http://www.contoso.com/books");

        Console.WriteLine("Position: {0}", navigator.Name);
        Console.WriteLine(navigator.OuterXml);
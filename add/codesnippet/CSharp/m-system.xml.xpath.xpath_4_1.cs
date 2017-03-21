        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlDocument childNodes = new XmlDocument();
        childNodes.Load(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator childNodesNavigator = childNodes.CreateNavigator();

        navigator.InsertAfter(childNodesNavigator);

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
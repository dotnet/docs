        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlReader pages = XmlReader.Create(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator.InsertAfter(pages);

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        navigator.AppendChildElement(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100");

        Console.WriteLine(navigator.OuterXml);
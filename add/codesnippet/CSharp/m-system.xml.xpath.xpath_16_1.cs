        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlReader pages = XmlReader.Create(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator.ReplaceSelf(pages);

        Console.WriteLine("Position after delete: {0}", navigator.Name);
        Console.WriteLine(navigator.OuterXml);
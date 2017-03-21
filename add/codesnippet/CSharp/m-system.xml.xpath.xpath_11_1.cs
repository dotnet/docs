        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlWriter pages = navigator.AppendChild();
        pages.WriteElementString("pages", "100");
        pages.Close();

        Console.WriteLine(navigator.OuterXml);
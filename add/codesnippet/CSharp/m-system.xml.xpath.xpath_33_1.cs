        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlReader reader = navigator.ReadSubtree();

        while (reader.Read())
        {
            Console.WriteLine(reader.ReadInnerXml());
        }

        reader.Close();
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        Double total = (double)navigator.Evaluate("sum(descendant::bk:book/bk:price)", manager);
        Console.WriteLine("Total price for all books: {0}", total.ToString());
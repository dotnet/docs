        XPathDocument readOnlyDocument = new XPathDocument("books.xml");
        XPathNavigator readOnlyNavigator = readOnlyDocument.CreateNavigator();

        XmlDocument editableDocument = new XmlDocument();
        editableDocument.Load("books.xml");
        XPathNavigator editableNavigator = editableDocument.CreateNavigator();

        Console.WriteLine("XPathNavigator.CanEdit from XPathDocument: {0}", readOnlyNavigator.CanEdit);
        Console.WriteLine("XPathNavigator.CanEdit from XmlDocument: {0}", editableNavigator.CanEdit);
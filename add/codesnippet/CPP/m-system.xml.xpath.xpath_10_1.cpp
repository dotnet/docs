        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");

        XmlDocument^ childNodes = gcnew XmlDocument();
        childNodes->Load(gcnew StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator^ childNodesNavigator = childNodes->CreateNavigator();

        navigator->PrependChild(childNodesNavigator);

        Console::WriteLine(navigator->OuterXml);
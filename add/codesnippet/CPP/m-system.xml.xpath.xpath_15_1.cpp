        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");
        navigator->MoveToChild("price", "http://www.contoso.com/books");

        XmlDocument^ childNodes = gcnew XmlDocument();
        childNodes->Load(gcnew StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator^ childNodesNavigator = childNodes->CreateNavigator();

        navigator->ReplaceSelf(childNodesNavigator);

        Console::WriteLine("Position after delete: {0}", navigator->Name);
        Console::WriteLine(navigator->OuterXml);
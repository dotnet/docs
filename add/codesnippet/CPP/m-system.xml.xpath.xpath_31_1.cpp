        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");
        navigator->MoveToChild("price", "http://www.contoso.com/books");

        navigator->DeleteSelf();

        Console::WriteLine("Position after delete: {0}", navigator->Name);
        Console::WriteLine(navigator->OuterXml);
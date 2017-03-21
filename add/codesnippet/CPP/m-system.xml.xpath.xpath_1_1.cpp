        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");
        navigator->MoveToChild("price", "http://www.contoso.com/books");

        XmlWriter^ attributes = navigator->CreateAttributes();

        attributes->WriteAttributeString("discount", "1.00");
        attributes->WriteAttributeString("currency", "USD");
        attributes->Close();

        navigator->MoveToParent();
        Console::WriteLine(navigator->OuterXml);
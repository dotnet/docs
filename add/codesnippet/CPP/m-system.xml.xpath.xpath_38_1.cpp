        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");
        navigator->MoveToChild("price", "http://www.contoso.com/books");

        XmlWriter^ pages = navigator->InsertBefore();
        pages->WriteElementString("pages", "100");
        pages->Close();

        navigator->MoveToParent();
        Console::WriteLine(navigator->OuterXml);
        XPathDocument^ document = gcnew XPathDocument("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToFollowing("book", "http://www.contoso.com/books");
        XPathNavigator^ boundary = navigator->Clone();
        boundary->MoveToFollowing("first-name", "http://www.contoso.com/books");

        navigator->MoveToFollowing("price", "http://www.contoso.com/books", boundary);

        Console::WriteLine("Position (after boundary): {0}", navigator->Name);
        Console::WriteLine(navigator->OuterXml);

        navigator->MoveToFollowing("title", "http://www.contoso.com/books", boundary);

        Console::WriteLine("Position (before boundary): {0}", navigator->Name);
        Console::WriteLine(navigator->OuterXml);
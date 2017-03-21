        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XmlNamespaceManager^ manager = gcnew XmlNamespaceManager(document->NameTable);
        manager->AddNamespace("bk", "http://www.contoso.com/books");

        XPathNavigator^ first = navigator->SelectSingleNode("/bk:bookstore/bk:book[1]", manager);
        XPathNavigator^ last = navigator->SelectSingleNode("/bk:bookstore/bk:book[2]", manager);

        navigator->MoveTo(first);
        navigator->DeleteRange(last);
        Console::WriteLine(navigator->OuterXml);
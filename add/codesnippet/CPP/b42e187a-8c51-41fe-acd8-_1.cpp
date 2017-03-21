        XPathDocument^ document = gcnew XPathDocument("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XmlNamespaceManager^ manager = gcnew XmlNamespaceManager(navigator->NameTable);
        manager->AddNamespace("bk", "http://www.contoso.com/books");

        XPathNavigator^ node = navigator->SelectSingleNode("//bk:title", manager);
        Console::WriteLine(node->InnerXml);
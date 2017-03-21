        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XmlNamespaceManager^ manager = gcnew XmlNamespaceManager(navigator->NameTable);
        manager->AddNamespace("bk", "http://www.contoso.com/books");

        for each (XPathNavigator^ nav in navigator->Select("//bk:price", manager))
        {
            if(nav->Value == "11.99")
            {
                nav->SetValue("12.99");
            }
        }

        Console::WriteLine(navigator->OuterXml);
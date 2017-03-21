        XPathDocument^ document = gcnew XPathDocument("books.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XPathNavigator^ node = navigator->SelectSingleNode("//title");
        Console::WriteLine(node->InnerXml);
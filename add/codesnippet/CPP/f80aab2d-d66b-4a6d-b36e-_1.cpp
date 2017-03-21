        XPathDocument^ document = gcnew XPathDocument("books.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XPathExpression^ query = navigator->Compile("//title");

        XPathNavigator^ node = navigator->SelectSingleNode(query);
        Console::WriteLine(node->InnerXml);
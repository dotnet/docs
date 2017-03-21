        XPathDocument^ document = gcnew XPathDocument("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

	navigator->MoveToFollowing(XPathNodeType::Element);

        Console::WriteLine("Position: {0}", navigator->Name);
        Console::WriteLine(navigator->OuterXml);
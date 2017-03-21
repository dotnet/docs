        XPathDocument^ document = gcnew XPathDocument("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToFollowing("price", "http://www.contoso.com/books");
        XPathNavigator^ boundary = navigator->Clone();

        navigator->MoveToRoot();

	while (navigator->MoveToFollowing(XPathNodeType::Text, boundary))
        {
            Console::WriteLine(navigator->OuterXml);
        }
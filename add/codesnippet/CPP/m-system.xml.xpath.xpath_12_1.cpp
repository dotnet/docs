        XPathDocument^ document = gcnew XPathDocument("books.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XPathExpression^ query = navigator->Compile("/bookstore/book");
        XPathNodeIterator^ nodes = navigator->Select(query);
        XPathNavigator^ nodesNavigator = nodes->Current;

		XPathNodeIterator^ nodesText = nodesNavigator->SelectDescendants(XPathNodeType::Text, false);

        while (nodesText->MoveNext())
        {
            Console::WriteLine(nodesText->Current->Value);
        }
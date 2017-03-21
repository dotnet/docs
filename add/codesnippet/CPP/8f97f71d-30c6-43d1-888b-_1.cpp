        XPathDocument^ document = gcnew XPathDocument("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XmlNamespaceManager^ manager = gcnew XmlNamespaceManager(navigator->NameTable);
        manager->AddNamespace("bk", "http://www.contoso.com/books");

        XPathNodeIterator^ nodes = navigator->Select("/bk:bookstore/bk:book/bk:price", manager);
        // Move to the first node bk:price node.
        if(nodes->MoveNext())
        {
            // Now nodes.Current points to the first selected node.
  	    XPathNavigator^ nodesNavigator = nodes->Current;

            // Select all the descendants of the current price node.
	    XPathNodeIterator^ nodesText = nodesNavigator->SelectDescendants(XPathNodeType::Text, false);

            while(nodesText->MoveNext())
            {
		Console::WriteLine(nodesText->Current->Value);
            }
        }
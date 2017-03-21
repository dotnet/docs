        XPathDocument^ document = gcnew XPathDocument("books.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        // Select all book nodes.
        XPathNodeIterator^ nodes = navigator->SelectDescendants("book", "", false);

        // Select all book nodes that have the matching attribute value.
        XPathExpression^ expr = navigator->Compile("book[@genre='novel']");
        while (nodes->MoveNext())
        {
            XPathNavigator^ navigator2 = nodes->Current->Clone();
            if (navigator2->Matches(expr))
            {
                navigator2->MoveToFirstChild();
                Console::WriteLine("Book title:  {0}", navigator2->Value);
            }
        }
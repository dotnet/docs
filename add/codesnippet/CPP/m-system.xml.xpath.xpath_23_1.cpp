        XPathDocument^ document = gcnew XPathDocument("books.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        // Select all book nodes and display all attributes on each book.
        XPathNodeIterator^ nodes = navigator->SelectDescendants("book", "", false);
        while (nodes->MoveNext())
        {
            XPathNavigator^ navigator2 = nodes->Current->Clone();
            navigator2->MoveToFirstAttribute();
            Console::WriteLine("{0} = {1}", navigator2->Name, navigator2->Value);

            while (navigator2->MoveToNextAttribute())
            {
                Console::WriteLine("{0} = {1}", navigator2->Name, navigator2->Value);
            }
      
            Console::WriteLine();
        }
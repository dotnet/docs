        XPathDocument^ document = gcnew XPathDocument("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");

        // Select all the descendant nodes of the book node.
        XPathNodeIterator^ bookDescendants = navigator->SelectDescendants("", "http://www.contoso.com/books", false);

        // Display the LocalName of each descendant node.
        Console::WriteLine("Descendant nodes of the book node:");
        while (bookDescendants->MoveNext())
        {
            Console::WriteLine(bookDescendants->Current->Name);
        }

        // Select all the child nodes of the book node.
        XPathNodeIterator^ bookChildren = navigator->SelectChildren("", "http://www.contoso.com/books");

        // Display the LocalName of each child node.
        Console::WriteLine("\nChild nodes of the book node:");
        while (bookChildren->MoveNext())
        {
            Console::WriteLine(bookChildren->Current->Name);
        }

        // Select all the ancestor nodes of the title node.
        navigator->MoveToChild("title", "http://www.contoso.com/books");
        
        XPathNodeIterator^ bookAncestors = navigator->SelectAncestors("", "http://www.contoso.com/books", false);

        // Display the LocalName of each ancestor node.
        Console::WriteLine("\nAncestor nodes of the title node:");

        while (bookAncestors->MoveNext())
        {
            Console::WriteLine(bookAncestors->Current->Name);
        }
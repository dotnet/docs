        XPathDocument^ document = gcnew XPathDocument("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");

	XmlWriter^ writer = XmlWriter::Create("contosoBook.xml");
        navigator->WriteSubtree(writer);

        writer->Close();
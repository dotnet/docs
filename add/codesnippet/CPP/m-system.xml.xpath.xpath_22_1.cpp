        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        XmlNamespaceManager^ manager = gcnew XmlNamespaceManager(document->NameTable);
        manager->AddNamespace("bk", "http://www.contoso.com/books");

        XPathNavigator^ first = navigator->SelectSingleNode("/bk:bookstore/bk:book[1]", manager);
        XPathNavigator^ last = navigator->SelectSingleNode("/bk:bookstore/bk:book[2]", manager);

        navigator->MoveTo(first);
        XmlWriter^ newRange = navigator->ReplaceRange(last);
        newRange->WriteStartElement("book");
            newRange->WriteAttributeString("genre", "");
            newRange->WriteAttributeString("publicationdate", "2005-04-07");
            newRange->WriteAttributeString("ISBN", "0");
            newRange->WriteStartElement("title");
                newRange->WriteString("New Book");
            newRange->WriteEndElement();
            newRange->WriteStartElement("author");
                newRange->WriteStartElement("first-name");
                    newRange->WriteString("First Name");
                newRange->WriteEndElement();
                newRange->WriteStartElement("last-name");
                    newRange->WriteString("Last Name");
                newRange->WriteEndElement();
            newRange->WriteEndElement();
            newRange->WriteElementString("price", "$0.00");
        newRange->WriteEndElement();
        newRange->Close();
        Console::WriteLine(navigator->OuterXml);
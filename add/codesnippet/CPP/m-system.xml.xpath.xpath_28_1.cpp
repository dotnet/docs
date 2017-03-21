        XmlReaderSettings^ settings = gcnew XmlReaderSettings();
        settings->Schemas->Add("http://www.contoso.com/books", "contosoBooks.xsd");
		settings->ValidationType = ValidationType::Schema;

        XmlReader^ reader = XmlReader::Create("contosoBooks.xml", settings);
        XmlDocument^ document = gcnew XmlDocument();
        document->Load(reader);

        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");
        navigator->MoveToChild("price", "http://www.contoso.com/books");

        Decimal^ price = gcnew Decimal(19.99);
        navigator->SetTypedValue(price);

        navigator->MoveToParent();
        Console::WriteLine(navigator->OuterXml);
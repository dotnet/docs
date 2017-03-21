        // Create an XmlReaderSettings object with the contosoBooks.xsd schema.
        XmlReaderSettings^ settings = gcnew XmlReaderSettings();
        settings->Schemas->Add("http://www.contoso.com/books", "contosoBooks.xsd");
		settings->ValidationType = ValidationType::Schema;

        // Create an XmlReader object with the contosoBooks.xml file and its schema.
		XmlReader^ reader = XmlReader::Create("contosoBooks.xml", settings);

        XPathDocument^ document = gcnew XPathDocument(reader);
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");
        navigator->MoveToChild("price", "http://www.contoso.com/books");

        // Display the current type of the price element.
		Console::WriteLine(navigator->ValueType);

        // Get the value of the price element as a string and display it.
		String^ price = dynamic_cast<String^>(navigator->ValueAs(String::typeid));
		Console::WriteLine(price);
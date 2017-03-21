        XPathDocument^ document = gcnew XPathDocument("books.xml");
        XPathNavigator^ navigator = document->CreateNavigator();
		Hashtable^ table = gcnew Hashtable(XPathNavigator::NavigatorComparer);

        // Add nodes to the Hashtable.
        for each (XPathNavigator^ navigator2 in navigator->Select("//book"))
        {
            Object^ value = navigator2->Evaluate("string(./title)");
            table->Add(navigator2->Clone(), value);
			Console::WriteLine("Added book with title {0}", value);
        }

		Console::WriteLine(table->Count);
        Console::WriteLine("Does the Hashtable have the book \"The Confidence Man\"?");
        Console::WriteLine(table->Contains(navigator->SelectSingleNode("//book[title='The Confidence Man']")));
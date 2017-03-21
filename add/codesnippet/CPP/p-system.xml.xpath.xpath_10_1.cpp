        XPathDocument^ document = gcnew XPathDocument("valueas.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        // ValueAsBoolean
        navigator->MoveToChild("root", "");
        navigator->MoveToChild("booleanElement", "");
        bool^ booleanValue = navigator->ValueAsBoolean;
		Console::WriteLine(navigator->LocalName + ": " + booleanValue);

        // ValueAsDateTime
        navigator->MoveToNext("dateTimeElement", "");
        DateTime^ dateTimeValue = navigator->ValueAsDateTime;
		Console::WriteLine(navigator->LocalName + ": " + dateTimeValue);

        // ValueAsDouble, ValueAsInt32, ValueAsInt64, ValueAsSingle
        navigator->MoveToNext("numberElement", "");
        Double doubleValue = navigator->ValueAsDouble;
        Int32 int32Value = navigator->ValueAsInt;
        Int64 int64Value = navigator->ValueAsLong;
        Console::WriteLine(navigator->LocalName + ": " + doubleValue);
        Console::WriteLine(navigator->LocalName + ": " + int32Value);
        Console::WriteLine(navigator->LocalName + ": " + int64Value);
        for each(KeyValuePair<String^, String^> kvp in myDictionary)
        {
            Console::WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
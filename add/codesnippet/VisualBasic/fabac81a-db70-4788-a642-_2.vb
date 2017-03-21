        ' When you use foreach to enumerate dictionary elements
        ' with the IDictionary interface, the elements are retrieved
        ' as DictionaryEntry objects instead of KeyValuePair objects.
        Console.WriteLine()
        For Each de As DictionaryEntry In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                de.Key, de.Value)
        Next 
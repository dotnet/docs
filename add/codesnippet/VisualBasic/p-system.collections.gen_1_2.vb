        ' When you use foreach to enumerate dictionary elements,
        ' the elements are retrieved as KeyValuePair objects.
        Console.WriteLine()
        For Each kvp As KeyValuePair(Of String, String) In openWith
            Console.WriteLine("Key = {0}, Value = {1}", _
                kvp.Key, kvp.Value)
        Next kvp
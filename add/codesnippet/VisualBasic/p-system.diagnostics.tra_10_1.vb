        ' Get the custom attributes for the TraceSource.
        Console.WriteLine("Number of custom trace source attributes = " + ts.Attributes.Count)
        Dim de As DictionaryEntry
        For Each de In ts.Attributes
            Console.WriteLine("Custom trace source attribute = " + de.Key + "  " + de.Value)
        Next de
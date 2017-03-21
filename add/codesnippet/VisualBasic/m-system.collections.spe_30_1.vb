        ' Clear the OrderedDictionary and add new values
        myOrderedDictionary.Clear()
        myOrderedDictionary.Add("newKey1", "newValue1")
        myOrderedDictionary.Add("newKey2", "newValue2")
        myOrderedDictionary.Add("newKey3", "newValue3")

        ' Display the contents of the "new" Dictionary Imports an enumerator
        Dim myEnumerator As IDictionaryEnumerator = _
            myOrderedDictionary.GetEnumerator()

        Console.WriteLine( _
            "{0}Displaying the entries of a 'new' OrderedDictionary.", _
            Environment.NewLine)

        DisplayEnumerator(myEnumerator)
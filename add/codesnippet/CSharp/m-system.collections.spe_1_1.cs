        // Clear the OrderedDictionary and add new values
        myOrderedDictionary.Clear();
        myOrderedDictionary.Add("newKey1", "newValue1");
        myOrderedDictionary.Add("newKey2", "newValue2");
        myOrderedDictionary.Add("newKey3", "newValue3");

        // Display the contents of the "new" Dictionary using an enumerator
        IDictionaryEnumerator myEnumerator =
            myOrderedDictionary.GetEnumerator();

        Console.WriteLine(
            "{0}Displaying the entries of a \"new\" OrderedDictionary.",
            Environment.NewLine);

        DisplayEnumerator(myEnumerator);
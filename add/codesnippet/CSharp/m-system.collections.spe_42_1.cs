        // Creates and initializes a OrderedDictionary.
        OrderedDictionary myOrderedDictionary = new OrderedDictionary();
        myOrderedDictionary.Add("testKey1", "testValue1");
        myOrderedDictionary.Add("testKey2", "testValue2");
        myOrderedDictionary.Add("keyToDelete", "valueToDelete");
        myOrderedDictionary.Add("testKey3", "testValue3");

        ICollection keyCollection = myOrderedDictionary.Keys;
        ICollection valueCollection = myOrderedDictionary.Values;

        // Display the contents using the key and value collections
        DisplayContents(keyCollection, valueCollection, myOrderedDictionary.Count);
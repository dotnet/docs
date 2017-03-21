        // Modifying the OrderedDictionary
        if (!myOrderedDictionary.IsReadOnly)
        {
            // Insert a new key to the beginning of the OrderedDictionary
            myOrderedDictionary.Insert(0, "insertedKey1", "insertedValue1");

            // Modify the value of the entry with the key "testKey2"
            myOrderedDictionary["testKey2"] = "modifiedValue";

            // Remove the last entry from the OrderedDictionary: "testKey3"
            myOrderedDictionary.RemoveAt(myOrderedDictionary.Count - 1);

            // Remove the "keyToDelete" entry, if it exists
            if (myOrderedDictionary.Contains("keyToDelete"))
            {
                myOrderedDictionary.Remove("keyToDelete");
            }
        }
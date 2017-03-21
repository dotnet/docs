        ' Creates and initializes a OrderedDictionary.
        Dim myOrderedDictionary As New OrderedDictionary()
        myOrderedDictionary.Add("testKey1", "testValue1")
        myOrderedDictionary.Add("testKey2", "testValue2")
        myOrderedDictionary.Add("keyToDelete", "valueToDelete")
        myOrderedDictionary.Add("testKey3", "testValue3")

        Dim keyCollection As ICollection = myOrderedDictionary.Keys
        Dim valueCollection As ICollection = myOrderedDictionary.Values

        ' Display the contents Imports the key and value collections
        DisplayContents( _
            keyCollection, valueCollection, myOrderedDictionary.Count)
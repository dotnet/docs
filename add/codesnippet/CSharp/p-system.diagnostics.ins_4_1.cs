    // Display the contents of an InstanceDataCollection.
    public static void ProcessInstanceDataCollection(InstanceDataCollection idCol)
    {

        ICollection idColKeys = idCol.Keys;
        string[] idColKeysArray = new string[idColKeys.Count];
        idColKeys.CopyTo(idColKeysArray, 0);

        ICollection idColValues = idCol.Values;
        InstanceData[] idColValuesArray = new InstanceData[idColValues.Count];
        idColValues.CopyTo(idColValuesArray, 0);

        Console.WriteLine("  InstanceDataCollection for \"{0}\" " +
            "has {1} elements.", idCol.CounterName, idCol.Count);

        // Display the InstanceDataCollection Keys and Values.
        // The Keys and Values collections have the same number of elements.
        int index;
        for(index=0; index<idColKeysArray.Length; index++)
        {
            Console.WriteLine("    Next InstanceDataCollection " +
                "Key is \"{0}\"", idColKeysArray[index]);
            ProcessInstanceDataObject(idColValuesArray[index]);
        }
    }
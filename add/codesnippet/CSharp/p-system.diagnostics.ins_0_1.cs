
        // Process the InstanceDataCollectionCollection for this category.
        PerformanceCounterCategory pcc = new PerformanceCounterCategory(categoryName);
        InstanceDataCollectionCollection idColCol = pcc.ReadCategory();

        ICollection idColColKeys = idColCol.Keys;
        string[] idCCKeysArray = new string[idColColKeys.Count];
        idColColKeys.CopyTo(idCCKeysArray, 0);

        ICollection idColColValues = idColCol.Values;
        InstanceDataCollection[] idCCValuesArray = new InstanceDataCollection[idColColValues.Count];
        idColColValues.CopyTo(idCCValuesArray, 0);

        Console.WriteLine("InstanceDataCollectionCollection for \"{0}\" " +
            "has {1} elements.", categoryName, idColCol.Count);

        // Display the InstanceDataCollectionCollection Keys and Values.
        // The Keys and Values collections have the same number of elements.
        int index;
        for(index=0; index<idCCKeysArray.Length; index++)
        {
            Console.WriteLine("  Next InstanceDataCollectionCollection " +
                "Key is \"{0}\"", idCCKeysArray[index]);
            ProcessInstanceDataCollection(idCCValuesArray[index]);
        }
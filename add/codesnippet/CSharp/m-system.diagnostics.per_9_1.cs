
        // Process the InstanceDataCollectionCollection for this category.
        PerformanceCounterCategory pcc = new PerformanceCounterCategory(categoryName);
        InstanceDataCollectionCollection idColCol = pcc.ReadCategory();
        InstanceDataCollection[] idColArray = new InstanceDataCollection[idColCol.Count];

        Console.WriteLine("InstanceDataCollectionCollection for \"{0}\" " +
            "has {1} elements.", categoryName, idColCol.Count);
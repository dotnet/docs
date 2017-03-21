        StringDictionary myCollection = new StringDictionary();
        lock(myCollection.SyncRoot)
        {
            foreach (Object item in myCollection)
            {
                // Insert your code here.
            }
        }
        SortedList myCollection = new SortedList();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
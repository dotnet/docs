        Hashtable myCollection = new Hashtable();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
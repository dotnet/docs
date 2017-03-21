        Queue myCollection = new Queue();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
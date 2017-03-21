        Stack myCollection = new Stack();

        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
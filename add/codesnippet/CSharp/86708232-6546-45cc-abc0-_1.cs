        ICollection myCollection = new ShortStringDictionary();
        lock(myCollection.SyncRoot)
        {
            foreach (Object item in myCollection)
            {
                // Insert your code here.
            }
        }
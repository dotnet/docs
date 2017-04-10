
using System;
using System.Collections;
using System.Collections.Specialized;

public class HybridDictSample
{
    public static void Main()
    {
        // Creates and initializes a new HybridDictionary.
        HybridDictionary myHybridDictionary = new HybridDictionary();

        // <snippet2>
        foreach (DictionaryEntry de in myHybridDictionary)
        {
            //...
        }
        // </snippet2>

        // <snippet3>
        HybridDictionary myCollection = new HybridDictionary();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </snippet3>
    }
}

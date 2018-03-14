
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesListDictionary
{
    public static void Main()
    {
        // <Snippet2>
        ListDictionary myCollection = new ListDictionary();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }

    public static void Dummy()
    {
        ListDictionary myListDictionary = new ListDictionary();
        // <Snippet3>
        foreach (DictionaryEntry de in myListDictionary)
        {
            //...
        }
        // </Snippet3>
    }
}



using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringDictionary
{
    public static void Main()
    {
        // <Snippet2>
        StringDictionary myCollection = new StringDictionary();
        lock(myCollection.SyncRoot)
        {
            foreach (Object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }
}


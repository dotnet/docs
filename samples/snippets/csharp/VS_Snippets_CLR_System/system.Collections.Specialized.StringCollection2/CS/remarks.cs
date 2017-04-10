
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringCollection
{
    public static void Main()
    {
        // <Snippet2>
        StringCollection myCollection = new StringCollection();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }
}

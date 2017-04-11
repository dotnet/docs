using System;
using System.Collections;

public class SamplesHashtable
{
    public static void Main()
    {
        // <Snippet2>
        Hashtable myCollection = new Hashtable();
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


using System;
using System.Collections;

public class SamplesQueue
{
    public static void Main()
    {
        // <Snippet2>
        Queue myCollection = new Queue();
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


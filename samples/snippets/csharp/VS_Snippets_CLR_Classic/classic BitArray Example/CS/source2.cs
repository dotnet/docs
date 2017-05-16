using System;
using System.Collections;

public class SamplesLocker
{
    public static void Main()
    {

        // <Snippet2>
        BitArray myCollection = new BitArray(64, true);
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




using System;
using System.Collections;

public class SamplesStack
{
    public static void Main()
    {
        // <Snippet2>
        Stack myCollection = new Stack();

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


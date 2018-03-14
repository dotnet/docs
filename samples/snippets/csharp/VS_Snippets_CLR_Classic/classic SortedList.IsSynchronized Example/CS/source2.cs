using System;
using System.Collections;

public class SamplesSortedList
{
    public static void Main()
    {
        // <Snippet2>
        SortedList myCollection = new SortedList();
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


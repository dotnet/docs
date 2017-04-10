using System;
using System.Collections;


public class Remarks
{
    public static void Main()
    {
        ArrayList someCollection = new ArrayList(5);
        // <Snippet1>
        ICollection myCollection = someCollection;
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet1>
    }

    public static void Dummy()
    {
        ArrayList someCollection = new ArrayList(5);
        // <Snippet2>
        ICollection myCollection = someCollection;
        lock(myCollection.SyncRoot)
        {
            // Some operation on the collection, which is now thread safe.
        }
        // </Snippet2>
    }
}





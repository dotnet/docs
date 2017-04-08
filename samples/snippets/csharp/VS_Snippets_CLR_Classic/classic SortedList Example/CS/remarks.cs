using System;
using System.Collections;

public class SamplesSortedList
{
    public static void Main()
    {
        // Creates and initializes a new SortedList.
        SortedList mySortedList = new SortedList();
        mySortedList.Add("Third", "!");
        mySortedList.Add("Second", "World");
        mySortedList.Add("First", "Hello");

        // <Snippet2>
        foreach (DictionaryEntry de in mySortedList)
        {
            //...
        }
        // </Snippet2>
    }
}


using System;
using System.Collections;
using System.Collections.Specialized;

public class OrderedDictionarySample
{
    public static void Main()
    {
        OrderedDictionary myOrderedDictionary = new OrderedDictionary();
        // <Snippet06>
        foreach (DictionaryEntry de in myOrderedDictionary)
        {
            //...
        }
        // </Snippet06>
    }
}


using System;
using System.Collections;

public class SimpleDictionary : DictionaryBase
{
}

public class DictionaySamples
{
    public static void Main()
    {
        // Create a dictionary that contains no more than three entries.
        IDictionary myDictionary = new SimpleDictionary();

        // Add three people and their ages to the dictionary.
        myDictionary.Add("Jeff", 40);
        myDictionary.Add("Kristin", 34);
        myDictionary.Add("Aidan", 1);
        // Display every entry's key and value.
        foreach (DictionaryEntry de in myDictionary)
        {
            Console.WriteLine("{0} is {1} years old.", de.Key, de.Value);
        }

        // Remove an entry that exists.
        myDictionary.Remove("Jeff");

        // Remove an entry that does not exist, but do not throw an exception.
        myDictionary.Remove("Max");

        // <Snippet14>
        foreach (DictionaryEntry de in myDictionary)
        {
            //...
        }
        // </Snippet14>
    }
}

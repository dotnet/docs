//Types:System.Collections.DictionaryEntry  Vendor: Richter
//Types:System.Collections.IDictionary  Vendor: Richter
//Types:System.Collections.IDictionaryEnumerator  Vendor: Richter
//<snippet1>
using System;
using System.Collections;

//<snippet2>
// This class implements a simple dictionary using an array of DictionaryEntry objects (key/value pairs).
public class SimpleDictionary : IDictionary
{
    // The array of items
    private DictionaryEntry[] items;
    private Int32 ItemsInUse = 0;

    // Construct the SimpleDictionary with the desired number of items.
    // The number of items cannot change for the life time of this SimpleDictionary.
    public SimpleDictionary(Int32 numItems)
    {
        items = new DictionaryEntry[numItems];
    }


    #region IDictionary Members
    //<snippet4>
    public bool IsReadOnly { get { return false; } }
    //</snippet4>
    //<snippet5>	
    public bool Contains(object key)
    {
       Int32 index;
       return TryGetIndexOfKey(key, out index);
    }
    //</snippet5>
    //<snippet6>		
    public bool IsFixedSize { get { return false; } }
    //</snippet6>
    //<snippet7>	
    public void Remove(object key)
    {
        if (key == null) throw new ArgumentNullException("key");
        // Try to find the key in the DictionaryEntry array
        Int32 index;
        if (TryGetIndexOfKey(key, out index))
        {
            // If the key is found, slide all the items up.
            Array.Copy(items, index + 1, items, index, ItemsInUse - index - 1);
            ItemsInUse--;
        } 
        else
        {
            // If the key is not in the dictionary, just return. 
        }
    }
    //</snippet7>
    //<snippet8>		
    public void Clear() { ItemsInUse = 0; }
    //</snippet8>
    //<snippet9>	
    public void Add(object key, object value) 
    {
        // Add the new key/value pair even if this key already exists in the dictionary.
        if (ItemsInUse == items.Length)
            throw new InvalidOperationException("The dictionary cannot hold any more items.");
        items[ItemsInUse++] = new DictionaryEntry(key, value);
    }
    //</snippet9>
    //<snippet10>	
    public ICollection Keys
    {
        get
        {
            // Return an array where each item is a key.
            Object[] keys = new Object[ItemsInUse];
            for (Int32 n = 0; n < ItemsInUse; n++)
                keys[n] = items[n].Key;
            return keys;
        }
    }
    //</snippet10>
    //<snippet11>  
    public ICollection Values
    {
        get
        {
            // Return an array where each item is a value.
            Object[] values = new Object[ItemsInUse];
            for (Int32 n = 0; n < ItemsInUse; n++)
                values[n] = items[n].Value;
            return values;
        }
    }
    //</snippet11>
    //<snippet13>
    public object this[object key]
    {
        get
        {   
            // If this key is in the dictionary, return its value.
            Int32 index;
            if (TryGetIndexOfKey(key, out index))
            {
                // The key was found; return its value.
                return items[index].Value;
            } 
            else
            {
                // The key was not found; return null.
                return null;
            }
        }

        set
        {
            // If this key is in the dictionary, change its value. 
            Int32 index;
            if (TryGetIndexOfKey(key, out index))
            {
                // The key was found; change its value.
                items[index].Value = value;
            } 
            else
            {
                // This key is not in the dictionary; add this key/value pair.
                Add(key, value);
            }
        }
    }
    //</snippet13>
    private Boolean TryGetIndexOfKey(Object key, out Int32 index)
    {
        for (index = 0; index < ItemsInUse; index++)
        {
            // If the key is found, return true (the index is also returned).
            if (items[index].Key.Equals(key)) return true;
        }
      
        // Key not found, return false (index should be ignored by the caller).
        return false;
    }
//<snippet3>
    private class SimpleDictionaryEnumerator : IDictionaryEnumerator
    {
        // A copy of the SimpleDictionary object's key/value pairs.
        DictionaryEntry[] items;
        Int32 index = -1;

        public SimpleDictionaryEnumerator(SimpleDictionary sd)
        {
            // Make a copy of the dictionary entries currently in the SimpleDictionary object.
            items = new DictionaryEntry[sd.Count];
            Array.Copy(sd.items, 0, items, 0, sd.Count);
        }

        // Return the current item.
        public Object Current { get { ValidateIndex(); return items[index]; } }

        // Return the current dictionary entry.
        public DictionaryEntry Entry
        {
            get { return (DictionaryEntry) Current; }
        }

        // Return the key of the current item.
        public Object Key { get { ValidateIndex();  return items[index].Key; } }

        // Return the value of the current item.
        public Object Value { get { ValidateIndex();  return items[index].Value; } }

        // Advance to the next item.
        public Boolean MoveNext()
        {
            if (index < items.Length - 1) { index++; return true; }
            return false;
        }

        // Validate the enumeration index and throw an exception if the index is out of range.
        private void ValidateIndex()
        {
            if (index < 0 || index >= items.Length)
            throw new InvalidOperationException("Enumerator is before or after the collection.");
        }

        // Reset the index to restart the enumeration.
        public void Reset()
        {
            index = -1;
        }
    }
    //<snippet12>
    public IDictionaryEnumerator GetEnumerator()
    {
        // Construct and return an enumerator.
        return new SimpleDictionaryEnumerator(this);
    }
    //</snippet12>
    #endregion

    #region ICollection Members
    public bool IsSynchronized { get { return false; } }
    public object SyncRoot { get { throw new NotImplementedException(); } }
    public int Count { get { return ItemsInUse; } }
    public void CopyTo(Array array, int index) { throw new NotImplementedException(); }
    #endregion

    #region IEnumerable Members
    IEnumerator IEnumerable.GetEnumerator() 
    {
        // Construct and return an enumerator.
        return ((IDictionary)this).GetEnumerator();
    }
    #endregion
}
//</snippet3>
//</snippet2>

public sealed class App
{
    static void Main()
    {
        // Create a dictionary that contains no more than three entries.
        IDictionary d = new SimpleDictionary(3);

        // Add three people and their ages to the dictionary.
        d.Add("Jeff", 40);
        d.Add("Kristin", 34);
        d.Add("Aidan", 1);

        Console.WriteLine("Number of elements in dictionary = {0}", d.Count);

        Console.WriteLine("Does dictionary contain 'Jeff'? {0}", d.Contains("Jeff"));
        Console.WriteLine("Jeff's age is {0}", d["Jeff"]);

        // Display every entry's key and value.
        foreach (DictionaryEntry de in d)
        {
            Console.WriteLine("{0} is {1} years old.", de.Key, de.Value);
        }

        // Remove an entry that exists.
        d.Remove("Jeff");

        // Remove an entry that does not exist, but do not throw an exception.
        d.Remove("Max");

        // Show the names (keys) of the people in the dictionary.
        foreach (String s in d.Keys)
            Console.WriteLine(s);

        // Show the ages (values) of the people in the dictionary.
        foreach (Int32 age in d.Values)
            Console.WriteLine(age);
    }
}

// This code produces the following output.
//
// Number of elements in dictionary = 3
// Does dictionary contain 'Jeff'? True
// Jeff's age is 40
// Jeff is 40 years old.
// Kristin is 34 years old.
// Aidan is 1 years old.
// Kristin
// Aidan
// 34
// 1
//</snippet1>
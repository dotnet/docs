using System;
using System.Collections;
using System.Collections.Specialized;

public class SimpleOD : IOrderedDictionary
{
    private ArrayList itemlist;

    public SimpleOD(int numItems)
    {
        itemlist = new ArrayList(numItems);
    }

    public int IndexOfKey(object key)
    {
        for (int i = 0; i < itemlist.Count; i++)
        {
            if (((DictionaryEntry)itemlist[i]).Key == key)
                return i;
        }

        // key not found, reutrn -1.
        return -1;
    }

    public object this[object key]
    {
        get
        {
            return ((DictionaryEntry)itemlist[IndexOfKey(key)]).Value;
        }
        set
        {
            itemlist[IndexOfKey(key)] = new DictionaryEntry(key, value);
        }
    }

    // IOrderedDictionary Members
    public IDictionaryEnumerator GetEnumerator()
    {
        return new ODEnum(itemlist);
    }

    public void Insert(int index, object key, object value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw new ArgumentException("An element with the same key already exists in the collection.");
        }
        itemlist.Insert(index, new DictionaryEntry(key, value));
    }

    public void RemoveAt(int index)
    {
        itemlist.RemoveAt(index);
    }

    public object this[int index]
    {
        get
        {
            return ((DictionaryEntry)itemlist[index]).Value;
        }
        set
        {
            object key = ((DictionaryEntry)itemlist[index]).Key;
            itemlist[index] = new DictionaryEntry(Keys, value);
        }
    }
    // IDictionary Members

    public void Add(object key, object value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw new ArgumentException("An element with the same key already exists in the collection.");
        }
        itemlist.Add(new DictionaryEntry(key, value));
    }

    public void Clear()
    {
        itemlist.Clear();
    }

    public bool Contains(object key)
    {
        if (IndexOfKey(key) == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsFixedSize
    {
        get
        {
            return false;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public ICollection Keys
    {
        get
        {
            ArrayList KeyCollection = new ArrayList(itemlist.Count);
            for (int i = 0; i < itemlist.Count; i++)
            {
                KeyCollection[i] = ((DictionaryEntry)itemlist[i]).Key;
            }
            return KeyCollection;
        }
    }

    public void Remove(object key)
    {
        itemlist.RemoveAt(IndexOfKey(key));
    }

    public ICollection Values
    {
        get
        {
            ArrayList ValueCollection = new ArrayList(itemlist.Count);
            for (int i = 0; i < itemlist.Count; i++)
            {
                ValueCollection[i] = ((DictionaryEntry)itemlist[i]).Value;
            }
            return ValueCollection;
        }
    }


    // ICollection Members

    public void CopyTo(Array array, int index)
    {
        itemlist.CopyTo(array, index);
    }

    public int Count
    {
        get
        {
            return itemlist.Count;
        }
    }

    public bool IsSynchronized
    {
        get
        {
            return itemlist.IsSynchronized;
        }
    }

    public object SyncRoot
    {
        get
        {
            return itemlist.SyncRoot;
        }
    }

    // IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ODEnum(itemlist);
    }
}

public class ODEnum : IDictionaryEnumerator
{
    public ArrayList itemlist;
    
    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public ODEnum(ArrayList list)
    {
        itemlist = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < itemlist.Count);
    }

    public void Reset()
    {
        position = -1;
    }

    public object Current
    {
        get
        {
            try
            {
                return itemlist[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public DictionaryEntry Entry
    {
        get
        {
            return (DictionaryEntry)Current;
        }
    }

    public object Key
    {
        get
        {
            try
            {
                return ((DictionaryEntry)itemlist[position]).Key;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public object Value
    {
        get
        {
            try
            {
                return ((DictionaryEntry)itemlist[position]).Value;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

class App
{
    static void Main()
    {
        int index = 1;

        SimpleOD myOrderedDictionary = new SimpleOD(2);
        myOrderedDictionary.Add("Way", "ToGo");
        myOrderedDictionary.Add("Far", "Out");

        object obj;
        //<snippet04>
        obj = myOrderedDictionary[index];
        //</snippet04>
        //<snippet03>
        foreach (DictionaryEntry de in myOrderedDictionary)
        {
            //...
        }
        //</snippet03>
    }
}

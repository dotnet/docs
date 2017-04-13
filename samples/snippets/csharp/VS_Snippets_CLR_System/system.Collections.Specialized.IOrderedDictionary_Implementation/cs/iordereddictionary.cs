//<snippet00>
using System;
using System.Collections;
using System.Collections.Specialized;

//<snippet01>
public class People : IOrderedDictionary
{
    private ArrayList _people;

    public People(int numItems)
    {
        _people = new ArrayList(numItems);
    }

    public int IndexOfKey(object key)
    {
        for (int i = 0; i < _people.Count; i++)
        {
            if (((DictionaryEntry)_people[i]).Key == key)
                return i;
        }

        // key not found, reutrn -1.
        return -1;
    }

    public object this[object key]
    {
        get
        {
            return ((DictionaryEntry)_people[IndexOfKey(key)]).Value;
        }
        set
        {
            _people[IndexOfKey(key)] = new DictionaryEntry(key, value);
        }
    }

    // IOrderedDictionary Members
    public IDictionaryEnumerator GetEnumerator()
    {
        return new PeopleEnum(_people);
    }

    public void Insert(int index, object key, object value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw new ArgumentException("An element with the same key already exists in the collection.");
        }
        _people.Insert(index, new DictionaryEntry(key, value));
    }

    public void RemoveAt(int index)
    {
        _people.RemoveAt(index);
    }

    public object this[int index]
    {
        get
        {
            return ((DictionaryEntry)_people[index]).Value;
        }
        set
        {
            object key = ((DictionaryEntry)_people[index]).Key;
            _people[index] = new DictionaryEntry(Keys, value);
        }
    }
    // IDictionary Members

    public void Add(object key, object value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw new ArgumentException("An element with the same key already exists in the collection.");
        }
        _people.Add(new DictionaryEntry(key, value));
    }

    public void Clear()
    {
        _people.Clear();
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
            ArrayList KeyCollection = new ArrayList(_people.Count);
            for (int i = 0; i < _people.Count; i++)
            {
                KeyCollection.Add( ((DictionaryEntry)_people[i]).Key );
            }
            return KeyCollection;
        }
    }

    public void Remove(object key)
    {
        _people.RemoveAt(IndexOfKey(key));
    }

    public ICollection Values
    {
        get
        {
            ArrayList ValueCollection = new ArrayList(_people.Count);
            for (int i = 0; i < _people.Count; i++)
            {
                ValueCollection.Add( ((DictionaryEntry)_people[i]).Value );
            }
            return ValueCollection;
        }
    }


    // ICollection Members

    public void CopyTo(Array array, int index)
    {
        _people.CopyTo(array, index);
    }

    public int Count
    {
        get
        {
            return _people.Count;
        }
    }

    public bool IsSynchronized
    {
        get
        {
            return _people.IsSynchronized;
        }
    }

    public object SyncRoot
    {
        get
        {
            return _people.SyncRoot;
        }
    }

    // IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
}

public class PeopleEnum : IDictionaryEnumerator
{
    public ArrayList _people;
    
    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public PeopleEnum(ArrayList list)
    {
        _people = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _people.Count);
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
                return _people[position];
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
                return ((DictionaryEntry)_people[position]).Key;
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
                return ((DictionaryEntry)_people[position]).Value;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
//</snippet01>

class App
{
    static void Main()
    {
        People peopleCollection = new People(3);
        peopleCollection.Add("John", "Smith");
        peopleCollection.Add("Jim", "Johnson");
        peopleCollection.Add("Sue", "Rabon");

        Console.WriteLine("Displaying the entries in peopleCollection:");
        foreach (DictionaryEntry de in peopleCollection)
        {
            Console.WriteLine("{0} {1}", de.Key, de.Value);
        }

        Console.WriteLine();
        Console.WriteLine("Displaying the entries in the modified peopleCollection:");
        peopleCollection["Jim"] = "Jackson";
        peopleCollection.Remove("Sue");
        peopleCollection.Insert(0, "Fred", "Anderson");

        foreach (DictionaryEntry de in peopleCollection)
        {
            Console.WriteLine("{0} {1}", de.Key, de.Value);
        }

    }
}
/* This code produces output similar to the following:
 * 
 * Displaying the entries in peopleCollection:
 * John Smith
 * Jim Johnson
 * Sue Rabon
 * 
 * Displaying the entries in the modified peopleCollection:
 * Fred Anderson
 * John Smith
 * Jim Jackson
 */
//</snippet00>
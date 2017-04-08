//<snippet01>
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        SimpleList test = new SimpleList();

        // Populate the List
        Console.WriteLine("Populate the List");
        test.Add("one");
        test.Add("two");
        test.Add("three");
        test.Add("four");
        test.Add("five");
        test.Add("six");
        test.Add("seven");
        test.Add("eight");
        test.PrintContents();
        Console.WriteLine();

        // Remove elements from the list
        Console.WriteLine("Remove elements from the list");
        test.Remove("six");
        test.Remove("eight");
        test.PrintContents();
        Console.WriteLine();

        // Add an element to the end of the list
        Console.WriteLine("Add an element to the end of the list");
        test.Add("nine");
        test.PrintContents();
        Console.WriteLine();

        // Insert an element into the middle of the list
        Console.WriteLine("Insert an element into the middle of the list");
        test.Insert(4, "number");
        test.PrintContents();
        Console.WriteLine();

        // Check for specific elements in the list
        Console.WriteLine("Check for specific elements in the list");
        Console.WriteLine("List contains \"three\": {0}", test.Contains("three"));
        Console.WriteLine("List contains \"ten\": {0}", test.Contains("ten"));
    }
} // class Program

//<snippet02>
class SimpleList : IList
{
    private object[] _contents = new object[8];
    private int _count;

    public SimpleList()
    {
        _count = 0;
    }

    // IList Members
    public int Add(object value)
    {
        if (_count < _contents.Length)
        {
            _contents[_count] = value;
            _count++;

            return (_count - 1);
        }
        else
        {
            return -1;
        }
    }

    public void Clear()
    {
        _count = 0;
    }

    public bool Contains(object value)
    {
        bool inList = false;
        for (int i = 0; i < Count; i++)
        {
            if (_contents[i] == value)
            {
                inList = true;
                break;
            }
        }
        return inList;
    }

    public int IndexOf(object value)
    {
        int itemIndex = -1;
        for (int i = 0; i < Count; i++)
        {
            if (_contents[i] == value)
            {
                itemIndex = i;
                break;
            }
        }
        return itemIndex;
    }

    public void Insert(int index, object value)
    {
        if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
        {
            _count++;

            for (int i = Count - 1; i > index; i--)
            {
                _contents[i] = _contents[i - 1];
            }
            _contents[index] = value;
        }
    }

    public bool IsFixedSize
    {
        get
        {
            return true;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public void Remove(object value)
    {
        RemoveAt(IndexOf(value));
    }

    public void RemoveAt(int index)
    {
        if ((index >= 0) && (index < Count))
        {
            for (int i = index; i < Count - 1; i++)
            {
                _contents[i] = _contents[i + 1];
            }
            _count--;
        }
    }

    public object this[int index]
    {
        get
        {
            return _contents[index];
        }
        set
        {
            _contents[index] = value;
        }
    }

    // ICollection Members

    public void CopyTo(Array array, int index)
    {
        int j = index;
        for (int i = 0; i < Count; i++)
        {
            array.SetValue(_contents[i], j);
            j++;
        }
    }

    public int Count
    {
        get
        {
            return _count;
        }
    }

    public bool IsSynchronized
    {
        get
        {
            return false;
        }
    }

    // Return the current instance since the underlying store is not
    // publicly available.
    public object SyncRoot
    {
        get
        {
            return this;
        }
    }

    // IEnumerable Members

    public IEnumerator GetEnumerator()
    {
        // Refer to the IEnumerator documentation for an example of
        // implementing an enumerator.
        throw new Exception("The method or operation is not implemented.");
    }

    public void PrintContents()
    {
        Console.WriteLine("List has a capacity of {0} and currently has {1} elements.", _contents.Length, _count);
        Console.Write("List contents:");
        for (int i = 0; i < Count; i++)
        {
            Console.Write(" {0}", _contents[i]);
        }
        Console.WriteLine();
    }
}
//</snippet02>

// This code produces output similar to the following:
// Populate the List:
// List has a capacity of 8 and currently has 8 elements.
// List contents: one two three four five six seven eight
//
// Remove elements from the list:
// List has a capacity of 8 and currently has 6 elements.
// List contents: one two three four five seven
//
// Add an element to the end of the list:
// List has a capacity of 8 and currently has 7 elements.
// List contents: one two three four five seven nine
//
// Insert an element into the middle of the list:
// List has a capacity of 8 and currently has 8 elements.
// List contents: one two three four number five seven nine
//
// Check for specific elements in the list:
// List contains "three": True
// List contains "ten": False
//</snippet01>
// REDMOND\glennha
//<Snippet1>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// This class demonstrates one way to use the ChangeItemKey
// method to store objects with keys that can be changed. The 
// ChangeItemKey method is used to keep the internal lookup
// Dictionary in sync with the keys of the stored objects. 
//
// MutableKeys stores MutableKey objects, which have an Integer
// Key property that can be set. Therefore, MutableKeys inherits
// KeyedCollection(Of Integer, MutableKey).
//
public class MutableKeys : KeyedCollection<int, MutableKey>
{
    // This parameterless constructor delegates to the base class 
    // constructor that specifies a dictionary threshold. A
    // threshold of 0 means the internal Dictionary is created
    // the first time an object is added.
    //
    public MutableKeys() : base(null, 0) {}
    
    protected override int GetKeyForItem(MutableKey item)
    {
        // The key is MutableKey.Key.
        return item.Key;
    }

    protected override void InsertItem(int index, MutableKey newItem)
    {
        if (newItem.Collection != null) 
            throw new ArgumentException("The item already belongs to a collection.");

        base.InsertItem(index, newItem);
        newItem.Collection = this;
    }

    protected override void SetItem(int index, MutableKey newItem)
    {
        MutableKey replaced = Items[index];

        if (newItem.Collection != null) 
            throw new ArgumentException("The item already belongs to a collection.");

        base.SetItem(index, newItem);
        newItem.Collection = this;
        replaced.Collection = null;
    }

    protected override void RemoveItem(int index)
    {
        MutableKey removedItem = Items[index];

        base.RemoveItem(index);
        removedItem.Collection = null;
    }

    protected override void ClearItems()
    {
        foreach( MutableKey mk in Items )
        {
            mk.Collection = null;
        }
        
        base.ClearItems();
    }

    internal void ChangeKey(MutableKey item, int newKey)
    {
        base.ChangeItemKey(item, newKey);
    }
    
    public void Dump()
    {
        Console.WriteLine("\nDUMP:");
        if (Dictionary == null)
        {
            Console.WriteLine("    The dictionary has not been created.");
        }
        else
        {
            Console.WriteLine("    Dictionary entries");
            Console.WriteLine("    ------------------");

            foreach( KeyValuePair<int, MutableKey> kvp in Dictionary )
            {
                Console.WriteLine("    {0} : {1}", kvp.Key, kvp.Value);
            }
        }

        Console.WriteLine("\n    List of items");
        Console.WriteLine("    -------------");

        foreach( MutableKey mk in Items )
        {
            Console.WriteLine("    {0}", mk);
        }
    }
}

public class Demo
{
    public static void Main()
    {
        MutableKeys mkeys = new MutableKeys();

        // The Add method is inherited from Collection.
        //
        mkeys.Add(new MutableKey(110072674, "Widget"));
        mkeys.Add(new MutableKey(110072675, "Sprocket"));

        mkeys.Dump();
    
        Console.WriteLine("\nCreate and insert a new item:");
        MutableKey test = new MutableKey(110072684, "Gear");
        mkeys.Insert(1, test);

        mkeys.Dump();

        try
        {
            Console.WriteLine("\nTry to insert the item again:");
            mkeys.Insert(1, test);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }

        Console.WriteLine("\nChange the Key property of the item:");
        test.Key = 100000072;

        mkeys.Dump();

        try
        {
            Console.WriteLine("\nTry to set the Key property to an existing key:");
            test.Key = 110072674;
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }

        mkeys.Dump();
    }
    
    private static void Display(MutableKeys order)
    {
        Console.WriteLine();
        foreach( MutableKey item in order )
        {
            Console.WriteLine(item);
        }
    }
}

// This class has a key that can be changed.
// 
public class MutableKey
{

    public MutableKey(int newKey, string newValue)
    {
        _key = newKey;
        Value = newValue;
    } //New
    
    public string Value;
    internal MutableKeys Collection;
    
    private int _key;
    public int Key    
    {
        get
        {
            return _key;
        }
        set
        {
            if (Collection != null)
            {
                Collection.ChangeKey(this, value);
            }

            _key = value;
        }
    }

    public override string ToString()
    {
        return String.Format("{0,9} {1}", _key, Value);
    }
        
}

/* This code example produces the following output:

DUMP:
    Dictionary entries
    ------------------
    110072674 : 110072674 Widget
    110072675 : 110072675 Sprocket

    List of items
    -------------
    110072674 Widget
    110072675 Sprocket

Create and insert a new item:

DUMP:
    Dictionary entries
    ------------------
    110072674 : 110072674 Widget
    110072675 : 110072675 Sprocket
    110072684 : 110072684 Gear

    List of items
    -------------
    110072674 Widget
    110072684 Gear
    110072675 Sprocket

Try to insert the item again:
Error: The item already belongs to a collection.

Change the Key property of the item:

DUMP:
    Dictionary entries
    ------------------
    110072674 : 110072674 Widget
    110072675 : 110072675 Sprocket
    100000072 : 100000072 Gear

    List of items
    -------------
    110072674 Widget
    100000072 Gear
    110072675 Sprocket

Try to set the Key property to an existing key:
Error: An item with the same key has already been added.

DUMP:
    Dictionary entries
    ------------------
    110072674 : 110072674 Widget
    110072675 : 110072675 Sprocket
    100000072 : 100000072 Gear

    List of items
    -------------
    110072674 Widget
    100000072 Gear
    110072675 Sprocket
 */
//</Snippet1>



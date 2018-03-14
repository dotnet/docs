//Types:System.Collections.DictionaryEntry  Vendor: Richter
//Types:System.Collections.IDictionary  Vendor: Richter
//Types:System.Collections.IDictionaryEnumerator  Vendor: Richter
//<snippet1>
using namespace System;
using namespace System::Collections;

//<snippet2>
// This class implements a simple dictionary using an array of
// DictionaryEntry objects (key/value pairs).
public ref class SimpleDictionary : public IDictionary
{
    // The array of items
private:
    array<DictionaryEntry^>^ items;
private:
    int itemsInUse;

    // Construct the SimpleDictionary with the desired number of
    // items. The number of items cannot change for the life time of
    // this SimpleDictionary.
public:
    SimpleDictionary(int size)
    {
        items = gcnew array<DictionaryEntry^>(size);
    }

    #pragma region IDictionary Members
    //<snippet4>
public:
    property virtual bool IsReadOnly
    {
        bool get()
        {
            return false;
        }
    }
    //</snippet4>
    //<snippet5>
public:
    virtual bool Contains(Object^ key)
    {
        int index;
        return TryGetIndexOfKey(key, &index);
    }
    //</snippet5>
    //<snippet6>
public:
    virtual property bool IsFixedSize
    {
        bool get()
        {
            return false;
        }
    }
    //</snippet6>
    //<snippet7>
public:
    virtual void Remove(Object^ key)
    {
        if (key == nullptr)
        {
            throw gcnew ArgumentNullException("key");
        }
        // Try to find the key in the DictionaryEntry array
        int index;
        if (TryGetIndexOfKey(key, &index))
        {
            // If the key is found, slide all the items down.
            Array::Copy(items, index + 1, items, index, itemsInUse -
                index - 1);
            itemsInUse--;
        }
        else
        {
            // If the key is not in the dictionary, just return.
            return;
        }
    }
    //</snippet7>
    //<snippet8>
public:
    virtual void Clear()
    {
        itemsInUse = 0;
    }
    //</snippet8>
    //<snippet9>
public:
    virtual void Add(Object^ key, Object^ value)
    {
        // Add the new key/value pair even if this key already exists
        // in the dictionary.
        if (itemsInUse == items->Length)
        {
            throw gcnew InvalidOperationException
                ("The dictionary cannot hold any more items.");
        }
        items[itemsInUse++] = gcnew DictionaryEntry(key, value);
    }
    //</snippet9>
    //<snippet10>
public:
    virtual property ICollection^ Keys
    {
        ICollection^ get()
        {
            // Return an array where each item is a key.
            array<Object^>^ keys = gcnew array<Object^>(itemsInUse);
            for (int i = 0; i < itemsInUse; i++)
            {
                keys[i] = items[i]->Key;
            }
            return keys;
        }
    }
    //</snippet10>
    //<snippet11>
public:
    virtual property ICollection^ Values
    {
        ICollection^ get()
        {
            // Return an array where each item is a value.
            array<Object^>^ values = gcnew array<Object^>(itemsInUse);
            for (int i = 0; i < itemsInUse; i++)
            {
                values[i] = items[i]->Value;
            }
            return values;
        }
    }
    //</snippet11>
    //<snippet13>
public:
    virtual property Object^ default[Object^]
    {
        Object^ get(Object^ key)
        {
            // If this key is in the dictionary, return its value.
            int index;
            if (TryGetIndexOfKey(key, &index))
            {
                // The key was found; return its value.
                return items[index]->Value;
            }
            else
            {
                // The key was not found; return null.
                return nullptr;
            }
        }

        void set(Object^ key, Object^ value)
        {
            // If this key is in the dictionary, change its value.
            int index;
            if (TryGetIndexOfKey(key, &index))
            {
                // The key was found; change its value.
                items[index]->Value = value;
            }
            else
            {
                // This key is not in the dictionary; add this
                // key/value pair.
                Add(key, value);
            }
        }
    }
    //</snippet13>
private:
    bool TryGetIndexOfKey(Object^ key, int* index)
    {
        for (*index = 0; *index < itemsInUse; *index++)
        {
            // If the key is found, return true (the index is also
            // returned).
            if (items[*index]->Key->Equals(key))
            {
                return true;
            }
        }

        // Key not found, return false (index should be ignored by
        // the caller).
        return false;
    }
//</snippet2>
//<snippet3>
private:
    ref class SimpleDictionaryEnumerator : public IDictionaryEnumerator
    {
        // A copy of the SimpleDictionary object's key/value pairs.
private:
        array<DictionaryEntry^>^ items;
private:
        int index;

public:
        SimpleDictionaryEnumerator(SimpleDictionary^ sd)
        {
            // Make a copy of the dictionary entries currently in the
            // SimpleDictionary object.
            items = gcnew array<DictionaryEntry^>(sd->Count);
            Array::Copy(sd->items, 0, items, 0, sd->Count);
            index = -1;
        }

        // Return the current item.
public:
        virtual property Object^ Current
        {
            Object^ get()
            {
                ValidateIndex();
                return items[index];
            }
        }

        // Return the current dictionary entry.
public:
        virtual property DictionaryEntry Entry
        {
            DictionaryEntry get()
            {
                return (DictionaryEntry) Current;
            }
        }

        // Return the key of the current item.
public:
        virtual property Object^ Key
        {
            Object^ get()
            {
                ValidateIndex();
				return items[index]->Key;
            }
        }

        // Return the value of the current item.
public:
        virtual property Object^ Value
        {
            Object^ get()
            {
                ValidateIndex();
                return items[index]->Value;
            }
        }

        // Advance to the next item.
public:
        virtual bool MoveNext()
        {
            if (index < items->Length - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        // Validate the enumeration index and throw an exception if
        // the index is out of range.
private:
        void ValidateIndex()
        {
            if (index < 0 || index >= items->Length)
            {
                throw gcnew InvalidOperationException
                    ("Enumerator is before or after the collection.");
            }
        }

        // Reset the index to restart the enumeration.
public:
        virtual void Reset()
        {
            index = -1;
        }
    };
    //<snippet12>
public:
    virtual IDictionaryEnumerator^ GetEnumerator()
    {
        // Construct and return an enumerator.
        return gcnew SimpleDictionaryEnumerator(this);
    }
    //</snippet12>
    #pragma endregion

    #pragma region ICollection Members
public:
    virtual property bool IsSynchronized
    {
        bool get()
        {
            return false;
        }
    }

public:
    virtual property Object^ SyncRoot
    {
        Object^ get()
        {
            throw gcnew NotImplementedException();
        }
    }

public:
    virtual property int Count
    {
        int get()
        {
            return itemsInUse;
        }
    }

public:
    virtual void CopyTo(Array^ array, int index)
    {
        throw gcnew NotImplementedException();
    }
    #pragma endregion

    #pragma region IEnumerable Members

    virtual IEnumerator^ IEnumerable_GetEnumerator() 
        = IEnumerable::GetEnumerator
    {
        // Construct and return an enumerator.
        return ((IDictionary^)this)->GetEnumerator();
    }
    #pragma endregion
};
//</snippet3>

int main()
{
    // Create a dictionary that contains no more than three
    // entries.
    IDictionary^ d = gcnew SimpleDictionary(3);

    // Add three people and their ages to the dictionary.
    d->Add("Jeff", 40);
    d->Add("Kristin", 34);
    d->Add("Aidan", 1);

    Console::WriteLine("Number of elements in dictionary = {0}",
        d->Count);

    Console::WriteLine("Does dictionary contain 'Jeff'? {0}",
        d->Contains("Jeff"));
    Console::WriteLine("Jeff's age is {0}", d["Jeff"]);

    // Display every entry's key and value.
    for each (DictionaryEntry^ de in d)
    {
        Console::WriteLine("{0} is {1} years old.", de->Key,
            de->Value);
    }

    // Remove an entry that exists.
    d->Remove("Jeff");

    // Remove an entry that does not exist, but do not throw an
    // exception.
    d->Remove("Max");

    // Show the names (keys) of the people in the dictionary.
    for each (String^ s in d->Keys)
    {
        Console::WriteLine(s);
    }

    // Show the ages (values) of the people in the dictionary.
    for each (int age in d->Values)
    {
        Console::WriteLine(age);
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

//<snippet00>

#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

//<snippet01>
public ref class PeopleEnum : IDictionaryEnumerator
{
private:
    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position;
    ArrayList^ _people;

public:
    PeopleEnum(ArrayList^ list)
    {
        this->Reset();
        _people = list;
    }

    virtual bool MoveNext()
    {
        position++;
        return (position < _people->Count);
    }

    virtual void Reset()
    {
        position = -1;
    }

    virtual property Object^ Current
    {
        Object^ get()
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException^)
            {
                throw gcnew InvalidOperationException();
            }
        }
    }

    virtual property DictionaryEntry Entry
    {
        DictionaryEntry get()
        {
            return (DictionaryEntry)(Current);
        }
    }

    virtual property Object^ Key
    {
        Object^ get()
        {
            try
            {
                return ((DictionaryEntry^)_people[position])->Key;
            }
            catch (IndexOutOfRangeException^)
            {
                throw gcnew InvalidOperationException();
            }
        }
    }

    virtual property Object^ Value
    {
        Object^ get()
        {
            try
            {
                return ((DictionaryEntry^)_people[position])->Value;
            }
            catch (IndexOutOfRangeException^)
            {
                throw gcnew InvalidOperationException();
            }
        }
    }
};

public ref class People : IOrderedDictionary
{
private:
    ArrayList^ _people;

public:
    People(int numItems)
    {
        _people = gcnew ArrayList(numItems);
    }

    int IndexOfKey(Object^ key)
    {
        for (int i = 0; i < _people->Count; i++)
        {
            if (((DictionaryEntry^)_people[i])->Key == key)
                return i;
        }

        // key not found, return -1.
        return -1;
    }

    virtual property Object^ default[Object^]
    {
        Object^ get(Object^ key)
        {
            return ((DictionaryEntry^)_people[IndexOfKey(key)])->Value;
        }
        void set(Object^ key, Object^ value)
        {
            _people[IndexOfKey(key)] = gcnew DictionaryEntry(key, value);
        }
    }

    // IOrderedDictionary Members
    virtual IDictionaryEnumerator^ GetEnumerator()
    {
        return gcnew PeopleEnum(_people);
    }

    virtual void Insert(int index, Object^ key, Object^ value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw gcnew ArgumentException("An element with the same key already exists in the collection.");
        }
        _people->Insert(index, gcnew DictionaryEntry(key, value));
    }

    virtual void RemoveAt(int index)
    {
        _people->RemoveAt(index);
    }

    virtual property Object^ default[int]
    {
        Object^ get(int index)
        {
            return ((DictionaryEntry^)_people[index])->Value;
        }
        void set(int index, Object^ value)
        {
            Object^ key = ((DictionaryEntry^)_people[index])->Key;
            _people[index] = gcnew DictionaryEntry(Keys, value);
        }
    }

    // IDictionary Members

    virtual void Add(Object^ key, Object^ value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw gcnew ArgumentException("An element with the same key already exists in the collection.");
        }
        _people->Add(gcnew DictionaryEntry(key, value));
    }

    virtual void Clear()
    {
        _people->Clear();
    }

    virtual bool Contains(Object^ key)
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

    virtual property bool IsFixedSize
    {
        bool get()
        {
            return false;
        }
    }

    virtual property bool IsReadOnly
    {
        bool get()
        {
            return false;
        }
    }

    virtual property ICollection^ Keys
    {
        ICollection^ get()
        {
            ArrayList^ KeyCollection = gcnew ArrayList(_people->Count);
            for (int i = 0; i < _people->Count; i++)
            {
                KeyCollection->Add( ((DictionaryEntry^)_people[i])->Key );
            }
            return KeyCollection;
        }
    }

    virtual void Remove(Object^ key)
    {
        _people->RemoveAt(IndexOfKey(key));
    }

    virtual property ICollection^ Values
    {
        ICollection ^get()
        {
            ArrayList^ ValueCollection = gcnew ArrayList(_people->Count);
            for (int i = 0; i < _people->Count; i++)
            {
                ValueCollection->Add( ((DictionaryEntry^)_people[i])->Value );
            }
            return ValueCollection;
        }
    }

    // ICollection Members

    virtual void CopyTo(Array^ array, int index)
    {
        _people->CopyTo(array, index);
    }

    virtual property int Count
    {
        int get()
        {
            return _people->Count;
        }
    }

    virtual property bool IsSynchronized
    {
        bool get()
        {
            return _people->IsSynchronized;
        }
    }

    virtual property Object^ SyncRoot
    {
        Object^ get()
        {
            return _people->SyncRoot;
        }
    }

    // IEnumerable Members

    virtual IEnumerator^ IfcGetEnumerator() = IEnumerable::GetEnumerator
    {
        return (IEnumerator^) gcnew PeopleEnum(_people);
    }
};
//</snippet01>

class App
{
public:
    static void Main()
    {
        People^ peopleCollection = gcnew People(3);
        peopleCollection->Add("John", "Smith");
        peopleCollection->Add("Jim", "Johnson");
        peopleCollection->Add("Sue", "Rabon");

        Console::WriteLine("Displaying the entries in peopleCollection:");
        for each (DictionaryEntry^ de in peopleCollection)
        {
            Console::WriteLine("{0} {1}", de->Key, de->Value);
        }
        Console::WriteLine();
        Console::WriteLine("Displaying the entries in the modified peopleCollection:");
        peopleCollection["Jim"] = "Jackson";
        peopleCollection->Remove("Sue");
        peopleCollection->Insert(0, "Fred", "Anderson");

        for each (DictionaryEntry^ de in peopleCollection)
        {
            Console::WriteLine("{0} {1}", de->Key, de->Value);
        }

    }
};

int main()
{
    App::Main();
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
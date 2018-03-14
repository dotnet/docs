
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

public ref class ODEnum : IDictionaryEnumerator
{
private:
    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position;
    ArrayList^ itemlist;

public:
    ODEnum(ArrayList^ list)
    {
        this->Reset();
        itemlist = list;
    }

    virtual bool MoveNext()
    {
        position++;
        return (position < itemlist->Count);
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
                return itemlist[position];
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
                return ((DictionaryEntry^)itemlist[position])->Key;
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
                return ((DictionaryEntry^)itemlist[position])->Value;
            }
            catch (IndexOutOfRangeException^)
            {
                throw gcnew InvalidOperationException();
            }
        }
    }
};

public ref class SimpleOD : IOrderedDictionary
{
private:
    ArrayList^ itemlist;

public:
    SimpleOD(int numItems)
    {
        itemlist = gcnew ArrayList(numItems);
    }

    int IndexOfKey(Object^ key)
    {
        for (int i = 0; i < itemlist->Count; i++)
        {
            if (((DictionaryEntry^)itemlist[i])->Key == key)
                return i;
        }

        // key not found, return -1.
        return -1;
    }

    virtual property Object^ default[Object^]
    {
        Object^ get(Object^ key)
        {
            return ((DictionaryEntry^)itemlist[IndexOfKey(key)])->Value;
        }
        void set(Object^ key, Object^ value)
        {
            itemlist[IndexOfKey(key)] = gcnew DictionaryEntry(key, value);
        }
    }

    // IOrderedDictionary Members
    virtual IDictionaryEnumerator^ GetEnumerator()
    {
        return gcnew ODEnum(itemlist);
    }

    virtual void Insert(int index, Object^ key, Object^ value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw gcnew ArgumentException("An element with the same key already exists in the collection.");
        }
        itemlist->Insert(index, gcnew DictionaryEntry(key, value));
    }

    virtual void RemoveAt(int index)
    {
        itemlist->RemoveAt(index);
    }

    virtual property Object^ default[int]
    {
        Object^ get(int index)
        {
            return ((DictionaryEntry^)itemlist[index])->Value;
        }
        void set(int index, Object^ value)
        {
            Object^ key = ((DictionaryEntry^)itemlist[index])->Key;
            itemlist[index] = gcnew DictionaryEntry(Keys, value);
        }
    }

    // IDictionary Members

    virtual void Add(Object^ key, Object^ value)
    {
        if (IndexOfKey(key) != -1)
        {
            throw gcnew ArgumentException("An element with the same key already exists in the collection.");
        }
        itemlist->Add(gcnew DictionaryEntry(key, value));
    }

    virtual void Clear()
    {
        itemlist->Clear();
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
            ArrayList^ KeyCollection = gcnew ArrayList(itemlist->Count);
            for (int i = 0; i < itemlist->Count; i++)
            {
                KeyCollection[i] = ((DictionaryEntry^)itemlist[i])->Key;
            }
            return KeyCollection;
        }
    }

    virtual void Remove(Object^ key)
    {
        itemlist->RemoveAt(IndexOfKey(key));
    }

    virtual property ICollection^ Values
    {
        ICollection ^get()
        {
            ArrayList^ ValueCollection = gcnew ArrayList(itemlist->Count);
            for (int i = 0; i < itemlist->Count; i++)
            {
                ValueCollection[i] = ((DictionaryEntry^)itemlist[i])->Value;
            }
            return ValueCollection;
        }
    }

    // ICollection Members

    virtual void CopyTo(Array^ array, int index)
    {
        itemlist->CopyTo(array, index);
    }

    virtual property int Count
    {
        int get()
        {
            return itemlist->Count;
        }
    }

    virtual property bool IsSynchronized
    {
        bool get()
        {
            return itemlist->IsSynchronized;
        }
    }

    virtual property Object^ SyncRoot
    {
        Object^ get()
        {
            return itemlist->SyncRoot;
        }
    }

    // IEnumerable Members

    virtual IEnumerator^ IfcGetEnumerator() = IEnumerable::GetEnumerator
    {
        return (IEnumerator^) gcnew ODEnum(itemlist);
    }
};

class App
{
public:
    static void Main()
    {
        int index = 1;

        SimpleOD^ myOrderedDictionary = gcnew SimpleOD(2);
        myOrderedDictionary->Add("Way", "ToGo");
        myOrderedDictionary->Add("Far", "Out");

        Object^ obj;
        //<snippet04>
        obj = myOrderedDictionary[index];
        //</snippet04>
        //<snippet03>
        for each (DictionaryEntry de in myOrderedDictionary)
        {
            //...
        }
        //</snippet03>
    }
};

int main()
{
    App::Main();
}

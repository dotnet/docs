
using namespace System;
using namespace System::Collections;
using namespace System::Diagnostics;
using namespace System::Reflection;

ref class HashtableDebugView;

[DebuggerDisplay("{value}", Name = "{key}")]
ref class KeyValuePairs
{
private:
    IDictionary^ dictionary;
    Object^ key;
    Object^ value;

public:
    KeyValuePairs(IDictionary^ dictionary, Object^ key, Object^ value)
    {
        this->value = value;
        this->key = key;
        this->dictionary = dictionary;
    }
};

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(HashtableDebugView::typeid)]
ref class MyHashtable : Hashtable
{
private:
    static const String^ TestString = "This should not appear in the debug window.";

internal:
    ref class HashtableDebugView
    {
    private:
        Hashtable^ hashtable;
    public:
        static const String^ TestString = "This should appear in the debug window.";
        HashtableDebugView(Hashtable^ hashtable)
        {
            this->hashtable = hashtable;
        }

        [DebuggerBrowsable(DebuggerBrowsableState::RootHidden)]
        property array<KeyValuePairs^>^ Keys
        {
            array<KeyValuePairs^>^ get()
            {
                array<KeyValuePairs^>^ keys = gcnew array<KeyValuePairs^>(hashtable->Count);

                IEnumerator^ ie = hashtable->Keys->GetEnumerator();
                int i = 0;
                Object^ key;
                while (ie->MoveNext())
                {
                    key = ie->Current;
                    keys[i] = gcnew KeyValuePairs(hashtable, key, hashtable[key]);
                    i++;
                }
                return keys;
            }
        }
    };
};

public ref class DebugViewTest
{
private:
    // The following constant will appear in the debug window for DebugViewTest.
    static const String^ TabString = "    ";
public:
    // The following DebuggerBrowsableAttribute prevents the property following it
    // from appearing in the debug window for the class.
    [DebuggerBrowsable(DebuggerBrowsableState::Never)]
    static String^ y = "Test String";

    static void Main()
    {
        MyHashtable^ myHashTable = gcnew MyHashtable();
        myHashTable->Add("one", 1);
        myHashTable->Add("two", 2);
        Console::WriteLine(myHashTable->ToString());
        Console::WriteLine("In Main.");
    }
};

int main()
{
    DebugViewTest::Main();
}
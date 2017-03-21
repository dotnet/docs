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
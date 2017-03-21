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
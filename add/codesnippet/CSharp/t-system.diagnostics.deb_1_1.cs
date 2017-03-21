        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public KeyValuePairs[] Keys
        {
            get
            {
                KeyValuePairs[] keys = new KeyValuePairs[hashtable.Count];

                int i = 0;
                foreach(object key in hashtable.Keys)
                {
                    keys[i] = new KeyValuePairs(hashtable, key, hashtable[key]);
                    i++;
                }
                return keys;
            }
        }
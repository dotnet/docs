[DebuggerTypeProxy(typeof(HashtableDebugView))]
class MyHashtable : Hashtable
{
    private const string TestString = "This should not appear in the debug window.";

    internal class HashtableDebugView
    {
        private Hashtable hashtable;
        public const string TestString = "This should appear in the debug window.";
        public HashtableDebugView(Hashtable hashtable)
        {
            this.hashtable = hashtable;
        }

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
    }
}
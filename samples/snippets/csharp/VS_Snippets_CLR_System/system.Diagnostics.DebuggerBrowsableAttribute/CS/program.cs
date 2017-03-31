//<Snippet1>
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

class DebugViewTest
{
    // The following constant will appear in the debug window for DebugViewTest.
    const string TabString = "    ";
    //<Snippet2>
    // The following DebuggerBrowsableAttribute prevents the property following it
    // from appearing in the debug window for the class.
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public static string y = "Test String";
    //</Snippet2>

    static void Main()
    {
        MyHashtable myHashTable = new MyHashtable();
        myHashTable.Add("one", 1);
        myHashTable.Add("two", 2);
        Console.WriteLine(myHashTable.ToString());
        Console.WriteLine("In Main.");
    }
}
//<Snippet3>
[DebuggerDisplay("{value}", Name = "{key}")]
internal class KeyValuePairs
{
    private IDictionary dictionary;
    private object key;
    private object value;

    public KeyValuePairs(IDictionary dictionary, object key, object value)
    {
        this.value = value;
        this.key = key;
        this.dictionary = dictionary;
    }
}
//</Snippet3>
//<Snippet4>
[DebuggerDisplay("Count = {Count}")]
//<Snippet5>
[DebuggerTypeProxy(typeof(HashtableDebugView))]
class MyHashtable : Hashtable
//</Snippet4>
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

        //<Snippet6>
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
      //</Snippet6>
    }
}
//</Snippet5>
//</Snippet1>


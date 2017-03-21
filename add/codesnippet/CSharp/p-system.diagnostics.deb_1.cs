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
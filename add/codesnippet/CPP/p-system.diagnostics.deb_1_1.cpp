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
public class TempRecord
{
    // Array of temperature values
    float[] temps =
    [
        56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
    ];

    // To enable client code to validate input
    // when accessing your indexer.
    public int Length => temps.Length;
    
    // Indexer declaration.
    // If index is out of range, the temps array will throw the exception.
    public float this[int index]
    {
        get => temps[index];
        set => temps[index] = value;
    }
}

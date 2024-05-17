using System.Diagnostics.CodeAnalysis;

namespace StandardQueryOperators;

// <group_by_contiguous_keys_chunkextensions>
public static class ChunkExtensions
{
    public static IEnumerable<IGrouping<TKey, TSource>> ChunkBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector) =>
                source.ChunkBy(keySelector, EqualityComparer<TKey>.Default);

    public static IEnumerable<IGrouping<TKey, TSource>> ChunkBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
    {
        // Flag to signal end of source sequence.
        const bool noMoreSourceElements = true;

        // Auto-generated iterator for the source array.
        IEnumerator<TSource>? enumerator = source.GetEnumerator();

        // Move to the first element in the source sequence.
        if (!enumerator.MoveNext())
        {
            yield break;        // source collection is empty
        }

        while (true)
        {
            var key = keySelector(enumerator.Current);

            Chunk<TKey, TSource> current = new(key, enumerator, value => comparer.Equals(key, keySelector(value)));

            yield return current;

            if (current.CopyAllChunkElements() == noMoreSourceElements)
            {
                yield break;
            }
        }
    }
}
// </group_by_contiguous_keys_chunkextensions>

// <group_by_contiguous_keys_chunk_class>
class Chunk<TKey, TSource> : IGrouping<TKey, TSource>
{
    // INVARIANT: DoneCopyingChunk == true ||
    //   (predicate != null && predicate(enumerator.Current) && current.Value == enumerator.Current)

    // A Chunk has a linked list of ChunkItems, which represent the elements in the current chunk. Each ChunkItem
    // has a reference to the next ChunkItem in the list.
    class ChunkItem
    {
        public ChunkItem(TSource value) => Value = value;
        public readonly TSource Value;
        public ChunkItem? Next;
    }

    public TKey Key { get; }

    // Stores a reference to the enumerator for the source sequence
    private IEnumerator<TSource> enumerator;

    // A reference to the predicate that is used to compare keys.
    private Func<TSource, bool> predicate;

    // Stores the contents of the first source element that
    // belongs with this chunk.
    private readonly ChunkItem head;

    // End of the list. It is repositioned each time a new
    // ChunkItem is added.
    private ChunkItem? tail;

    // Flag to indicate the source iterator has reached the end of the source sequence.
    internal bool isLastSourceElement;

    // Private object for thread synchronization
    private readonly object m_Lock;

    // REQUIRES: enumerator != null && predicate != null
    public Chunk(TKey key, [DisallowNull] IEnumerator<TSource> enumerator, [DisallowNull] Func<TSource, bool> predicate)
    {
        Key = key;
        this.enumerator = enumerator;
        this.predicate = predicate;

        // A Chunk always contains at least one element.
        head = new ChunkItem(enumerator.Current);

        // The end and beginning are the same until the list contains > 1 elements.
        tail = head;

        m_Lock = new object();
    }

    // Indicates that all chunk elements have been copied to the list of ChunkItems.
    private bool DoneCopyingChunk => tail == null;

    // Adds one ChunkItem to the current group
    // REQUIRES: !DoneCopyingChunk && lock(this)
    private void CopyNextChunkElement()
    {
        // Try to advance the iterator on the source sequence.
        isLastSourceElement = !enumerator.MoveNext();

        // If we are (a) at the end of the source, or (b) at the end of the current chunk
        // then null out the enumerator and predicate for reuse with the next chunk.
        if (isLastSourceElement || !predicate(enumerator.Current))
        {
            enumerator = default!;
            predicate = default!;
        }
        else
        {
            tail!.Next = new ChunkItem(enumerator.Current);
        }

        // tail will be null if we are at the end of the chunk elements
        // This check is made in DoneCopyingChunk.
        tail = tail!.Next;
    }

    // Called after the end of the last chunk was reached.
    internal bool CopyAllChunkElements()
    {
        while (true)
        {
            lock (m_Lock)
            {
                if (DoneCopyingChunk)
                {
                    return isLastSourceElement;
                }
                else
                {
                    CopyNextChunkElement();
                }
            }
        }
    }

    // Stays just one step ahead of the client requests.
    public IEnumerator<TSource> GetEnumerator()
    {
        // Specify the initial element to enumerate.
        ChunkItem? current = head;

        // There should always be at least one ChunkItem in a Chunk.
        while (current != null)
        {
            // Yield the current item in the list.
            yield return current.Value;

            // Copy the next item from the source sequence,
            // if we are at the end of our local list.
            lock (m_Lock)
            {
                if (current == tail)
                {
                    CopyNextChunkElement();
                }
            }

            // Move to the next ChunkItem in the list.
            current = current.Next;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
// </group_by_contiguous_keys_chunk_class>

// <group_by_contiguous_keys_client_code>
public static class GroupByContiguousKeys
{
    // The source sequence.
    static readonly KeyValuePair<string, string>[] list = [
        new("A", "We"),
        new("A", "think"),
        new("A", "that"),
        new("B", "LINQ"),
        new("C", "is"),
        new("A", "really"),
        new("B", "cool"),
        new("B", "!")
    ];

    // Query variable declared as class member to be available
    // on different threads.
    static readonly IEnumerable<IGrouping<string, KeyValuePair<string, string>>> query =
        list.ChunkBy(p => p.Key);

    public static void GroupByContiguousKeys1()
    {
        // ChunkBy returns IGrouping objects, therefore a nested
        // foreach loop is required to access the elements in each "chunk".
        foreach (var item in query)
        {
            Console.WriteLine($"Group key = {item.Key}");
            foreach (var inner in item)
            {
                Console.WriteLine($"\t{inner.Value}");
            }
        }
    }
}
// </group_by_contiguous_keys_client_code>

public static class GroupByContiguousKeysExamples
{
    public static void RunAllSnippets()
    {
        GroupByContiguousKeys.GroupByContiguousKeys1();
    }
}

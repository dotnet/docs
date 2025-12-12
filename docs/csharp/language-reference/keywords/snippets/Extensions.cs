namespace keywords;

// <ExtensionMembers>
/// <summary>
/// Contains extension members for numeric sequences.
/// </summary>
public static class NumericSequences
{
    /// <summary>
    /// Defines extensions for integer sequences.
    /// </summary>
    /// <param name="sequence">The sequence used as a receiver.</param>
    extension(IEnumerable<int> sequence)
    {
        /// <summary>
        /// Adds a scalar value to each element in the sequence.
        /// </summary>
        /// <param name="operand">The amount to add.</param>
        /// <returns>
        /// A new sequence where each value contains the updated value.
        /// </returns>
        public IEnumerable<int> AddValue(int operand)
        {
            foreach (var item in sequence)
            {
                yield return item + operand;
            }
        }

        /// <summary>
        /// Gets the median value of the sequence.
        /// </summary>
        /// <remarks>
        /// This value is calculated when requested.
        /// </remarks>
        public int Median
        {
            get
            {

                var sortedList = sequence.OrderBy(n => n).ToList();
                int count = sortedList.Count;
                int middleIndex = count / 2;

                if (count % 2 == 0)
                {
                    // Even number of elements: average the two middle elements
                    return (sortedList[middleIndex - 1] + sortedList[middleIndex]);
                }
                else
                {
                    // Odd number of elements: return the middle element
                    return sortedList[middleIndex];
                }
            }
        }

        /// <summary>
        /// Concatenates two sequences of integers into a single sequence.
        /// </summary>
        /// <remarks>The resulting sequence enumerates all elements from <paramref name="left"/> in order,
        /// followed by all elements from <paramref name="right"/>. Enumeration is deferred and performed lazily as the
        /// returned sequence is iterated.</remarks>
        /// <param name="left">The first sequence of integers to concatenate. Cannot be null.</param>
        /// <param name="right">The second sequence of integers to concatenate. Cannot be null.</param>
        /// <returns>A sequence that contains the elements of the first sequence followed by the
        /// elements of the second sequence.</returns>
        public static IEnumerable<int> operator +(IEnumerable<int> left, IEnumerable<int> right)
            => left.Concat(right);
    }
}
// </ExtensionMembers>

public static class NumericStaticExtensions
{
    // <StaticExtensions>
    /// <summary>
    /// Provides static extensions for the <see cref="IEnumerable{Int32}"/> type.
    /// </summary>
    extension(IEnumerable<int>)
    {
        // Method:
        /// <summary>
        /// Generates a sequence of integers, starting from a specified value and incrementing by a given amount.
        /// </summary>
        /// <param name="low">The starting value of the sequence.</param>
        /// <param name="count">The number of integers to generate. Must be non-negative.</param>
        /// <param name="increment">The value by which to increment each subsequent integer in the sequence.</param>
        /// <returns>
        /// An enumerable collection of integers, beginning with the specified starting value and containing the
        /// specified number of elements, each incremented by the given amount.
        /// </returns>
        public static IEnumerable<int> Generate(int low, int count, int increment)
        {
            for (int i = 0; i < count; i++)
                yield return low + (i * increment);
        }

        // Property:
        /// <summary>
        /// Gets an empty sequence of integers representing the identity element for sequence operations.
        /// </summary>
        /// <remarks>
        /// This property can be used as a neutral starting point when aggregating or composing
        /// sequences of integers. The returned sequence is always empty and does not allocate any storage.
        /// </remarks>
        public static IEnumerable<int> Identity => Enumerable.Empty<int>();
    }
    // </StaticExtensions>
}

// <GenericExtension>
/// <summary>
/// Contains generic extension members for sequences.
/// </summary>
public static class GenericExtensions
{
    /// <summary>
    /// Defines extensions for generic sequences.
    /// </summary>
    /// <typeparam name="TReceiver">The type of elements in the receiver sequence.</typeparam>
    /// <param name="source">The sequence used as a receiver.</param>
    extension<TReceiver>(IEnumerable<TReceiver> source)
    {
        /// <summary>
        /// Returns a sequence containing a specified number of elements from the source, starting at a given index.
        /// </summary>
        /// <param name="start">The zero-based index at which to begin retrieving elements. Must be greater than or equal to 0.</param>
        /// <param name="count">The number of elements to return. Must be greater than or equal to 0.</param>
        /// <returns>
        /// An <see cref="IEnumerable{TReceiver}"/> that contains up to <paramref name="count"/> elements from the
        /// source sequence, starting at the element at position <paramref name="start"/>. If <paramref name="start"/>
        /// is greater than the number of elements in the source, an empty sequence is returned.
        /// </returns>
        public IEnumerable<TReceiver> Spread(int start, int count)
            => source.Skip(start).Take(count);

        /// <summary>
        /// Returns a sequence that contains the elements of the original sequence followed by the elements of a
        /// specified sequence, each transformed by a converter function.
        /// </summary>
        /// <remarks>
        /// Enumeration of the returned sequence will not start until the sequence is iterated.
        /// The converter function is applied to each element of the appended sequence as it is enumerated.
        /// </remarks>
        /// <typeparam name="TArg">The type of the elements in the sequence to append.</typeparam>
        /// <param name="second">The sequence whose elements are to be appended after being converted. Cannot be null.</param>
        /// <param name="Converter">A function to convert each element of the appended sequence to the result type. Cannot be null.</param>
        /// <returns>
        /// An IEnumerable<TReceiver> that contains the elements of the original sequence followed by the converted
        /// elements of the specified sequence.
        /// </returns>
        public IEnumerable<TReceiver> Append<TArg>(IEnumerable<TArg> second, Func<TArg, TReceiver> Converter)
        {
            foreach(TReceiver item in source)
            {
                yield return item;
            }
            foreach (TArg item in second)
            {
                yield return Converter(item);
            }
        }

        /// <summary>
        /// Returns a sequence that consists of the elements of the specified collection, transformed by the provided
        /// converter, followed by the elements of the current sequence.
        /// </summary>
        /// <remarks>
        /// Enumeration of the returned sequence will not start until the sequence is iterated.
        /// Both the input collection and the converter function must not be null; otherwise, an exception will be
        /// thrown at enumeration time.
        /// </remarks>
        /// <typeparam name="TArg">The type of the elements in the collection to prepend.</typeparam>
        /// <param name="second">The collection whose elements are to be transformed and prepended to the current sequence. Cannot be null.</param>
        /// <param name="converter">A function to convert each element of the prepended collection to the target type. Cannot be null.</param>
        /// <returns>
        /// An IEnumerable<TReceiver> that contains the converted elements of the specified collection followed by the
        /// elements of the current sequence.
        /// </returns>
        public IEnumerable<TReceiver> Prepend<TArg>(IEnumerable<TArg> second, Func<TArg, TReceiver> converter)
        {
            foreach (TArg item in second)
            {
                yield return converter(item);
            }
            foreach (TReceiver item in source)
            {
                yield return item;
            }
        }
    }
}
// </GenericExtension>

public static class ExtensionExamples
{
    public static void BasicExample()
    {
        // <UseExtensionMethod>
        IEnumerable<int> numbers = Enumerable.Range(1, 10);
        numbers = numbers.AddValue(10);

        var median = numbers.Median;

        var combined = numbers + Enumerable.Range(100, 10);
        // </UseExtensionMethod>

        // <UseStaticExtensions>
        var newSequence = IEnumerable<int>.Generate(5, 10, 2);
        var identity = IEnumerable<int>.Identity;
        // </UseStaticExtensions>
    }
}

namespace LinqFaroShuffle;

public static class CardExtensions
{
    extension<T>(IEnumerable<T> sequence)
    {
        // <snippet1>
        public IEnumerable<T> InterleaveSequenceWith(IEnumerable<T> second)
        {
            var firstIter = sequence.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }
        // </snippet1>

        // <snippet2>
        public bool SequenceEquals(IEnumerable<T> second)
        {
            var firstIter = sequence.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while ((firstIter?.MoveNext() == true) && secondIter.MoveNext())
            {
                if ((firstIter.Current is not null) && !firstIter.Current.Equals(secondIter.Current))
                {
                    return false;
                }
            }

            return true;
        }
        // </snippet2>

        // <snippet3>
        public IEnumerable<T> LogQuery(string tag)
        {
            // File.AppendText creates a new file if the file doesn't exist.
            using (var writer = File.AppendText("debug.log"))
            {
                writer.WriteLine($"Executing Query {tag}");
            }

            return sequence;
        }
        // </snippet3>
    }
}

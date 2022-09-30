public class GetEnumeratorExample
{
    // <GetEnumeratorExample>
    public static void Example()
    {
        var point = new Point(1, 2, 3);
        foreach (int coordinate in point)
        {
            Console.Write(coordinate);
            Console.Write(" ");
        }
        // Output: 1 2 3
    }

    public readonly record struct Point(int X, int Y, int Z)
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return X;
            yield return Y;
            yield return Z;
        }
    }
    // </GetEnumeratorExample>
}
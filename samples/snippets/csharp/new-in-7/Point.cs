namespace new_in_7
{
    // <SnippetPointWithDeconstruction>
    public class Point
    {
        public Point(double x, double y)
            => (X, Y) = (x, y);

        public double X { get; }
        public double Y { get; }

        public void Deconstruct(out double x, out double y) =>
            (x, y) = (X, Y);
    }
    // </SnippetPointWithDeconstruction>
}

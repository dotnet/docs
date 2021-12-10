public static class Utilities
{
    // <MidPoint>
    public static T MidPoint<T>(T left, T right)
        where T : INumber<T> => (left + right) / (T.One + T.One);
    // </MidPoint>
}

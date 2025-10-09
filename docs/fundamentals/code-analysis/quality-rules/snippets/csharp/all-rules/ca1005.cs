namespace ca1005
{
    //<snippet1>
    // This class violates the rule.
    public class TooManyTypeParameters<T, K, V>
    {
        public void M1(T t, K k, V v)
        {
            // ...
        }
    }

    // This class satisfies the rule.
    public class CorrectTypeParameters<T, K>
    {
        public void M1(T t, K k)
        {
            // ...
        }
    }
    //</snippet1>
}

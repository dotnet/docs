public class B<T, U> { }
public class A<V>
{
    public B<V, X> GetSomething<X>()
    {
        return new B<V, X>();
    }
}
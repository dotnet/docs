public class Base<T, U> {}

public class Derived<V> : Base<string, V>
{
    public G<Derived <V>> F;

    public class Nested {}
}

public class G<T> {}
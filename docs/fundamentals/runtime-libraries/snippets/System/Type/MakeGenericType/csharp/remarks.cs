using System;

// <Snippet1>
public class Base<T, U> { }
public class Derived<V> : Base<int, V> { }
// </Snippet1>

// <Snippet2>
public class Outermost<T>
{
    public class Inner<U>
    {
        public class Innermost1<V> {}
        public class Innermost2 {}
    }
}
// </Snippet2>

class ProgStubClass
{
    public static void Main() {}
}
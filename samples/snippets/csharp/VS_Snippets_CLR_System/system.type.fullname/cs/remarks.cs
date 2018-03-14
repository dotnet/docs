using System;

// <Snippet1>
public class Base<TBase> { }
public class Derived<TDerived> : Base<TDerived> { }
// </Snippet1>

class ProgStubClass
{
    public static void Main() {}
}
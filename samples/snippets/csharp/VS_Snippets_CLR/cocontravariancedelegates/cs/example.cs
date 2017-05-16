//<Snippet1>
using System;

//<Snippet2>
public class Base {}
public class Derived : Base {}

public class Program
{
    public static Derived MyMethod(Base b)
    {
        return b as Derived ?? new Derived();
    }

    static void Main() 
    {
        Func<Base, Derived> f1 = MyMethod;
//</Snippet2>

//<Snippet3>
        // Covariant return type.
        Func<Base, Base> f2 = f1;
        Base b2 = f2(new Base());
//</Snippet3>

//<Snippet4>
        // Contravariant parameter type.
        Func<Derived, Derived> f3 = f1;
        Derived d3 = f3(new Derived());
//</Snippet4>

//<Snippet5>
        // Covariant return type and contravariant parameter type.
        Func<Derived, Base> f4 = f1;
        Base b4 = f4(new Derived());
//</Snippet5>
    }
}
//</Snippet1>


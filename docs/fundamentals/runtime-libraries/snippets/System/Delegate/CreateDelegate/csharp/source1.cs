// <Snippet1>
using System;
using System.Reflection;

// Define two classes to use in the demonstration, a base class and
// a class that derives from it.
//
public class Base { }

public class Derived : Base
{
    // Define a static method to use in the demonstration. The method
    // takes an instance of Base and returns an instance of Derived.
    // For the purposes of the demonstration, it is not necessary for
    // the method to do anything useful.
    //
    public static Derived MyMethod(Base arg)
    {
        Base dummy = arg;
        return new Derived();
    }
}

// Define a delegate that takes an instance of Derived and returns an
// instance of Base.
//
public delegate Base Example5(Derived arg);

class Test
{
    public static void Main()
    {
        // The binding flags needed to retrieve MyMethod.
        BindingFlags flags = BindingFlags.Public | BindingFlags.Static;

        // Get a MethodInfo that represents MyMethod.
        MethodInfo minfo = typeof(Derived).GetMethod("MyMethod", flags);

        // Demonstrate contravariance of parameter types and covariance
        // of return types by using the delegate Example5 to represent
        // MyMethod. The delegate binds to the method because the
        // parameter of the delegate is more restrictive than the
        // parameter of the method (that is, the delegate accepts an
        // instance of Derived, which can always be safely passed to
        // a parameter of type Base), and the return type of MyMethod
        // is more restrictive than the return type of Example5 (that
        // is, the method returns an instance of Derived, which can
        // always be safely cast to type Base).
        //
        Example5 ex =
            (Example5)Delegate.CreateDelegate(typeof(Example5), minfo);

        // Execute MyMethod using the delegate Example5.
        //
        Base b = ex(new Derived());
    }
}
// </Snippet1>

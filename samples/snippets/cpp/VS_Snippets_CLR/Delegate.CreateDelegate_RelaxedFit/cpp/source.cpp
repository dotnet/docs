// REDMOD\glennha
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Define two classes to use in the demonstration, a base class and 
// a class that derives from it.
//
public ref class Base {};

public ref class Derived : Base
{
    // Define a static method to use in the demonstration. The method 
    // takes an instance of Base and returns an instance of Derived.  
    // For the purposes of the demonstration, it is not necessary for 
    // the method to do anything useful. 
    //
public:
    static Derived^ MyMethod(Base^ arg)
    {
        Base^ dummy = arg;
        return gcnew Derived();
    }
};

// Define a delegate that takes an instance of Derived and returns an
// instance of Base.
//
public delegate Base^ Example(Derived^ arg);

void main()
{
    // The binding flags needed to retrieve MyMethod.
    BindingFlags flags = BindingFlags::Public | BindingFlags::Static;

    // Get a MethodInfo that represents MyMethod.
    MethodInfo^ minfo = Derived::typeid->GetMethod("MyMethod", flags);

    // Demonstrate contravariance of parameter types and covariance
    // of return types by using the delegate Example to represent
    // MyMethod. The delegate binds to the method because the
    // parameter of the delegate is more restrictive than the 
    // parameter of the method (that is, the delegate accepts an
    // instance of Derived, which can always be safely passed to
    // a parameter of type Base), and the return type of MyMethod
    // is more restrictive than the return type of Example (that
    // is, the method returns an instance of Derived, which can
    // always be safely cast to type Base). 
    //
    Example^ ex = 
        (Example^) Delegate::CreateDelegate(Example::typeid, minfo);

    // Execute MyMethod using the delegate Example.
    //        
    Base^ b = ex(gcnew Derived());
}
// </Snippet1>

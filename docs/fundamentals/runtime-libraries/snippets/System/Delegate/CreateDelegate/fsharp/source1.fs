module source1

// <Snippet1>
open System
open System.Reflection

// Define two classes to use in the demonstration, a base class and
// a class that derives from it.
type Base() = class end

type Derived() =
    inherit Base()

    // Define a static method to use in the demonstration. The method
    // takes an instance of Base and returns an instance of Derived.
    // For the purposes of the demonstration, it is not necessary for
    // the method to do anything useful.
    static member MyMethod(arg: Base) =
        Derived()

// Define a delegate that takes an instance of Derived and returns an
// instance of Base.
type Example = delegate of Derived -> Base

// The binding flags needed to retrieve MyMethod.
let flags = BindingFlags.Public ||| BindingFlags.Static

// Get a MethodInfo that represents MyMethod.
let minfo = typeof<Derived>.GetMethod("MyMethod", flags)

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
let ex = Delegate.CreateDelegate(typeof<Example>, minfo) :?> Example

// Execute MyMethod using the delegate Example.
let b = Derived() |> ex.Invoke
// </Snippet1>
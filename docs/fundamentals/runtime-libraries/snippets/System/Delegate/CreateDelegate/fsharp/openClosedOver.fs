module openClosedOver

// All four permutations of instance/static with open/closed.
//
//<Snippet1>
open System
open System.Reflection

// A sample class with an instance method and a static method.
type C(id) =
    member _.M1(s) =
        printfn $"Instance method M1 on C:  id = %i{id}, s = %s{s}"

    static member M2(s) =
        printfn $"Static method M2 on C:  s = %s{s}"
    
// Declare three delegate types for demonstrating the combinations
// of static versus instance methods and open versus closed
// delegates.
type D1 = delegate of C * string -> unit
type D2 = delegate of string -> unit
type D3 = delegate of unit -> unit

let c1 = C 42

// Get a MethodInfo for each method.
//
let mi1 = typeof<C>.GetMethod("M1", BindingFlags.Public ||| BindingFlags.Instance)
let mi2 = typeof<C>.GetMethod("M2", BindingFlags.Public ||| BindingFlags.Static)

printfn "\nAn instance method closed over C."

// In this case, the delegate and the
// method must have the same list of argument types use
// delegate type D2 with instance method M1.
let test = Delegate.CreateDelegate(typeof<D2>, c1, mi1, false)

// Because false was specified for throwOnBindFailure
// in the call to CreateDelegate, the variable 'test'
// contains null if the method fails to bind (for
// example, if mi1 happened to represent a method of
// some class other than C).
if test <> null then
    let d2 = test :?> D2

    // The same instance of C is used every time the
    // delegate is invoked.
    d2.Invoke "Hello, World!"
    d2.Invoke "Hi, Mom!"

printfn "\nAn open instance method."

// In this case, the delegate has one more
// argument than the instance method this argument comes
// at the beginning, and represents the hidden instance
// argument of the instance method. Use delegate type D1
// with instance method M1.
let d1 = Delegate.CreateDelegate(typeof<D1>, null, mi1) :?> D1

// An instance of C must be passed in each time the
// delegate is invoked.
d1.Invoke(c1, "Hello, World!")
d1.Invoke(C 5280, "Hi, Mom!")

printfn "\nAn open static method."
// In this case, the delegate and the method must
// have the same list of argument types use delegate type
// D2 with static method M2.
let d2 = Delegate.CreateDelegate(typeof<D2>, null, mi2) :?> D2

// No instances of C are involved, because this is a static
// method.
d2.Invoke "Hello, World!"
d2.Invoke "Hi, Mom!"

printfn "\nA static method closed over the first argument (String)."
// The delegate must omit the first argument of the method.
// A string is passed as the firstArgument parameter, and
// the delegate is bound to this string. Use delegate type
// D3 with static method M2.
let d3 = Delegate.CreateDelegate(typeof<D3>, "Hello, World!", mi2) :?> D3

// Each time the delegate is invoked, the same string is used.
d3.Invoke()

// This code example produces the following output:
//     An instance method closed over C.
//     Instance method M1 on C:  id = 42, s = Hello, World!
//     Instance method M1 on C:  id = 42, s = Hi, Mom!
//     
//     An open instance method.
//     Instance method M1 on C:  id = 42, s = Hello, World!
//     Instance method M1 on C:  id = 5280, s = Hi, Mom!
//     
//     An open static method.
//     Static method M2 on C:  s = Hello, World!
//     Static method M2 on C:  s = Hi, Mom!
//     
//     A static method closed over the first argument (String).
//     Static method M2 on C:  s = Hello, World!
//</Snippet1>
module source

// Showing all the things D(A) can bind to.
//<Snippet1>
open System

// Declare two sample classes, C and F. Class C has an ID
// property so instances can be identified.
type C(id) =
    member _.ID = id 

    member _.M1(c: C) =
        printfn $"Instance method M1(C c) on C:  this.id = {id}, c.ID = {c.ID}"

    member _.M2() =
        printfn $"Instance method M2() on C:  this.id = {id}"

    static member M3(c: C) =
        printfn $"Static method M3(C c) on C:  c.ID = {c.ID}"

    static member M4(c1: C, c2: C) =
        printfn $"Static method M4(C c1, C c2) on C:  c1.ID = {c1.ID}, c2.ID = {c2.ID}"

// Declare a delegate type. The object of this code example
// is to show all the methods this delegate can bind to.
type D = delegate of C -> unit


type F() =
    member _.M1(c: C) =
        printfn $"Instance method M1(C c) on F:  c.ID = {c.ID}"

    member _.M3(c: C) =
        printfn $"Static method M3(C c) on F:  c.ID = {c.ID}"

    member _.M4(f: F, c: C) =
        printfn $"Static method M4(F f, C c) on F:  c.ID = {c.ID}"

[<EntryPoint>]
let main _ =
    let c1 = C 42
    let c2 = C 1491
    let f1 = F()

    // Instance method with one argument of type C.
    let cmi1 = typeof<C>.GetMethod "M1"
    // Instance method with no arguments.
    let cmi2 = typeof<C>.GetMethod "M2"
    // Static method with one argument of type C.
    let cmi3 = typeof<C>.GetMethod "M3"
    // Static method with two arguments of type C.
    let cmi4 = typeof<C>.GetMethod "M4"

    // Instance method with one argument of type C.
    let fmi1 = typeof<F>.GetMethod "M1"
    // Static method with one argument of type C.
    let fmi3 = typeof<F>.GetMethod "M3"
    // Static method with an argument of type F and an argument
    // of type C.
    let fmi4 = typeof<F>.GetMethod "M4"

    printfn "\nAn instance method on any type, with an argument of type C."
    // D can represent any instance method that exactly matches its
    // signature. Methods on C and F are shown here.
    let d = Delegate.CreateDelegate(typeof<D>, c1, cmi1) :?> D
    d.Invoke c2
    let d =  Delegate.CreateDelegate(typeof<D>, f1, fmi1) :?> D
    d.Invoke c2

    Console.WriteLine("\nAn instance method on C with no arguments.")
    // D can represent an instance method on C that has no arguments
    // in this case, the argument of D represents the hidden first
    // argument of any instance method. The delegate acts like a
    // static method, and an instance of C must be passed each time
    // it is invoked.
    let d = Delegate.CreateDelegate(typeof<D>, null, cmi2) :?> D
    d.Invoke c1

    printfn "\nA static method on any type, with an argument of type C."
    // D can represent any static method with the same signature.
    // Methods on F and C are shown here.
    let d = Delegate.CreateDelegate(typeof<D>, null, cmi3) :?> D
    d.Invoke c1
    let d = Delegate.CreateDelegate(typeof<D>, null, fmi3) :?> D
    d.Invoke c1

    printfn "\nA static method on any type, with an argument of"
    printfn "    that type and an argument of type C."
    // D can represent any static method with one argument of the
    // type the method belongs and a second argument of type C.
    // In this case, the method is closed over the instance of
    // supplied for the its first argument, and acts like an instance
    // method. Methods on F and C are shown here.
    let d = Delegate.CreateDelegate(typeof<D>, c1, cmi4) :?> D
    d.Invoke c2
    let test =
        Delegate.CreateDelegate(typeof<D>, f1, fmi4, false)

    // This final example specifies false for throwOnBindFailure
    // in the call to CreateDelegate, so the variable 'test'
    // contains Nothing if the method fails to bind (for
    // example, if fmi4 happened to represent a method of
    // some class other than F).
    match test with
    | :? D as d ->
        d.Invoke c2
    | _ -> ()
    0

// This code example produces the following output:
//     An instance method on any type, with an argument of type C.
//     Instance method M1(C c) on C:  this.id = 42, c.ID = 1491
//     Instance method M1(C c) on F:  c.ID = 1491
//    
//     An instance method on C with no arguments.
//     Instance method M2() on C:  this.id = 42
//    
//     A static method on any type, with an argument of type C.
//     Static method M3(C c) on C:  c.ID = 42
//     Static method M3(C c) on F:  c.ID = 42
//    
//     A static method on any type, with an argument of
//         that type and an argument of type C.
//     Static method M4(C c1, C c2) on C:  c1.ID = 42, c2.ID = 1491
//     Static method M4(F f, C c) on F:  c.ID = 1491
//</Snippet1>
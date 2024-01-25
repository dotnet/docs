module equals_val2

// <Snippet4>
// Define a value type that does not override Equals.
[<Struct>]
type Person(personName: string) =
    override _.ToString() =
        personName

let person1 = Person "John"
let person2 = Person "John"

printfn "Calling Equals:"
printfn $"{person1.Equals person2}"

printfn $"\nCasting to an Object and calling Equals:"
printfn $"{(person1 :> obj).Equals(person2 :> obj)}"
// The example displays the following output:
//       Calling Equals:
//       True
//
//       Casting to an Object and calling Equals:
//       True
// </Snippet4>
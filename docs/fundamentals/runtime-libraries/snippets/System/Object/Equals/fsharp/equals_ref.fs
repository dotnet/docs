module equals_ref

// <Snippet2>
// Define a reference type that does not override Equals.
type Person(name) =
    override _.ToString() =
        name

let person1a = Person "John"
let person1b = person1a
let person2 = Person(string person1a)

printfn "Calling Equals:"
printfn $"person1a and person1b: {person1a.Equals person1b}"
printfn $"person1a and person2: {person1a.Equals person2}"

printfn "\nCasting to an Object and calling Equals:"
printfn $"person1a and person1b: {(person1a :> obj).Equals(person1b :> obj)}"
printfn $"person1a and person2: {(person1a :> obj).Equals(person2 :> obj)}"
// The example displays the following output:
//       person1a and person1b: True
//       person1a and person2: False
//
//       Casting to an Object and calling Equals:
//       person1a and person1b: True
//       person1a and person2: False
// </Snippet2>
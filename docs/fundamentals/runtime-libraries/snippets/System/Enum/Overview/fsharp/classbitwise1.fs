module classbitwise1

open System

// <Snippet13>
[<Flags>] 
type Pets =
    | None = 0
    | Dog = 1
    | Cat = 2
    | Bird = 4
    | Rodent = 8
    | Reptile = 16
    | Other = 32
// </Snippet13>

// <Snippet14>
let familyPets = Pets.Dog ||| Pets.Cat
printfn $"Pets: {familyPets:G} ({familyPets:D})"
// The example displays the following output:
//       Pets: Dog, Cat (3)
// </Snippet14>

let showHasFlag () =
    // <Snippet15>
    let familyPets = Pets.Dog ||| Pets.Cat
    if familyPets.HasFlag Pets.Dog then
        printfn "The family has a dog."
    // The example displays the following output:
    //       The family has a dog.
    // </Snippet15>

let showIfSet () =
    // <Snippet16>
    let familyPets = Pets.Dog ||| Pets.Cat
    if (familyPets &&& Pets.Dog) = Pets.Dog then
        printfn "The family has a dog."
    // The example displays the following output:
    //       The family has a dog.
    // </Snippet16>

let testForNone () =
    // <Snippet17>
    let familyPets = Pets.Dog ||| Pets.Cat
    if familyPets = Pets.None then
        printfn "The family has no pets."
    else
        printfn "The family has pets."
    // The example displays the following output:
    //       The family has pets.
    // </Snippet17>

showHasFlag ()
showIfSet ()
testForNone ()

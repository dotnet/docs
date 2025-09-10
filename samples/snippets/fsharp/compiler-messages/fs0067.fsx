(* Redundant Type test *)
type Dog() =
    member this.Name = "Dog"

let dog = Dog()

if dog :? Dog then
    printfn "It always be a dog"

(* Redundant Downcast *)
type Cat(name: string) =
    member this.Name = name

let cat = Cat("Kitten")

let sameCat = cat :?> Cat

printfn "It's still a %s" sameCat.Name

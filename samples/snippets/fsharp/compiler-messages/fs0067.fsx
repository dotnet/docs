(* Redundant Type test *)
type Dog() =
    member this.Bark() = printfn "Woof!"

let dog = Dog()

if dog :? Dog then
    dog.Bark()

(* Redundant Downcast *)
type Cat(name: string) =
    member this.Name = name

let cat = Cat("Kitten")

let sameCat = cat :?> Cat

printfn "It's still a %s" sameCat.Name

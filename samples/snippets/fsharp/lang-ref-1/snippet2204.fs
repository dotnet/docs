type Incrementor(delta) =
    member this.Increment(i: int byref) = i <- i + delta

let incrementor = new Incrementor(1)
let mutable myDelta1 = 10
incrementor.Increment(ref myDelta1)
// Prints 10:
printfn "%d" myDelta1

let mutable myDelta2 = 10
incrementor.Increment(&myDelta2)
// Prints 11:
printfn "%d" myDelta2

let refInt = ref 10
incrementor.Increment(refInt)
// Prints 11:
printfn "%d" !refInt
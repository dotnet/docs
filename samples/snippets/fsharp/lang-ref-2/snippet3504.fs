type MyClass1(x) as this =
    // This use of the self identifier produces a warning - avoid.
    let x1 = this.X
    // This use of the self identifier is acceptable.
    do printfn "Initializing object with X =%d" this.X
    member this.X = x
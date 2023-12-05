open System

type MyType(a: int, b: int) as this =
    inherit Object()
    let x = 2 * a
    let y = 2 * b
    do printfn "Initializing object %d %d %d %d %d %d" a b x y (this.Prop1) (this.Prop2)
    static do printfn "Initializing MyType."
    member this.Prop1 = 4 * x
    member this.Prop2 = 4 * y

    override this.ToString() =
        System.String.Format("{0} {1}", this.Prop1, this.Prop2)

let obj1 = new MyType(1, 2)

type IPrintable =
    abstract member Print: unit -> unit

type SomeClass1(x: int, y: float) =
    interface IPrintable with
        member this.Print() = printfn "%d %f" x y

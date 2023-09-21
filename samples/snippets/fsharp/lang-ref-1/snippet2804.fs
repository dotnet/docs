let makePrintable (x: int, y: float) =
    { new IPrintable with
        member this.Print() = printfn "%d %f" x y }

let x3 = makePrintable (1, 2.0)
x3.Print()

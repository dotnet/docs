type PointWithCounter(a: int, b: int) =
    // A variable i.
    let mutable i = 0

    // A let binding that uses a pattern.
    let (x, y) = (a, b)

    // A private function binding.
    let privateFunction x y = x * x + 2 * y

    // A static let binding.
    static let mutable count = 0

    // A do binding.
    do count <- count + 1

    member this.Prop1 = x
    member this.Prop2 = y
    member this.CreatedCount = count
    member this.FunctionValue = privateFunction x y

let point1 = PointWithCounter(10, 52)

printfn "%d %d %d %d" (point1.Prop1) (point1.Prop2) (point1.CreatedCount) (point1.FunctionValue)

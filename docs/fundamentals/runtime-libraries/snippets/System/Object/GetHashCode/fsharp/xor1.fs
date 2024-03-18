module xor1

// <Snippet2>
// A type that represents a 2-D point.
[<Struct; CustomEquality; NoComparison>]
type Point(x: int, y: int) =
    member _.X = x
    member _.Y = y

    override _.Equals(obj) =
        match obj with
        | :? Point as p ->
            x = p.X && y = p.Y
        | _ -> 
            false

    override _.GetHashCode() =
        x ^^^ y

let pt = Point(5, 8)
printfn $"{pt.GetHashCode()}"

let pt2 = Point(8, 5)
printfn $"{pt.GetHashCode()}"
// The example displays the following output:
//       13
//       13
// </Snippet2>
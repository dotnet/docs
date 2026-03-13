module xor2

// <Snippet3>
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
        System.HashCode.Combine(x, y)

let pt = Point(5, 8)
printfn $"{pt.GetHashCode()}"

let pt2 = Point(8, 5)
printfn $"{pt2.GetHashCode()}"
// The example displays output similar to the following.
// Note: HashCode.Combine results are not stable across .NET versions.
//       185727722
//       -363254492
// </Snippet3>
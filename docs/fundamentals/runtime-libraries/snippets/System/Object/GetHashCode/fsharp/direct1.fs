module direct1

// <Snippet1>
open System

[<Struct; CustomEquality; NoComparison>]
type Number(value: int) =
    member _.Value = value

    override _.Equals(obj) =
        match obj with
        | :? Number as n ->
            n.Value = value
        | _ -> false

    override _.GetHashCode() =
        value

    override _.ToString() =
        string value

let rnd = Random()
for _ = 0 to 9 do
    let randomN = rnd.Next(Int32.MinValue, Int32.MaxValue)
    let n = Number randomN
    printfn $"n = {n,12}, hash code = {n.GetHashCode(),12}"
// The example displays output like the following:
//       n =   -634398368, hash code =   -634398368
//       n =   2136747730, hash code =   2136747730
//       n =  -1973417279, hash code =  -1973417279
//       n =   1101478715, hash code =   1101478715
//       n =   2078057429, hash code =   2078057429
//       n =   -334489950, hash code =   -334489950
//       n =    -68958230, hash code =    -68958230
//       n =   -379951485, hash code =   -379951485
//       n =    -31553685, hash code =    -31553685
//       n =   2105429592, hash code =   2105429592
// </Snippet1>
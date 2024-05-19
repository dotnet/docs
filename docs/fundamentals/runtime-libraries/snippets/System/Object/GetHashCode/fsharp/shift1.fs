module shift1

// <Snippet5>
open System

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

    override this.GetHashCode() =
        this.ShiftAndWrap(x.GetHashCode(), 2) ^^^ y.GetHashCode()

    member _.ShiftAndWrap(value, positions) =
        let positions = positions &&& 0x1F

        // Save the existing bit pattern, but interpret it as an unsigned integer.
        let number = BitConverter.ToUInt32(BitConverter.GetBytes value, 0)
        // Preserve the bits to be discarded.
        let wrapped = number >>> (32 - positions)
        // Shift and wrap the discarded bits.
        BitConverter.ToInt32(BitConverter.GetBytes((number <<< positions) ||| wrapped), 0)

let pt = Point(5, 8)
printfn $"{pt.GetHashCode()}"

let pt2 = Point(8, 5)
printfn $"{pt2.GetHashCode()}"
// The example displays the following output:
//       28
//       37
// </Snippet5>

// <Snippet4>
let shiftAndWrap (value: int) positions =
    let positions = positions &&& 0x1F

    // Save the existing bit pattern, but interpret it as an unsigned integer.
    let number = BitConverter.ToUInt32(BitConverter.GetBytes value, 0)
    // Preserve the bits to be discarded.
    let wrapped = number >>> (32 - positions)
    // Shift and wrap the discarded bits.
    BitConverter.ToInt32(BitConverter.GetBytes((number <<< positions) ||| wrapped), 0)
// </Snippet4>
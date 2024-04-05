module equals3

// <Snippet1>
type Point(x, y) =
    member _.X = x
    member _.Y = y

    override _.Equals(obj) =
        // Performs an equality check on two points (integer pairs).
        match obj with
        | :? Point as p ->
            x = p.X && y = p.Y
        | _ ->
            false
    
    override _.GetHashCode() =
        (x, y).GetHashCode()

type Rectangle(upLeftX, upLeftY, downRightX, downRightY) =
    let a = Point(upLeftX, upLeftY)
    let b = Point(downRightX, downRightY)
    
    member _.UpLeft = a
    member _.DownRight = b

    override _.Equals(obj) =
        // Perform an equality check on two rectangles (Point object pairs).
        match obj with
        | :? Rectangle as r ->
            a.Equals(r.UpLeft) && b.Equals(r.DownRight)
        | _ -> 
            false
        
    override _.GetHashCode() =
        (a, b).GetHashCode()

    override _.ToString() =
       $"Rectangle({a.X}, {a.Y}, {b.X}, {b.Y})"

let r1 = Rectangle(0, 0, 100, 200)
let r2 = Rectangle(0, 0, 100, 200)
let r3 = Rectangle(0, 0, 150, 200)

printfn $"{r1} = {r2}: {r1.Equals r2}"
printfn $"{r1} = {r3}: {r1.Equals r3}"
printfn $"{r2} = {r3}: {r2.Equals r3}"
// The example displays the following output:
//    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 100, 200): True
//    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 150, 200): False
//    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 150, 200): False
// </Snippet1>
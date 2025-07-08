module equals2

// <Snippet1>
type Point(x, y) =
    new () = Point(0, 0)
    member _.X = x
    member _.Y = y

    override _.Equals(obj) =
        //Check for null and compare run-time types.
        match obj with
        | :? Point as p ->
            x = p.X && y = p.Y
        | _ -> 
            false

    override _.GetHashCode() =
        (x <<< 2) ^^^ y

    override _.ToString() =
        $"Point({x}, {y})"

type Point3D(x, y, z) =
    inherit Point(x, y)
    member _.Z = z

    override _.Equals(obj) =
        match obj with
        | :? Point3D as pt3 ->
            base.Equals(pt3 :> Point) && z = pt3.Z
        | _ -> 
            false

    override _.GetHashCode() =
        (base.GetHashCode() <<< 2) ^^^ z

    override _.ToString() =
        $"Point({x}, {y}, {z})"

let point2D = Point(5, 5)
let point3Da = Point3D(5, 5, 2)
let point3Db = Point3D(5, 5, 2)
let point3Dc = Point3D(5, 5, -1)

printfn $"{point2D} = {point3Da}: {point2D.Equals point3Da}"
printfn $"{point2D} = {point3Db}: {point2D.Equals point3Db}"
printfn $"{point3Da} = {point3Db}: {point3Da.Equals point3Db}"
printfn $"{point3Da} = {point3Dc}: {point3Da.Equals point3Dc}"
// The example displays the following output:
//       Point(5, 5) = Point(5, 5, 2): False
//       Point(5, 5) = Point(5, 5, 2): False
//       Point(5, 5, 2) = Point(5, 5, 2): True
//       Point(5, 5, 2) = Point(5, 5, -1): False
// </Snippet1>
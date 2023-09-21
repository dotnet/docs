type RectangleXY(x1: float, y1: float, x2: float, y2: float) =
    // Field definitions.
    let height = y2 - y1
    let width = x2 - x1
    let area = height * width
    // Private functions.
    static let maxFloat (x: float) (y: float) = if x >= y then x else y
    static let minFloat (x: float) (y: float) = if x <= y then x else y
    // Properties.
    // Here, "this" is used as the self identifier,
    // but it can be any identifier.
    member this.X1 = x1
    member this.Y1 = y1
    member this.X2 = x2
    member this.Y2 = y2
    // A static method.
    static member intersection(rect1: RectangleXY, rect2: RectangleXY) =
        let x1 = maxFloat rect1.X1 rect2.X1
        let y1 = maxFloat rect1.Y1 rect2.Y1
        let x2 = minFloat rect1.X2 rect2.X2
        let y2 = minFloat rect1.Y2 rect2.Y2

        let result: RectangleXY option =
            if (x2 > x1 && y2 > y1) then
                Some(RectangleXY(x1, y1, x2, y2))
            else
                None

        result

// Test code.
let testIntersection =
    let r1 = RectangleXY(10.0, 10.0, 20.0, 20.0)
    let r2 = RectangleXY(15.0, 15.0, 25.0, 25.0)
    let r3: RectangleXY option = RectangleXY.intersection (r1, r2)

    match r3 with
    | Some(r3) -> printfn "Intersection rectangle: %f %f %f %f" r3.X1 r3.Y1 r3.X2 r3.Y2
    | None -> printfn "No intersection found."

testIntersection

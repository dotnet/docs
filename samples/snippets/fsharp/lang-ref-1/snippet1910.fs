type Point3D = { x: float; y: float; z: float }
let evaluatePoint (point: Point3D) =
    match point with
    | { x = 0.0; y = 0.0; z = 0.0 } -> printfn "Point is at the origin."
    | { x = xVal; y = 0.0; z = 0.0 } -> printfn "Point is on the x-axis. Value is %f." xVal
    | { x = 0.0; y = yVal; z = 0.0 } -> printfn "Point is on the y-axis. Value is %f." yVal
    | { x = 0.0; y = 0.0; z = zVal } -> printfn "Point is on the z-axis. Value is %f." zVal
    | { x = xVal; y = yVal; z = zVal } -> printfn "Point is at (%f, %f, %f)." xVal yVal zVal

evaluatePoint { x = 0.0; y = 0.0; z = 0.0 }
evaluatePoint { x = 100.0; y = 0.0; z = 0.0 }
evaluatePoint { x = 10.0; y = 0.0; z = -1.0 }
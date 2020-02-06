
    let delta = 1.0e-10
    let isPerfectSquare (x:int) =
        let y = sqrt (float x)
        abs(y - round y) < delta
    let isPerfectCube (x:int) =
        let y = System.Math.Pow(float x, 1.0/3.0)
        abs(y - round y) < delta
    let lookForCubeAndSquare array1 =
        let result = Array.tryFind (fun elem -> isPerfectSquare elem && isPerfectCube elem) array1
        match result with
        | Some x -> printfn "Found an element: %d" x
        | None -> printfn "Failed to find a matching element."

    lookForCubeAndSquare [| 1 .. 10 |]
    lookForCubeAndSquare [| 100 .. 1000 |]
    lookForCubeAndSquare [| 2 .. 50 |]
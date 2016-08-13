
    let findPerfectSquareAndCube array1 =
        let delta = 1.0e-10
        let isPerfectSquare (x:int) =
            let y = sqrt (float x)
            abs(y - round y) < delta
        let isPerfectCube (x:int) =
            let y = System.Math.Pow(float x, 1.0/3.0)
            abs(y - round y) < delta
        // intFunction : (float -> float) -> int -> int
        // Allows the use of a floating point function with integers.
        let intFunction function1 number = int (round (function1 (float number)))
        let cubeRoot x = System.Math.Pow(x, 1.0/3.0)
        // testElement: int -> (int * int * int) option
        // Test an element to see whether it is a perfect square and a perfect
        // cube, and, if so, return the element, square root, and cube root
        // as an option value. Otherwise, return None.
        let testElement elem = 
            if isPerfectSquare elem && isPerfectCube elem then
                Some(elem, intFunction sqrt elem, intFunction cubeRoot elem)
            else None
        match Array.tryPick testElement array1 with
        | Some (n, sqrt, cuberoot) -> printfn "Found an element %d with square root %d and cube root %d." n sqrt cuberoot
        | None -> printfn "Did not find an element that is both a perfect square and a perfect cube."

    findPerfectSquareAndCube [| 1 .. 10 |]
    findPerfectSquareAndCube [| 2 .. 100 |]
    findPerfectSquareAndCube [| 100 .. 1000 |]
    findPerfectSquareAndCube [| 1000 .. 10000 |]
    findPerfectSquareAndCube [| 2 .. 50 |]
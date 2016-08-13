let list1 = [ 2 .. 100 ]
let delta = 1.0e-10
let isPerfectSquare (x:int) =
    let y = sqrt (float x)
    abs(y - round y) < delta
let isPerfectCube (x:int) =
    let y = System.Math.Pow(float x, 1.0/3.0)
    abs(y - round y) < delta
let element = List.find (fun elem -> isPerfectSquare elem && isPerfectCube elem) list1
let index = List.findIndex (fun elem -> isPerfectSquare elem && isPerfectCube elem) list1
printfn "The first element that is both a square and a cube is %d and its index is %d." element index
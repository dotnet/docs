namespace MathService

module MyMath =
    let private square x = x * x
    let private isOdd x = x % 2 <> 0

    let sumOfSquares xs = 
        xs 
        |> Seq.filter isOdd 
        |> Seq.map square

module Say =
    let hello name =
        printfn "Hello %s" name

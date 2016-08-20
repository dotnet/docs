// Normally sequences are evaluated lazily.  In this case,
// the sequence is created from a list, which is not evaluated
// lazily. Therefore, without Seq.delay, the elements would be
// evaluated at the time of the call to makeSequence.
let makeSequence function1 maxNumber = Seq.delay (fun () ->
    let rec loop n acc =
        printfn "Evaluating %d." n
        match n with
        | 0 -> acc
        | n -> (function1 n) :: loop (n - 1) acc
    loop maxNumber []
    |> Seq.ofList)
printfn "Calling makeSequence."
let seqSquares = makeSequence (fun x -> x * x) 4
let seqCubes = makeSequence (fun x -> x * x * x) 4
printfn "Printing sequences."
printfn "Squares:"
seqSquares |> Seq.iter (fun x -> printf "%d " x)
printfn "\nCubes:"
seqCubes |> Seq.iter (fun x -> printf "%d " x)
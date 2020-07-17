// Compare the output of this example with that of the previous.
// Notice that Seq.delay delays the
// execution of the loop until the sequence is used.
let makeSequence function1 maxNumber =
    let rec loop n acc =
        printfn "Evaluating %d." n
        match n with
        | 0 -> acc
        | n -> (function1 n) :: loop (n - 1) acc
    loop maxNumber []
    |> Seq.ofList
printfn "Calling makeSequence."
let seqSquares = makeSequence (fun x -> x * x) 4
let seqCubes = makeSequence (fun x -> x * x * x) 4
printfn "Printing sequences."
printfn "Squares:"
seqSquares |> Seq.iter (fun x -> printf "%d " x)
printfn "\nCubes:"
seqCubes |> Seq.iter (fun x -> printf "%d " x)
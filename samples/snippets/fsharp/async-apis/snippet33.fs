let generateInfiniteSequence fDenominator isAlternating =
    if (isAlternating) then
        Seq.initInfinite (fun index -> 1.0 /(fDenominator index) * (if (index % 2 = 0) then -1.0 else 1.0))
    else
        Seq.initInfinite (fun index -> 1.0 /(fDenominator index))

// This is the series of recipocals of the squares.
let squaresSeries = generateInfiniteSequence (fun index -> float (index * index)) false

// This function sums a sequence, up to the specified number of terms.
let sumSeq length sequence =
    Seq.unfold (fun state ->
        let subtotal = snd state + Seq.nth (fst state + 1) sequence
        if (fst state >= length) then None
        else Some(subtotal, (fst state + 1, subtotal))) (0, 0.0)

// This function sums an infinite sequence up to a given value
// for the difference (epsilon) between subsequent terms,
// up to a maximum number of terms, whichever is reached first.
let infiniteSum infiniteSeq epsilon maxIteration =
    infiniteSeq
    |> sumSeq maxIteration
    |> Seq.pairwise
    |> Seq.takeWhile (fun elem -> abs (snd elem - fst elem) > epsilon)
    |> List.ofSeq
    |> List.rev
    |> List.head
    |> snd

let pi = System.Math.PI

// Because this is not an alternating series, a much smaller epsilon
// value and more terms are needed to obtain an accurate result.
let computeSum epsilon =
    let maxTerms =  10000000
    async {
        let result = infiniteSum squaresSeries epsilon maxTerms
        printfn "Result: %f pi*pi/6: %f" result (pi*pi/6.0)
    }

// Start the computation on a new thread.
Async.Start(computeSum 1.0e-8)

// Because the computation is running on a separate thread,
// this message is printed to the console without any delay.
printfn "Computing. Press any key to stop waiting."
System.Console.ReadLine() |> ignore

    let seq1 = Seq.unfold (fun state -> if (state > 20) then None else Some(state, state + 1)) 0
    printfn "The sequence seq1 contains numbers from 0 to 20."
    for x in seq1 do printf "%d " x
    let fib = Seq.unfold (fun state ->
        if (snd state > 1000) then None
        else Some(fst state + snd state, (snd state, fst state + snd state))) (1,1)
    printfn "\nThe sequence fib contains Fibonacci numbers."
    for x in fib do printf "%d " x
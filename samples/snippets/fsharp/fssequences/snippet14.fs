let seq1 =
    0 // Initial state
    |> Seq.unfold (fun state ->
        if (state > 20) then
            None
        else
            Some(state, state + 1))

printfn "The sequence seq1 contains numbers from 0 to 20."

for x in seq1 do
    printf "%d " x

let fib =
    (0, 1)
    |> Seq.unfold (fun state ->
        let cur, next = state
        if cur < 0 then  // overflow
            None
        else
            let next' = cur + next
            let state' = next, next'
            Some (cur, state') )

printfn "\nThe sequence fib contains Fibonacci numbers."
for x in fib do printf "%d " x
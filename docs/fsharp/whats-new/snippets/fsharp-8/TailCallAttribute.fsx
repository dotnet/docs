// <Classic>
[<TailCall>]
let rec factorialClassic n =
    match n with
    | 0u | 1u -> 1u
    | _ -> n * (factorialClassic (n - 1u))
// </Classic>

// <Accumulator>
[<TailCall>]
let rec factorialWithAcc n accumulator = 
    match n with
    | 0u | 1u -> accumulator
    | _ -> factorialWithAcc (n - 1u) (n * accumulator)
// </Accumulator>

// Test both
let result1 = factorialClassic 5u
let result2 = factorialWithAcc 5u 1u

printfn "Classic factorial(5): %d" result1
printfn "Accumulator factorial(5): %d" result2

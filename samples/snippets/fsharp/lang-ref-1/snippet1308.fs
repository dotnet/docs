let IsPrimeMultipleTest n x = x = n || x % n <> 0

let rec RemoveAllMultiples listn listx =
    match listn with
    | head :: tail -> RemoveAllMultiples tail (List.filter (IsPrimeMultipleTest head) listx)
    | [] -> listx


let GetPrimesUpTo n =
    let max = int (sqrt (float n))
    RemoveAllMultiples [ 2..max ] [ 1..n ]

printfn "Primes Up To %d:\n %A" 100 (GetPrimesUpTo 100)
// Recursive isprime function.
let isprime n =
    let rec check i =
        i > n / 2 || (n % i <> 0 && check (i + 1))

    check 2

let aSequence =
    seq {
        for n in 1..100 do
            if isprime n then
                n
    }

for x in aSequence do
    printfn "%d" x

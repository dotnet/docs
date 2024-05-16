module example

// <Snippet3>
open System
open System.Reflection

let limit = 10000000
let primes = PrimeNumberGenerator limit
let start = 1000001
try
    let values = primes.GetPrimesFrom start
    printfn $"There are {values.Length} prime numbers from {start} to {limit}"
with :? NotPrimeException as e ->
    printfn $"{e.NonPrime} is not prime"
    printfn $"{e}"
    printfn "--------"

let domain = AppDomain.CreateDomain "Domain2"
let gen = 
    domain.CreateInstanceAndUnwrap(
        typeof<PrimeNumberGenerator>.Assembly.FullName,
        "PrimeNumberGenerator", true,
        BindingFlags.Default, null,
        [| box 1000000 |], null, null)
    :?> PrimeNumberGenerator
try
    let start = 100
    printfn $"{gen.GetPrimesFrom start}"
with :? NotPrimeException as e ->
    printfn $"{e.NonPrime} is not prime"
    printfn $"{e}"
    printfn "--------"
// </Snippet3>
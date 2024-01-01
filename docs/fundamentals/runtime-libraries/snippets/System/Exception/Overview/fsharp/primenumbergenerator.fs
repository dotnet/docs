// <Snippet2>
namespace global

open System

[<Serializable>]
type PrimeNumberGenerator(upperBound) =
    let start = 2
    let maxUpperBound = 10000000
    let primes = ResizeArray()
    let primeTable = 
        upperBound + 1
        |> Array.zeroCreate<bool>

    do
        if upperBound > maxUpperBound then
            let message = $"{upperBound} exceeds the maximum upper bound of {maxUpperBound}."
            raise (ArgumentOutOfRangeException message)
        
        // Create array and mark 0, 1 as not prime (True).
        primeTable[0] <- true
        primeTable[1] <- true

        // Use Sieve of Eratosthenes to determine prime numbers.
        for i = start to float upperBound |> sqrt |> ceil |> int do
            if not primeTable[i] then
                for multiplier = i to upperBound / i do
                    if i * multiplier <= upperBound then
                        primeTable[i * multiplier] <- true
        
        // Populate array with prime number information.
        let mutable index = start
        while index <> -1 do
            index <- Array.FindIndex(primeTable, index, fun flag -> not flag)
            if index >= 1 then
                primes.Add index
                index <- index + 1

    member _.GetAllPrimes() =
        primes.ToArray()

    member _.GetPrimesFrom(prime) =
        let start = 
            Seq.findIndex ((=) prime) primes
        
        if start < 0 then
            raise (NotPrimeException(prime, $"{prime} is not a prime number.") )
        else
            Seq.filter ((>=) prime) primes
            |> Seq.toArray
// </Snippet2>
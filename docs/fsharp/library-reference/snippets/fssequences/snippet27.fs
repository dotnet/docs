
   // Recursive isprime function.
   let isPrime n =
       let rec check i =
           i > n/2 || (n % i <> 0 && check (i + 1))
       check 2

   let seqPrimes = seq { for n in 2 .. 10000 do if isPrime n then yield n }
   // Cache the sequence to avoid recomputing the sequence elements.
   let cachedSeq = Seq.cache seqPrimes
   for index in 1..5 do
       printfn "%d is prime." (Seq.nth (Seq.length cachedSeq - index) cachedSeq)
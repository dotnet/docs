let isDivisibleBy number elem = elem % number = 0
let result = Seq.find (isDivisibleBy 5) [ 1 .. 100 ]
printfn "%d " result
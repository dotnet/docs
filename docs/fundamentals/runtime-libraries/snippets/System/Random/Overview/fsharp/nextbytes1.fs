module NextBytes1

open System

// <Snippet5>
let rnd = Random()
let bytes = Array.zeroCreate 20
rnd.NextBytes bytes

for i = 1 to bytes.Length do
    printf "%3i   " bytes.[i - 1]
    if (i % 10 = 0) then printfn ""

// The example displays output like the following:
//       141    48   189    66   134   212   211    71   161    56
//       181   166   220   133     9   252   222    57    62    62
// </Snippet5>

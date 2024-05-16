module Unique

// <Snippet13>
open System
open System.Threading

printfn "Instantiating two random number generators..."
let rnd1 = Random()
Thread.Sleep 2000
let rnd2 = Random()

printfn "\nThe first random number generator:"
for _ = 1 to 10 do 
    printfn $"   {rnd1.Next()}"

printfn "\nThe second random number generator:"
for _ = 1 to 10 do 
    printfn $"   {rnd2.Next()}"

// The example displays output like the following:
//       Instantiating two random number generators...
//
//       The first random number generator:
//          643164361
//          1606571630
//          1725607587
//          2138048432
//          496874898
//          1969147632
//          2034533749
//          1840964542
//          412380298
//          47518930
//
//       The second random number generator:
//          1251659083
//          1514185439
//          1465798544
//          517841554
//          1821920222
//          195154223
//          1538948391
//          1548375095
//          546062716
//          897797880
// </Snippet13>

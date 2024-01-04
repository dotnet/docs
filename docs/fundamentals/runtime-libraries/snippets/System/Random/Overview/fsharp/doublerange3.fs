module DoubleRange3

open System

// <Snippet19>
let rnd = Random()

let lowerBound = 10.0
let upperBound = 11.0

let range =
    Array.init 1000000 (fun _ -> rnd.NextDouble() * (upperBound - lowerBound) +  lowerBound)
    |> Array.countBy (fun x -> Math.Truncate((x - lowerBound) * 10.0) |> int)
    |> Array.map snd

for i = 0 to 9 do 
    let lowerRange = 10.0 + float i * 0.1
    printfn $"{lowerRange:N1} to {lowerRange + 0.1:N1}: {range.[i],8:N0}  ({float range.[i] / 1000000.0,6:P2})"

// The example displays output like the following:
//       10.0 to 10.1:   99,929  ( 9.99 %)
//       10.1 to 10.2:  100,189  (10.02 %)
//       10.2 to 10.3:   99,384  ( 9.94 %)
//       10.3 to 10.4:  100,240  (10.02 %)
//       10.4 to 10.5:   99,397  ( 9.94 %)
//       10.5 to 10.6:  100,580  (10.06 %)
//       10.6 to 10.7:  100,293  (10.03 %)
//       10.7 to 10.8:  100,135  (10.01 %)
//       10.8 to 10.9:   99,905  ( 9.99 %)
//       10.9 to 11.0:   99,948  ( 9.99 %)
// </Snippet19>

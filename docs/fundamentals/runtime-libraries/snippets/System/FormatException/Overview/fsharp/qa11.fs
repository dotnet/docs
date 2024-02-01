module qa11

// <Snippet21>
open System

let rnd = Random()
let mutable total = 0
let numbers = Array.zeroCreate<int> 4
for i = 0 to 2 do
   let number = rnd.Next 1001
   numbers[i] <- number
   total <- total + number
numbers[3] <- total
Console.WriteLine("{0} + {1} + {2} = {3}", numbers)   
// </Snippet21>
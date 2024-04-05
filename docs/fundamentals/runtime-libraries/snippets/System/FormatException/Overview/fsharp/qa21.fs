module qa21

// <Snippet22>
open System

let rnd = Random()
let numbers = Array.zeroCreate<int> 4
let mutable total = 0
for i = 0 to 2 do
   let number = rnd.Next 1001
   numbers[i] <- number
   total <- total + number
numbers[3] <- total
let values = Array.zeroCreate<obj> numbers.Length
numbers.CopyTo(values, 0)
Console.WriteLine("{0} + {1} + {2} = {3}", values)   
// </Snippet22>
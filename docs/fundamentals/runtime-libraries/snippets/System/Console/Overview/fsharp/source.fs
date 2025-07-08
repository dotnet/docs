// <Snippet1>
module Example

open System

[<EntryPoint>]
let main argv =
    Console.Write("Hello ")
    Console.WriteLine("World!")
    Console.Write("Enter your name: ")
    let name = Console.ReadLine()
    Console.Write("Good day, ")
    Console.Write(name)
    Console.WriteLine("!")
    0
    
// The example displays output similar to the following:
//       Hello World!
//       Enter your name: James
//       Good day, James!
// </Snippet1>

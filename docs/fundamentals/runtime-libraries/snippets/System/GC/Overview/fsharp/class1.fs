//<snippet1>
open System

let maxGarbage = 1000

type MyGCCollectClass() =
    member _.MakeSomeGarbage() =
        for _ = 1 to maxGarbage do
            // Create objects and release them to fill up memory with unused objects.
            Version() |> ignore

[<EntryPoint>]
let main _ =
    let myGCCol = MyGCCollectClass()

    // Determine the maximum number of generations the system
    // garbage collector currently supports.
    printfn $"The highest generation is {GC.MaxGeneration}"

    myGCCol.MakeSomeGarbage()

    // Determine which generation myGCCol object is stored in.
    printfn $"Generation: {GC.GetGeneration myGCCol}"

    // Determine the best available approximation of the number
    // of bytes currently allocated in managed memory.
    printfn $"Total Memory: {GC.GetTotalMemory false}"

    // Perform a collection of generation 0 only.
    GC.Collect 0

    // Determine which generation myGCCol object is stored in.
    printfn $"Generation: {GC.GetGeneration myGCCol}"

    printfn $"Total Memory: {GC.GetTotalMemory false}"

    // Perform a collection of all generations up to and including 2.
    GC.Collect 2

    // Determine which generation myGCCol object is stored in.
    printfn $"Generation: {GC.GetGeneration myGCCol}"
    printfn $"Total Memory: {GC.GetTotalMemory false}"

    0
//</snippet1>
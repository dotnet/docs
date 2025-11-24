// Static let in discriminated unions
open FSharp.Reflection

type AbcDU = A | B | C
    with   
        static let namesAndValues = 
            FSharpType.GetUnionCases(typeof<AbcDU>) 
            |> Array.map (fun c -> c.Name, FSharpValue.MakeUnion (c,[||]) :?> AbcDU)
        static let stringMap = namesAndValues |> dict
        static let mutable cnt = 0

        static do printfn "Init done! We have %i cases" stringMap.Count
        static member TryParse text = 
            let cnt = System.Threading.Interlocked.Increment(&cnt)
            stringMap.TryGetValue text, sprintf "Parsed %i" cnt

// Test the functionality
let result1 = AbcDU.TryParse "A"
let result2 = AbcDU.TryParse "B"
let result3 = AbcDU.TryParse "Invalid"

printfn "Parse 'A': %A" result1
printfn "Parse 'B': %A" result2
printfn "Parse 'Invalid': %A" result3

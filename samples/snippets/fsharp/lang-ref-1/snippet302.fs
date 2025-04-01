let fullNotation = [ "a"; "ab"; "abc" ] |> List.find ( fun text -> text.EndsWith("c") )
printfn "%A" fullNotation         // Output: "abc"

let shorthandNotation = [ "a"; "ab"; "abc" ] |> List.find ( _.EndsWith("b") )
printfn "%A" shorthandNotation    // Output: "ab"

let append1 string1 = string1 + ".append1"
let append2 string1 = string1 + ".append2"

let result1 = append1 <| "abc"
printfn "append1 <| \"abc\" gives %A" result1

// Reverse pipelines require parentheses.
let result2 :string = append2 <| (append1 <| "abc")
printfn "result2: %A" result2

// Reverse pipelines can be used to eliminate the need for
// parentheses in some expressions.
raise <| new System.Exception("A failure occurred.")
// Wildcard pattern matching "nothing" examples

// Example 1: Wildcard ignoring function parameters
let ignoreAllParams _ _ = "Ignores all input"

// Example 2: Wildcard in destructuring, ignoring elements
let getFirstOnly (first, _) = first

// Example 3: Using wildcard to ignore optional values
let handleEmpty opt =
    match opt with
    | Some _ -> "Has something"
    | None -> "Has nothing"

// Usage
printfn "%s" (ignoreAllParams 42 "test")
printfn "%d" (getFirstOnly (1, "ignored"))
printfn "%s" (handleEmpty None)
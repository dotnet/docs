// Wildcard pattern matching "nothing" examples
open System

// Example 1: Wildcard matching unit type (representing nothing)
let processUnit x =
    match x with
    | () -> "Matched unit (nothing)"

// Example 2: Wildcard ignoring function parameters
let ignoreAllParams _ _ = "Ignores all input"

// Example 3: Wildcard in destructuring, ignoring elements
let getFirstOnly (first, _) = first

// Example 4: Using wildcard to ignore optional values
let handleEmpty opt =
    match opt with
    | Some _ -> "Has something"
    | None -> "Has nothing"

// Usage
printfn "%s" (processUnit ())
printfn "%s" (ignoreAllParams 42 "test")
printfn "%d" (getFirstOnly (1, "ignored"))
printfn "%s" (handleEmpty None)
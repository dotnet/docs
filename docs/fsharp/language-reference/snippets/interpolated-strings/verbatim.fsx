// Verbatim interpolated strings with $@ or @$
let name = "Alice"
let path = @"C:\Users\Alice\Documents"

// Using $@ prefix (interpolated verbatim string)
printfn $@"User {name} has files in: {path}"

// Using @$ prefix (also valid)
printfn @$"User {name} has files in: {path}"

// Embedding quotes without escaping
let message = $@"He said ""{name}"" is here"
printfn "%s" message

// Multi-line verbatim interpolated strings
let multiline = $@"Name: {name}
Path: {path}
Status: Active"
printfn "%s" multiline

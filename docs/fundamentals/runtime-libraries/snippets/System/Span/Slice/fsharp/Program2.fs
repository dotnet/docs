module Program2

open System

let getContentLength (span: ReadOnlySpan<char>) =
    let slice = span.Slice 16
    Int32.Parse slice

let contentLength = "Content-Length: 132"
let length = getContentLength (contentLength.ToCharArray())
printfn $"Content length: {length}"
// Output:
//      Content length: 132
module Intern1.fs
open System
open System.Text

// <Snippet1>
let s1 = "MyTest"
let s2 = StringBuilder().Append("My").Append("Test").ToString()
let s3 = String.Intern s2
printfn $"{s2 :> obj = s1 :> obj}" // Different references.
printfn $"{s3 :> obj = s1 :> obj}" // The same reference.
// </Snippet1>

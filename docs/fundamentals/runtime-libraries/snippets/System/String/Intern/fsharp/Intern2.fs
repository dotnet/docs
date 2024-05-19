module Intern2.fs
open System
open System.Text

// <Snippet2>
let str1 = String.Empty
let str2 = String.Empty

let sb = StringBuilder().Append String.Empty
let str3 = String.Intern(string sb)

if (str1 :> obj) = (str3 :> obj) then
    printfn "The strings are equal."
else
    printfn "The strings are not equal."
// </Snippet2>

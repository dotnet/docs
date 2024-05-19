module equalssb1

// <Snippet5>
open System
open System.Text

let sb1 = StringBuilder "building a string..."
let sb2 = StringBuilder "building a string..."

printfn $"sb1.Equals(sb2): {sb1.Equals sb2}"
printfn $"((Object) sb1).Equals(sb2): {(sb1 :> obj).Equals sb2}"
                  
printfn $"Object.Equals(sb1, sb2): {Object.Equals(sb1, sb2)}"

let sb3 = StringBuilder "building a string..."
printfn $"\nsb3.Equals(sb2): {sb3.Equals sb2}"
// The example displays the following output:
//       sb1.Equals(sb2): True
//       ((Object) sb1).Equals(sb2): False
//       Object.Equals(sb1, sb2): False
//
//       sb3.Equals(sb2): False
// </Snippet5>
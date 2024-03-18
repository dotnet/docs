module compare2.fs
// <Snippet12>
open System
open System.Collections.Generic
open System.Globalization

// IComparer<String> implementation to perform string sort using an F# object expression.
let scompare = 
    { new IComparer<String> with
        member _.Compare(x, y) =
            CultureInfo.CurrentCulture.CompareInfo.Compare(x, y, CompareOptions.StringSort) }

let strings = [| "coop"; "co-op"; "cooperative"; "co\u00ADoperative"; "cœur"; "coeur" |]

// Perform a word sort using the current (en-US) culture.
let current = Array.copy strings
Array.Sort(current, StringComparer.CurrentCulture)

// Perform a word sort using the invariant culture.
let invariant = Array.copy strings
Array.Sort(invariant, StringComparer.InvariantCulture)

// Perform an ordinal sort.
let ordinal = Array.copy strings
Array.Sort(ordinal, StringComparer.Ordinal)

// Perform a string sort using the current culture.
let stringSort = Array.copy strings
Array.Sort(stringSort, scompare)

// Display array values
printfn "%13s %13s %15s %13s %13s\n" "Original" "Word Sort" "Invariant Word" "Ordinal Sort" "String Sort"
for i = 0 to strings.Length - 1 do
    printfn "%13s %13s %15s %13s %13s\n" strings[i] current[i] invariant[i] ordinal[i] stringSort[i]

// The example displays the following output:
//         Original     Word Sort  Invariant Word  Ordinal Sort   String Sort
//
//             coop          cœur            cœur         co-op         co-op
//            co-op         coeur           coeur         coeur          cœur
//      cooperative          coop            coop          coop         coeur
//     co­operative         co-op           co-op   cooperative          coop
//             cœur   cooperative     cooperative  co­operative   cooperative
//            coeur  co­operative    co­operative          cœur  co­operative
// </Snippet12>

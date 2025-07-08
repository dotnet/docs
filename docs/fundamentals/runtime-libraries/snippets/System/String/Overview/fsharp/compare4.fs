module compare4.fs
// <Snippet21>
open System
open System.Globalization
open System.Threading

let str1 = "Apple"
let str2 = "Æble"
let str3 = "AEble"

// Set the current culture to Danish in Denmark.
Thread.CurrentThread.CurrentCulture <- CultureInfo "da-DK"
printfn $"Current culture: {CultureInfo.CurrentCulture.Name}"
printfn $"Comparison of {str1} with {str2}: {String.Compare(str1, str2)}"
printfn $"Comparison of {str2} with {str3}: {String.Compare(str2, str3)}\n"

// Set the current culture to English in the U.S.
Thread.CurrentThread.CurrentCulture <- CultureInfo "en-US"
printfn $"Current culture: {CultureInfo.CurrentCulture.Name}"
printfn $"Comparison of {str1} with {str2}: {String.Compare(str1, str2)}"
printfn $"Comparison of {str2} with {str3}: {String.Compare(str2, str3)}\n"

// Perform an ordinal comparison.
printfn "Ordinal comparison"
printfn $"Comparison of {str1} with {str2}: {String.Compare(str1, str2, StringComparison.Ordinal)}"
printfn $"Comparison of {str2} with {str3}: {String.Compare(str2, str3, StringComparison.Ordinal)}"
// The example displays the following output:
//       Current culture: da-DK
//       Comparison of Apple with Æble: -1
//       Comparison of Æble with AEble: 1
//
//       Current culture: en-US
//       Comparison of Apple with Æble: 1
//       Comparison of Æble with AEble: 0
//
//       Ordinal comparison
//       Comparison of Apple with Æble: -133
//       Comparison of Æble with AEble: 133
// </Snippet21>

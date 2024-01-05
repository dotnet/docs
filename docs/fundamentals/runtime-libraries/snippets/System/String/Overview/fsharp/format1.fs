module format1.fs
// <Snippet8>
open System
open System.Globalization

let date = DateTime(2011, 3, 1)
let cultures = 
      [| CultureInfo.InvariantCulture
         CultureInfo "en-US"
         CultureInfo "fr-FR" |]

for culture in cultures do
    printfn $"""{(if String.IsNullOrEmpty culture.Name then "Invariant" else culture.Name),-12} {date.ToString("d", culture)}"""
// The example displays the following output:
//       Invariant    03/01/2011
//       en-US        3/1/2011
//       fr-FR        01/03/2011
// </Snippet8>

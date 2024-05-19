module search1.fs
// <Snippet22>
open System.Globalization

let cultureNames = [| "da-DK"; "en-US" |]
let str = "aerial"
let ch = 'æ'  // U+00E6

printf "Ordinal comparison -- "
printfn $"Position of '{ch}' in {str}: {str.IndexOf ch}"
                  
for cultureName in cultureNames do
    let ci = CultureInfo.CreateSpecificCulture(cultureName).CompareInfo
    printf $"{cultureName} cultural comparison -- "
    printfn $"Position of '{ch}' in {str}: {ci.IndexOf(str, ch)}"
// The example displays the following output:
//       Ordinal comparison -- Position of 'æ' in aerial: -1
//       da-DK cultural comparison -- Position of 'æ' in aerial: -1
//       en-US cultural comparison -- Position of 'æ' in aerial: 0
// </Snippet22>

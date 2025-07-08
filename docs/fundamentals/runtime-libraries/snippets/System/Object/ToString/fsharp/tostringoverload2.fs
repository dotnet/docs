module tostringoverload2

// <Snippet5>
open System.Globalization

let cultureNames =
    [| "en-US"; "en-GB"; "fr-FR"; "hr-HR"; "ja-JP" |]
let value = 1603.49m
for cultureName in cultureNames do
    let culture = CultureInfo cultureName
    printfn $"""{culture.Name}: {value.ToString("C2", culture)}"""
// The example displays the following output:
//       en-US: $1,603.49
//       en-GB: £1,603.49
//       fr-FR: 1 603,49 €
//       hr-HR: 1.603,49 kn
//       ja-JP: ¥1,603.49
// </Snippet5>
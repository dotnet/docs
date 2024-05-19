module format3

// <Snippet5>
open System
open System.Globalization

type BooleanFormatter(culture) =
    interface ICustomFormatter with
        member this.Format(_, arg, formatProvider) =
            if formatProvider <> this then null
            else
                match arg with
                | :? bool as value -> 
                    match culture.Name with 
                    | "en-US" -> string arg
                    | "fr-FR" when value -> "vrai"
                    | "fr-FR" -> "faux"
                    | "ru-RU" when value -> "верно"
                    | "ru-RU" -> "неверно"
                    | _ -> string arg
                | _ -> null
    interface IFormatProvider with
        member this.GetFormat(formatType) =
            if formatType = typeof<ICustomFormatter> then this
            else null
    new() = BooleanFormatter CultureInfo.CurrentCulture

let cultureNames = [ ""; "en-US"; "fr-FR"; "ru-RU" ]
for cultureName in cultureNames do
    let value = true
    let culture = CultureInfo.CreateSpecificCulture cultureName 
    let formatter = BooleanFormatter culture

    String.Format(formatter, "Value for '{0}': {1}", culture.Name, value)
    |> printfn "%s"

// The example displays the following output:
//       Value for '': True
//       Value for 'en-US': True
//       Value for 'fr-FR': vrai
//       Value for 'ru-RU': верно
// </Snippet5>
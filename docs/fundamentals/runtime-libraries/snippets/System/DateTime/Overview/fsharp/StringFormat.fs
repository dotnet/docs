module StringFormat

open System

let showDefaultToString () =
    // <Snippet1>
    let date1 = DateTime(2008, 3, 1, 7, 0, 0)
    printfn $"{date1.ToString()}"
    // For en-US culture, displays 3/1/2008 7:00:00 AM
    // </Snippet1>

let showCultureSpecificToString () =
    // <Snippet2>
    let date1 = DateTime(2008, 3, 1, 7, 0, 0)
    printfn $"""{date1.ToString(System.Globalization.CultureInfo.CreateSpecificCulture "fr-FR")}"""
    // Displays 01/03/2008 07:00:00
    // </Snippet2>

let showDefaultFullDateAndTime () =
    // <Snippet3>
    let date1 = DateTime(2008, 3, 1, 7, 0, 0)
    printfn $"""{date1.ToString "F"}"""
    // Displays Saturday, March 01, 2008 7:00:00 AM
    // </Snippet3>

let showCultureSpecificFullDateAndTime () =
    // <Snippet4>
    let date1 = DateTime(2008, 3, 1, 7, 0, 0)
    printfn $"""{date1.ToString("F", new System.Globalization.CultureInfo "fr-FR")}"""
    // Displays samedi 1 mars 2008 07:00:00
    // </Snippet4>

let showIso8601Format () =
    // <Snippet5>
    let date1 = DateTime(2008, 3, 1, 7, 0, 0, DateTimeKind.Utc)
    printfn $"""{date1.ToString("yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture)}"""
    // Displays 2008-03-01T07:00:00+00:00
    // </Snippet5>

showDefaultToString ()
showCultureSpecificToString ()
showDefaultFullDateAndTime ()
showCultureSpecificFullDateAndTime ()
showIso8601Format ()
module case2.fs
// <Snippet17>
open System
open System.Globalization
open System.Threading

let disallowed = "file"

let isAccessAllowed (resource: string) =
    let cultures = 
        [| CultureInfo.CreateSpecificCulture "en-US"
           CultureInfo.CreateSpecificCulture "tr-TR" |]
    let index = resource.IndexOfAny [| '\\'; '/' |]
    let scheme =
        if index > 0 then
            resource.Substring(0, index - 1)
        else 
            null

    // Change the current culture and perform the comparison.
    for culture in cultures do
        Thread.CurrentThread.CurrentCulture <- culture
        printfn $"Culture: {CultureInfo.CurrentCulture.DisplayName}"
        printfn $"{resource}"
        printfn $"Access allowed: {String.Equals(disallowed, scheme, StringComparison.CurrentCultureIgnoreCase) |> not}"
        printfn ""
        
isAccessAllowed @"FILE:\\\c:\users\user001\documents\FinancialInfo.txt"
// The example displays the following output:
//       Culture: English (United States)
//       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
//       Access allowed: False
//
//       Culture: Turkish (Turkey)
//       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
//       Access allowed: True
// </Snippet17>

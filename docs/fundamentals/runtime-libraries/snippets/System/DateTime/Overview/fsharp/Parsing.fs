module Parsing

open System

let parseStandardFormats () =
    // <Snippet1>
    System.Threading.Thread.CurrentThread.CurrentCulture <-
        System.Globalization.CultureInfo.CreateSpecificCulture "en-GB"

    let date1 = DateTime(2013, 6, 1, 12, 32, 30)
    let badFormats = ResizeArray<String>()

    printfn "%-37s %-19s\n" "Date String" "Date"
    for dateString in date1.GetDateTimeFormats() do
        match DateTime.TryParse dateString with
        | true, parsedDate ->
            printfn $"%-37s{dateString} %-19O{parsedDate}\n" 
        | _ ->
            badFormats.Add dateString

    // Display strings that could not be parsed.
    if badFormats.Count > 0 then
        printfn "\nStrings that could not be parsed: "
        for badFormat in badFormats do
            printfn $"   {badFormat}"
    // Press "Run" to see the output.
    // </Snippet1>

let parseCustomFormats () =
    // <Snippet2>
    let formats = [| "yyyyMMdd"; "HHmmss" |]
    let dateStrings = 
        [ "20130816"; "20131608"; "  20130816   "
          "115216"; "521116"; "  115216  " ]

    for dateString in dateStrings do
        match DateTime.TryParseExact(dateString, formats, null,
                                    System.Globalization.DateTimeStyles.AllowWhiteSpaces |||
                                    System.Globalization.DateTimeStyles.AdjustToUniversal) with
        | true, parsedDate ->
            printfn $"{dateString} --> {parsedDate:g}"
        | _ ->
            printfn $"Cannot convert {dateString}"

    // The example displays the following output:
    //       20130816 --> 8/16/2013 12:00 AM
    //       Cannot convert 20131608
    //         20130816    --> 8/16/2013 12:00 AM
    //       115216 --> 4/22/2013 11:52 AM
    //       Cannot convert 521116
    //         115216   --> 4/22/2013 11:52 AM
    // </Snippet2>

let parseISO8601 () =
    // <Snippet3>
    let iso8601String = "20080501T08:30:52Z"
    let dateISO8602 = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture)

    printfn $"{iso8601String} --> {dateISO8602:g}"
    // </Snippet3>

parseStandardFormats ()
parseCustomFormats ()
parseISO8601 ()
module Persistence

open System
open System.Collections.Generic
open System.Globalization
open System.IO
open System.Runtime.Serialization
open System.Runtime.Serialization.Formatters.Binary
open System.Threading
open System.Xml.Serialization
open DateTimeExtensions

let filenameTxt = @".\BadDates.txt"

// <Snippet1>
let saveLocalDatesAsString () =
    let dates = 
        [ DateTime(2014, 6, 14, 6, 32, 0)
          DateTime(2014, 7, 10, 23, 49, 0)
          DateTime(2015, 1, 10, 1, 16, 0)
          DateTime(2014, 12, 20, 21, 45, 0)
          DateTime(2014, 6, 2, 15, 14, 0) ]

    printfn $"Current Time Zone: {TimeZoneInfo.Local.DisplayName}"
    printfn $"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:"

    let output =
        [ for date in dates do
            printfn $"{date}"
            string date ]
        |> String.concat "|"

    use sw = new StreamWriter(filenameTxt)
    sw.Write output
    printfn "Saved dates..."

let restoreLocalDatesFromString () =
    TimeZoneInfo.ClearCachedData()
    printfn $"Current Time Zone: {TimeZoneInfo.Local.DisplayName}"
    Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture "en-GB"

    use sr = new StreamReader(filenameTxt)
    let inputValues = 
        sr.ReadToEnd().Split('|', StringSplitOptions.RemoveEmptyEntries)

    printfn $"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:"

    for inputValue in inputValues do
        match DateTime.TryParse inputValue with
        | true, dateValue ->
            printfn $"'{inputValue}' --> {dateValue:f}"
        | _ ->
            printfn $"Cannot parse '{inputValue}'"

    printfn "Restored dates..."

let persistAsLocalStrings () =
    saveLocalDatesAsString ()
    restoreLocalDatesFromString ()

// When saved on an en-US system, the example displays the following output:
//       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
//       The dates on an en-US system:
//       Saturday, June 14, 2014 6:32 AM
//       Thursday, July 10, 2014 11:49 PM
//       Saturday, January 10, 2015 1:16 AM
//       Saturday, December 20, 2014 9:45 PM
//       Monday, June 02, 2014 3:14 PM
//       Saved dates...
//
// When restored on an en-GB system, the example displays the following output:
//       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
//       The dates on an en-GB system:
//       Cannot parse //6/14/2014 6:32:00 AM//
//       //7/10/2014 11:49:00 PM// --> 07 October 2014 23:49
//       //1/10/2015 1:16:00 AM// --> 01 October 2015 01:16
//       Cannot parse //12/20/2014 9:45:00 PM//
//       //6/2/2014 3:14:00 PM// --> 06 February 2014 15:14
//       Restored dates...
// </Snippet1>

// <Snippet2>
let saveDatesAsInvariantStrings () =
    let dates = 
        [ DateTime(2014, 6, 14, 6, 32, 0)
          DateTime(2014, 7, 10, 23, 49, 0)
          DateTime(2015, 1, 10, 1, 16, 0)
          DateTime(2014, 12, 20, 21, 45, 0)
          DateTime(2014, 6, 2, 15, 14, 0) ]

    printfn $"Current Time Zone: {TimeZoneInfo.Local.DisplayName}"
    printfn $"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:"

    let output =
        [ for date in dates do
            printfn $"{date:f}"
            date.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture) ]
        |> String.concat "|"

    use sw = new StreamWriter(filenameTxt)
    sw.Write output
    printfn "Saved dates..."

let restoreDatesAsInvariantStrings () =
    TimeZoneInfo.ClearCachedData()
    printfn $"Current Time Zone: {TimeZoneInfo.Local.DisplayName}"
    Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture "en-GB"
    
    use sr = new StreamReader(filenameTxt)
    let inputValues = 
        sr.ReadToEnd().Split('|', StringSplitOptions.RemoveEmptyEntries)

    printfn $"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:"

    for inputValue in inputValues do
        match DateTime.TryParseExact(inputValue, "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind) with
        | true, dateValue ->
            printfn $"'{inputValue}' --> {dateValue.ToLocalTime():f}"
        | _ ->
            printfn $"Cannot parse '{inputValue}'"

    printfn "Restored dates..."

let persistAsInvariantStrings () =
    saveDatesAsInvariantStrings ()
    restoreDatesAsInvariantStrings ()

// When saved on an en-US system, the example displays the following output:
//       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
//       The dates on an en-US system:
//       Saturday, June 14, 2014 6:32 AM
//       Thursday, July 10, 2014 11:49 PM
//       Saturday, January 10, 2015 1:16 AM
//       Saturday, December 20, 2014 9:45 PM
//       Monday, June 02, 2014 3:14 PM
//       Saved dates...
//
// When restored on an en-GB system, the example displays the following output:
//       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
//       The dates on an en-GB system:
//       '2014-06-14T13:32:00.0000000Z' --> 14 June 2014 14:32
//       '2014-07-11T06:49:00.0000000Z' --> 11 July 2014 07:49
//       '2015-01-10T09:16:00.0000000Z' --> 10 January 2015 09:16
//       '2014-12-21T05:45:00.0000000Z' --> 21 December 2014 05:45
//       '2014-06-02T22:14:00.0000000Z' --> 02 June 2014 23:14
//       Restored dates...
// </Snippet2>

let filenameInts = @".\IntDates.bin"

// <Snippet3>
let saveDatesAsInts () =
    let dates = 
        [ DateTime(2014, 6, 14, 6, 32, 0)
          DateTime(2014, 7, 10, 23, 49, 0)
          DateTime(2015, 1, 10, 1, 16, 0)
          DateTime(2014, 12, 20, 21, 45, 0)
          DateTime(2014, 6, 2, 15, 14, 0) ]

    printfn $"Current Time Zone: {TimeZoneInfo.Local.DisplayName}"
    printfn $"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:"
    let ticks =
        [| for date in dates do
            printfn $"{date:f}"
            date.ToUniversalTime().Ticks |]
    use fs = new FileStream(filenameInts, FileMode.Create)
    use bw = new BinaryWriter(fs)
    bw.Write ticks.Length

    for tick in ticks do
        bw.Write tick

    printfn "Saved dates..."

let restoreDatesAsInts () =
    TimeZoneInfo.ClearCachedData()
    printfn $"Current Time Zone: {TimeZoneInfo.Local.DisplayName}"
    Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture "en-GB"
    use fs = new FileStream(filenameInts, FileMode.Open)
    use br = new BinaryReader(fs)

    try
        let items = br.ReadInt32()
        let dates =
            [| for _ in 0..items do
                let ticks = br.ReadInt64()
                DateTime(ticks).ToLocalTime() |]

        printfn $"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:"
        for value in dates do
            printfn $"{value:f}"
    with 
    | :? EndOfStreamException ->
        printfn "File corruption detected. Unable to restore data..."
    | :? IOException ->
        printfn "Unspecified I/O error. Unable to restore data..."
    // Thrown during array initialization.
    | :? OutOfMemoryException ->
        printfn"File corruption detected. Unable to restore data..."

    printfn "Restored dates..."

let persistAsIntegers () =
    saveDatesAsInts ()
    restoreDatesAsInts ()

// When saved on an en-US system, the example displays the following output:
//       Current Time Zone: (UTC-08:00) Pacific Time (US & Canada)
//       The dates on an en-US system:
//       Saturday, June 14, 2014 6:32 AM
//       Thursday, July 10, 2014 11:49 PM
//       Saturday, January 10, 2015 1:16 AM
//       Saturday, December 20, 2014 9:45 PM
//       Monday, June 02, 2014 3:14 PM
//       Saved dates...
//
// When restored on an en-GB system, the example displays the following output:
//       Current Time Zone: (UTC) Dublin, Edinburgh, Lisbon, London
//       The dates on an en-GB system:
//       14 June 2014 14:32
//       11 July 2014 07:49
//       10 January 2015 09:16
//       21 December 2014 05:45
//       02 June 2014 23:14
//       Restored dates...
// </Snippet3>

let filenameXml = @".\LeapYears.xml"

// <Snippet4>
let persistAsXML () =
    // Serialize the data.
    let leapYears =
        [| for year in 2000..4..2100 do
            if DateTime.IsLeapYear year then
                DateTime(year, 2, 29) |]

    let serializer = XmlSerializer(leapYears.GetType())
    use sw = new StreamWriter(filenameXml)

    try
        serializer.Serialize(sw, leapYears)
    with :? InvalidOperationException as e ->
        printfn $"{e.InnerException.Message}"

    // Deserialize the data.
    use fs = new FileStream(filenameXml, FileMode.Open)
        
    let deserializedDates = serializer.Deserialize fs :?> DateTime []

    // Display the dates.
    printfn $"Leap year days from 2000-2100 on an {Thread.CurrentThread.CurrentCulture.Name} system:"
    
    let mutable nItems = 0
    for dat in deserializedDates do
        printf $"   {dat:d}     "
        nItems <- nItems + 1
        if nItems % 5 = 0 then
            printfn ""

// The example displays the following output:
//    Leap year days from 2000-2100 on an en-GB system:
//       29/02/2000       29/02/2004       29/02/2008       29/02/2012       29/02/2016
//       29/02/2020       29/02/2024       29/02/2028       29/02/2032       29/02/2036
//       29/02/2040       29/02/2044       29/02/2048       29/02/2052       29/02/2056
//       29/02/2060       29/02/2064       29/02/2068       29/02/2072       29/02/2076
//       29/02/2080       29/02/2084       29/02/2088       29/02/2092       29/02/2096
// </Snippet4>

let filenameBin = @".\Dates.bin"

File.Delete filenameTxt
persistAsLocalStrings ()
File.Delete filenameTxt
persistAsInvariantStrings ()
File.Delete filenameTxt

File.Delete filenameInts
persistAsIntegers ()
File.Delete filenameInts

File.Delete filenameXml
persistAsXML ()
File.Delete filenameXml

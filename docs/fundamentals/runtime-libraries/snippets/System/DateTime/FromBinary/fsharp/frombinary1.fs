// <Snippet1>
open System

let localDate = DateTime(2010, 3, 14, 2, 30, 0, DateTimeKind.Local)
let binLocal = localDate.ToBinary()
if TimeZoneInfo.Local.IsInvalidTime localDate then
    printfn $"{localDate} is an invalid time in the {TimeZoneInfo.Local.StandardName} zone."

let localDate2 = DateTime.FromBinary binLocal
printfn $"{localDate} = {localDate2}: {localDate.Equals localDate2}"

// The example displays the following output:
//    3/14/2010 2:30:00 AM is an invalid time in the Pacific Standard Time zone.
//    3/14/2010 2:30:00 AM = 3/14/2010 3:30:00 AM: False
// </Snippet1>
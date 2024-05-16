module Calender

open System

let thaiBuddistEra () =
    // <Snippet1>
    let thTH = System.Globalization.CultureInfo "th-TH"
    let value = DateTime(2016, 5, 28)

    printfn $"{value.ToString thTH}"

    thTH.DateTimeFormat.Calendar <- System.Globalization.GregorianCalendar()

    printfn $"{value.ToString thTH}"

    // The example displays the following output:
    //       28/5/2559 0:00:00
    //       28/5/2016 0:00:00
    // </Snippet1>

let thaiBuddhistEraParse () =
    // <Snippet2>
    let thTH = System.Globalization.CultureInfo "th-TH"
    let value = DateTime.Parse("28/05/2559", thTH)
    printfn $"{value.ToString thTH}"

    thTH.DateTimeFormat.Calendar <- System.Globalization.GregorianCalendar()
    printfn $"{value.ToString thTH}"

    // The example displays the following output:
    //       28/5/2559 0:00:00
    //       28/5/2016 0:00:00
    // </Snippet2>

let instantiateCalendar () =
    // <Snippet3>
    let thTH = System.Globalization.CultureInfo "th-TH"
    let dat = DateTime(2559, 5, 28, thTH.DateTimeFormat.Calendar)
    
    printfn $"""Thai Buddhist era date: {dat.ToString("d", thTH)}"""
    printfn $"Gregorian date:   {dat:d}"

    // The example displays the following output:
    //       Thai Buddhist Era Date:  28/5/2559
    //       Gregorian Date:     28/05/2016
    // </Snippet3>

let calendarFields () =
    // <Snippet4>
    let thTH = System.Globalization.CultureInfo "th-TH"
    let cal = thTH.DateTimeFormat.Calendar
    let dat = DateTime(2559, 5, 28, cal)
    printfn "Using the Thai Buddhist Era calendar:"
    printfn $"""Date: {dat.ToString("d", thTH)}"""
    printfn $"Year: {cal.GetYear dat}"
    printfn $"Leap year: {cal.IsLeapYear(cal.GetYear dat)}\n"

    printfn "Using the Gregorian calendar:"
    printfn $"Date: {dat:d}"
    printfn $"Year: {dat.Year}"
    printfn $"Leap year: {DateTime.IsLeapYear dat.Year}"

    // The example displays the following output:
    //       Using the Thai Buddhist Era calendar
    //       Date :   28/5/2559
    //       Year: 2559
    //       Leap year :   True
    //
    //       Using the Gregorian calendar
    //       Date :   28/05/2016
    //       Year: 2016
    //       Leap year :   True
    // </Snippet4>

let calculateWeeks () =
    // <Snippet5>
    let thTH = System.Globalization.CultureInfo "th-TH"
    let thCalendar = thTH.DateTimeFormat.Calendar
    let dat = DateTime(1395, 8, 18, thCalendar)
    printfn "Using the Thai Buddhist Era calendar:"
    printfn $"""Date: {dat.ToString("d", thTH)}"""
    printfn $"Day of Week: {thCalendar.GetDayOfWeek dat}"
    printfn $"Week of year: {thCalendar.GetWeekOfYear(dat, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday)}\n"

    let greg = System.Globalization.GregorianCalendar()
    printfn "Using the Gregorian calendar:"
    printfn $"Date: {dat:d}"
    printfn $"Day of Week: {dat.DayOfWeek}"
    printfn $"Week of year: {greg.GetWeekOfYear(dat, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday)}"

    // The example displays the following output:
    //       Using the Thai Buddhist Era calendar
    //       Date :  18/8/1395
    //       Day of Week: Sunday
    //       Week of year: 34
    //
    //       Using the Gregorian calendar
    //       Date :  18/08/0852
    //       Day of Week: Sunday
    //       Week of year: 34
    // </Snippet5>


thaiBuddistEra ()
thaiBuddhistEraParse ()
instantiateCalendar ()
calendarFields ()
calculateWeeks ()
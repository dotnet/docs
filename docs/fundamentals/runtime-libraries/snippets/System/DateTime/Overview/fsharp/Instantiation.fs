module Instantiation

open System

let instantiateWithConstructor () =
    // <Snippet1>
    let date1 = DateTime(2008, 5, 1, 8, 30, 52)
    printfn $"{date1}" 
    // </Snippet1>

let instantiateWithReturnValue () =
    // <Snippet3>
    let date1 = DateTime.Now
    let date2 = DateTime.UtcNow
    let date3 = DateTime.Today
    // </Snippet3>
    ()

let instantiateFromString () =
    // <Snippet4>
    let dateString = "5/1/2008 8:30:52 AM"
    let date1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture)
    let iso8601String = "20080501T08:30:52Z"
    let dateISO8602 = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture)
    // </Snippet4>
    ()

let instantiateUsingDftCtor () =
    // <Snippet5>
    let dat1 = DateTime()

    // The following method call displays 1/1/0001 12:00:00 AM.
    printfn $"{dat1.ToString System.Globalization.CultureInfo.InvariantCulture}"
    
    // The following method call displays True.
    printfn $"{dat1.Equals DateTime.MinValue}"
    // </Snippet5>

instantiateWithConstructor ()
instantiateWithReturnValue ()
instantiateFromString ()
instantiateUsingDftCtor ()
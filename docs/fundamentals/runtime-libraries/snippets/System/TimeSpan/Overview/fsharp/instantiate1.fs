module instantiate1

open System

let implicit () =
    // <Snippet2>
    let interval = TimeSpan()
    printfn $"{interval.Equals TimeSpan.Zero}"    // Displays "True".
    // </Snippet2>
   
let explicit () =
    // <Snippet3>
    let interval = TimeSpan(2, 14, 18)
    printfn $"{interval}"              
    
    // Displays "02:14:18".
    // </Snippet3>
   
let timeSpanOperation () =
    // <Snippet4>
    let departure = DateTime(2010, 6, 12, 18, 32, 0)
    let arrival = DateTime(2010, 6, 13, 22, 47, 0)
    let travelTime = arrival - departure  
    printfn $"{arrival} - {departure} = {travelTime}"
    
    // The example displays the following output:
    //       6/13/2010 10:47:00 PM - 6/12/2010 6:32:00 PM = 1.04:15:00
    // </Snippet4>

let parse () =
    // <Snippet5>
    let values = [| "12"; "31."; "5.8:32:16"; "12:12:15.95"; ".12" |]
    for value in values do
        try
            let ts = TimeSpan.Parse value
            printfn $"'{value}' --> {ts}"
        with 
        | :? FormatException ->
            printfn $"Unable to parse '{value}'"
        | :? OverflowException ->
            printfn $"'{value}' is outside the range of a TimeSpan."
    
    // The example displays the following output:
    //       '12' --> 12.00:00:00
    //       Unable to parse '31.'
    //       '5.8:32:16' --> 5.08:32:16
    //       '12:12:15.95' --> 12:12:15.9500000
    //       Unable to parse '.12'  
    // </Snippet5>    


implicit ()
printfn ""
explicit ()
printfn ""
timeSpanOperation ()
printfn ""
parse ()
printfn ""

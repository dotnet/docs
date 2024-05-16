module formatoverload1

// <Snippet8>
open System

let dat = DateTime(2012, 1, 17, 9, 30, 0) 
let city = "Chicago"
let temp = -16
String.Format("At {0} in {1}, the temperature was {2} degrees.", dat, city, temp)
|> printfn "%s"
// The example displays output like the following:
//    At 1/17/2012 9:30:00 AM in Chicago, the temperature was -16 degrees.   
// </Snippet8>
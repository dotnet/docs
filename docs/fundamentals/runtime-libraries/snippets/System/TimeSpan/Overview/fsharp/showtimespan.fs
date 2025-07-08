module showtimespan

// <Snippet2>
open System

let interval = DateTime.Now - DateTime.Now.Date
printfn $"Elapsed Time Today: {interval:d} hours."
// The example displays the following output:
//       Elapsed Time Today: 01:40:52.2524662 hours.
// </Snippet2>
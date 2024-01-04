module Array1

open System

// <Snippet10>
let cities = 
    [| "Atlanta"; "Boston"; "Chicago"; "Detroit";
       "Fort Wayne"; "Greensboro"; "Honolulu"; "Indianapolis";
       "Jersey City"; "Kansas City"; "Los Angeles";
       "Milwaukee"; "New York"; "Omaha"; "Philadelphia";
       "Raleigh"; "San Francisco"; "Tulsa"; "Washington" |]

let rnd = Random()

let index = rnd.Next(0,cities.Length)

printfn "Today's city of the day: %s" cities.[index]

// The example displays output like the following:
//   Today's city of the day: Honolulu
// </Snippet10>

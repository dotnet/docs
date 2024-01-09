module comparisons1

// <Snippet1>
open System

let v1 = Version(2, 0)
let v2 = Version "2.1"

printf $"Version {v1} is "

match v1.CompareTo v2 with
| 0 -> printf "the same as"
| 1 -> printf "later than"
| _ -> printf "earlier than"

printf $" Version {v2}."
// The example displays the following output:
//       Version 2.0 is earlier than Version 2.1.
// </Snippet1>      
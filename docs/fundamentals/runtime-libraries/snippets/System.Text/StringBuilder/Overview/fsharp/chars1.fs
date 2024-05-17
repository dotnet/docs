module chars1
// <Snippet7>
open System
open System.Globalization
open System.Text

let rnd = Random()
let sb = new StringBuilder()

// Generate 10 random numbers and store them in a StringBuilder.
for _ = 0 to 9 do
    rnd.Next().ToString "N5" |> sb.Append |> ignore

printfn "The original string:"
printfn $"{sb}"

// Decrease each number by one.
for i = 0 to sb.Length - 1 do
    if Char.GetUnicodeCategory(sb[i]) = UnicodeCategory.DecimalDigitNumber then
        let number = Char.GetNumericValue sb.[i] |> int
        let number = number - 1
        let number = if number < 0 then 9 else number
        sb.[i] <- number.ToString()[0]

printfn "\nThe new string:"
printfn $"{sb}"

// The example displays the following output:
//    The original string:
//    1,457,531,530.00000940,522,609.000001,668,113,564.000001,998,992,883.000001,792,660,834.00
//    000101,203,251.000002,051,183,075.000002,066,000,067.000001,643,701,043.000001,702,382,508
//    .00000
//
//    The new string:
//    0,346,420,429.99999839,411,598.999990,557,002,453.999990,887,881,772.999990,681,559,723.99
//    999090,192,140.999991,940,072,964.999991,955,999,956.999990,532,690,932.999990,691,271,497
//    .99999
// </Snippet7>

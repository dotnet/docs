module Long1

open System

// <Snippet14>
[<Literal>]
let ONE_TENTH = 922337203685477581L

let rnd = Random()

let count =
    // Generate 20 million random long integers.
    Array.init 20000000 (fun _ -> rnd.NextDouble() * (float Int64.MaxValue) |> int64 )
    |> Array.countBy (fun x -> x / ONE_TENTH) // Categorize and count random numbers.
    |> Array.map snd

// Display breakdown by range.
printfn "%28s %32s   %7s\n" "Range" "Count" "Pct."
for i = 0 to 9 do
    let r1 = int64 i * ONE_TENTH
    let r2 = if i < 9 then r1 + ONE_TENTH - 1L else Int64.MaxValue
    printfn $"{r1,25:N0}-{r2,25:N0}  {count.[i],8:N0}   {float count.[i] / 20000000.0,7:P2}"

// The example displays output like the following:
//                           Range                            Count      Pct.
//
//                            0-  922,337,203,685,477,580  1,996,148    9.98 %
//      922,337,203,685,477,581-1,844,674,407,370,955,161  2,000,293   10.00 %
//    1,844,674,407,370,955,162-2,767,011,611,056,432,742  2,000,094   10.00 %
//    2,767,011,611,056,432,743-3,689,348,814,741,910,323  2,000,159   10.00 %
//    3,689,348,814,741,910,324-4,611,686,018,427,387,904  1,999,552   10.00 %
//    4,611,686,018,427,387,905-5,534,023,222,112,865,485  1,998,248    9.99 %
//    5,534,023,222,112,865,486-6,456,360,425,798,343,066  2,000,696   10.00 %
//    6,456,360,425,798,343,067-7,378,697,629,483,820,647  2,001,637   10.01 %
//    7,378,697,629,483,820,648-8,301,034,833,169,298,228  2,002,870   10.01 %
//    8,301,034,833,169,298,229-9,223,372,036,854,775,807  2,000,303   10.00 %
// </Snippet14>

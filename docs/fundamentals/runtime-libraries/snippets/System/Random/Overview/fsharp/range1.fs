module Range1

open System

// <Snippet15>
let rnd = Random()
for i = 1 to 15 do 
    printf "%3i    " (rnd.Next(-10, 11))
    if i % 5 = 0 then printfn ""
// The example displays output like the following:
//        -2     -5     -1     -2     10
//        -3      6     -4     -8      3
//        -7     10      5     -2      4
// </Snippet15>

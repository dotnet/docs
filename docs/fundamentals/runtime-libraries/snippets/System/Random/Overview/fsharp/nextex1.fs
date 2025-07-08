module NextEx1

open System

// <Snippet6>
let rnd = Random()
for i = 0 to 9 do 
    printf "%3i   " (rnd.Next(-10, 11))

// The example displays output like the following:
//    2     9    -3     2     4    -7    -3    -8    -8     5
// </Snippet6>

module chptrctor_null

// <Snippet5>
#nowarn "9"
open System

let chars = [| 'a'; 'b'; 'c'; 'd'; '\000'; 'A'; 'B'; 'C'; 'D'; '\000' |]
let s =
    use chPtr = fixed chars
    String(chPtr, 0, chars.Length)

for ch in s do
    printf $"{uint16 ch:X4} "
printfn ""

let s2 = 
    use chPtr = fixed chars
    String chPtr    

for ch in s2 do
    printf $"{uint16 ch:X4} "
printfn ""  
// The example displays the following output:
//       0061 0062 0063 0064 0000 0041 0042 0043 0044 0000
//       0061 0062 0063 0064
// </Snippet5>
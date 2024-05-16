module ptrctor_null

// <Snippet6>
#nowarn "9"
open System

let bytes = 
    [| 0x61y; 0x62y; 0x063y; 0x064y; 0x00y; 0x41y; 0x42y; 0x43y; 0x44y; 0x00y |]

let s =
    use bytePtr = fixed bytes
    String(bytePtr, 0, bytes.Length)

for ch in s do
    printf $"{uint16 ch:X4} "
printfn ""

let s2 =
    use bytePtr = fixed bytes
    String bytePtr         

for ch in s do
    printf $"{uint16 ch:X4} "
printfn ""
// The example displays the following output:
//       0061 0062 0063 0064 0000 0041 0042 0043 0044 0000
//       0061 0062 0063 0064
// </Snippet6>
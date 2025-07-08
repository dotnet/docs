module array1

// <Snippet6>
let values = [| 1; 2; 4; 8; 16; 32; 64; 128 |]
printfn $"{values}"

let list = ResizeArray values
printfn $"{list}"

// The example displays the following output:
//       System.Int32[]
//       System.Collections.Generic.List`1[System.Int32]
// </Snippet6>
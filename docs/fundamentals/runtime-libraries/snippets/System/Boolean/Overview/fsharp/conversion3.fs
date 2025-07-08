module conversion3

// <Snippet8>
open System

let flag = true

let byteValue = Convert.ToByte flag
printfn $"{flag} -> {byteValue}"

let sbyteValue = Convert.ToSByte flag
printfn $"{flag} -> {sbyteValue}"

let dblValue = Convert.ToDouble flag
printfn $"{flag} -> {dblValue}"

let intValue = Convert.ToInt32(flag);
printfn $"{flag} -> {intValue}"

// The example displays the following output:
//       True -> 1
//       True -> 1
//       True -> 1
//       True -> 1
// </Snippet8>
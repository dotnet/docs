module size1

// <Snippet14>
#nowarn "9" "51"
open FSharp.NativeInterop

[<Struct>]
type BoolStruct =
   val flag1: bool
   val flag2: bool
   val flag3: bool
   val flag4: bool
   val flag5: bool

let inline nint addr = NativePtr.toNativeInt addr

let mutable b = BoolStruct()
let addr = &&b

printfn $"Size of BoolStruct: {sizeof<BoolStruct>}"
printfn "Field offsets:"
printfn $"   flag1: {nint &&b.flag1 - nint addr}"
printfn $"   flag2: {nint &&b.flag2 - nint addr}"
printfn $"   flag3: {nint &&b.flag3 - nint addr}"
printfn $"   flag4: {nint &&b.flag4 - nint addr}"
printfn $"   flag5: {nint &&b.flag5 - nint addr}"

// The example displays the following output:
//       Size of BoolStruct: 5
//       Field offsets:
//          flag1: 0
//          flag1: 1
//          flag1: 2
//          flag1: 3
//          flag1: 4
// </Snippet14> 
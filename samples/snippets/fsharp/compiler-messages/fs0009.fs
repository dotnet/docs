(* use of unverifiable function *)
let n: nativeptr<bool> = NativeInterop.NativePtr.stackalloc 1

(* use of the fixed expression *)
type R = { Address: int }

let useFixed (r: R) = 
    use f = fixed &r.Address
    ()

(* use of LayoutKind.Explicit *)
open System.Runtime.InteropServices

[<Struct; StructLayout(LayoutKind.Explicit)>]
type EmptyStruct = 
    struct end

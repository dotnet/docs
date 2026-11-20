// <Literals>
let [<Literal>] bytesInKB = 2f ** 10f
let [<Literal>] bytesInMB = bytesInKB * bytesInKB
let [<Literal>] bytesInGB = 1 <<< 30
let [<Literal>] customBitMask = 0b01010101uy
let [<Literal>] inverseBitMask = ~~~ customBitMask
// </Literals>

printfn "Bytes in KB: %f" bytesInKB
printfn "Bytes in MB: %f" bytesInMB
printfn "Bytes in GB: %d" bytesInGB
printfn "Custom bit mask: %d" customBitMask
printfn "Inverse bit mask: %d" inverseBitMask

// <Enums>
type MyEnum = 
    | A = (1 <<< 5)
    | B = (17 * 45 % 13)
    | C = bytesInGB
// </Enums>

printfn "MyEnum.A: %d" (int MyEnum.A)
printfn "MyEnum.B: %d" (int MyEnum.B)
printfn "MyEnum.C: %d" (int MyEnum.C)

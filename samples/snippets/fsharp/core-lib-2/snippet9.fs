let isDone = false
printfn "Printing Boolean values: %b %b" isDone (not isDone)
let s1,s2 = "test1", @"C:\test2"
printfn "Printing strings (note literal printing of string with special character): %s%s" s1 s2
let i1, i2 = -123, 1891
printfn "Printing an integer in decimal form, with and without a width: %d %10d" i1 i2
printfn "Printing an integer in lowercase hexadecimal: %x or 0x%x" i1 i2
printfn "Printing as an unsigned integer: %u %u" i1 i2
printfn "Printing an integer as uppercase hexadecimal: %X or 0x%X" i1 i2
printfn "Printing as an octal integer: %o %o" i1 i2
printfn "Printing in columns."
for i in 115 .. 59 .. 1000 do
    printfn "%10d%10d%10d%10d%10d" (10100015-i) (i-100) (115+i) (99992/i) (i-8388229)
let x1, x2 = 3.141592654, 6.022E23
printfn "Printing floating point numbers %e %e" x1 x2
printfn "Printing floating point numbers %E %E" x1 x2
printfn "Printing floating point numbers %f %f" x1 x2
printfn "Printing floating point numbers %F %F" x1 x2
printfn "Printing floating point numbers %g %G" x1 x2
printfn "Using the width and precision modifiers: %10.5e %10.3e" x1 x2

printfn "Using the flags:\nZero Pad:|%010d| Plus:|%+10d |LeftJustify:|%-10d| SpacePad:|% d|" 1001 1001 1001 1001
printfn "zero pad   | |+- both   | |- and ' ' | |' ' and 0 | | normal "
for i in -115 .. 17 .. 100 do
    printfn "|%010d| |%+-10d| |%- 10d| |% 010d| |%10d|" (80-i) (i+85) (100+i) (99992/i) (i-80)

let d = 0.124M
printfn "Decimal: %M" d

printfn "Print as object: %O %O %O %O" 12 1.1 "test" (fun x -> x + 1)

printfn "%A" [| 1; 2; 3 |]

printfn "Printing from a function (no args): %t" (fun writer -> writer.WriteLine("X"))

printfn "Printing from a function with arg: %a" (fun writer (value:int) -> writer.WriteLine("Printing {0}.", value)) 10
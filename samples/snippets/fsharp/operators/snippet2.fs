let append string1 string2 = string1 + "." + string2

let result1 = ("abc", "def") ||> append
printfn "(\"abc\", \"def\") ||> append gives %A" result1

let toUpper (string1:string) (string2:string) = string1.ToUpper(), string2.ToUpper()

let result2 = ("abc", "def")
               ||> toUpper
               ||> append

printfn "result2: %A" result2
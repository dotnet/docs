let append string1 string2 = string1 + "." + string2

let result1 = append <|| ("abc", "def")
printfn "append <|| (\"abc\", \"def\") gives %A" result1

let toUpper (string1:string) (string2:string) = string1.ToUpper(), string2.ToUpper()

// Reverse pipelines require parentheses.
let result2 = append <|| (toUpper <|| ("abc", "def"))

printfn "result2: %A" result2
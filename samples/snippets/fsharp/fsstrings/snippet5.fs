let string1 = String.init 10 (fun i -> i.ToString())
printfn "%s" string1
let string2 = String.init 26 (fun i ->
    sprintf "%c" (char (i + int 'A')))
printfn "%s" string2
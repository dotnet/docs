let ignoreInt (f: int) = ()

do ignoreInt (fun x -> x + 1)


let ignoreInt (i: int) = ()

do ignoreInt 1

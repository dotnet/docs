(* example of unboxing an obj to an unknown type *)
let unboxAndPrint x = 
    match x with
    | :? string as s -> printfn "%s" s
    | _ -> printfn "not a string"

(* fixing the error by giving `x` a known type *)
let unboxAndPrint (x: obj) = 
    match x with
    | :? string as s -> printfn "%s" s
    | _ -> printfn "not a string"

(* fixing the error by using `x` in a way the constrains the known types *)
let unboxAndPrint x = 
    printfn "%s" (string x)

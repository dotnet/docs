// A list of functions that transform
// integers. (int -> int)
let ops1 =
  [ (fun x -> x + 1), "add 1"
    (fun x -> x + 2), "add 2"
    (fun x -> x - 5), "subtract 5" ]

let ops2 =
  [ (fun x -> x + 1), "add 1"
    (fun x -> x * 5), "multiply by 5"
    (fun x -> x * x), "square" ]

// Compare scan and scanBack, which apply the
// operations in the opposite order.
let compareOpOrder ops x0 =
    let ops, opNames = List.unzip ops
    let xs1 = List.scan (fun x op -> op x) x0 ops
    let xs2 = List.scanBack (fun op x -> op x) ops x0

    printfn "Operations:"
    opNames |> List.iter (fun opName -> printf "%s  " opName)
    printfn ""

    // Print the intermediate results.
    let xs = List.zip xs1 (List.rev xs2)
    printfn "List.scan List.scanBack"
    for (x1, x2) in xs do
        printfn "%10d %10d" x1 x2
    printfn ""

compareOpOrder ops1 10
compareOpOrder ops2 10

    // An array of functions that transform 
    // integers. (int -> int)
    let ops1 =
     [| fun x -> x + 1
        fun x -> x + 2
        fun x -> x - 5 |]

    let ops2 =
     [| fun x -> x + 1
        fun x -> x * 5
        fun x -> x * x |]

    // Compare scan and scanBack, which apply the
    // operations in the opposite order.
    let compareOpOrder ops x0 =
        let xs1 = Array.scan (fun x op -> op x) x0 ops
        let xs2 = Array.scanBack (fun op x -> op x) ops x0

        // Print the intermediate results
        let xs = Array.zip xs1 (Array.rev xs2)
        for (x1, x2) in xs do
            printfn "%10d %10d" x1 x2
        printfn ""

    compareOpOrder ops1 10
    compareOpOrder ops2 10
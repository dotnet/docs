// Print all the lines read in from the console.
let printLines1 () =
    let mutable finished = false

    while not finished do
        match System.Console.ReadLine() with
        | null -> finished <- true
        | s -> printfn "line is: %s" s


// Attempt to wrap the printing loop into a
// sequence expression to delay the computation.
let printLines2 () =
    seq {
        let mutable finished = false
        // Compiler error:
        while not finished do
            match System.Console.ReadLine() with
            | null -> finished <- true
            | s -> s
    }

// You must use a reference cell instead.
let printLines3 () =
    seq {
        let mutable finished = false

        while not finished do
            match System.Console.ReadLine() with
            | null -> finished := true
            | s -> s
    }
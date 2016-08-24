let numbers = seq {1..20}
let evens = Seq.choose(fun x ->
                            match x with
                            | x when x%2=0 -> Some(x)
                            | _ -> None ) numbers
printfn "numbers = %A\n" numbers
printfn "evens = %A" evens
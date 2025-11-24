// try-with within collection expressions
let sum =
    [ for x in [0;1] do       
            try          
                yield 1              
                yield (10/x)    
                yield 100  
            with _ ->
                yield 1000 ]
    |> List.sum

printfn "Sum: %d" sum
printfn "Expected: 1112 (list is [1;1000;1;10;100])"

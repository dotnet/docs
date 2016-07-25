
    let data = [1;2;3;4]
    printfn "data = \n%A" data
    printfn "List.head data = %d" (List.head data)
    printfn "List.tail data = \n%A" (List.tail data)
    printfn "List.length data = %d" (List.length data)
    let consume data = 
        match data with 
        | 1::rest    -> printfn "matched a 1";       rest
        | 2::3::rest -> printfn "matched a 2 and 3"; rest 
        | [4]        -> printfn "matched a 4";       []
        | _          -> printfn "unexpected!";         [] 
    let data = consume data 
    let data = consume data 
    let data = consume data 
    printfn "At end of list? %b" (data = [])
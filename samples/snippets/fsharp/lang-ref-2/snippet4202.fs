
    type Delegate1 = delegate of int * char -> string

    let replicate n c = String.replicate n (string c)

    // An F# function value constructed from an unapplied let-bound function 
    let function1 = replicate

    // A delegate object constructed from an F# function value
    let delObject = new Delegate1(function1)

    // An F# function value constructed from an unapplied .NET member
    let functionValue = delObject.Invoke

    List.map (fun c -> functionValue(5,c)) ['a'; 'b'; 'c']
    |> List.iter (printfn "%s")

    // Or if you want to get back the same curried signature
    let replicate' n c =  delObject.Invoke(n,c)

    // You can pass a lambda expression as an argument to a function expecting a compatible delegate type
    // System.Array.ConvertAll takes an array and a converter delegate that transforms an element from
    // one type to another according to a specified function.
    let stringArray = System.Array.ConvertAll([|'a';'b'|], fun c -> replicate' 3 c)
    printfn "%A" stringArray
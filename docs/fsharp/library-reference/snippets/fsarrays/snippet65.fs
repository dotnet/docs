
    open System

    let array1 = [| "<>"; "&"; "&&"; "&&&"; "<"; ">"; "|"; "||"; "|||" |]
    printfn "Before sorting: "
    array1 |> printfn "%A"
    let sortFunction (string1:string) (string2:string) =
        if (string1.Length > string2.Length) then
           1
        else if (string1.Length < string2.Length) then
           -1
        else
            String.Compare(string1, string2)

    Array.sortWith sortFunction array1
    |> printfn "After sorting: \n%A"
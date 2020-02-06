let binary n =
    let rec generateBinary n =
        if (n / 2 = 0) then [n]
        else (n % 2) :: generateBinary (n / 2)
    generateBinary n |> List.rev |> Array.ofList

printfn "%A" (binary 1024)

let resultArray = Array.distinct (binary 1024)
printfn "%A" resultArray
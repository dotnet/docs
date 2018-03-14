let binary n =
    let rec generateBinary n =
        if (n / 2 = 0) then [n]
        else (n % 2) :: generateBinary (n / 2)
    generateBinary n |> List.rev

printfn "%A" (binary 1024)

let resultList = List.distinct (binary 1024)
printfn "%A" resultList
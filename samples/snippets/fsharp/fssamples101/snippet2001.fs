let data = "The quick brown fox jumps over the lazy dog"
let set =
    data.ToCharArray()
    |> Set.ofSeq
for c in set do
    printf "'%c' " c
printfn ""
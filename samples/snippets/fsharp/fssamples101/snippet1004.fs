let data = [(1,1,2001); (2,2,2004); (6,17,2009)]
let list1 =
    data |> List.map (fun (a,b,c) ->
        let date = new System.DateTime(c, a, b)
        date.ToString("F"))

for i in list1 do printfn "%A" i
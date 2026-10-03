// <Types>
type Person = {Name : string; Age : int}
let people = [ {Name = "Joe"; Age = 20} ; {Name = "Will"; Age = 30} ; {Name = "Joe"; Age = 51}]
// </Types>

// <Before>
let beforeThisFeature = 
    people 
    |> List.distinctBy (fun x -> x.Name)
    |> List.groupBy (fun x -> x.Age)
    |> List.map (fun (x,y) -> y)
    |> List.map (fun x -> x.Head.Name)
    |> List.sortBy (fun x -> x.ToString())
// </Before>

printfn "Before: %A" beforeThisFeature

// <After>
let possibleNow = 
    people 
    |> List.distinctBy _.Name
    |> List.groupBy _.Age
    |> List.map snd
    |> List.map _.Head.Name
    |> List.sortBy _.ToString()
// </After>

printfn "After: %A" possibleNow

// <Standalone>
let ageAccessor : Person -> int = _.Age
let getNameLength = _.Name.Length
// </Standalone>

printfn "Age accessor: %d" (ageAccessor people[0])
printfn "Name length: %d" (getNameLength people[0])

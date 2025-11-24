// Property shorthand examples
type Person = {Name : string; Age : int}
let people = [ {Name = "Joe"; Age = 20} ; {Name = "Will"; Age = 30} ; {Name = "Joe"; Age = 51}]

// Before F# 8
let beforeThisFeature = 
    people 
    |> List.distinctBy (fun x -> x.Name)
    |> List.groupBy (fun x -> x.Age)
    |> List.map (fun (x,y) -> y)
    |> List.map (fun x -> x.Head.Name)
    |> List.sortBy (fun x -> x.ToString())

printfn "Before: %A" beforeThisFeature

// With F# 8
let possibleNow = 
    people 
    |> List.distinctBy _.Name
    |> List.groupBy _.Age
    |> List.map snd
    |> List.map _.Head.Name
    |> List.sortBy _.ToString()

printfn "After: %A" possibleNow

// Standalone lambda functions
let ageAccessor : Person -> int = _.Age
let getNameLength = _.Name.Length

printfn "Age accessor: %d" (ageAccessor people[0])
printfn "Name length: %d" (getNameLength people[0])

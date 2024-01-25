module equalsoverride

// <Snippet6>
open System

type Person(name, id) =
    member _.Name = name
    member _.Id = id

    override _.Equals(obj) =
        match obj with
        | :? Person as personObj ->
            id.Equals personObj.Id
        | _ -> 
            false

    override _.GetHashCode() =
        id.GetHashCode()

let p1 = Person("John", "63412895")
let p2 = Person("Jack", "63412895")
printfn $"{p1.Equals p2}"
printfn $"{Object.Equals(p1, p2)}"
// The example displays the following output:
//       True
//       True
// </Snippet6>
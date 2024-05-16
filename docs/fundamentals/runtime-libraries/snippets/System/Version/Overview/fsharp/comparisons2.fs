module comparisons2

// <Snippet2>
open System

type VersionTime =
    | Earlier = -1
    | Same = 0
    | Later = 1

let showRelationship (v1: Version) (v2: Version) =
    printfn $"Relationship of {v1} to {v2}: {v1.CompareTo v2 |> enum<VersionTime>}" 

let v1 = Version(1, 1)
let v1a = Version "1.1.0"
showRelationship v1 v1a

let v1b = Version(1, 1, 0, 0)
showRelationship v1b v1a

// The example displays the following output:
//       Relationship of 1.1 to 1.1.0: Earlier
//       Relationship of 1.1.0.0 to 1.1.0: Later
// </Snippet2>
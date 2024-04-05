module Missing1a

// <Snippet1>
open System

type InfoModule(firstUse: DateTime) =
    let mutable ctr = 0

    member _.Increment() =
        ctr <- ctr + 1
        ctr
   
    member _.GetInitializationTime() =
        firstUse
// </Snippet1>
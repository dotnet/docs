module CompositionConsumer

// <CombineUse>
open Composition.Adapters
open Composition.Algorithms

let inline combineAll (batches: ^T list) : ^T =
    List.reduce (++) batches

let observations = combineAll [["temperature"]; ["pressure"; "humidity"]]
let summary = combineAll [(2, ["temperature"]); (3, ["pressure"; "humidity"])]

printfn "%A" observations
printfn "%A" summary
// ["temperature"; "pressure"; "humidity"]
// (5, ["temperature"; "pressure"; "humidity"])
// </CombineUse>

// <ContextUse>
let priced =
    (["catalogue price"], fun units -> decimal units * 12m)
        <*> (["validated quantity"], 3)

printfn "%A" priced
// (["catalogue price"; "validated quantity"], 36M)
// </ContextUse>

// <ReturnUse>
let oneBatch: string list = singleton "ready"
let oneOptional: string option = singleton "ready"
// ["ready"] and Some "ready"
// </ReturnUse>

[<EntryPoint>]
let main _ =
    if observations <> ["temperature"; "pressure"; "humidity"] ||
       summary <> (5, observations) then failwith "Combination"
    if priced <> (["catalogue price"; "validated quantity"], 36m) then
        failwith "Contextual application"
    let structPriced =
        struct (["catalogue price"], fun units -> decimal units * 12m)
            <*> struct (["validated quantity"], 3)
    if structPriced <> struct (fst priced, snd priced) then failwith "Struct context"
    if oneBatch <> ["ready"] || oneOptional <> Some "ready" then failwith "Return"
    0

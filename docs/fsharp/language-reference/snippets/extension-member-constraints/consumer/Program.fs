module StructuralConsumer

// <Paths>
open System.Numerics
open Structural.Adapters
open Structural.Algorithms

let complexRoute =
    [ Complex(0.0, 0.0); Complex(3.0, 4.0); Complex(6.0, 4.0) ]
let vectorRoute =
    [ Vector2(0.0f, 0.0f); Vector2(3.0f, 4.0f); Vector2(6.0f, 4.0f) ]

printn (pathLength complexRoute) // 8
printn (pathLength vectorRoute)  // 8
// </Paths>

// <Mapping>
let inline cleanNames values =
    map (fun (name: string) -> name.Trim().ToUpperInvariant()) values

let batch: string list = cleanNames [ " Ada "; " grace " ]
let optional: string option = cleanNames (Some " linus ")
let missing: string option = cleanNames (None: string option)
let lengths: int list = map String.length batch
let nested: int option list = map (map String.length) [ Some "abc"; None ]

printfn "%A; %A; %A" batch optional missing
printfn "%A; %A" lengths nested
// ["ADA"; "GRACE"]; Some "LINUS"; None
// [3; 5]; [Some 3; None]
// </Mapping>

[<EntryPoint>]
let main _ =
    if pathLength complexRoute <> 8.0 || pathLength vectorRoute <> 8.0 then
        failwith "Path lengths"
    if pathLength ([]: Complex list) <> 0.0 then failwith "Empty path"
    if pathLength [Vector2(2.0f, 3.0f)] <> 0.0 then failwith "Single point"
    if batch <> ["ADA"; "GRACE"] || optional <> Some "LINUS" || missing <> None then
        failwith "Shared mapping"
    if lengths <> [3; 5] || nested <> [Some 3; None] then failwith "Type-changing mapping"
    0

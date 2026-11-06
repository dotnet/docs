module ContractConsumer

open Contracts

// <DefaultConsumer>
type ReadyCheck() =
    interface IReadyCheck

let health = ReadyCheck() :> IHealthCheck
let status = health.Status()
// </DefaultConsumer>

// <ProtectedConsumer>
type Counter() =
    inherit CounterBase()
    member this.Project(offsets: int list) =
        offsets |> List.map (fun offset -> this.count + offset)

let counts = Counter().Project [ 1; 2; 3 ]
// </ProtectedConsumer>

if status <> "Ready" || counts <> [ 8; 9; 10 ] then failwith "Interop contracts"

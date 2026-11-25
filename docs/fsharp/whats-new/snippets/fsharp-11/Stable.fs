module FSharp11Examples

open System
open System.IO
open System.Threading
open System.Threading.Tasks

// <Interpolation>
let name = "Ada"
let score = 97.5
let message: string = $"{name}: {score:F1}"
printn message
// Ada: 97.5
// </Interpolation>

// <Report>
let report (processed: int) (total: decimal) (elapsed: TimeSpan) : string =
    $"{processed} items, total {total:F2}, elapsed {elapsed.TotalMilliseconds:F0} ms"

printn (report 12 145.50m (TimeSpan.FromMilliseconds 250.0))
// 12 items, total 145.50, elapsed 250 ms
// </Report>

// <Grid>
let grid = Array2D.init 3 4 (fun row column -> row * 4 + column)
let doubled = grid |> Array2D.map (fun value -> value * 2)
let snapshot = Array2D.copy doubled

printn $"{snapshot.GetLength(0)} x {snapshot.GetLength(1)}; last = {snapshot[2, 3]}"
// 3 x 4; last = 22
// </Grid>

// <RecordTypes>
type Endpoint = { Host: string; Port: int }

type ClientOptions =
    { ...Endpoint
      TimeoutSeconds: int }
// </RecordTypes>

// <RecordValues>
let local = { Host = "localhost"; Port = 5432 }
let options: ClientOptions = { ...local; TimeoutSeconds = 30 }

let remote = {| ...options; Host = "db.example.com" |}

printn $"{remote.Host}:{remote.Port}, timeout {remote.TimeoutSeconds}s"
// db.example.com:5432, timeout 30s
// </RecordValues>

// <Projection>
let endpoint: Endpoint = { ...options }
let overrides = {| Host = "db.example.com"; Port = 5433 |}
let production: ClientOptions =
    { ...options; ...overrides; TimeoutSeconds = 60 }

printn $"{endpoint.Host}:{endpoint.Port}"
printn $"{production.Host}:{production.Port}, timeout {production.TimeoutSeconds}s"
// localhost:5432
// db.example.com:5433, timeout 60s
// </Projection>

// <Evaluation>
let visits = ResizeArray<string>()
let hostFrom source host =
    visits.Add source
    {| Host = host |}

let selected =
    {| ...hostFrom "first" "localhost"
       ...hostFrom "second" "db.example.com" |}

assert (selected.Host = "db.example.com")
assert (Seq.toList visits = [ "first"; "second" ])
// </Evaluation>

// <Nested>
let original = {| Connection = local; Retries = 3 |}
let changed = {| ...original; Connection.Port = 5433 |}

assert (changed.Connection.Port = 5433)
assert (original.Connection.Port = 5432)
// </Nested>

// <Nullability>
open System.IO

let fileName: string = Path.GetFileName("reports/annual.csv")
let extension: string = Path.GetExtension(fileName)
printn (extension.ToUpperInvariant())
// .CSV

let fileNameOf (path: string | null) : string | null =
    Path.GetFileName path
// </Nullability>

// <Await>
open System.IO

let tryReadFile path =
    async {
        try
            let! contents =
                Async.StartTaskImmediate(fun ct -> File.ReadAllTextAsync(path, ct))
            return Some contents
        with :? FileNotFoundException ->
            return None
    }
// </Await>

// <AsyncBoundary>
let tryReadFileTask (path: string) (ct: CancellationToken) =
    tryReadFile path |> Task.startAsyncImmediate ct
// </AsyncBoundary>

// <Bounded>
open System.IO
open System.Threading

let readFiles (paths: seq<string>) (ct: CancellationToken) =
    paths
    |> Seq.map (fun path ->
        fun token -> File.ReadAllTextAsync(path, token))
    |> Task.parallelLimit 4 ct
// </Bounded>

// <Pipeline>
open System.IO
open System.Threading

let fileLength (path: string) (ct: CancellationToken) =
    File.ReadAllTextAsync(path, ct)
    |> Task.map String.length
    |> Task.catch
// </Pipeline>

// <ReturnOverloads>
type Inject =
    [<AllowOverloadOnReturnType>]
    static member Pure(value: 'T) : 'T list = [value]

    [<AllowOverloadOnReturnType>]
    static member Pure(value: 'T) : 'T option = Some value

let batch: string list = Inject.Pure "ready"
let optional: string option = Inject.Pure "ready"
// ["ready"] and Some "ready"
// </ReturnOverloads>

// <Culture>
open System.Globalization

let value = 12.5m
let machineText: string = $"{value:F2}"
let displayText =
    value.ToString("F2", CultureInfo.GetCultureInfo("fr-FR"))

assert (machineText = "12.50")
assert (displayText = "12,50")
// </Culture>

// <Closure>
let inline foldItems
    ([<InlineIfLambda; OptimizeClosureIfNotInlined>] folder)
    state
    (items: 'T[]) =
    let mutable total = state
    for item in items do
        total <- folder total item
    total
// </Closure>

// <Collection>
let aboveLimit limit (measurements: float list) =
    measurements |> List.exists (fun value -> value > limit)

printn (aboveLimit 80.0 [ 72.0; 86.0; 75.0 ])
// True
// </Collection>

// <EmptyResults>
let checkTitle (title: string) =
    if String.IsNullOrWhiteSpace title then [|"A title is required."|]
    else Array.empty

let warnings = ["Introduction"; "Installation"] |> List.toArray |> Array.collect checkTitle
let sharedEmpty = obj.ReferenceEquals(warnings, Array.empty<string>)
// true: no new empty result array
// </EmptyResults>

let verify () =
    if report 12 145.50m (TimeSpan.FromMilliseconds 250.0) <> "12 items, total 145.50, elapsed 250 ms" then
        failwith "Reporting interpolation"
    if snapshot[2, 3] <> 22 || snapshot.GetLength(0) <> 3 || obj.ReferenceEquals(snapshot, doubled) then
        failwith "Array2D snapshot"
    if not (aboveLimit 80.0 [72.0; 86.0; 75.0]) || aboveLimit 90.0 [72.0; 86.0; 75.0] then
        failwith "Captured predicate"
    if not sharedEmpty || Array.collect checkTitle [|"Valid"; ""|] <> [|"A title is required."|] then
        failwith "Empty and nonempty diagnostics"
    if message <> "Ada: 97.5" then failwith message
    if remote.Host <> "db.example.com" || remote.Port <> 5432 || remote.TimeoutSeconds <> 30 then
        failwith "anonymous spread"
    if endpoint <> local || options.Host <> "localhost" then failwith "projection"
    if production.Host <> "db.example.com" || production.Port <> 5433 || production.TimeoutSeconds <> 60 then
        failwith "overrides"
    if selected.Host <> "db.example.com" || Seq.toList visits <> [ "first"; "second" ] then
        failwith "evaluation"
    if changed.Connection.Port <> 5433 || original.Connection.Port <> 5432 then
        failwith "nested update"
    if extension.ToUpperInvariant() <> ".CSV" || batch <> ["ready"] || optional <> Some "ready" then
        failwith "interop"
    if fileNameOf null <> null || fileNameOf "reports/annual.csv" <> "annual.csv" then
        failwith "Conditional nullability"
    if machineText <> "12.50" || displayText <> "12,50" then failwith "culture"
    if foldItems (+) 0 [| 1; 2; 3 |] <> 6 then failwith "closure"

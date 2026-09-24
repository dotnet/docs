module FSharp11Examples

open System
open System.IO
open System.Threading
open System.Threading.Tasks

// <Interpolation>
let shipmentId = "SHP-1042"
let parcelCount = 3
let weightKg = 12.5m
let status: string =
    $"Shipment {shipmentId}: {parcelCount} parcels, {weightKg:F2} kg"

printn status
// </Interpolation>

// <RecordTypes>
type DeliveryAddress =
    { Street: string; City: string; PostalCode: string }

type Shipment =
    { ...DeliveryAddress
      TrackingId: string
      WeightKg: decimal }
// </RecordTypes>

// <RecordValues>
let destination: DeliveryAddress =
    { Street = "10 Market Street"; City = "Cambridge"; PostalCode = "CB1 1AA" }

let shipment: Shipment =
    { ...destination; TrackingId = "SHP-1042"; WeightKg = 12.5m }

let trackingUpdate =
    {| ...shipment; Status = "Dispatched" |}
// </RecordValues>

// <Projection>
type ShippingLabel =
    { ...DeliveryAddress; TrackingId: string }

let label: ShippingLabel = { ...shipment }
let redirected: Shipment = { ...shipment; City = "Oxford"; PostalCode = "OX1 1AA" }
// </Projection>

// <Evaluation>
let visits = ResizeArray<string>()
let addressFrom source city =
    visits.Add source
    {| City = city |}

let selected =
    {| ...addressFrom "saved address" "Cambridge"
       ...addressFrom "customer correction" "Oxford" |}

assert (selected.City = "Oxford")
assert (Seq.toList visits = [ "saved address"; "customer correction" ])
// </Evaluation>

// <Nullability>
let reportName: string = Path.GetFileName("reports/dispatch.csv")
let extension: string = Path.GetExtension(reportName)
let isCsv = extension.Equals(".csv", StringComparison.OrdinalIgnoreCase)
// </Nullability>

// <Await>
let tryReadReport path =
    async {
        try
            let! contents =
                Async.StartTaskImmediate(fun ct -> File.ReadAllTextAsync(path, ct))
            return Some contents
        with :? FileNotFoundException ->
            return None
    }
// </Await>

// <Bounded>
let readReports (paths: seq<string>) (ct: CancellationToken) =
    paths
    |> Seq.map (fun path ->
        fun token -> File.ReadAllTextAsync(path, token))
    |> Task.parallelLimit 4 ct
// </Bounded>

// <Pipeline>
let reportLength (path: string) (ct: CancellationToken) =
    File.ReadAllTextAsync(path, ct)
    |> Task.map String.length
    |> Task.catch
// </Pipeline>

// <ReturnOverloads>
type ShipmentId =
    [<AllowOverloadOnReturnType>]
    static member Parse(text: string) : int = Int32.Parse text

    [<AllowOverloadOnReturnType>]
    static member Parse(text: string) : int64 = Int64.Parse text

let databaseId: int64 = ShipmentId.Parse "1042"
// </ReturnOverloads>

// <Culture>
let weight = 12.5m
let machineText: string = $"{weight:F2}"
let displayText =
    weight.ToString("F2", Globalization.CultureInfo.GetCultureInfo("fr-FR"))

assert (machineText = "12.50")
assert (displayText = "12,50")
// </Culture>

// <Closure>
let inline foldParcels
    ([<InlineIfLambda; OptimizeClosureIfNotInlined>] folder)
    state
    (parcels: 'T[]) =
    let mutable total = state
    for parcel in parcels do
        total <- folder total parcel
    total
// </Closure>

let verify () =
    if status <> "Shipment SHP-1042: 3 parcels, 12.50 kg" then failwith status
    if trackingUpdate.Status <> "Dispatched" || label.TrackingId <> "SHP-1042" then failwith "spread"
    if redirected.City <> "Oxford" || shipment.City <> "Cambridge" then failwith "update"
    if not isCsv || databaseId <> 1042L then failwith "interop"
    if foldParcels (+) 0 [| 1; 2; 3 |] <> 6 then failwith "closure"

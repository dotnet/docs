module ShipmentApi

// <Handler>
open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.DependencyInjection

type ShipmentStore() =
    member _.Status trackingId =
        if trackingId = "SHP-1042" then "Dispatched" else "Unknown"

let status
    (trackingId: string)
    ([<FromServices>] store: ShipmentStore)
    ([<FromHeader(Name = "X-Customer")>] customer: string) =
    $"{customer}: {trackingId} is {store.Status trackingId}"

let handler = Func<string, ShipmentStore, string, string>(status)
// </Handler>

// <Identity>
let repeated = Func<string, ShipmentStore, string, string>(status)
let same = handler.Equals repeated
printfn "%b" same
// true
// </Identity>

if not same then failwith "The repeated named handler has different identity."

// <Metadata>
let parameters = handler.Method.GetParameters()
let header =
    parameters[2].GetCustomAttributes(typeof<FromHeaderAttribute>, false)[0]
    :?> FromHeaderAttribute
assert (handler.Method.Name = "status")
assert (parameters[0].Name = "trackingId")
assert (parameters[1].IsDefined(typeof<FromServicesAttribute>, false))
assert (header.Name = "X-Customer")
// </Metadata>

if handler.Method.Name <> "status"
   || parameters[0].Name <> "trackingId"
   || not (parameters[1].IsDefined(typeof<FromServicesAttribute>, false))
   || header.Name <> "X-Customer" then
    failwith "The route handler metadata wasn't preserved."

// <App>
[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    builder.Services.AddSingleton<ShipmentStore>() |> ignore
    let app = builder.Build()
    app.MapGet("/shipments/{trackingId}", handler) |> ignore
    app.Run()
    0
// </App>

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

// <Metadata>
let parameters = handler.Method.GetParameters()
assert (parameters[0].Name = "trackingId")
assert (parameters[1].IsDefined(typeof<FromServicesAttribute>, false))
assert (parameters[2].GetCustomAttributes(typeof<FromHeaderAttribute>, false).Length = 1)
// </Metadata>

if parameters[0].Name <> "trackingId"
   || not (parameters[1].IsDefined(typeof<FromServicesAttribute>, false))
   || parameters[2].GetCustomAttributes(typeof<FromHeaderAttribute>, false).Length <> 1 then
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

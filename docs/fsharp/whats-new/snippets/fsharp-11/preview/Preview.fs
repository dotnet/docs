module PreviewExamples

open System
open System.IO
open System.Threading.Tasks
open System.Runtime.CompilerServices
open System.Diagnostics.CodeAnalysis

// <RecordConstructor>
type Parcel = { TrackingId: string; WeightKg: decimal }
let parcel = Parcel(TrackingId = "SHP-1042", WeightKg = 12.5m)
// </RecordConstructor>

// <Extensions>
type Uri with
    member uri.ResourceName = Array.last uri.Segments

type Report = { Name: string }
    with member report.ResourceName = report.Name

let inline resourceName (resource: ^T) =
    ((^T) : (member ResourceName: string) resource)

let fromUrl = resourceName (Uri("https://example.com/reports/dispatch.csv"))
let fromModel = resourceName { Name = "dispatch.csv" }
// </Extensions>

// <Concrete>
let pending = Task.FromResult("dispatch.csv")
let wrapped = ValueTask<_>(pending)
let report: string = wrapped.Result
// </Concrete>

// <Priority>
type ReportWriter =
    static member Write(value: obj) = "legacy"

    [<OverloadResolutionPriority(1)>]
    static member Write<'T>(value: 'T) = "typed"

let writer = ReportWriter.Write(box 42)
// </Priority>

// <Named>
type Dispatch =
    [<RequireNamedArguments>]
    static member Schedule(express: bool, signatureRequired: bool) =
        (express, signatureRequired)

let delivery = Dispatch.Schedule(express = true, signatureRequired = false)
// </Named>

// <Reraise>
let loadManifest path =
    async {
        try
            let! text =
                Async.StartTaskImmediate(fun ct -> File.ReadAllTextAsync(path, ct))
            return text
        with :? IOException as error ->
            Console.Error.WriteLine($"Manifest unavailable: {error.Message}")
            return reraise ()
    }
// </Reraise>

[<EntryPoint>]
let main _ =
    if parcel.WeightKg <> 12.5m then failwith "Constructor"
    if fromUrl <> "dispatch.csv" || fromModel <> fromUrl then failwith "Extension"
    if report <> "dispatch.csv" || writer <> "typed" then failwith "Overload"
    if delivery <> (true, false) then failwith "Named arguments"
    let missing = Path.Combine(__SOURCE_DIRECTORY__, "absent-manifest.txt")
    try
        Async.RunSynchronously(loadManifest missing) |> ignore
        failwith "Expected FileNotFoundException"
    with :? FileNotFoundException -> ()
    Console.WriteLine("Preview examples: passed")
    0

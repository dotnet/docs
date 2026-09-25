module PreviewExamples

open System
open System.IO
open System.Threading.Tasks
open System.Runtime.CompilerServices
open System.Diagnostics.CodeAnalysis

// <RecordConstructor>
type Person = { Name: string; Age: int }
let person = Person(Name = "Ada", Age = 36)
// </RecordConstructor>

// <Extensions>
type System.String with
    static member (*) (text: string, count: int) = String.replicate count text

let inline twice value = value * 2

let number = twice 21     // 42
let text = twice "ha"     // "haha"
// </Extensions>

// <Concrete>
open System.Threading.Tasks

let pending = Task.FromResult 42
let wrapped = ValueTask<_>(pending)
let answer: int = wrapped.Result
// ValueTask<int>, not ValueTask<Task<int>>
// </Concrete>

// <Priority>
open System.Runtime.CompilerServices

type Overloads =
    static member Choose(value: obj) = "object overload"

    [<OverloadResolutionPriority(1)>]
    static member Choose<'T>(value: 'T) = "generic overload"

let chosen = Overloads.Choose(box 42)
// "generic overload"; without the attribute, "object overload"
// </Priority>

// <Named>
open System.Diagnostics.CodeAnalysis

type Client =
    [<RequireNamedArguments>]
    static member Configure(useTls: bool, keepAlive: bool) =
        (useTls, keepAlive)

let settings = Client.Configure(useTls = true, keepAlive = false)
// Client.Configure(true, false) is rejected.
// </Named>

// <Reraise>
open System
open System.IO

let readText path =
    async {
        try
            let! text =
                Async.StartTaskImmediate(fun ct -> File.ReadAllTextAsync(path, ct))
            return text
        with :? IOException as error ->
            Console.Error.WriteLine($"Read failed: {error.Message}")
            return reraise ()
    }
// </Reraise>

[<EntryPoint>]
let main _ =
    if person.Name <> "Ada" || person.Age <> 36 then failwith "Constructor"
    if number <> 42 || text <> "haha" then failwith "Extension"
    if answer <> 42 || chosen <> "generic overload" then failwith "Overload"
    if settings <> (true, false) then failwith "Named arguments"
    let missing = Path.Combine(__SOURCE_DIRECTORY__, "absent-manifest.txt")
    try
        Async.RunSynchronously(readText missing) |> ignore
        failwith "Expected FileNotFoundException"
    with :? FileNotFoundException -> ()
    Console.WriteLine("Preview examples: passed")
    0

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

type Check =
    static member That(condition: bool) =
        if condition then "OK" else "Check failed."

    [<OverloadResolutionPriority(1)>]
    static member That(condition: bool, [<CallerLineNumber>] ?line: int) =
        if condition then "OK" else $"Check failed at line {defaultArg line 0}."

let stock = 0
let diagnostic = Check.That(stock > 0)
// The diagnostic includes the caller's source line.
// </Priority>

// <Named>
open System.Diagnostics.CodeAnalysis

type Query =
    [<RequireNamedArguments>]
    static member Execute(numerator: decimal, denominator: decimal) =
        numerator / denominator

let ratio = Query.Execute(numerator = 3m, denominator = 4m)
// 0.75M; Query.Execute(3m, 4m) is rejected.
// </Named>

// <Reraise>
open System
open System.IO
open System.Threading.Tasks

let readReport (logFailure: exn -> Task) path =
    task {
        try
            return! File.ReadAllTextAsync(path)
        with :? IOException as error ->
            do! logFailure error
            return reraise ()
    }
// </Reraise>

[<EntryPoint>]
let main _ =
    if person.Name <> "Ada" || person.Age <> 36 then failwith "Constructor"
    if number <> 42 || text <> "haha" then failwith "Extension"
    if answer <> 42 || not (diagnostic.StartsWith("Check failed at line ")) ||
       diagnostic = "Check failed at line 0." then failwith "Overload"
    if ratio <> 0.75m then failwith "Named arguments"
    let missing = Path.Combine(__SOURCE_DIRECTORY__, "absent-manifest.txt")
    try
        (readReport (fun _ -> Task.CompletedTask) missing).GetAwaiter().GetResult() |> ignore
        failwith "Expected FileNotFoundException"
    with :? FileNotFoundException -> ()
    Console.WriteLine("Preview examples: passed")
    0

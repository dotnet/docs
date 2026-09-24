module FSharp11Checks

open System
open System.IO
open System.Threading
open System.Threading.Tasks
open FSharp11Examples

[<EntryPoint>]
let main _ =
    verify ()
    let folder = Path.Combine(__SOURCE_DIRECTORY__, "sample-reports")
    Directory.CreateDirectory folder |> ignore
    try
        let paths =
            [| for i in 1..8 do
                   let path = Path.Combine(folder, $"{i}.txt")
                   File.WriteAllText(path, $"Report {i}")
                   yield path |]
        let actual = (readReports paths CancellationToken.None).GetAwaiter().GetResult()
        let expected = [| for i in 1..8 -> $"Report {i}" |]
        if actual <> expected then failwith "Results aren't in input order."
        let missing = Path.Combine(folder, "missing.txt")
        if Async.RunSynchronously(tryReadReport missing) <> None then failwith "Expected None."
        if Async.RunSynchronously(tryReadReport paths[0]) <> Some "Report 1" then failwith "Expected report."
        if (reportLength paths[0] CancellationToken.None).GetAwaiter().GetResult() <> Ok 8 then
            failwith "Expected length."
        use canceled = new CancellationTokenSource()
        canceled.Cancel()
        try
            (readReports paths canceled.Token).GetAwaiter().GetResult() |> ignore
            failwith "Expected cancellation."
        with :? OperationCanceledException -> ()
        Console.WriteLine("Stable examples: passed")
        0
    finally
        Directory.Delete(folder, true)

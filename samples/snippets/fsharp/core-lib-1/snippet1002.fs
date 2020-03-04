open System
open System.IO

let writeToFile filename numBytes =
    async {
        use file = File.Create(filename)
        printfn "Writing to file %s." filename
        do! file.AsyncWrite(Array.zeroCreate<byte> numBytes)
    }

let readFile filename numBytes =
    async {
        use file = File.OpenRead(filename)
        printfn "Reading from file %s." filename
        do! file.AsyncRead(numBytes) |> Async.Ignore
    }

let filename = "BigFile.dat"
let numBytes = 100000000

let result1 = writeToFile filename numBytes
             |> Async.Catch
             |> Async.RunSynchronously
match result1 with
| Choice1Of2 _ -> printfn "Successfully wrote to file."; ()
| Choice2Of2 exn ->
      printfn "Exception occurred writing to file %s: %s" filename exn.Message

// Start these next two operations asynchronously, forcing an exception due
// to trying to access the file twice simultaneously.
Async.Start(readFile filename numBytes)
let result2 = writeToFile filename numBytes
             |> Async.Catch
             |> Async.RunSynchronously
match result2 with
| Choice1Of2 buffer -> printfn "Successfully read from file."
| Choice2Of2 exn ->
    printfn "Exception occurred reading from file %s: %s" filename (exn.Message)
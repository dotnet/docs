open System
open System.IO
open System.Threading.Tasks
open Microsoft.FSharp.Control

let baseFilename = "file"

let task1 = Task.Factory.StartNew(fun () ->
        let count = 100000000
        let random = new Random()
        let number = random.Next(10)
        let filename = baseFilename + number.ToString() + ".dat"
        use file = File.Create(filename)
        printfn "Writing to file %s." filename
        file.Write(Array.zeroCreate<byte> count, 0, count)
        printfn "Completed write operation on file %s." filename
        filename)

let readFromFileCreatedByTask task =
    async {
        let! filename = Async.AwaitTask(task)
        use file = File.OpenRead(filename)
        printfn "Reading from file %s." filename
        let! buffer = file.AsyncRead(100000000)
        printfn "Read %d bytes from file %s." (buffer.Length) filename
    }

Async.RunSynchronously(readFromFileCreatedByTask task1)

printfn "Completed."
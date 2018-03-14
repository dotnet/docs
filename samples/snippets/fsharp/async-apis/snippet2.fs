let bufferData (number:int) =
    [| for i in 1 .. 1000 -> byte (i % 256) |]
    |> Array.permute (fun index -> index)

// Create a counter as a reference cell that can be modified in parallel.
let counter = ref 0

// writeFileInner writes the data to an open stream
// that represents the file. It also updates the counter.

// The counter is locked because it will be accessed by
// multiple asynchronous computations.

// The counter must be updated as soon as the
// AsyncWrite completes, in the same synchronous
// program flow. There must not be a let! or do! between
// the AsyncWrite call and the counter update.
let writeFileInner (stream:System.IO.Stream) data =
    let result = stream.AsyncWrite(data)
    lock counter (fun () -> counter := !counter + 1)
    result

// writeFile encapsulates the asynchronous write operation.
// The do! includes both the file I/O operation and the
// counter update in order to keep those operations
// together.
let writeFile fileName bufferData =
    async {
      use outputFile = System.IO.File.Create(fileName)
      do! writeFileInner outputFile bufferData
      // Updating the counter here would not be effective.
    }

let async1 = Seq.init 1000 (fun num -> bufferData num)
             |> Seq.mapi (fun num value ->
                 writeFile ("file" + num.ToString() + ".dat") value)
             |> Async.Parallel
try
    Async.RunSynchronously(async1, 100) |> ignore
with
   | exc -> printfn "%s" exc.Message
            printfn "%d write operations completed successfully." !counter
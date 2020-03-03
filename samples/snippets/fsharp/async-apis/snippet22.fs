open System
open System.IO

type Status<'T> =
|   Success of 'T
|   Failure of exn
|   Cancel

let Continue value =
    Async.FromContinuations(fun (cont, econt, ccont) ->
        match value with
        | Success result -> cont(result)
        | Failure exn -> econt(exn)
        | Cancel -> ccont(new OperationCanceledException()))

let mutable cancelFlag = false

let writeLongFileInChunks filename (data : byte array) =
    async {
        do! Async.SwitchToNewThread()
        let result =
            try
                printfn "Opening file %s" filename
                use file = System.IO.File.Create(filename)
                let mutable count = 0
                let blockSize = 20
                while (cancelFlag = false && count < data.Length / blockSize) do
                    let slice = data.[count * blockSize .. (count + 1) * blockSize - 1]
                    Async.RunSynchronously(file.AsyncWrite slice)
                    count <- count + 1
                if (cancelFlag = false) then
                    // Write the last data, if any.
                    if (data.Length % blockSize <> 0) then
                       let slice = data.[(count + 1) * blockSize .. data.Length - 1]
                       Async.RunSynchronously(file.AsyncWrite slice)
                    Continue (Success(()))
                else
                    Continue Cancel

            with
            | exn -> Continue (Failure(exn))

        return! result
    }


let data = Array.zeroCreate<byte> 10000000

Async.StartWithContinuations(writeLongFileInChunks "x.data" data,
                             (fun _ -> printfn "Success!"),
                             (fun exn -> printfn "Exception: %s" (exn.Message)),
                             (fun _ -> printfn "Operation cancelled."))

Console.WriteLine("Press enter to cancel writing to file x.dat.")
Console.ReadLine() |> ignore
cancelFlag <- true
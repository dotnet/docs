
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
            // Throw away the data being read.
            do! file.AsyncRead(numBytes) |> Async.Ignore
        }
        
    let filename = "BigFile.dat"
    let numBytes = 100000000

    writeToFile filename numBytes
    |> Async.RunSynchronously

    readFile filename numBytes
    |> Async.RunSynchronously
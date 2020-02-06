
    open System.IO

    let streamWriter1 = File.CreateText("test1.txt")
    let count = 10000000
    let buffer = Array.init count (fun index -> byte (index % 256)) 

    printfn "Writing to file test1.txt."
    let asyncResult = streamWriter1.BaseStream.BeginWrite(buffer, 0, count, null, null)

    // Read a file, but use AwaitIAsyncResult to wait for the write operation
    // to be completed before reading.
    let readFile filename asyncResult count = 
        async {
            let! returnValue = Async.AwaitIAsyncResult(asyncResult)
            printfn "Reading from file test1.txt."
            // Close the file.
            streamWriter1.Close()
            // Now open the same file for reading.
            let streamReader1 = File.OpenText(filename)
            let! newBuffer = streamReader1.BaseStream.AsyncRead(count)
            return newBuffer
        }

    let bufferResult = readFile "test1.txt" asyncResult count
                       |> Async.RunSynchronously
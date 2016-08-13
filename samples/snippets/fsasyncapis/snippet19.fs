
    let file = System.IO.File.Create("BigFile.dat")
    let buffer = Array.zeroCreate<byte> 100000000
    let asyncWrite = Async.FromBeginEnd(buffer, 0, 100000000, file.BeginWrite, file.EndWrite)
    let asyncRead = Async.FromBeginEnd(buffer, 0, 100000000, file.BeginRead, file.EndRead)

    Async.RunSynchronously(asyncWrite)
    printfn "Wrote file."
    Async.RunSynchronously(asyncRead) |> ignore
    printfn "Read file."
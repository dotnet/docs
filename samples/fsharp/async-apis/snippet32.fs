
    let bufferData (number:int) =
        [| for count in 1 .. 1000 -> byte (count % 256) |]
        |> Array.permute (fun index -> index)

    let writeFiles bufferData =
        Seq.init 1000 (fun num -> bufferData num)
        |> Seq.mapi (fun num value ->
            async {
                let fileName = "file" + num.ToString() + ".dat"
                use outputFile = System.IO.File.Create(fileName)
                do! outputFile.AsyncWrite(value)
            })
        |> Async.Parallel
        |> Async.Ignore

    writeFiles bufferData
    |> Async.Start
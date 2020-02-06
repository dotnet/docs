
    let bufferData number =
        [| for count in 1 .. 1000 -> byte (count % 256) |]
        |> Array.permute (fun num -> num)

    let writeFile fileName bufferData =
        async {
            use outputFile = System.IO.File.Create(fileName)
            do! outputFile.AsyncWrite(bufferData) 
        }

    Seq.init 1000 (fun num -> bufferData num)
    |> Seq.mapi (fun num value -> writeFile ("file" + num.ToString() + ".dat") value)
    |> Async.Parallel
    |> Async.Ignore
    |> Async.RunSynchronously
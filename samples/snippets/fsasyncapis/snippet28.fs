
    open System
    open System.IO

    let asyncMethod f = 
        async {  
            do! Async.SwitchToNewThread() 
            let result = f() 
            do! Async.SwitchToThreadPool() 
            return result
        } 

    let GetFilesAsync(path) = asyncMethod (fun () -> Directory.GetFiles(path))

    let listFiles path =
        async {
            let! files = GetFilesAsync(path)
            Array.iter (fun elem -> printfn "%s" elem) files
        }

    printfn "Here we go..."
    // The output is interleaved, which shows that these are both 
    // running simultaneously.
    Async.Start(listFiles ".")
    Async.Start(listFiles ".")
    Console.WriteLine("Press a key to continue...")
    Console.ReadLine() |> ignore
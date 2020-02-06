
    let fileName = "directoryListing.txt"
    let printDirectoryInfo (dirName:string) (fileName:string) =
        use file = System.IO.File.CreateText(fileName)
        System.IO.Directory.EnumerateFileSystemEntries(dirName)
        |> Seq.iter (fun elem -> fprintfn file "%s" elem )
    printDirectoryInfo @"C:\" fileName
    printfn "%s" (System.IO.File.OpenText(fileName).ReadToEnd())
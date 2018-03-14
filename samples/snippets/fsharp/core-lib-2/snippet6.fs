let fileName = "directoryListingXY.txt"
let printDirectoryInfo (dirName:string) (fileName:string) =
    use file = System.IO.File.CreateText(fileName)
    System.IO.Directory.EnumerateDirectories(dirName)
    |> Seq.map (fun elem -> new System.IO.DirectoryInfo(elem))
    |> Seq.iter (fun elem -> fprintfn file "%50s %A" elem.FullName elem.LastAccessTime )
    System.IO.Directory.EnumerateFiles(dirName)
    |> Seq.map (fun elem -> new System.IO.FileInfo(elem))
    |> Seq.iter (fun elem -> fprintfn file "%50s %A" elem.FullName elem.LastAccessTime )
printDirectoryInfo @"C:\" fileName
printfn "%s" (System.IO.File.OpenText(fileName).ReadToEnd())
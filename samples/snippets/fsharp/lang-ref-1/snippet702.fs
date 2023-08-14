// Open a file and create a stream reader.
let fileStream1 =
    try
        System.IO.File.OpenRead("TextFile1.txt")
    with :? System.IO.FileNotFoundException ->
        printfn "Error: TextFile1.txt not found."
        exit (1)

let streamReader = new System.IO.StreamReader(fileStream1)

// ProcessNextLine returns false when there is no more input;
// it returns true when there is more input.
let ProcessNextLine nextLine =
    match nextLine with
    | null -> false
    | inputString ->
        match ParseDateTime inputString with
        | Some(date) -> printfn "%s" (date.ToLocalTime().ToString())
        | None -> printfn "Failed to parse the input."

        true

// A null value returned from .NET method ReadLine when there is
// no more input.
while ProcessNextLine(streamReader.ReadLine()) do
    ()

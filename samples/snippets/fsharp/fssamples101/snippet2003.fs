// Write a test file
System.IO.File.WriteAllLines(@"test.csv", [| "Desmond, Barrow, Market Place, 2";
                                             "Molly, Singer, Band, 12" |]);

/// This function builds an IEnumerable<string list> object that enumerates the CSV-split
/// lines of the given file on-demand
let CSVFileEnumerator(fileName) =

    // The function is implemented using a sequence expression
    seq { use sr = System.IO.File.OpenText(fileName)
          while not sr.EndOfStream do
             let line = sr.ReadLine()
             let words = line.Split [|',';' ';'\t'|]
             yield words }

// Now test this out on our test file, iterating the entire file
let test = CSVFileEnumerator(@"test.csv")
printfn "-------Enumeration 1------";
test |> Seq.iter (string >> printfn "line %s");
// Now do it again, this time determining the numer of entries on each line.
// Note how the file is read from the start again, since each enumeration is
// independent.
printfn "-------Enumeration 2------";
test |> Seq.iter (Array.length >> printfn "line has %d entries");
// Now do it again, this time determining the numer of entries on each line.
// Note how the file is read from the start again, since each enumeration is
// independent.
printfn "-------Enumeration 3------";
test |> Seq.iter (Array.map (fun s -> s.Length) >> printfn "lengths of entries: %A")

   let printNumbersToFile fileName n =
      // "use" will cause the file to be closed when it
      // goes out of scope.
      use file = System.IO.File.CreateText(fileName)
      [ 1 .. n ]
      |> List.iter (fun elem -> fprintf file "%d " elem)
      fprintfn file ""
   printNumbersToFile "1to100.txt" 100
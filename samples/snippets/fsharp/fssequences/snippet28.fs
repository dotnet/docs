let addNegations seq1 =
   Seq.collect (fun x -> seq { x; -x }) seq1
   |> Seq.sort
addNegations [ 1 .. 4 ] |> Seq.iter (fun elem -> printf "%d " elem)
printfn ""
addNegations [| 0; -4; 2; -12 |] |> Seq.iter (fun elem -> printf "%d " elem)
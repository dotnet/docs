let array1 = [ 1; 3; -2; 4 ]
              |> List.toArray
Array.set array1 3 -10
Array.sortInPlaceWith (fun elem1 elem2 -> compare elem1 elem2) array1
printfn "%A" array1
open System.Text

let firstArray : StringBuilder array = Array.init 3 (fun index -> new StringBuilder(""))
let secondArray = Array.copy firstArray
// Reset an element of the first array to a new value.
firstArray[0] <- new StringBuilder("Test1")
// Change an element of the first array.
firstArray[1].Insert(0, "Test2") |> ignore
printfn "%A" firstArray
printfn "%A" secondArray
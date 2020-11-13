(* passing a parameter to a value *)
let v = 10

v "a parameter"

(* incorrect indexer usage - missing dot *)
let listOfInts = [1; 2; 3]
printfn "%d" (listOfInts[1])

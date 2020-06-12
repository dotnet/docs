let list1 = [ 1 .. 10 ]

// The following chunks the list into sub-lists of size 2
printfn "%A" (List.chunkBySize 2 list1)

// The following chunks the list into sub-lists of size 3, with the last list being a single element
printfn "%A" (List.chunkBySize 3 list1)

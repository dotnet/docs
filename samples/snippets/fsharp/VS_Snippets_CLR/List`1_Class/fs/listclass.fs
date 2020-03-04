// <Snippet1>

[<EntryPoint>]
let main argv = 
    // We refer to System.Collections.Generic.List<'T> by its type 
    // abbreviation ResizeArray<'T> to avoid conflict with the List module.    
    // Note: In F# code, F# linked lists are usually preferred over
    // ResizeArray<'T> when an extendable collection is required.
    let dinosaurs = ResizeArray<_>()
 
    // Write out the dinosaurs in the ResizeArray.
    let printDinosaurs() =
        printfn ""
        dinosaurs |> Seq.iter (fun p -> printfn "%O" p) 
 
    
    printfn "\nCapacity: %i" dinosaurs.Capacity
 
    dinosaurs.Add("Tyrannosaurus")
    dinosaurs.Add("Amargasaurus")
    dinosaurs.Add("Mamenchisaurus")
    dinosaurs.Add("Deinonychus")
    dinosaurs.Add("Compsognathus")
 
    printDinosaurs()
 
    printfn "\nCapacity: %i" dinosaurs.Capacity
    printfn "Count: %i" dinosaurs.Count
 
    printfn "\nContains(\"Deinonychus\"): %b" (dinosaurs.Contains("Deinonychus"))
 
    printfn "\nInsert(2, \"Compsognathus\")"
    dinosaurs.Insert(2, "Compsognathus")
 
    printDinosaurs()
 
    // Shows accessing the list using the Item property.
    printfn "\ndinosaurs[3]: %s" dinosaurs.[3]
 
    printfn "\nRemove(\"Compsognathus\")"
    dinosaurs.Remove("Compsognathus") |> ignore
 
    printDinosaurs()
 
    dinosaurs.TrimExcess()
    printfn "\nTrimExcess()"
    printfn "Capacity: %i" dinosaurs.Capacity
    printfn "Count: %i" dinosaurs.Count
 
    dinosaurs.Clear()
    printfn "\nClear()"
    printfn "Capacity: %i" dinosaurs.Capacity
    printfn "Count: %i" dinosaurs.Count
 
    0 // return an integer exit code
 
    (* This code example produces the following output:
 
Capacity: 0
 
Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus
Compsognathus
 
Capacity: 8
Count: 5
 
Contains("Deinonychus"): true
 
Insert(2, "Compsognathus")
 
Tyrannosaurus
Amargasaurus
Compsognathus
Mamenchisaurus
Deinonychus
Compsognathus
 
dinosaurs[3]: Mamenchisaurus
 
Remove("Compsognathus")
 
Tyrannosaurus
Amargasaurus
Mamenchisaurus
Deinonychus
Compsognathus
 
TrimExcess()
Capacity: 5
Count: 5
 
Clear()
Capacity: 5
Count: 0
    *)

// </Snippet1>

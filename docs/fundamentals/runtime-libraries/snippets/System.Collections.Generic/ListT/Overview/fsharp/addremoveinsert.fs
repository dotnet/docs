//<snippet1>

// Simple business object. A PartId is used to identify the type of part  
// but the part name can change.  
[<CustomEquality; NoComparison>]
type Part = { PartId : int ; mutable PartName : string } with
    override this.GetHashCode() = hash this.PartId
    override this.Equals(other) =
        match other with
        | :? Part as p -> this.PartId = p.PartId
        | _ -> false
    override this.ToString() = sprintf "ID: %i   Name: %s" this.PartId this.PartName

[<EntryPoint>]
let main argv = 
    // We refer to System.Collections.Generic.List<'T> by its type 
    // abbreviation ResizeArray<'T> to avoid conflicts with the F# List module.    
    // Note: In F# code, F# linked lists are usually preferred over
    // ResizeArray<'T> when an extendable collection is required.
    let parts = ResizeArray<_>()
    parts.Add({PartName = "crank arm" ; PartId = 1234})
    parts.Add({PartName = "chain ring"; PartId = 1334 })
    parts.Add({PartName = "regular seat"; PartId = 1434 })
    parts.Add({PartName = "banana seat"; PartId = 1444 })
    parts.Add({PartName = "cassette"; PartId = 1534 })
    parts.Add({PartName = "shift lever"; PartId = 1634 })

    // Write out the parts in the ResizeArray.  This will call the overridden ToString method
    // in the Part type
    printfn ""
    parts |> Seq.iter (fun p -> printfn "%O" p)

    // Check the ResizeArray for part #1734. This calls the IEquatable.Equals method 
    // of the Part type, which checks the PartId for equality.    
    printfn "\nContains(\"1734\"): %b" (parts.Contains({PartId=1734; PartName=""}))
    
    // Insert a new item at position 2.
    printfn "\nInsert(2, \"1834\")"
    parts.Insert(2, { PartName = "brake lever"; PartId = 1834 })

    // Write out all parts
    parts |> Seq.iter (fun p -> printfn "%O" p)

    printfn "\nParts[3]: %O" parts.[3]

    printfn "\nRemove(\"1534\")"
    // This will remove part 1534 even though the PartName is different, 
    // because the Equals method only checks PartId for equality.
    // Since Remove returns true or false, we need to ignore the result
    parts.Remove({PartId=1534; PartName="cogs"}) |> ignore

    // Write out all parts
    printfn ""
    parts |> Seq.iter (fun p -> printfn "%O" p)

    printfn "\nRemoveAt(3)"
    // This will remove the part at index 3.
    parts.RemoveAt(3)

    // Write out all parts
    printfn ""
    parts |> Seq.iter (fun p -> printfn "%O" p)

    0 // return an integer exit code

//</snippet1>

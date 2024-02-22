module customize1

// <Snippet7>
open System
open System.Collections.Generic

type CList<'T>() = 
    inherit ResizeArray<'T>()
    
    override this.ToString() =
        let mutable retVal = String.Empty
        for item in this do
            if String.IsNullOrEmpty retVal then
                retVal <- retVal + string item
            else
                retVal <- retVal + $", {item}"
        retVal

let list2 = CList()
list2.Add 1000
list2.Add 2000
printfn $"{list2}"
// The example displays the following output:
//    1000, 2000
// </Snippet7>
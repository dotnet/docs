module customize2

// <Snippet8>
open System
open System.Collections.Generic

type List<'T> with
    member this.ToString2<'T>() = 
        let mutable retVal = String.Empty
        for item in this do
           retVal <- retVal + $"""{if String.IsNullOrEmpty retVal then "" else ", "}{item}"""
        if String.IsNullOrEmpty retVal then "{}" else "{ " + retVal + " }"

    member this.ToString<'T>(fmt: string) =
        let mutable retVal = String.Empty
        for item in this do
            match box item with
            | :? IFormattable as ifmt ->
                retVal <- retVal + $"""{if String.IsNullOrEmpty retVal then "" else ", "}{ifmt.ToString(fmt, null)}"""
            | _ ->
                retVal <- retVal + this.ToString2()
        if String.IsNullOrEmpty retVal then "{}" else "{ " + retVal + " }"

let list = ResizeArray()
list.Add 1000
list.Add 2000
printfn $"{list.ToString2()}"
printfn $"""{list.ToString "N0"}"""
// The example displays the following output:
//       { 1000, 2000 }
//       { 1,000, 2,000 }
// </Snippet8>
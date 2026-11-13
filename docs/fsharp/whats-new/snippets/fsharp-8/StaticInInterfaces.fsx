// <Interface>
[<Interface>]
type IDemoable =
    abstract member Show: string -> unit
    static member AutoFormat(a) = sprintf "%A" a
// </Interface>

// Example implementation
type MyType() =
    interface IDemoable with
        member _.Show(s) = printfn "Showing: %s" s

let value = 42
let formatted = IDemoable.AutoFormat(value)
printfn "Formatted: %s" formatted

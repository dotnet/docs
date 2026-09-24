module TailOperations

// <Builder>
type TraceBuilder() =
    member _.Return(value) = value
    member _.Zero() = ()
    member _.Bind(value, continuation) =
        System.Console.WriteLine("Bind")
        continuation value
    member _.ReturnFrom(value) =
        System.Console.WriteLine("ReturnFrom")
        value
    member _.ReturnFromFinal(value) =
        System.Console.WriteLine("ReturnFromFinal")
        value

let trace = TraceBuilder()
let forwarded = trace { return! 42 }
let completed = trace { do! () }
// </Builder>

if forwarded <> 42 then failwith "Tail result"

module usageerrors2

// <Snippet5>
// In F#, null is not a valid state for declared types 
// without 'AllowNullLiteralAttribute'
[<AllowNullLiteral>]
type Person() =
    member val Name = "" with get, set

    override this.GetHashCode() =
        this.Name.GetHashCode()

    override this.Equals(obj) =
        // This implementation handles a null obj argument.
        match obj with
        | :? Person as p -> 
            this.Name.Equals p.Name
        | _ ->
            false

let p1 = Person()
p1.Name <- "John"
let p2: Person = null

printfn $"p1 = p2: {p1.Equals p2}"
// The example displays the following output:
//        p1 = p2: False
// </Snippet5>
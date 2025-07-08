module usageerrors1

// <Snippet4>
// In F#, null is not a valid state for declared types 
// without 'AllowNullLiteralAttribute'
[<AllowNullLiteral>]
type Person() =
    member val Name = "" with get, set

    override this.GetHashCode() =
        this.Name.GetHashCode()

    override this.Equals(obj) =
        // This implementation contains an error in program logic:
        // It assumes that the obj argument is not null.
        let p = obj :?> Person
        this.Name.Equals p.Name

let p1 = Person()
p1.Name <- "John"
let p2: Person = null

// The following throws a NullReferenceException.
printfn $"p1 = p2: {p1.Equals p2}"
// </Snippet4>
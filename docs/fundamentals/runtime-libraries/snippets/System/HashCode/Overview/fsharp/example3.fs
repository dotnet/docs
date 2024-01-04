module example3

// <Snippet1>
open System
open System.Collections.Generic

[<Struct; CustomEquality; NoComparison>]
type Path([<ParamArray>]segments: string[]) =
    member _.Segments = 
        Array.AsReadOnly segments

    override this.Equals(obj) =
        match obj with
        | :? Path as o -> (this :> IEquatable<_>).Equals(o)
        | _ -> false

    interface IEquatable<Path> with
        member this.Equals(other: Path) =
            Object.ReferenceEquals(this.Segments, other.Segments) ||
            not (isNull this.Segments) && 
            not (isNull other.Segments) &&
            this.Segments.Count = other.Segments.Count &&
            Seq.forall2 (fun x y -> String.Equals(x, y, StringComparison.OrdinalIgnoreCase)) this.Segments other.Segments 

    override this.GetHashCode() =
        let hash = HashCode()

        for i = 0 to this.Segments.Count - 1 do
            hash.Add(this.Segments[i], StringComparer.OrdinalIgnoreCase)
        hash.ToHashCode()

let set = 
    HashSet<Path> [
        Path("C:", "tmp", "file.txt")
        Path("C:", "tmp", "file.tmp")
        Path("C:", "tmp", "file.txt") ]

printfn $"Item count: {set.Count}."

// The example displays the following output:
// Item count: 1.
// </Snippet1>
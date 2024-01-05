module example4

// <Snippet1>
open System
open System.Collections.Generic

module PlatformUtils =
    let pathEquals a b = String.Equals(a, b, StringComparison.OrdinalIgnoreCase)
    let addPath (hash: byref<HashCode>) path = hash.Add(path, StringComparer.OrdinalIgnoreCase)

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
            Seq.forall2 PlatformUtils.pathEquals this.Segments other.Segments 

    override this.GetHashCode() =
        let mutable hash = HashCode()

        for i = 0 to this.Segments.Count - 1 do
            PlatformUtils.addPath &hash this.Segments[i]
        hash.ToHashCode()


let set =
    HashSet<Path> [
        Path("C:", "tmp", "file.txt")
        Path("C:", "TMP", "file.txt")
        Path("C:", "tmp", "FILE.TXT") ]

printfn $"Item count: {set.Count}."

// The example displays the following output:
// Item count: 1.
// </Snippet1>
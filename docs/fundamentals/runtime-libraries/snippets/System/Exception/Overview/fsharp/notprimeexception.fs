// <Snippet1>
namespace global

open System
open System.Runtime.Serialization

[<Serializable>]
type NotPrimeException = 
    inherit Exception
    val notAPrime: int

    member this.NonPrime =
        this.notAPrime

    new (value) =
        { inherit Exception($"%i{value} is not a prime number."); notAPrime = value }

    new (value, message) =
        { inherit Exception(message); notAPrime = value }

    new (value, message, innerException: Exception) =
        { inherit Exception(message, innerException); notAPrime = value }

    // F# does not support protected members
    new () = 
        { inherit Exception(); notAPrime = 0 }

    new (info: SerializationInfo, context: StreamingContext) =
        { inherit Exception(info, context); notAPrime = 0 }

// </Snippet1>
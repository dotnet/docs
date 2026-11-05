// <NamedAttribute>
namespace System.Diagnostics.CodeAnalysis

open System

[<Sealed; AttributeUsage(AttributeTargets.Method ||| AttributeTargets.Constructor)>]
type RequireNamedArgumentsAttribute() =
    inherit Attribute()
// </NamedAttribute>

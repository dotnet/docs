// TEMPORARY SHIM.
//
// The unions and closed-hierarchy features rely on these support types. A later
// .NET SDK ships them in the base class library, at which point this file should
// be deleted. They're defined here so the sample compiles on the preview SDK that
// recognizes the language syntax but doesn't yet include the types.
//
// This file is intentionally NOT referenced by any tutorial snippet.

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
public class UnionAttribute : Attribute;

public interface IUnion
{
    object? Value { get; }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class IsClosedTypeAttribute : Attribute;

// Remove this file when UnionAttribute and IUnion are included in the .NET runtime.
// <RuntimePolyfill>
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public sealed class UnionAttribute : Attribute;

    public interface IUnion
    {
        object? Value { get; }
    }
}
// </RuntimePolyfill>

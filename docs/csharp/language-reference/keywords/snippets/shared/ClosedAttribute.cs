// In preview 5 of C# 15, the runtime doesn't yet define ClosedAttribute,
// so projects that use the 'closed' modifier must declare it.
namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ClosedAttribute : Attribute { }

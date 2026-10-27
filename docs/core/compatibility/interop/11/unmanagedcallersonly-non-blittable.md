---
title: "Breaking change: Native AOT rejects non-blittable UnmanagedCallersOnly signatures"
description: "Learn about the breaking change in .NET 11 where Native AOT throws InvalidProgramException for non-blittable UnmanagedCallersOnly signatures when runtime marshalling is enabled."
ms.date: 10/21/2026
ai-usage: ai-generated
---

# Native AOT rejects non-blittable UnmanagedCallersOnly signatures

In .NET 11, Native AOT enforces the requirement that methods annotated with <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> use only blittable parameter and return types. When runtime marshalling is enabled, a call to a method with a non-blittable signature throws <xref:System.InvalidProgramException> and terminates the process.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, Native AOT accepted `[UnmanagedCallersOnly]` methods with non-blittable parameter or return types, such as `bool` and `char`, even when runtime marshalling was enabled. Calls to these methods passed values through without conversion.

## New behavior

Starting in .NET 11, when runtime marshalling is enabled, Native AOT throws <xref:System.InvalidProgramException> if an unmanaged caller invokes an `[UnmanagedCallersOnly]` method with a non-blittable parameter or return type. For example, a method that returns `bool` or accepts a `char` parameter is rejected.

Because the exception escapes the unmanaged entry point, the process terminates (fails fast). You can't catch this exception to recover from the invalid signature.

Native AOT now enforces the same signature restrictions as CoreCLR and ReadyToRun.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

`[UnmanagedCallersOnly]` methods don't perform marshalling. Their parameter and return types must be blittable, with the same binary representation in managed and native code. With runtime marshalling enabled, types such as `bool` and `char` don't satisfy this requirement. If the native caller expects a different representation, values passed without conversion can cause silent data corruption.

Runtime marshalling is enabled by default for assemblies without <xref:System.Runtime.CompilerServices.DisableRuntimeMarshallingAttribute>.

To enforce the attribute's contract and align Native AOT with CoreCLR and ReadyToRun, Native AOT now validates these signatures. For details, see [dotnet/runtime#130160](https://github.com/dotnet/runtime/pull/130160).

## Recommended action

Choose one of the following options:

- **Disable runtime marshalling for supported unmanaged types.** For types such as `bool` and `char`, add `[assembly: System.Runtime.CompilerServices.DisableRuntimeMarshalling]` to the assembly that declares the `[UnmanagedCallersOnly]` method. Place the assembly attribute after any `using` directives and before type declarations. The attribute disables runtime marshalling for the entire assembly, not just the method. Under these rules, `bool` uses a one-byte representation and `char` uses a two-byte representation, without conversion. Ensure that the native caller and managed method agree on each type's exact binary representation. Other types, such as strings and arrays, remain unsupported. For details and the assembly-wide effects, see [Disabled runtime marshalling](../../../../standard/native-interop/disabled-marshalling.md).
- **Replace non-blittable types with blittable equivalents.** For example, use `byte` for a one-byte Boolean value, `int` for a four-byte Boolean value, or `ushort` for a two-byte character value, according to the native signature. Convert values explicitly inside the managed method, and update the native declaration if necessary.

## Affected APIs

- <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute?displayProperty=fullName>

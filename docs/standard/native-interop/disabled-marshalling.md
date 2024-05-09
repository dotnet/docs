---
title: Disabled runtime marshalling - .NET
description: Learn how .NET marshals your types to a native representation when runtime marshalling is disabled.
ms.date: 04/08/2024
---

# Disabled runtime marshalling

When the [`System.Runtime.CompilerServices.DisableRuntimeMarshallingAttribute`](xref:System.Runtime.CompilerServices.DisableRuntimeMarshallingAttribute) attribute is applied to an assembly, the runtime disables most built-in support for data marshalling between managed and native representations. This article describes the features that are disabled and how .NET types map to native types when marshalling is disabled.

## Scenarios where marshalling is disabled

When the `DisableRuntimeMarshallingAttribute` is applied to an assembly, it affects P/Invokes and Delegate types in the assembly, as well as any calls to unmanaged function pointers in the assembly. It does not affect any P/Invoke or interop delegate types defined in other assemblies. It also does not disable marshalling for the runtime's built-in COM interop support. The built-in COM interop support can be enabled or disabled through a [feature switch](https://github.com/dotnet/runtime/blob/main/docs/workflow/trimming/feature-switches.md).

### Disabled features

When the `DisableRuntimeMarshallingAttribute` is applied to an assembly, the following attributes will have no effect or throw an exception:

- <xref:System.Runtime.InteropServices.LCIDConversionAttribute> on a P/Invoke or a delegate
- `SetLastError=true` on a P/Invoke
- `ThrowOnUnmappableChar=true` on a P/Invoke
- `BestFitMapping=true` on a P/Invoke
- .NET variadic argument method signatures (varargs)
- `in`, `ref`, `out` parameters

## Default rules for marshalling common types

When marshalling is disabled, the rules for default marshalling change to much simpler rules. These rules are described below. As mentioned in the [interop best practices documentation](best-practices.md#blittable-types), blittable types are types with the same layout in managed and native code and as such do not require any marshalling. Additionally, these rules cannot be customized with the tools mentioned in [the documentation on customizing parameter marshalling](customize-parameter-marshalling.md).

| C# keyword | .NET Type        | Native Type        |
|------------|------------------|--------------------|
| `byte`     | `System.Byte`    | `uint8_t`          |
| `sbyte`    | `System.SByte`   | `int8_t`           |
| `short`    | `System.Int16`   | `int16_t`          |
| `ushort`   | `System.UInt16`  | `uint16_t`         |
| `int`      | `System.Int32`   | `int32_t`          |
| `uint`     | `System.UInt32`  | `uint32_t`         |
| `long`     | `System.Int64`   | `int64_t`          |
| `ulong`    | `System.UInt64`  | `uint64_t`         |
| `char`     | `System.Char`    | `char16_t` (`CharSet` on the P/Invoke has no effect) |
| `nint`     | `System.IntPtr`  | `intptr_t`         |
| `nuint`    | `System.UIntPtr` | `uintptr_t`        |
|            | `System.Boolean` | `bool`             |
|            | User-defined [C# `unmanaged`](../../csharp/language-reference/builtin-types/unmanaged-types.md) type with no fields with `LayoutKind.Auto` | Treated as a blittable type. All [customized struct marshalling](customize-struct-marshalling.md) is ignored. |
|            | All other types  | unsupported        |

## Examples

The following example shows some features that are enabled or disabled when runtime marshalling is disabled. To demonstrate the manual application of this guidance, these examples use `[DllImport]` as opposed to the recommended `[LibraryImport]` attribute. The analyzer with ID [SYSLIB1054](../../fundamentals/syslib-diagnostics/syslib1050-1069.md) provides additional guidance when you use `[LibraryImport]`.

```csharp
using System.Runtime.InteropServices;

struct Unmanaged
{
    int i;
}

[StructLayout(LayoutKind.Auto)]
struct AutoLayout
{
    int i;
}

struct StructWithAutoLayoutField
{
    AutoLayout f;
}

[UnmanagedFunctionPointer] // OK: UnmanagedFunctionPointer attribute is supported
public delegate void Callback();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)] // OK: Specifying a calling convention is supported
public delegate void Callback2(int i); // OK: primitive value types are allowed

[DllImport("NativeLibrary", EntryPoint = "CustomEntryPointName")] // OK: Specifying a custom entry-point name is supported
public static extern void Import(int i);

[DllImport("NativeLibrary", CallingConvention = CallingConvention.Cdecl)] // OK: Specifying a custom calling convention is supported
public static extern void Import(int i);

[UnmanagedCallConv(new[] { typeof(CallConvCdecl) })] // OK: Specifying a custom calling convention is supported
[DllImport("NativeLibrary")]
public static extern void Import(int i);

[DllImport("NativeLibrary", EntryPoint = "CustomEntryPointName", CharSet = CharSet.Unicode, ExactSpelling = false)] // OK: Specifying a custom entry-point name and using CharSet-based lookup is supported
public static extern void Import(int i);

[DllImport("NativeLibrary")] // OK: Not explicitly specifying an entry-point name is supported
public static extern void Import(Unmanaged u); // OK: unmanaged type

[DllImport("NativeLibrary")] // OK: Not explicitly specifying an entry-point name is supported
public static extern void Import(StructWithAutoLayoutField u); // Error: unmanaged type with auto-layout field

[DllImport("NativeLibrary")]
public static extern void Import(Callback callback); // Error: managed types are not supported when runtime marshalling is disabled
```

---
title: Disabled runtime marshalling - .NET
description: Learn how .NET marshals your types to a native representation when runtime marshalling is disabled.
ms.date: 01/12/2022
---

# Disabled runtime marshalling

When the [`System.Runtime.CompilerServices.DisableRuntimeMarshallingAttribute`](xref:System.Runtime.CompilerServices.DisableRuntimeMarshallingAttribute) attribute is applied to an assembly, the runtime disables most built-in support for data marshalling between managed and native representations. This document describes the features that are disabled and how .NET types map to native types when marshalling is disabled.

## Scenarios where marshalling is disabled

When the `DisableRuntimeMarshallingAttribute` is applied to an assembly, it affects P/Invokes and Delegate types in the assembly, as well as any calls to unmanaged function pointers in the assembly. It does not affect any P/Invoke or interop delegate types defined in other assemblies. It also does not disable marshalling for the runtime's built-in COM interop support. The built-in COM interop support can be enabled or disabled through a [feature switch](https://github.com/dotnet/runtime/blob/main/docs/workflow/trimming/feature-switches.md).

### Disabled features

When the `DisableRuntimeMarshallingAttribute` is applied to an assembly, the following attributes will have no effect or throw an exception:

- [`LCIDConversionAttribute`](xref:System.Runtime.InteropServices.LCIDConversionAttribute) on a P/Invoke or a delegate
- `SetLastError=true` on a P/Invoke
- `ThrowOnUnmappableChar=true` on a P/Invoke
- `BestFitMapping=true` on a P/Invoke
- .NET variadic argument method signatures (varargs)
- `in`, `ref`, `out` parameters

## Default rules for marshaling common types

When marshalling is disabled, the rules for default marshalling change to much simpler rules. These rules are described below. As mentioned in the [interop best practices documentation](best-practices.md#Blittable-types), blittable types are types with the same layout in managed and native code and as such do not require any marshalling.

| .NET Type | Native Type        |
|-----------|--------------------|
| `byte`    | `uint8_t`          |
| `sbyte`   | `int8_t`           |
| `short`   | `int16_t`          |
| `ushort`  | `uint16_t`         |
| `int`     | `int32_t`          |
| `uint`    | `uint32_t`         |
| `long`    | `int64_t`          |
| `ulong`   | `uint64_t`         |
| `char`    | `char16_t` (`CharSet` on the P/Invoke has no effect) |
| `System.IntPtr` | `intptr_t`   |
| `System.UIntPtr` | `uintptr_t` |
| `bool`    | `bool`             |
| User-defined [C# `unmanaged`](../../csharp/language-reference/builtin-types/unmanaged-types.md) type | Treated as a blittable type |
| All other types | unsupported  |

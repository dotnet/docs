---
title: "Breaking change - Mono embedding APIs no longer supported on mobile platforms"
description: "Learn about the breaking change in .NET 11 where Mono embedding APIs are no longer supported on mobile platforms."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56482
---

# Mono embedding APIs no longer supported on mobile platforms

In .NET 11, Mono embedding APIs are no longer supported on mobile platforms.

## Version introduced

.NET 11

## Previous behavior

Native code could embed Mono by using Mono header files, linking to
`libmonosgen-2.0`, and calling `mono_*` APIs. These APIs exposed runtime,
domain, metadata, object, method-call, GC-handle, internal-call, thread, and
profiling features.

## New behavior

Mono embedding APIs are no longer supported. CoreCLR on mobile platforms
doesn't provide a direct replacement for the Mono embedding API.

This change doesn't affect normal P/Invoke, <xref:System.Runtime.InteropServices.LibraryImportAttribute>, Java interop, or
Objective-C interop.

## Type of breaking change

This change is [source incompatible](../../categories.md#source-compatibility), [binary incompatible](../../categories.md#binary-compatibility), and a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Mono and CoreCLR use different hosting and embedding interfaces.

## Recommended action

- Follow
  [native interoperability best practices](../../../../standard/native-interop/best-practices.md).
- Use <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> and C# function pointers for native-to-managed
  callbacks.
- Use values that have the same layout in managed and native code (blittable
  values).
- Consider moving performance-critical, chatty managed/native interfaces to a
  fully managed implementation to reduce interop overhead.

## Affected APIs

- The Mono native embedding API, including `mono_*` functions and
  `libmonosgen-2.0`.

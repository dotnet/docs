---
title: "Breaking change: SafeHandle types must have public constructor"
description: Learn about the breaking change in interop in .NET 8 where SafeHandle-derived types used as 'ref' or 'out' parameters or as return types in 'LibraryImport' or 'GeneratedComInterface' methods must have a public constructor.
ms.date: 06/06/2023
---
# SafeHandle types must have public constructor

Historically, passing <xref:System.Runtime.InteropServices.SafeHandle>-derived types to P/Invokes and COM methods has implicitly required a parameterless constructor of any visibility when a `SafeHandle`-derived type is passed as a `ref` or `out` parameter or a return type. Source-generated interop in .NET 7 and earlier .NET 8 preview versions allowed this behavior to enable easier migration from <xref:System.Runtime.InteropServices.DllImportAttribute>-based P/Invokes. At the same time, we updated the [SafeHandle documentation](/dotnet/api/system.runtime.interopservices.safehandle#notes-to-implementers) to tell implementers to provide a `public` parameterless constructor in their derived type. This breaking change makes that recommendation a requirement for source-generated marshalling.

## Previous behavior

A <xref:System.Runtime.InteropServices.SafeHandle>-derived type was required to have a parameterless constructor *of any visibility* when it was used:

- As a `ref` or `out` parameter or a return type in a <xref:System.Runtime.InteropServices.LibraryImportAttribute>-attributed method.
- In a method on a <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute>-attributed interface.

## New behavior

A <xref:System.Runtime.InteropServices.SafeHandle>-derived type is required to have a `public` parameterless constructor when it's used:

- As a `ref` or `out` parameter or a return type in a <xref:System.Runtime.InteropServices.LibraryImportAttribute>-attributed method.
- In a method on a <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute>-attributed interface.

If the type doesn't have a `public` parameterless constructor, the interop source generator emits a compile error.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The interop source generators are changing to push more code out of the source generators themselves and into the core .NET libraries. As part of this change, the interop team is starting to enforce the recommended guidelines for more maintainable and understandable interop code.

## Recommended action

Change the existing non-`public` parameterless constructor on the `SafeHandle`-derived type to be `public`.

## Affected APIs

- <xref:System.Runtime.InteropServices.LibraryImportAttribute?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute?displayProperty=fullName>

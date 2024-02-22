---
title: "Breaking change: IDispatchImplAttribute API is removed"
description: Learn about the breaking change in interop in .NET 8 where the IDispatchImplAttribute API has been removed.
ms.date: 08/22/2023
---
# IDispatchImplAttribute API is removed

The <xref:System.Runtime.InteropServices.IDispatchImplAttribute> implementation has officially been removed from .NET. This type was only discoverable at run time and its removal has no impact on visible API surface area. However, if an assembly targeting .NET Framework uses this type and is loaded in .NET 8 or a later version, the runtime will throw a <xref:System.TypeLoadException>.

## Previous behavior

The <xref:System.Runtime.InteropServices.IDispatchImplAttribute> type could be found at run time, but none of the documented semantics of the deprecated attribute applied.

## New behavior

Starting in .NET 8, attempting to load an assembly that contains this attribute throws a <xref:System.TypeLoadException>.

## Version introduced

.NET 8 Preview 6

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This attribute was removed as it was not longer respected and served no functional purpose.

## Recommended action

Remove use of this API in assemblies that are loaded in .NET 8 and later versions.

## Affected APIs

- <xref:System.Runtime.InteropServices.IDispatchImplAttribute?displayProperty=fullName>

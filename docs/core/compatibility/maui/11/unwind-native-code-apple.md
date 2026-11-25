---
title: "Breaking change - UnwindNativeCode isn't supported on Apple targets"
description: "Learn about the breaking change in .NET 11 where UnwindNativeCode isn't supported on Apple targets."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56481
---

# UnwindNativeCode isn't supported on Apple targets

In .NET 11, UnwindNativeCode isn't supported on Apple targets.

## Version introduced

.NET 11

## Previous behavior

Apple projects that used Mono could set
`MarshalManagedExceptionMode=UnwindNativeCode`.

## New behavior

CoreCLR doesn't support `MarshalManagedExceptionMode=UnwindNativeCode`. The
Apple workload reports error 0185.

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility) and is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

CoreCLR doesn't support unwinding managed exceptions through native stack
frames in this mode.

## Recommended action

- Remove `MarshalManagedExceptionMode=UnwindNativeCode`.
- Catch managed exceptions before they cross native code.
- Return a status value, create an Objective-C exception, or use a supported
  abort policy.

## Affected APIs

None. This change affects the `MarshalManagedExceptionMode` MSBuild property.

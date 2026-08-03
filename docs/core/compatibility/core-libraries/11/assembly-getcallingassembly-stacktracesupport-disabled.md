---
title: "Breaking change: Assembly.GetCallingAssembly behavior changes when stack trace support is disabled"
description: "Learn about the breaking change in .NET 11 where Assembly.GetCallingAssembly can throw NotSupportedException when stack trace support is disabled."
ms.date: 08/03/2026
ai-usage: ai-assisted
---

# Assembly.GetCallingAssembly behavior changes when stack trace support is disabled

<xref:System.Reflection.Assembly.GetCallingAssembly?displayProperty=nameWithType> now supports Native AOT and uses stack trace data to resolve the caller. If stack trace support is disabled, the method now throws <xref:System.NotSupportedException> on both Native AOT and CoreCLR.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, on Native AOT, <xref:System.Reflection.Assembly.GetCallingAssembly?displayProperty=nameWithType> always threw <xref:System.PlatformNotSupportedException>. Previously, on CoreCLR, the method returned the calling assembly even if `StackTraceSupport` was set to `false`.

## New behavior

Starting in .NET 11, on Native AOT, <xref:System.Reflection.Assembly.GetCallingAssembly?displayProperty=nameWithType> returns the calling assembly by inspecting stack trace data. Starting in .NET 11, on both Native AOT and CoreCLR, the method throws <xref:System.NotSupportedException> if `StackTrace.IsSupported` is `false`, for example when the `StackTraceSupport` feature switch is set to `false`.

The exception message is:

`Unable to retrieve stack trace information when StackTraceSupport feature switch is set to false.`

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To return a correct caller, <xref:System.Reflection.Assembly.GetCallingAssembly?displayProperty=nameWithType> requires stack trace data. If stack trace support is unavailable, the runtime can't determine the caller reliably. The runtime now throws <xref:System.NotSupportedException> instead of returning an incorrect result. For Native AOT support details, see [dotnet/runtime#129963](https://github.com/dotnet/runtime/pull/129963).

## Recommended action

If you publish with `StackTraceSupport` set to `false` and your app calls <xref:System.Reflection.Assembly.GetCallingAssembly?displayProperty=nameWithType>, expect <xref:System.NotSupportedException>. Use one of these options:

- Enable stack trace support by removing the switch or setting `StackTraceSupport` to `true`.
- Remove calls to <xref:System.Reflection.Assembly.GetCallingAssembly?displayProperty=nameWithType>.
- Catch <xref:System.NotSupportedException> and handle the fallback path explicitly.

## Affected APIs

- <xref:System.Reflection.Assembly.GetCallingAssembly?displayProperty=fullName>

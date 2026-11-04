---
title: "Breaking change - CoreCLR replaces Mono runtime for .NET mobile apps"
description: "Learn about the breaking change in .NET 11 where CoreCLR replaces Mono runtime for .NET mobile apps."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56476
---

# CoreCLR replaces Mono runtime for .NET mobile apps

.NET 11 mobile workloads use CoreCLR as their supported runtime.

## Version introduced

.NET 11

## Previous behavior

Supported .NET 10 Android, iOS, tvOS, and Mac Catalyst projects used Mono by
default. A project could set `UseMonoRuntime=true` to select Mono.

Apps and tools could also see Mono names in runtime information, package files,
stack traces, symbols, and diagnostic events.

## New behavior

Supported .NET 11 Android, iOS, tvOS, and Mac Catalyst projects use CoreCLR.
Setting `UseMonoRuntime=true` causes build error
[NETSDK1242](../../../tools/sdk-errors/netsdk1242.md).

Apps and tools can see new runtime names. For example:

- <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription>
  reports .NET instead of Mono.
- Android packages contain CoreCLR files instead of `libmonosgen-2.0`.
- Stack traces, symbols, and diagnostic events identify CoreCLR.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility), [binary compatibility](../../categories.md#binary-compatibility), and [behavior](../../categories.md#behavioral-change).

## Reason for change

.NET 11 mobile workloads use CoreCLR as their supported runtime.

## Recommended action

- Remove `UseMonoRuntime=true` from .NET 11 projects.
- If an app must use Mono, keep it on .NET 10.
- Update tools that look for Mono package files, symbols, stack frames, or
  diagnostic names.
- Don't add code that checks whether the runtime is Mono or CoreCLR. Check for
  the feature that the app needs instead.

## Affected APIs

- <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription>
  reports .NET instead of Mono.

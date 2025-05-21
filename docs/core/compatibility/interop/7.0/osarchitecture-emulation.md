---
title: "Breaking change: RuntimeInformation.OSArchitecture under emulation"
description: Learn about the breaking change in interop in .NET 7 where RuntimeInformation.OSArchitecture now returns the correct value under emulation.
ms.date: 09/13/2022
ms.topic: concept-article
---
# RuntimeInformation.OSArchitecture under emulation

<xref:System.Runtime.InteropServices.RuntimeInformation.OSArchitecture?displayProperty=fullName> now returns the correct value under emulation.

## Previous behavior

Previously, <xref:System.Runtime.InteropServices.RuntimeInformation.OSArchitecture?displayProperty=nameWithType> returned <xref:System.Runtime.InteropServices.Architecture.X64?displayProperty=nameWithType> in emulated processes on Windows Arm 64-bit and macOS Apple Silicon systems.

## New behavior

Starting in .NET 7, <xref:System.Runtime.InteropServices.RuntimeInformation.OSArchitecture?displayProperty=nameWithType> returns <xref:System.Runtime.InteropServices.Architecture.Arm64?displayProperty=nameWithType> in emulated processes on Windows Arm 64-bit and macOS Apple Silicon systems.

## Version introduced

7 Preview 6

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The previous behavior was incorrect.

## Recommended action

Code that expects the process architecture should be changed to call <xref:System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture?displayProperty=nameWithType> instead.

## Affected APIs

- <xref:System.Runtime.InteropServices.RuntimeInformation.OSArchitecture?displayProperty=fullName>

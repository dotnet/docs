---
title: "Breaking change: FrameworkDescription's value is .NET instead of .NET Core"
description: Learn about the .NET 5 breaking change in core .NET libraries where RuntimeInformation.FrameworkDescription now returns ".NET" instead of ".NET Core".
ms.date: 11/01/2020
---
# FrameworkDescription's value is .NET instead of .NET Core

<xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=nameWithType> now returns ".NET" instead of ".NET Core".

## Change description

In previous .NET versions, <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=nameWithType> returns ".NET Core" as part of the description string, for example, `.NET Core 3.1.1`.

Starting in .NET 5, <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=nameWithType> returns ".NET" as part of the description string, for example, `.NET 5.0.0`.

## Reason for change

With .NET 5, `netcoreapp` is replaced by `net` as the short target-framework moniker. For consistency, the framework's description has also been updated. The change is cosmetic, as the `FrameworkName` isn't encoded anywhere else than in the <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=nameWithType> property.

## Version introduced

5.0

## Recommended action

Update any code that searches for ".NET Core" in the string returned by <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription>.

## Affected APIs

- <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=fullName>

<!--

### Category

Core .NET libraries

### Affected APIs

- `P:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription`

-->

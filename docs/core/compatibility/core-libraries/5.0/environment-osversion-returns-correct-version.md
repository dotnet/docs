---
title: "Breaking change: Environment.OSVersion returns the correct operating system version"
description: Learn about the .NET 5 breaking change in core .NET libraries where Environment.OSVersion returns the actual version of the operating system instead of, for example, the OS that's selected for application compatibility.
ms.date: 11/01/2020
---
# Environment.OSVersion returns the correct operating system version

<xref:System.Environment.OSVersion?displayProperty=nameWithType> returns the actual version of the operating system (OS) instead of, for example, the OS that's selected for application compatibility.

## Change description

In previous .NET versions, <xref:System.Environment.OSVersion?displayProperty=nameWithType> returns an OS version that may be incorrect when an application runs under Windows compatibility mode. For more information, see [GetVersionExA function remarks](/windows/win32/api/sysinfoapi/nf-sysinfoapi-getversionexa#remarks). On macOS, <xref:System.Environment.OSVersion?displayProperty=nameWithType> returns the underlying Darwin kernel version.

Starting in .NET 5, <xref:System.Environment.OSVersion?displayProperty=nameWithType> returns the actual version of the operating system for Windows and macOS.

The following table shows the difference in behavior.

|  | Previous .NET versions | .NET 5+ |
|--|------------------------|---------|
| **Windows** | 6.2.9200.0 | 10.0.19042.0 |
| **macOS** | 19.6.0.0 | 10.15.7 |

## Reason for change

Users of this property expect it to return the actual version of the operating system. Most .NET apps don't specify their supported version in their application manifest, and thus get the default supported version from the dotnet host. As a result, the compatibility shim is rarely meaningful for the app that's running. When Windows releases a new version and an older dotnet host is still in use, these apps may get an incorrect OS version. Returning the actual version is more inline with developers' expectations of this API.

With the introduction of <xref:System.OperatingSystem.IsWindowsVersionAtLeast%2A?displayProperty=nameWithType>, <xref:System.OperatingSystem.IsMacOSVersionAtLeast%2A?displayProperty=nameWithType>, and <xref:System.Runtime.Versioning.SupportedOSPlatformAttribute?displayProperty=nameWithType> in .NET 5, <xref:System.Environment.OSVersion?displayProperty=nameWithType> was changed to be consistent for Windows and macOS.

## Version introduced

5.0

## Recommended action

Review and test any code that uses <xref:System.Environment.OSVersion?displayProperty=nameWithType> to ensure it behaves as desired.

## Affected APIs

- <xref:System.Environment.OSVersion?displayProperty=fullName>

<!--

### Category

Core .NET libraries

### Affected APIs

- `P:System.Environment.OSVersion`

-->

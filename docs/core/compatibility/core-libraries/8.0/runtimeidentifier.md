---
title: ".NET 8 breaking change: RuntimeIdentifier returns platform for which the runtime was built"
description: Learn about the .NET 8 breaking change in core .NET libraries where RuntimeInformation.RuntimeIdentifier returns the platform for which the runtime was built.
ms.date: 09/06/2023
ms.topic: article
---
# RuntimeIdentifier returns platform for which the runtime was built

<xref:System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier?displayProperty=nameWithType> returns the platform for which the runtime was built, rather than a value computed at run time.

## Previous behavior

The value was a runtime identifier (RID) computed via OS files or APIs. This generally meant it was a version-specific and distro-specific RID. For example, when running an application on Windows 11, the value was `win10-x64` or, on Ubuntu 20.04, it could be `ubuntu.20.04-x64`.

## New behavior

Starting in .NET 8, the value is the RID for which the runtime was built. This means that for portable builds of the runtime (all Microsoft-provided builds), the value is non-version-specific and non-distro-specific. For example, the value on Windows 11 is `win-x64`, and on Ubuntu 20.04, it's `linux-x64`. For non-portable builds (source-build), the build sets a build RID that can have a version and distro, and that value is the RID that's returned.

## Version introduced

.NET 8 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change is in line with a .NET 8 change to [RID-specific asset resolution](../../deployment/8.0/rid-asset-list.md) and the move away from a distro-aware runtime. <xref:System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier?displayProperty=nameWithType> is an opaque value that should represent the platform on which the host or runtime considers itself to be running. In .NET 8, that corresponds to the platform for which the host or runtime is built, rather than an RID computed at run time.

## Recommended action

<xref:System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier?displayProperty=nameWithType> is an opaque value and not intended to be parsed into its component parts. For the OS version of the actual machine an application is running on, use <xref:System.Environment.OSVersion?displayProperty=nameWithType>. For a description, use <xref:System.Runtime.InteropServices.RuntimeInformation.OSDescription?displayProperty=nameWithType>. For a specific ID (distro) and corresponding version on Linux, you can read the [os-release](https://www.freedesktop.org/software/systemd/man/os-release.html) file.

## Affected APIs

- <xref:System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier?displayProperty=fullName>

## See also

- [.NET SDK uses a smaller RID graph](../../sdk/8.0/rid-graph.md)
- [Host determines RID-specific assets](../../deployment/8.0/rid-asset-list.md)

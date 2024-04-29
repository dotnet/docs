---
title: "Breaking change: .NET 8 is not supported on Year 2038 compatible Linux distros"
description: Learn about the .NET 8 behavior on Year 2038 compatible Linxu distros.
ms.date: 05/01/2024
---
# .NET 8 is not supported on Year 2038 compatible Arm32 Linux distros

Linux Arm32 distros have used 32-bit integers to represent time. A 32-bit integer is [unable to represent dates after January 18th, 2038](https://en.wikipedia.org/wiki/Unix_time#Range_of_representable_times). Year 2038 (Y2038) compatible distros use a 64-bit integer for time, which resolves the problem. However, this change is breaking for .NET 8.

[.NET 8 is not supported on Y2038-compatible Arm32 distros](https://github.com/dotnet/core/discussions/9285), such as Ubuntu 24.04 and Debian 13. The same is true for earlier .NET versions.

.NET 10 will be supported on Y2038-compatible Arm32 distros.

Arm64, and x64 environments are unaffected.

## Previous behavior

.NET 8 and earlier versions work on Ubuntu 22.04, Debian 12, and other Y2038-incompatible Arm32 distros.

## New behavior

.NET 8 and earlier versions do not work reliably on Ubuntu 24.04, Debian 13, and other Y2038-compatible Arm32 distros.

Y2038-incompatible .NET builds running on Y2038-compatible Arm32 distros may see the following error.

```bash
The SSL connection could not be established, see inner exception.
The remote certificate is invalid because of errors in the certificate chain: NotTimeValid
```

Some scenarios will be unaffected by this problem and work fine. However, running Y2038-incompatible .NET builds on Y2038-compatible Linux distros (and vice versa) is not supported.

## Version introduced

.NET 8

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

.NET needs to respond to Y2038 changes in Linux distros in order to function correctly. It will do so in .NET 10.

## Recommended action

Deploy .NET 8 and earlier versions on Y2038-incompatible Arm32 distros. Deploy .NET 10 and latest on Y2038-compatible distros.

## Affected APIs

Any API that relies on a native API that takes a time value.

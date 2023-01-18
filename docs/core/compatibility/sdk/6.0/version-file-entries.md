---
title: "Breaking change: .version file includes build version"
description: Learn about a breaking change in the .NET SDK where the .version file now includes the specific build version.
ms.date: 09/16/2022
---
# .version file includes build version

The .NET SDK installation folder (under *dotnet/sdk/\<version>*) contains a *.version* file. This file includes the following data:

- The hash for the commit for that version of the .NET SDK.
- The stable version.
- The [runtime identifier (RID)](../../../rid-catalog.md) of the .NET SDK.

This change adds the specific build number from the product's build system.

For example, the file now includes information similar to the following:

```txt
baae4cac8b288405720786a3bcd35ee5a6086f1b
6.0.401
win-x64
6.0.401-servicing.22414.4
```

## Previous behavior

The *dotnet/sdk/\<version>.version* file contained three values:

- Git commit hash
- Simplified version
- RID

## New behavior

The *dotnet/sdk/\<version>.version* file contains four values:

- Git commit hash
- Simplified Version
- RID
- Precise build version

## Version introduced

.NET SDK 6.0.401

## Reason for change

This change was made to enable internal testing of the `dotnet-install` script. The simpler, short build version cannot be used by the `dotnet-install` script prior to release.

## Recommended action

No action is necessary unless you have tooling that parses the *.version* file. If you do, you'll need to account for a fourth entry in the file.

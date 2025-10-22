---
title: "Default .NET container tags now use Ubuntu"
description: Learn about the breaking change where the default .NET container tags, like `10.0`, use Ubuntu.
ms.date: 2/26/2025
---

# Default .NET images use Ubuntu

The default Linux distro for .NET tags has been changed from Debian to Ubuntu. This applies to all .NET tags that do not explicitly specify an OS.

- `docker pull mcr.microsoft.com/dotnet/sdk:10.0` - Refers to Ubuntu 24.04 "Noble Numbat"
- `docker pull mcr.microsoft.com/dotnet/sdk:10.0-noble` - Refers to Ubuntu 24.04 "Noble Numbat"

For more information about the container image platforms available at .NET 10's launch, see [dotnet-docker #6539](https://github.com/dotnet/dotnet-docker/discussions/6539). This change was proposed in [dotnet-docker #6526](https://github.com/dotnet/dotnet-docker/issues/6526).

## Version introduced

.NET 10 Preview 1

## Previous behavior

.NET 9 and earlier default tags reference images based on Debian.

## New behavior

Default tags reference images based on Ubuntu.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Debian and .NET release cycles (for mainline support) are the same length, while Debian is released (and by extensions) goes out of support first. Ubuntu support periods are much longer, such that a given .NET release will go out of support before the given Ubuntu version.

## Recommended action

Test your application. This change is unlikely to affect users.

## Affected APIs

N/A

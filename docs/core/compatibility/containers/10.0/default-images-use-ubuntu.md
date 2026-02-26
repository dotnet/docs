---
title: "Default .NET container tags now use Ubuntu"
description: Learn about the breaking change where the default .NET container tags, like `10.0`, use Ubuntu.
ms.date: 2/26/2025
ai-usage: ai-assisted
---

# Default .NET images use Ubuntu

The default Linux distro for .NET tags has been changed from Debian to Ubuntu. This applies to all .NET tags that do not explicitly specify an OS.

- `docker pull mcr.microsoft.com/dotnet/sdk:10.0` - Refers to Ubuntu 24.04 "Noble Numbat"
- `docker pull mcr.microsoft.com/dotnet/sdk:10.0-noble` - Refers to Ubuntu 24.04 "Noble Numbat"

Debian container images will not be shipped for .NET 10. For more information about the container image platforms available at .NET 10's launch, see [dotnet-docker #6539](https://github.com/dotnet/dotnet-docker/discussions/6539). This change was proposed in [dotnet-docker #6526](https://github.com/dotnet/dotnet-docker/issues/6526).

## Version introduced

.NET 10

## Previous behavior

In .NET 9 and earlier versions, default tags referenced images based on Debian.

## New behavior

Starting in .NET 10, the default container image tags reference Ubuntu images. Additionally, Debian-based images are no longer provided.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Debian and .NET release cycles (for mainline support) are the same length, while Debian is released (and by extensions) goes out of support first. Ubuntu support periods are much longer, such that a given .NET release will go out of support before the given Ubuntu version.

## Recommended action

Test your application with Ubuntu-based images. This change is unlikely to affect most users.

If you specifically require Debian-based images for .NET 10, you may need to create and maintain custom container images. Please see [installing .NET in a Dockerfile](https://github.com/dotnet/dotnet-docker/blob/main/documentation/scenarios/installing-dotnet.md) for details on how to create your own .NET container images.

## Affected APIs

N/A

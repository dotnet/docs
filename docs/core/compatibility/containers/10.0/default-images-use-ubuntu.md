---
title: "Default .NET container tags now use Ubuntu"
description: Learn about the breaking change where the default .NET container tags, like `10.0`, use Ubuntu.
ms.date: 2/26/2025
ms.topic: article
---

# Default .NET images use Ubuntu

The default Linux distro for .NET tags has been changed from Debian to Ubuntu. This applies to all .NET tags that do not explicitly specify an OS.

Debian images are still produced and supported. They can be referenced using the `-trixie-slim` suffix.

- `docker pull mcr.microsoft.com/dotnet/sdk:10.0-preview` - Refers to Ubuntu 24.04 "Noble Numbat"
- `docker pull mcr.microsoft.com/dotnet/sdk:10.0-preview-noble` - Refers to Ubuntu 24.04 "Noble Numbat"
- `docker pull mcr.microsoft.com/dotnet/sdk:10.0-preview-trixie-slim` - Refers to Debian 13 "Trixie"

The same change will apply to `10.0` tags once the `-preview` suffix is removed. This change was proposed in [dotnet-docker #5709](https://github.com/dotnet/dotnet-docker/discussions/5709).

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

If you prefer Debian or have a dependency on it, use a Debian specific tag, such as `10.0-preview-trixie-slim`.

## Affected APIs

N/A

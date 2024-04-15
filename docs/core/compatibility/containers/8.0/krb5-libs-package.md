---
title: "Kerberos package removed from Alpine and Debian images"
description: Learn about the breaking change in containers where the 'krb5-libs' package was removed from .NET container images.
ms.date: 08/01/2023
---
# Kerberos package removed from Alpine and Debian images

Kerberos is no longer installed in .NET Alpine and Debian container images. Kerberos provides secure networking using the Kerberos protocol.

Kerberos is installed by default in Ubuntu, so .NET Ubuntu images aren't affected by this change. However, Kerberos is not present in .NET Chiseled images.

Kerberos packages:

- Alpine: `krb5-libs`
- Debian: `libkrb5-3`
- Ubuntu: `libkrb5-3`

## Previous behavior

Prior to .NET 8, the Kerberos package was explicitly installed in all .NET container images.

## New behavior

.NET no longer installs the Kerberos package in its container images.

## Version introduced

.NET 8 Preview 7

## Type of change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The packages were removed to reduce the image size. The Kerberos secure networking scenario was considered not popular enough to warrant installing this package by default. The removal of this package reduces .NET 8 images by ~2.7 MB.

## Recommended action

If you require the affected package for your scenario, install it manually using the following Dockerfile instruction.

For Alpine:

```dockerfile
RUN apk add --upgrade krb5-libs
```

For Debian:

```dockerfile
RUN apt update && apt -y upgrade libkrb5-3
```

For Ubuntu Chiseled, follow [pattern to install additional slices](https://github.com/ubuntu-rocks/dotnet/issues/21).

## Affected APIs

- <xref:System.DirectoryServices.Protocols?displayProperty=fullName>

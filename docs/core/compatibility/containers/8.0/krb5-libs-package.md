---
title: "Breaking change: 'ca-certificates' and 'krb5-libs' packages removed from Alpine images"
description: Learn about the breaking change in containers where the 'ca-certificates' and 'krb5-libs' packages were removed from Alpine container images.
ms.date: 08/01/2023
---
# 'ca-certificates' and 'krb5-libs' packages removed from Alpine images

The `krb5-libs` package is no longer installed in .NET Alpine container images. This package enables Kerberos secure networking. Kerberos is installed by default in Debian and Ubuntu, so .NET Debian and Ubuntu images aren't affected by this change.

In addition, the `ca-certificates` package is no longer installed in .NET Alpine container images. The Alpine base image includes the `ca-certificates-bundle` package, which provides the same baseline content that's needed for most .NET apps. It's expected that very few (if any) .NET apps will be affected by this change.

## Previous behavior

Prior to .NET 8, the `ca-certificates` and `krb5-libs` packages were included in .NET's Alpine container images.

## New behavior

.NET no longer includes the `ca-certificates` and `krb5-libs` packages in its Alpine container images.

## Version introduced

.NET 8 Preview 7

## Type of change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The packages were removed to reduce the image size.

- For `krb5-libs`, the Kerberos secure networking scenario was considered not popular enough to warrant installing this package by default. The removal of this package reduces .NET 8 Alpine images by ~2.7 MB.
- For `ca-certificates`, the removal of this package reduces .NET 8 Alpine images by 0.6MB.

## Recommended action

If you require the affected packages for your scenario, install them yourself using the following Dockerfile instruction.

```dockerfile
RUN apk add --upgrade krb5-libs
```

## Affected APIs

- <xref:System.DirectoryServices.Protocols?displayProperty=fullName>
- <xref:System.Net.Http.HttpClient?displayProperty=fullName>

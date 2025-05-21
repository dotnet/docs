---
title: "Breaking change: 'ca-certificates' package removed from Alpine images"
description: Learn about the breaking change in containers where the 'ca-certificates' package was removed from Alpine container images.
ms.date: 08/01/2023
ms.topic: concept-article
---
# 'ca-certificates' package removed from Alpine images

The `ca-certificates` package is no longer installed in .NET Alpine container images. The Alpine base image includes the `ca-certificates-bundle` package, which provides the same baseline content that's needed for most .NET apps. It's expected that very few .NET apps will be affected by this change.

## Previous behavior

Prior to .NET 8, the `ca-certificates` package was included in .NET's Alpine container images.

## New behavior

.NET no longer includes the `ca-certificates` package in its Alpine container images.

## Version introduced

.NET 8 Preview 7

## Type of change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The package was removed to reduce the image size. The removal of this package reduces .NET 8 Alpine images by 0.6 MB.

## Recommended action

If you require the affected package for your scenario, install it manually using the following Dockerfile instruction.

```dockerfile
RUN apk add --upgrade ca-certificates
```

## Affected APIs

- <xref:System.Net.Http.HttpClient?displayProperty=fullName>

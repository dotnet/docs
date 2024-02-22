---
title: "Breaking change: 'libintl' package removed from Alpine images"
description: Learn about the breaking change in containers where the 'libintl' package was removed from Alpine container images.
ms.date: 07/11/2023
---
# 'libintl' package removed from Alpine images

The `libintl` package is no longer included in .NET's Alpine container images.

## Previous behavior

Prior to .NET 8, the `libintl` package was included in .NET's Alpine container images.

## New behavior

.NET no longer includes the `libintl` package in its Alpine container images.

If your application has its own dependency on `libintl`, you might see the following error when running with .NET 8 in an Alpine container:

> **Error loading shared library libintl.so.8: No such file or directory**

## Version introduced

.NET 8 Preview 5

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

It was determined that .NET has no dependency on the `libintl` package. Only packages that .NET requires are included on top of the base Alpine container image.

## Recommended action

Verify the functionality of your application when upgrading to .NET 8. If your application has a dependency on the `libintl` package, you can include it in the image by adding the following instruction to your Dockerfile:

`RUN apk add --no-cache libintl`

## Affected APIs

None.

## See also

- [dotnet/docker issue 4627](https://github.com/dotnet/dotnet-docker/issues/4627)

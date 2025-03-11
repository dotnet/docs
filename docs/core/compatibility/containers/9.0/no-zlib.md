---
title: ".NET 9 container images no longer install `zlib`"
description: Learn about the breaking change in containers where .NET 9 container images no longer install the zlib package.
ms.date: 08/29/2024
---
# .NET 9 container images no longer install zlib

.NET 9 container images no longer install `zlib` since it's not a dependency of the .NET Runtime anymore.

## Previous behavior

In previous .NET versions, .NET container images installed the latest version of the `zlib` package from the Linux base image package repositories.

## New behavior

Starting in .NET 9, container images no longer install `zlib`. In addition, `zlib` is no longer updated in images where it's already installed from the base image.

## Version introduced

.NET 9 Preview 7

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

In .NET 9, the Runtime contains a statically linked version of `zlib-ng`. As a result, the .NET Runtime no longer has a package dependency on `zlib`. To reduce .NET container image sizes, .NET 9 container images no longer install `zlib`, and no longer update `zlib` in images where it's already installed from the base Linux image.

## Recommended action

For most scenarios, no action is required. If your containerized .NET app has a direct package dependency on `zlib`, you should manually install it in your Dockerfile using the package manager.

## Affected APIs

None.

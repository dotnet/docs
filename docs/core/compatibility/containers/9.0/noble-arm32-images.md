---
title: "Breaking change: `9.0-noble` images are 64-bit only"
description: Learn about the breaking change in Ubuntu 24.04 "noble" container images.
ms.date: 07/11/2023
ms.custom: linux-related-content
---
# `9.0-noble` images are 64-bit only

.NET 9 container images for Ubuntu 24.04 are provided for Arm64 and x64 only. .NET 9 is not supported on Ubuntu 24.04 Arm32 due to [year 2038 incompatibility](../../core-libraries/9.0/y2038-incompatible.md).

## Previous behavior

Previously, you could reference a tag like `8.0` and be able to retrieve an Arm32 container image.

## New behavior

Starting in .NET 9, the `9.0` tag will only retrieve 64-bit images.

Canonical has signaled that Arm32 is on the path to being deprecated / not supported for Ubuntu. Ubuntu related .NET tags will be 64-bit only going forward.

> From 24.04 (noble), we will no longer be producing 32-bit (armhf) images for the Raspberry Pi.

> While armhf will remain a supported architecture for noble within its lifespan, there will be no support for the armhf architecture after noble. In future releases, armhf images will not be provided, and it will not be an available foreign architecture.

From [Ubuntu 24.04 release notes (No 32-bit (armhf) images)](https://discourse.ubuntu.com/t/noble-numbat-release-notes/39890#no-32-bit-armhf-images-96)

## Version introduced

.NET 9 Preview 4

## Type of change

This change is a [behavioral change](../../categories.md#binary-compatibility).

## Reason for change

This change was made due to .NET 9 year 2038 incompatibility (specific to Arm32).

## Recommended action

Use Debian or Alpine Arm32 images or switch to a 64-bit environment. For example, Raspberry Pi can run both Arm32 and Arm64 Raspberry Pi OS variants.

Example .NET 9 container tags supported for Arm32.

- Debian: `mcr.microsoft.com/dotnet/sdk:9.0`
- Alpine: `mcr.microsoft.com/dotnet/sdk:9.0-alpine`

## Affected APIs

None.

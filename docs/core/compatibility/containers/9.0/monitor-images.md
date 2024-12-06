---
title: ".NET Monitor images simplified to version-only tags"
description: Learn about the breaking change in containers where the .NET Monitor 9 image offering has been simplified to only provide Azure Linux distroless images.
ms.date: 12/4/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/43379
---

# .NET Monitor images simplified to version-only tags

The .NET Monitor 9 image offering has been simplified to only provide Azure Linux distroless images. As part of this change, the Ubuntu Chiseled and CBL-Mariner tags have been superseded by version-only tags.

## Version introduced

.NET Monitor 9

## Previous behavior

.NET Monitor 8 offered the following types of images:

- Ubuntu Chiseled Arm64 and x64
- CBL-Mariner Distroless Arm64 and x64

## New behavior

.NET Monitor 9 offers the following types of images and their tags:

- Azure Linux distroless Arm64 and x64: `9`, `9.0`, and `9.0.0`

The following tag patterns from .NET Monitor 8 don't have an equivalent in the .NET Monitor 9 offering:

- Ubuntu Chiseled Arm64 and x64:
  - `*-ubuntu-chiseled`
  - `*-ubuntu-chiseled-amd64`
  - `*-ubuntu-chiseled-arm64v8`
- CBL-Mariner distroless Arm64 and x64:
  - `*-cbl-mariner-distroless`
  - `*-cbl-mariner-distroless-amd64`
  - `*-cbl-mariner-distroless-arm64v8`

The .NET Monitor 9 images have version-only tags. There are no OS tags due to only producing images based on a single distro.

The `latest` tag has been updated from the Ubuntu Chiseled images to Azure Linux images.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

During the .NET Monitor 8.0 development cycle, only the .NET Ubuntu Chiseled images were publicly available for customers to use. Later in the development cycle, the .NET CBL-Mariner distroless images became publicly available for customers to use. At that time, it was decided to keep producing .NET Monitor images based on both distros so that current usage wasn't disrupted.

From the perspective of the .NET Monitor tool, both distros provided a similar capability set, footprint, and security posture. The .NET Monitor images are intended to be used as appliance images. These images aren't intended to be used as base images for derivation and are only intended to be used "as-is". With the public availability of the .NET CBL-Mariner images last year, and subsequent change to Azure Linux, the .NET Monitor image offering has been simplified to only produce images based on the Azure Linux distro. The tagging scheme has been simplified to reflect this change.

## Recommended action

Update your tag usage to indicate which image from the .NET Monitor 9 image offering you want to use. The following examples show some recommended migrations:

- `8-cbl-mariner-distroless` -> `9`
- `8.0-cbl-mariner-distroless` -> `9.0`
- `8-ubuntu-chiseled` -> `9`
- `8.0-ubuntu-chiseled` -> `9.0`

The following table shows the recommended .NET Monitor 9 tags.

| Tag   | Recommended use                                                     |
|-------|---------------------------------------------------------------------|
| `9`   | To stay on the latest .NET Monitor 9 *release and servicing* update |
| `9.0` | To stay on the latest .NET Monitor 9.0 *servicing* update           |

A full list of all supported tags can be found on .NET Monitor's [README](https://github.com/dotnet/dotnet-docker/blob/main/README.monitor.md#full-tag-listing) in the `dotnet/dotnet-docker` GitHub repository.

Starting in .NET Monitor 8, the image offering was changed from using full distro images to using distroless images. If you're migrating from .NET Monitor 7 or earlier, the notable changes when migrating from a full distro image to a distroless image are:

- The use of a non-root user
- The lack of a package manager
- The lack of a shell

If you were using full distro images (for example, Alpine), you might need to adjust the running user of the .NET Monitor image in your deployments when migrating to .NET Monitor 8 or later. You can find guidance for changing the running user in the .NET Monitor 8.0 [compatibility documentation](https://github.com/dotnet/dotnet-monitor/blob/main/documentation/compatibility/8.0/README.md).

For changes from .NET Monitor 8 to .NET Monitor 9, see the .NET Monitor 9.0 [compatibility documentation](https://github.com/dotnet/dotnet-monitor/blob/main/documentation/compatibility/9.0/README.md).

## Affected APIs

N/A

---
title: ".NET Monitor only includes distroless images"
description: Learn about the breaking change in deployment in .NET 8 where the .NET Monitor 8 image offering only includes distroless images.
ms.date: 12/07/2023
ms.custom: linux-related-content
ms.topic: article
---
# .NET Monitor only includes distroless images

The .NET Monitor 8 image offering has been simplified to focus on a better security posture and smaller image as compared to the .NET Monitor 7 image offering. As part of this change, the Alpine-based images for .NET Monitor have been superseded by the Ubuntu Chiseled-based images.

## Previous behavior

.NET Monitor 7 offered the following types of images:

- Alpine Arm64 and x64

## New behavior

.NET Monitor 8 offers the following types of images:

- Ubuntu Chiseled arm64 and x64

The following tag patterns from .NET Monitor 7 do not have an equivalent in the .NET Monitor 8 offering:

- Alpine tags: `*-alpine`, `*-alpine-arm64v8`, `*-alpine-amd64`

These tag patterns have been superseded by the following tag patterns in .NET Monitor 8:

- Ubuntu Chiseled tags: `*-ubuntu-chiseled`, `*-ubuntu-chiseled-arm64v8`, `*-ubuntu-chiseled-amd64`

The `latest` floating tag has automatically updated from the Alpine-based images to Ubuntu Chiseled-based images.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The intended usage of the .NET Monitor images is that they're used as "appliance" images. These images aren't intended to be used as base images for derivation and are only intended to be used "as-is". With the available support of Ubuntu Chiseled in the .NET containers offering, .NET Monitor transitioned its offering to only provide Ubuntu Chiseled-based images. These images provide a better security posture and reduce image size.

## Recommended action

The following tag patterns from .NET Monitor 7 do not have an equivalent in the .NET Monitor 8 offering:

- Alpine tags: `*-alpine`, `*-alpine-arm64v8`, `*-alpine-amd64`

Update your tag usage to indicate which image from the .NET Monitor 8 image offering you'd like to use. The following shows some examples of the recommended migration:

- `7-alpine` -> `8-ubuntu-chiseled`

The notable changes when migrating from a full distro image to a distroless image are the use of a non-root user, the lack of a package manager, and the lack of a shell.

If you were using full distro images (for example, Alpine), you might need to adjust the running user of the .NET Monitor image in your deployments when migrating to .NET Monitor 8. You can find guidance for changing the running user in the .NET Monitor 8.0 [compatibility documentation](https://github.com/dotnet/dotnet-monitor/blob/main/documentation/compatibility/8.0/README.md).

## Affected APIs

N/A

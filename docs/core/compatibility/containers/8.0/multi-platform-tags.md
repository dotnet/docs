---
title: "Breaking change: Multi-platform container tags are Linux-only"
description: Learn about the breaking change in containers where multi-platform container tags are now Linux-only.
ms.date: 07/11/2023
---
# Multi-platform container tags are Linux-only

The .NET 8 multi-platform container tags have been updated to be Linux-only. This means that the `latest`, `<major>.<minor>`, and `<major>.<minor>.<patch>` tags are Linux-only going forward.

Multi-platform tags, also known as multi-arch or manifest list tags, are dynamic tags that cause the appropriate image to be retrieved based on the context of the host system. For example, if you pull an image with a multi-platform tag from a Linux Arm64 machine, you'll get an Arm64 image (if the tag supports that).

## Previous behavior

Previously, you could reference a tag like `7.0` and be able to retrieve a Windows-based container image.

## New behavior

Starting in .NET 8, the `8.0`` tag will only retrieve a Linux-based image.

## Version introduced

.NET 8 Preview 3

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made because of usability issues related to the platform-matching algorithm for containerd when used in conjunction with Windows desktop OS versions. This change aligns .NET's Windows container images with the method of tagging that's used for the actual base Windows Server container images.

## Recommended action

Update your tag usage to indicate which Windows version you're targeting. Instead of using an image name like `mcr.microsoft.com/dotnet/aspnet:8.0`, you'll now need to use something like one of the following:

- `mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809`
- `mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-ltsc2022`
- `mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019`
- `mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022`

Select an image name based on whether you're using Nano Server or Windows Server Core and which version of that OS. You can find a full list of all supported tags on .NET's [Docker Hub page](https://hub.docker.com/_/microsoft-dotnet).

> [!NOTE]
> In the example image names, the `8.0` tag prefix is used, which is the value that will exist once .NET 8 ships. While .NET 8 is still in preview, you can replace `8.0` with `8.0-preview`.

## Affected APIs

None.

## See also

- [dotnet/dotnet-docker issue 4492](https://github.com/dotnet/dotnet-docker/issues/4492)

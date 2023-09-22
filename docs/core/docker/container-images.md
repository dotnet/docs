---
title: .NET container images
description: Learn about the various .NET container images available on Docker Hub.
ms.date: 09/22/2023
---

# .NET container images

.NET provides various container images for different scenarios. This article describes the different types of images and how they're used. For more information about official images, see the [Docker Hub: Microsoft .NET](https://hub.docker.com/_/microsoft-dotnet) repository.

## Tagging scheme

Starting with .NET 8, container images are more pragmatic in how they're differentiated. The following characteristics are used to differentiate images:

- The target framework moniker (TFM) of the app.
- The OS, version and architecture.
- The image type (for example, `runtime`, `aspnet`, `sdk`).
- The image variant (for example, `*-distroless`, `*-chiseled`).
- The image feature (for example, `*-aot`, `*-extra`).

## Small images

The following images are focused on resulting in the smallest possible image size:

- Alpine
- Mariner distroless
- Ubuntu chiseled

These images are smaller, as they don't include globalization dependencies such as, ICU or tzdata. These images only work with apps that are configured for globalization invariant mode. To configure an app for invariant globalization, add the following property to the project file:

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

> [!TIP]
> SDK images aren't produced for `*-distroless` or `*-chiseled` image types. Composite images are the smallest `aspnet` offering for CoreCLR.

## Large images

Containerized apps that require globalization inflate the image size, as they require globalization dependencies. Ubuntu and Debian images have ICU and tzdata installed already.

The tzdata dependency was added to the following images:

- `runtime-deps:8.0-jammy`
- `runtime-deps:8.0-bookworm-slim`

This globalization tactic is used by `runtime`, `aspnet`, and `sdk` images with the same tag.

> [!IMPORTANT]
> Adding tzdata to Debian bookworm images has no practical effect, unless there's an update to tzdata (that isn't yet included in Debian) at which point .NET images would include a newer tzdata.

Some packages are still optional, such as Kerberos, LDAP, and msquic. These packages are only required in niche scenarios.

## Scenario-based images

The [runtime-deps](https://hub.docker.com/_/microsoft-dotnet-runtime-deps) images have significant value, particularly since they include a standard user and port definitions. They're convenient to use for self-contained and native AOT scenarios. However, solely providing `runtime-deps` images that are needed by the [runtime](https://hub.docker.com/_/microsoft-dotnet-runtime) and [sdk](https://hub.docker.com/_/microsoft-dotnet-sdk) images isn't sufficient to enable all the imaginable scenarios or generate optimal images.

The need for `runtime-deps` extends to native AOT, `*-distroless` and `*-chiseled` image types as well. For each OS, three image variants are provided (all in `runtime-deps`), consider the following example using `*-chiseled` images:

- `8.0-jammy-chiseled`: Images for CoreCLR (no tzdata or ICU).
- `8.0-jammy-chiseled-aot`: Images for native AOT (no tzdata, ICU, or stdc++).
- `8.0-jammy-chiseled-extra`: Image for both CoreCLR and native AOT (includes tzdata, ICU, and stdc++).

In terms of scenarios:

The `8.0-jammy-chiseled` images are the base for `runtime` and `aspnet` images of the same tag. By default, native AOT apps can use the `8.0-jammy-chiseled-aot` image, since it's optimized for size. Native AOT apps and CoreCLR self-contained/single file apps that require globalization functionality can use `8.0-jammy-chiseled-extra`.

Alpine and Mariner images use the same scheme.

> [!NOTE]
> Debian and Ubuntu (non-chiseled) `runtime-deps` images will not have multiple variants.

## Native AOT container images

Native AOT images are published to the [sdk](https://hub.docker.com/_/microsoft-dotnet-sdk) repository, and tagged with the `-aot` suffix. These images enable building native AOT apps. They're created for distros with matching `runtime-deps:*-aot` images. These images are large, commonly twice the size of regular SDK images.

AOT images are published for:

- Alpine
- Mariner
- Ubuntu

For more information, see [Native AOT deployment](./deploying/native-aot/index.md).

## Docker hub repositories

All of the official Microsoft images for .NET are published to the [microsoft-dotnet](https://hub.docker.com/_/microsoft-dotnet) Docker Hub organization. Consider the following repositories.

_.NET stable image repositories:_

| Image repository | Image |
|--|--|
| [aspnet](https://hub.docker.com/_/microsoft-dotnet-aspnet) | `mcr.microsoft.com/dotnet/aspnet` |
| [monitor](https://hub.docker.com/_/microsoft-dotnet-monitor) | `mcr.microsoft.com/dotnet/monitor` |
| [monitor-base](https://hub.docker.com/_/microsoft-dotnet-monitor-base) | `mcr.microsoft.com/dotnet/monitor/base` |
| [runtime-deps](https://hub.docker.com/_/microsoft-dotnet-runtime-deps) | `mcr.microsoft.com/dotnet/runtime-deps` |
| [runtime](https://hub.docker.com/_/microsoft-dotnet-runtime) | `mcr.microsoft.com/dotnet/runtime` |
| [samples](https://hub.docker.com/_/microsoft-dotnet-samples) | `mcr.microsoft.com/dotnet/samples` |
| [sdk](https://hub.docker.com/_/microsoft-dotnet-sdk) | `mcr.microsoft.com/dotnet/sdk` |

_.NET nightly image repositories:_

| Image repository | Image |
|--|--|
| [nightly](https://hub.docker.com/_/microsoft-dotnet-nightly) | `mcr.microsoft.com/dotnet/nightly` |
| [nightly-aspnet](https://hub.docker.com/_/microsoft-dotnet-nightly-aspnet) | `mcr.microsoft.com/dotnet/nightly/aspnet` |
| [nightly-monitor-base](https://hub.docker.com/_/microsoft-dotnet-nightly-monitor-base) | `mcr.microsoft.com/dotnet/nightly/monitor/base` |
| [nightly-monitor](https://hub.docker.com/_/microsoft-dotnet-nightly-monitor) | `mcr.microsoft.com/dotnet/nightly/monitor` |
| [nightly-runtime-deps](https://hub.docker.com/_/microsoft-dotnet-nightly-runtime-deps) | `mcr.microsoft.com/dotnet/nightly/runtime-deps` |
| [nightly-runtime](https://hub.docker.com/_/microsoft-dotnet-nightly-runtime) | `mcr.microsoft.com/dotnet/nightly/runtime` |
| [nightly-sdk](https://hub.docker.com/_/microsoft-dotnet-nightly-sdk) | `mcr.microsoft.com/dotnet/nightly/sdk` |

_.NET Framework image repositories:_

| Image repository | Image |
|--|--|
| [framework](https://hub.docker.com/_/microsoft-dotnet-framework) | `mcr.microsoft.com/dotnet/framework` |
| [framework-aspnet](https://hub.docker.com/_/microsoft-dotnet-framework-aspnet) | `mcr.microsoft.com/dotnet/framework/aspnet` |
| [framework-runtime](https://hub.docker.com/_/microsoft-dotnet-framework-runtime) | `mcr.microsoft.com/dotnet/framework/runtime` |
| [framework-samples](https://hub.docker.com/_/microsoft-dotnet-framework-samples) | `mcr.microsoft.com/dotnet/framework/samples` |
| [framework-sdk](https://hub.docker.com/_/microsoft-dotnet-framework-sdk) | `mcr.microsoft.com/dotnet/framework/sdk` |
| [framework-wcf](https://hub.docker.com/_/microsoft-dotnet-framework-wcf) | `mcr.microsoft.com/dotnet/framework/wcf` |

For more information, see [New approach for differentiating .NET 8+ images](https://github.com/dotnet/dotnet-docker/discussions/4821).

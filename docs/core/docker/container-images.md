---
title: .NET container images
description: Learn about the various .NET container images available from Microsoft Artifact Registry and how they're used for different scenarios.
ms.date: 11/17/2026
ms.custom: linux-related-content
ai-usage: ai-assisted
---

# .NET container images

.NET provides various container images for different scenarios. This article describes the different types of images and how they're used. Microsoft publishes official .NET images to [Microsoft Artifact Registry](https://mcr.microsoft.com/) (`mcr.microsoft.com`). For more information about official images, see the [Microsoft .NET](https://hub.docker.com/_/microsoft-dotnet) page on Docker Hub. The examples in this article use .NET 10 and .NET 11 image tags.

## Tagging scheme

Starting with .NET 8, container images are more pragmatic in how they're differentiated. The following characteristics are used to differentiate images:

- The target framework moniker (TFM) of the app.
- The OS, version, and architecture.
- The image type (for example, `runtime`, `aspnet`, `sdk`).
- The image variant (for example, `*-distroless`, `*-chiseled`).
- The image feature (for example, `*-aot`, `*-extra`).

For example, `mcr.microsoft.com/dotnet/aspnet:10.0-noble-chiseled-extra` is an `aspnet` image for .NET 10 that's based on Ubuntu 24.04 (`noble`), uses the `chiseled` variant, and includes the `extra` feature.

Tags that don't specify an OS, such as `10.0` and `11.0`, refer to Ubuntu images: Ubuntu 24.04 (`noble`) for .NET 10 and Ubuntu 26.04 (`resolute`) for .NET 11. Starting with .NET 10, Microsoft doesn't provide Debian images. For more information, see [Default .NET images use Ubuntu](../compatibility/containers/10.0/default-images-use-ubuntu.md).

## Images optimized for size

The following image variants provide the smallest image sizes:

- Alpine (such as `10.0-alpine` and `11.0-alpine`)
- Azure Linux distroless (such as `10.0-azurelinux3.0-distroless` and `11.0-azurelinux4.0-distroless`)
- Ubuntu chiseled (such as `10.0-noble-chiseled` and `11.0-resolute-chiseled`)

The default variants of these images are smaller because they don't include International Components for Unicode (ICU). The default Alpine and Ubuntu chiseled images also omit time zone data (tzdata). The default Azure Linux distroless images include tzdata, but not ICU.

Because ICU isn't present, these images set the `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT` environment variable to `true`, which runs apps in [globalization invariant mode](../runtime-config/globalization.md#invariant-mode). Use these images only for apps that work correctly in invariant mode. To enable invariant mode wherever your app runs, not only in these containers, add the following property to your project file:

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

If your app requires culture data or time zone data that the default image doesn't include, use one of the [images suitable for globalization](#images-suitable-for-globalization) instead.

> [!TIP]
> SDK images aren't produced for `*-distroless` or `*-chiseled` image types. Composite images are the smallest `aspnet` offering for [Core CLR](../../standard/glossary.md#core-clr).

## Images suitable for globalization

Apps that require globalization need larger base images because those images include globalization dependencies. The following images include both ICU and tzdata:

- Ubuntu images, such as `10.0-noble` and `11.0-resolute` (default tags such as `10.0` and `11.0` also refer to these images)
- Azure Linux images, such as `10.0-azurelinux3.0` and `11.0-azurelinux4.0`
- Size-optimized `*-extra` variants, such as `10.0-alpine-extra`, `10.0-azurelinux3.0-distroless-extra`, `10.0-noble-chiseled-extra`, and `11.0-resolute-chiseled-extra`

The `*-extra` variants are available for `runtime-deps`, `runtime`, and `aspnet` images.

> [!IMPORTANT]
> Before you move an app to an image that includes ICU, make sure that the app isn't configured for invariant mode. MSBuild applies the `InvariantGlobalization` property when you build the app, so the app stays in invariant mode even when it runs on an image that includes ICU. Remove the property from the project file or set it to `false`, and then rebuild and republish the app.

Some packages are still optional, such as Kerberos, LDAP, and msquic. These packages are only required in niche scenarios.

## Scenario-based images

The [runtime-deps](https://hub.docker.com/_/microsoft-dotnet-runtime-deps) images have significant value, particularly since they include a standard user and port definitions. They're convenient to use for self-contained and native AOT scenarios. However, solely providing `runtime-deps` images that are needed by the [runtime](https://hub.docker.com/_/microsoft-dotnet-runtime) and [sdk](https://hub.docker.com/_/microsoft-dotnet-sdk) images isn't sufficient to enable all the imaginable scenarios or generate optimal images.

The need for `runtime-deps` extends to native AOT, `*-distroless`, and `*-chiseled` image types as well. Microsoft provides two `runtime-deps` variants for Alpine, Azure Linux distroless, and Ubuntu chiseled. Consider the following .NET 10 `*-chiseled` `runtime-deps` images:

- `10.0-noble-chiseled`: Supports Core CLR and native AOT apps that run in globalization invariant mode. This image omits tzdata and ICU.
- `10.0-noble-chiseled-extra`: Supports Core CLR and native AOT apps that require globalization. This image includes tzdata and ICU.

In terms of scenarios:

The `10.0-noble-chiseled` images are the base for `runtime` and `aspnet` images of the same tag. Native AOT apps and Core CLR self-contained or single-file apps that run in invariant mode can use the size-optimized `10.0-noble-chiseled` image. Native AOT apps and Core CLR self-contained or single-file apps that require globalization functionality can use `10.0-noble-chiseled-extra`, as long as they aren't built with `InvariantGlobalization` set to `true`.

.NET 11 uses the same scheme, for example, `11.0-resolute-chiseled` and `11.0-resolute-chiseled-extra`. Alpine and Azure Linux distroless images also use this scheme, for example, `10.0-alpine` and `10.0-alpine-extra`, or `11.0-azurelinux4.0-distroless` and `11.0-azurelinux4.0-distroless-extra`.

For .NET 10 and later versions, `runtime-deps` images don't have native AOT-specific (`*-aot`) variants. Native AOT apps use the regular `runtime-deps` images, and only [SDK images](#native-aot-container-images) use the `-aot` suffix.

> [!NOTE]
> Ubuntu (non-chiseled) and Azure Linux (non-distroless) `runtime-deps` images don't have multiple variants because they already include ICU and tzdata.

## Native AOT container images

Microsoft publishes native AOT SDK images to the [sdk](https://hub.docker.com/_/microsoft-dotnet-sdk) repository with the `-aot` suffix, such as `10.0-noble-aot` and `11.0-resolute-aot`. These images include the extra dependencies required to build native AOT apps. To run the compiled apps, use the regular `runtime-deps` images described in [Scenario-based images](#scenario-based-images). Native AOT SDK images are larger than standard SDK images, and the size difference varies by distribution and .NET version.

Native AOT SDK images are available for the following Linux distributions:

- Alpine
- Azure Linux
- Ubuntu

For more information, see [Native AOT deployment](../deploying/native-aot/index.md).

## Docker Hub repositories

The [Microsoft .NET](https://hub.docker.com/_/microsoft-dotnet) page on Docker Hub lists the official .NET container image repositories. Docker Hub describes each repository and lists its tags, while Microsoft Artifact Registry hosts the images. To pull an image, use its `mcr.microsoft.com` path from the **Image** column in the following tables.

_.NET stable image repositories:_

| Image repository                                                       | Image                                   |
|------------------------------------------------------------------------|-----------------------------------------|
| [sdk](https://hub.docker.com/_/microsoft-dotnet-sdk)                   | `mcr.microsoft.com/dotnet/sdk`          |
| [aspnet](https://hub.docker.com/_/microsoft-dotnet-aspnet)             | `mcr.microsoft.com/dotnet/aspnet`       |
| [runtime](https://hub.docker.com/_/microsoft-dotnet-runtime)           | `mcr.microsoft.com/dotnet/runtime`      |
| [runtime-deps](https://hub.docker.com/_/microsoft-dotnet-runtime-deps) | `mcr.microsoft.com/dotnet/runtime-deps` |
| [monitor](https://hub.docker.com/_/microsoft-dotnet-monitor)           | `mcr.microsoft.com/dotnet/monitor`      |
| [aspire-dashboard](https://hub.docker.com/r/microsoft/dotnet-aspire-dashboard/) | `mcr.microsoft.com/dotnet/aspire-dashboard` |
| [samples](https://hub.docker.com/_/microsoft-dotnet-samples)           | `mcr.microsoft.com/dotnet/samples`      |

_.NET nightly image repositories:_

| Image repository                                                             | Image                                      |
|------------------------------------------------------------------------------|--------------------------------------------|
| [nightly-aspnet](https://hub.docker.com/_/microsoft-dotnet-nightly-aspnet)   | `mcr.microsoft.com/dotnet/nightly/aspnet`  |
| [nightly-monitor](https://hub.docker.com/_/microsoft-dotnet-nightly-monitor) | `mcr.microsoft.com/dotnet/nightly/monitor` |
| [nightly-runtime-deps](https://hub.docker.com/_/microsoft-dotnet-nightly-runtime-deps) | `mcr.microsoft.com/dotnet/nightly/runtime-deps` |
| [nightly-runtime](https://hub.docker.com/_/microsoft-dotnet-nightly-runtime) | `mcr.microsoft.com/dotnet/nightly/runtime` |
| [nightly-sdk](https://hub.docker.com/_/microsoft-dotnet-nightly-sdk)         | `mcr.microsoft.com/dotnet/nightly/sdk`     |
| [nightly-aspire-dashboard](https://hub.docker.com/r/microsoft/dotnet-nightly-aspire-dashboard/) | `mcr.microsoft.com/dotnet/nightly/aspire-dashboard` |

_.NET Framework image repositories:_

| Image repository                                                                 | Image                                        |
|----------------------------------------------------------------------------------|----------------------------------------------|
| [framework-aspnet](https://hub.docker.com/_/microsoft-dotnet-framework-aspnet)   | `mcr.microsoft.com/dotnet/framework/aspnet`  |
| [framework-runtime](https://hub.docker.com/_/microsoft-dotnet-framework-runtime) | `mcr.microsoft.com/dotnet/framework/runtime` |
| [framework-samples](https://hub.docker.com/_/microsoft-dotnet-framework-samples) | `mcr.microsoft.com/dotnet/framework/samples` |
| [framework-sdk](https://hub.docker.com/_/microsoft-dotnet-framework-sdk)         | `mcr.microsoft.com/dotnet/framework/sdk`     |
| [framework-wcf](https://hub.docker.com/_/microsoft-dotnet-framework-wcf)         | `mcr.microsoft.com/dotnet/framework/wcf`     |

.NET Framework images are Windows container images. For an overview of all .NET Framework images, see the [Microsoft .NET Framework](https://hub.docker.com/_/microsoft-dotnet-framework) page on Docker Hub.

## See also

- [Default .NET images use Ubuntu](../compatibility/containers/10.0/default-images-use-ubuntu.md)
- [.NET image variants](https://github.com/dotnet/dotnet-docker/blob/main/documentation/image-variants.md)
- [What's new in .NET 8: Container images](../whats-new/dotnet-8/containers.md#container-images)
- [New approach for differentiating .NET 8+ images](https://github.com/dotnet/dotnet-docker/discussions/4821)

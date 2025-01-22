---
title: What's new in containers for .NET 8
description: Learn about the new containers features introduced in .NET 8.
titleSuffix: ""
ms.date: 11/14/2023
ms.topic: whats-new
ms.custom: linux-related-content
---
# What's new in containers for .NET 8

This article describes new features in containers for .NET 8.

## Container images

The following changes have been made to .NET container images for .NET 8:

- [Non-root user](#non-root-user)
- [Debian 12](#debian-12)
- [Chiseled Ubuntu images](#chiseled-ubuntu-images)
- [Build multi-platform container images](#build-multi-platform-container-images)
- [ASP.NET composite images](#aspnet-composite-images)

### Non-root user

Images include a `non-root` user. This user makes the images `non-root` capable. To run as `non-root`, add the following line at the end of your Dockerfile (or a similar instruction in your Kubernetes manifests):

```dockerfile
USER app
```

.NET 8 adds an environment variable for the UID for the `non-root` user, which is 1654. This environment variable is useful for the Kubernetes `runAsNonRoot` test, which requires that the container user be set via UID and not by name. This [dockerfile](https://github.com/dotnet/dotnet-docker/blob/e5bc76bca49a1bbf9c11e74a590cf6a9fe9dbf2a/samples/aspnetapp/Dockerfile.alpine-non-root#L27) shows an example usage.

The default port also changed from port `80` to `8080`. To support this change, a new environment variable `ASPNETCORE_HTTP_PORTS` is available to make it easier to change ports. The variable accepts a list of ports, which is simpler than the format required by `ASPNETCORE_URLS`. If you change the port back to port `80` using one of these variables, you can't run as `non-root`.

For more information, see [Default ASP.NET Core port changed from 80 to 8080](../../compatibility/containers/8.0/aspnet-port.md) and [New non-root 'app' user in Linux images](../../compatibility/containers/8.0/app-user.md).

### Debian 12

The container images now use [Debian 12 (Bookworm)](https://wiki.debian.org/DebianBookworm). Debian is the default Linux distro in the .NET container images.

For more information, see [Debian container images upgraded to Debian 12](../../compatibility/containers/8.0/debian-version.md).

### Chiseled Ubuntu images

[Chiseled Ubuntu images](https://devblogs.microsoft.com/dotnet/announcing-dotnet-chiseled-containers/) are available for .NET 8. Chiseled images have a reduced attacked surface because they're ultra-small, have no package manager or shell, and are `non-root`. This type of image is for developers who want the benefit of appliance-style computing.

Chiseled images do not support globalization, by default. [`extra`](https://github.com/dotnet/dotnet-docker/issues/5021) images are provided, which include `icu` and `tzdata` packages.

For more information on globalization and containers, see [Globalization Test App](https://github.com/dotnet/dotnet-docker/blob/main/samples/globalapp/README.md).

### Build multi-platform container images

Docker supports using and building [multi-platform images](https://docs.docker.com/build/building/multi-platform/) that work across multiple environments. .NET 8 introduces a new pattern that enables you to mix and match architectures with the .NET images you build. As an example, if you're using macOS and want to target an x64 cloud service in Azure, you can build the image by using the `--platform` switch as follows:

`docker build --pull -t app --platform linux/amd64`

The .NET SDK now supports `$TARGETARCH` values and the `-a` argument on restore. The following code snippet shows an example:

```dockerfile
RUN dotnet restore -a $TARGETARCH

# Copy everything else and build app.
COPY aspnetapp/. .
RUN dotnet publish -a $TARGETARCH --self-contained false --no-restore -o /app
```

For more information, see the [Improving multi-platform container support](https://devblogs.microsoft.com/dotnet/improving-multiplatform-container-support/) blog post.

### ASP.NET composite images

As part of an effort to improve containerization performance, new ASP.NET Docker images are available that have a composite version of the runtime. This composite is built by compiling multiple CIL assemblies into a single ready-to-run (R2R) output binary. Because these assemblies are embedded into a single image, jitting takes less time, and the startup performance of apps improves. The other big advantage of the composite over the regular ASP.NET image is that the composite images have a smaller size on disk.

There is a caveat to be aware of. Since composites have multiple assemblies embedded into one, they have tighter version coupling. Apps can't use custom versions of framework or ASP.NET binaries.

[Composite images](https://github.com/dotnet/dotnet-docker/blob/main/documentation/image-variants.md#composite-net-80) are available for the Alpine Linux, Ubuntu ("jammy") Chiseled, and Mariner Distroless platforms from the `mcr.microsoft.com/dotnet/aspnet` repo. The tags are listed with the `-composite` suffix on the [ASP.NET Docker page](https://hub.docker.com/_/microsoft-dotnet-aspnet).

## Container publishing

- [Generated-image defaults](#generated-image-defaults)
- [Performance and compatibility](#performance-and-compatibility)
- [Authentication](#authentication)
- [Publish to tar.gz archive](#publish-to-targz-archive)

### Generated-image defaults

`dotnet publish` can produce container images. It defaults to producing [`non-root` images](#non-root-user), which helps your apps stay secure-by-default. Change this default at any time by setting the `ContainerUser` property, for example with `root`.

The default output container tag is now `latest`. This default is in line with other tooling in the containers space and makes containers easier to use in inner development loops.

### Performance and compatibility

.NET 8 has improved performance for pushing containers to remote registries, especially Azure registries. Speedup comes from pushing layers in one operation and, for registries that don't support atomic uploads, a more reliable chunking mechanism.

These improvements also mean that more registries are supported: Harbor, Artifactory, Quay.io, and Podman.

### Authentication

.NET 8 adds support for OAuth token exchange authentication (Azure Managed Identity) when pushing containers to registries. This support means that you can now push to registries like Azure Container Registry without any authentication errors. The following commands show an example publishing flow:

```console
> az acr login -n <your registry name>
> dotnet publish -r linux-x64 -p PublishProfile=DefaultContainer
```

For more information containerizing .NET apps, see [Containerize a .NET app with dotnet publish](../../containers/sdk-publish.md).

### Publish to tar.gz archive

Starting in .NET 8, you can create a container directly as a *tar.gz* archive. This feature is useful if your workflow isn't straightforward and requires that you, for example, run a scanning tool over your images before pushing them. Once the archive is created, you can move it, scan it, or load it into a local Docker toolchain.

To publish to an archive, add the `ContainerArchiveOutputPath` property to your `dotnet publish` command, for example:

```dotnetcli
dotnet publish \
  -p PublishProfile=DefaultContainer \
  -p ContainerArchiveOutputPath=./images/sdk-container-demo.tar.gz
```

You can specify either a folder name or a path with a specific file name.

## See also

- [What's new in .NET 8](overview.md)

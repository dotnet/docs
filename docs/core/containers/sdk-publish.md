---
title: Containerize an app with dotnet publish
description: In this tutorial, you learn how to containerize a .NET application with dotnet publish command without the use of a Dockerfile.
ms.date: 11/17/2026
ms.topic: tutorial
ai-usage: ai-assisted
---

# Containerize a .NET app with dotnet publish

Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud. In this tutorial, you learn how to containerize a .NET application using the [dotnet publish](../tools/dotnet-publish.md) command without the use of a Dockerfile. Additionally, you explore how to configure the [container image](../docker/container-images.md) and execution, and how to clean up resources.

> [!TIP]
> If you're interested in using a _Dockerfile_ to containerize your .NET app, see [Tutorial: Containerize a .NET app](../docker/build-container.md).

## Prerequisites

Install the following prerequisites:

- [.NET 10 SDK or later](https://dotnet.microsoft.com/download/dotnet)\
If you have .NET installed, use the `dotnet --info` command to determine which SDK you're using.

If you plan on running the container locally, you need an Open Container Initiative (OCI)-compatible container runtime, such as:

- [Docker Desktop](https://www.docker.com/products/docker-desktop): Most common container runtime.
- [Podman](https://podman.io/): An open-source daemonless alternative to Docker.

> [!IMPORTANT]
> The .NET SDK creates container images without Docker. Docker or Podman are only needed if you want to run the image locally. By default, when you [publish your .NET app](#publish-net-app) as a container image it's pushed to a local container runtime. Alternatively, you can save the [image as a tarball](#publish-net-app-to-a-tarball) or push it directly to a [container registry](#publish-net-app-to-container-registry) without using any container runtime at all.

In addition to these prerequisites, it's recommended that you're familiar with [Worker Services in .NET](../extensions/workers.md) as the sample project is a worker.

## Create .NET app

You need a .NET app to containerize, so start by creating a new app from a template. Open your terminal, create a working folder (_sample-directory_) if you haven't already, and change directories so that you're in it. In the working folder, run the following command to create a new project in a subdirectory named _Worker_:

```dotnetcli
dotnet new worker -o Worker -n DotNet.ContainerImage
```

Your folder tree looks similar to the following directory:

```Directory
📁 sample-directory
    └──📂 Worker
        ├──appsettings.Development.json
        ├──appsettings.json
        ├──DotNet.ContainerImage.csproj
        ├──Program.cs
        ├──Worker.cs
        ├──📂 Properties
        │   └─── launchSettings.json
        └──📂 obj
            ├── DotNet.ContainerImage.csproj.nuget.dgspec.json
            ├── DotNet.ContainerImage.csproj.nuget.g.props
            ├── DotNet.ContainerImage.csproj.nuget.g.targets
            ├── project.assets.json
            └── project.nuget.cache
```

The `dotnet new` command creates a new folder named _Worker_ and generates a worker service that, when run, logs a message every second. From your terminal session, change directories and navigate into the _Worker_ folder. Use the `dotnet run` command to start the app.

```dotnetcli
dotnet run
Using launch settings from ./Worker/Properties/launchSettings.json...
Building...
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 01/06/2025 13:37:28 -06:00
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: .\Worker
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 01/06/2025 13:37:29 -06:00
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 01/06/2025 13:37:30 -06:00
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

The worker template loops indefinitely. Use the cancel command <kbd>Ctrl+C</kbd> to stop it.

## Set the container image name

There are various configuration options available when publishing an app as a container. By default, the container image name is the `AssemblyName` of the project. To set a different name, specify a `ContainerRepository` property. For this tutorial, open the _DotNet.ContainerImage.csproj_ file and add the highlighted `ContainerRepository` property, as shown in the following project file:

:::code language="xml" source="snippets/Worker/DotNet.ContainerImage.csproj" highlight="8":::

The preceding project file targets .NET 11. If you use the .NET 10 SDK, your project targets `net10.0` instead, and its package version differs.

The SDK tags the image as `latest` by default. For further reference, see [`ContainerRepository`](publish-configuration.md#containerrepository) and [`ContainerImageTag`](publish-configuration.md#containerimagetag).

## Publish .NET app

To publish the .NET app as a container, use the following [dotnet publish](../tools/dotnet-publish.md) command:

```dotnetcli
dotnet publish --os linux --arch x64 /t:PublishContainer
```

The preceding .NET CLI command publishes the app as a container:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).

> [!IMPORTANT]
> To publish the container locally, you must have a supported container runtime running. If it isn't running when you attempt to publish the app as a container, you experience an error similar to the following:
>
> ```console
> ..\build\Microsoft.NET.Build.Containers.targets(255,5): error CONTAINER1012: The local registry is not available, but pushing to a local registry was requested.
> ```

The `dotnet publish` command produces output similar to the example output:

```output
Restore complete (0.2s)
  DotNet.ContainerImage net11.0 linux-x64 succeeded (2.6s) → bin\Release\net11.0\linux-x64\publish\

Build succeeded in 3.1s
```

This command compiles your worker app to the _publish_ folder and pushes the container image to a local container runtime, such as Docker or Podman. The SDK detects which runtime to use with no additional configuration. To choose a specific runtime, set the [`LocalRegistry`](publish-configuration.md#localregistry) property.

## Run the container image

To verify that the image works, run it as a container with the `docker run` command:

```console
docker run -it --rm dotnet-worker-image
```

The `-it` option connects your terminal to the container, and the `--rm` option removes the container when it stops. The worker logs a message every second, similar to the following example output:

```output
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 11/17/2026 18:00:04 +00:00
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 11/17/2026 18:00:05 +00:00
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

To stop the app and the container, press <kbd>Ctrl+C</kbd>. If you use Podman, run the same command with `podman` in place of `docker`.

## Publish .NET app to a tarball

A tarball (or tar file) is a single file that contains other files. Tarballs are commonly used to distribute software or to create backups. In this case, the tarball distributes a container image. The SDK writes the image as an uncompressed tar archive, so this tutorial uses the _.tar_ file extension.

To publish a .NET app as a container to a tarball, use the following command:

```dotnetcli
dotnet publish --os linux --arch x64 /t:PublishContainer -p ContainerArchiveOutputPath=./images/container-image.tar
```

The preceding command publishes the app as a container to a tarball:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).
- Setting the `ContainerArchiveOutputPath` property to `./images/container-image.tar`.

The command doesn't require a running container runtime. If you set `ContainerArchiveOutputPath` to a folder instead of a file, the SDK names the file `$(ContainerRepository).tar.gz`. Despite the _.tar.gz_ extension, that file is also an uncompressed tar archive. For more information, see [`ContainerArchiveOutputPath`](publish-configuration.md#containerarchiveoutputpath).

### Load the tarball

A common use case for exporting to a tarball is for security-focused organizations. They create container images, export them as tarballs, and then run security-scanning tools over the tarballs. This approach simplifies compliance as it avoids the complexities of scanning a live system.

The tarball contains the entire container image, which you can load into a container runtime with the appropriate tool:

- [Docker](https://docs.docker.com/reference/cli/docker/image/load/): `docker load -i ./images/container-image.tar`
- [Podman](https://docs.podman.io/en/latest/markdown/podman-load.1.html): `podman load -i ./images/container-image.tar`

## Publish .NET app to container registry

Container registries are services that store and manage container images. They're used to store and distribute container images across multiple environments. Most registries require you to authenticate before you can publish an image. The .NET SDK reuses the credentials that the `docker login` command stores, or reads credentials from environment variables. For more information, see [Authenticate to container registries](overview.md#authenticate-to-container-registries).

For example, to publish to the GitHub Container Registry (`ghcr.io`), first sign in with your GitHub username and a personal access token (classic) that has the `write:packages` scope. When prompted for a password, enter the token. For more information, see [Authenticating with a personal access token (classic)](https://docs.github.com/packages/working-with-a-github-packages-registry/working-with-the-container-registry#authenticating-with-a-personal-access-token-classic).

```console
docker login ghcr.io -u USERNAME
```

Then publish the app as a container to the registry with the following command:

```dotnetcli
dotnet publish --os linux --arch x64 /t:PublishContainer -p ContainerRegistry=ghcr.io -p ContainerRepository=NAMESPACE/dotnet-worker-image
```

In the preceding commands, replace `USERNAME` with your GitHub username. Replace `NAMESPACE` with the lowercase name of the personal account or organization that owns the image. The `dotnet publish` command publishes the app as a container to a container registry:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).
- Setting the `ContainerRegistry` property to `ghcr.io`.
- Setting the `ContainerRepository` property to `NAMESPACE/dotnet-worker-image`, which overrides the value in the project file.

For more information, see [ContainerRegistry](publish-configuration.md#containerregistry).

## Clean up resources

In this tutorial, you published a .NET worker as a container image. If you want, delete the image from your local container runtime. Use the `docker images` command to list the image:

```console
docker images dotnet-worker-image
```

The output looks similar to the following example. The columns vary by Docker version.

```output
IMAGE                        ID             DISK USAGE   CONTENT SIZE   EXTRA
dotnet-worker-image:latest   c8105e2e5419        351MB         99.6MB
```

> [!TIP]
> Image files can be large. Typically, you would remove temporary containers you created while testing and developing your app. You usually keep the base images with the runtime installed if you plan on building other images based on that runtime.

To delete the image, run the `docker image rm` command:

```console
docker image rm dotnet-worker-image:latest
```

If you published the tarball, also delete the _images_ folder from the _Worker_ folder. If you use Podman, run the equivalent `podman` commands.

## Next steps

- [Announcing built-in container support for the .NET SDK](https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk)
- [Tutorial: Containerize a .NET app](../docker/build-container.md)
- [.NET container images](../docker/container-images.md)
- [Review the Azure services that support containers](https://azure.microsoft.com/overview/containers/)
- [Read about Dockerfile commands](https://docs.docker.com/engine/reference/builder/)
- [Explore the container tools in Visual Studio](/visualstudio/containers/overview)

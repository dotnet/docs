---
title: Containerize an app with dotnet publish
description: In this tutorial, you learn how to containerize a .NET application with dotnet publish command without the use of a Dockerfile.
ms.date: 01/07/2025
ms.topic: tutorial
---

# Containerize a .NET app with dotnet publish

Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud. In this tutorial, you learn how to containerize a .NET application using the [dotnet publish](../tools/dotnet-publish.md) command without the use of a Dockerfile. Additionally, you explore how to configure the [container image](../docker/container-images.md) and execution, and how to clean up resources.

> [!TIP]
> If you're interested in using a _Dockerfile_ to containerize your .NET app, see [Tutorial: Containerize a .NET app](../docker/build-container.md).

## Prerequisites

Install the following prerequisites:

- [.NET 8+ SDK](https://dotnet.microsoft.com/download/dotnet/8.0)\
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

There are various configuration options available when publishing an app as a container. By default, the container image name is the `AssemblyName` of the project. If that name is invalid as a container image name, you can override it by specifying a `ContainerRepository` as shown in the following project file:

:::code language="xml" source="snippets/Worker/DotNet.ContainerImage.csproj" highlight="8":::

For further reference, see [`ContainerRepository`](publish-configuration.md#containerrepository).

## Publish .NET app

To publish the .NET app as a container, use the following [dotnet publish](../tools/dotnet-publish.md) command:

```dotnetcli
dotnet publish --os linux --arch x64 /t:PublishContainer
```

The preceding .NET CLI command publishes the app as a container:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).

> [!IMPORTANT]
> To publish the container locally, you must have an active OCI-compliant daemon running. If it isn't running when you attempt to publish the app as a container, you experience an error similar to the following:
>
> ```console
> ..\build\Microsoft.NET.Build.Containers.targets(66,9): error MSB4018:
>    The "CreateNewImage" task failed unexpectedly. [..\Worker\DotNet.ContainerImage.csproj]
> ```

The `dotnet publish` command produces output similar to the example output:

```dotnetcli
Restore complete (0.2s)
  DotNet.ContainerImage succeeded (2.6s) → bin\Release\net9.0\linux-x64\publish\
```

This command compiles your worker app to the _publish_ folder and pushes the container image to your local Docker daemon by default. If you're using Podman, the tooling also supports pushing there with no additional configuration.

## Publish .NET app to a tarball

A tarball (or tar file) is a file that contains other files. It usually ends with a _*.tar.gz_ compound file extension to help indicate that it's a compressed archive. These file types are used to distribute software or to create backups. In this case, the tarball created is used to distribute a container image.

To publish a .NET app as a container to a tarball, use the following command:

```dotnetcli
dotnet publish --os linux --arch x64 \
    /t:PublishContainer \
    -p ContainerArchiveOutputPath=./images/container-image.tar.gz
```

The preceding command publishes the app as a container to a tarball:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).
- Setting the `ContainerArchiveOutputPath` property to `./images/container-image.tar.gz`.

The command doesn't require a running OCI-compliant daemon. For more information, see [`ContainerArchiveOutputPath`](publish-configuration.md#containerarchiveoutputpath).

### Load the tarball

A common use case for exporting to a tarball is for security-focused organizations. They create containers, export them as tarballs, and then run security-scanning tools over the tarballs. This approach simplifies compliance as it avoids the complexities of scanning a live system.

The tarball contains the entire container, which can then be loaded using the appropriate tool:

- [Docker](https://docs.docker.com/reference/cli/docker/image/load/): `docker load -i ./images/container-image.tar.gz`
- [Podman](https://docs.podman.io/en/latest/markdown/podman-load.1.html): `podman load -i ./images/container-image.tar.gz`

## Publish .NET app to container registry

Container registries are services that store and manage container images. They're used to store and distribute container images across multiple environments. You can publish a .NET app as a container to a container registry by using the following command:

```dotnetcli
dotnet publish --os linux --arch x64 \
    /t:PublishContainer \
    -p ContainerRegistry=ghcr.io
```

The preceding code publishes the app as a container to a container registry:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).
- Setting the `ContainerRegistry` property to `ghcr.io`.

For more information, see [ContainerRegistry](publish-configuration.md#containerregistry).

## Clean up resources

In this article, you published a .NET worker as a container image. If you want, delete this resource. Use the `docker images` command to see a list of installed images.

```console
docker images
```

Consider the following example output:

```console
REPOSITORY             TAG       IMAGE ID       CREATED          SIZE
dotnet-worker-image    1.0.0     25aeb97a2e21   12 seconds ago   191MB
```

> [!TIP]
> Image files can be large. Typically, you would remove temporary containers you created while testing and developing your app. You usually keep the base images with the runtime installed if you plan on building other images based on that runtime.

To delete the image, copy the image ID and run the `docker image rm` command:

```console
docker image rm 25aeb97a2e21
```

## Next steps

- [Announcing built-in container support for the .NET SDK](https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk)
- [Tutorial: Containerize a .NET app](../docker/build-container.md)
- [.NET container images](../docker/container-images.md)
- [Review the Azure services that support containers](https://azure.microsoft.com/overview/containers/)
- [Read about Dockerfile commands](https://docs.docker.com/engine/reference/builder/)
- [Explore the container tools in Visual Studio](/visualstudio/containers/overview)

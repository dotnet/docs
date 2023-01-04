---
title: Containerize an app with dotnet publish
description: In this tutorial, you'll learn how to containerize a .NET application with dotnet publish.
ms.date: 01/04/2023
ms.topic: tutorial
---

# Containerize a .NET app with dotnet publish

Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud. In this tutorial, you'll learn how to containerize a .NET application using the [dotnet publish](../tools/dotnet-publish.md) command.

## Prerequisites

Install the following prerequisites:

- [.NET 7+ SDK](https://dotnet.microsoft.com/download/dotnet/7.0)\
If you have .NET installed, use the `dotnet --info` command to determine which SDK you're using.
- [Docker Community Edition](https://www.docker.com/products/docker-desktop)

In addition to these prerequisites, it's recommended that you're familiar with [Worker Services in .NET](../extensions/workers.md).

## Create .NET app

You need a .NET app to containerize, so start by creating a new app from a template. Open your terminal, create a working folder (*sample-directory*) if you haven't already, and change directories so that you're in it. In the working folder, run the following command to create a new project in a subdirectory named *Worker*:

```dotnetcli
dotnet new worker -o Worker -n DotNet.ContainerImage
```

Your folder tree will look like the following:

```Directory
📁 sample-directory
    └──📂 Worker
        ├──appsettings.Development.json
        ├──appsettings.json
        ├──DotNet.ContainerImage.csproj
        ├──Program.cs
        ├──Worker.cs
        └──📂 obj
            ├── DotNet.ContainerImage.csproj.nuget.dgspec.json
            ├── DotNet.ContainerImage.csproj.nuget.g.props
            ├── DotNet.ContainerImage.csproj.nuget.g.targets
            ├── project.assets.json
            └── project.nuget.cache
```

The `dotnet new` command creates a new folder named _Worker_ and generates a worker service that, when run, logs a message every second. From your terminal session, change directories and navigate into the *Worker* folder. Use the `dotnet run` command to start the app.

```dotnetcli
dotnet run
Building...
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:00 -05:00
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: .\Worker
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:01 -05:00
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:02 -05:00
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:03 -05:00
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
Attempting to cancel the build...
```

The worker template loops indefinitely. Use the cancel command <kbd>Ctrl+C</kbd> to stop it.

## Add NuGet package

The [Microsoft.NET.Build.Containers NuGet package](https://libraries.io/nuget/Microsoft.NET.Build.Containers) package is currently required to publish an app as a container. To add the `Microsoft.NET.Build.Containers` NuGet package to the worker template, run the following [dotnet add package](../tools/dotnet-add-package.md) command:

```dotnetcli
dotnet add package Microsoft.NET.Build.Containers
```

## Set the container image name

There are various configuration options available when publishing an app as a container. For more information, see [Configure container image](#configure-container-image).

By default, the container image name is the `AssemblyName` of the project. If that name is invalid as a container image name, you can override it by specifying a `ContainerImageName` as shown in the following:

:::code language="xml" source="snippets/Worker/DotNet.ContainerImage.csproj" highlight="8":::

## Publish .NET app

To publish the .NET app as a container, use the following `dotnet publish` command:

```dotnetcli
dotnet publish --os linux --arch x64 /t:PublishContainer -c Release
```

The preceding .NET CLI command publishes the app as a container:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).
- Using the release configuration (`-c Release`).

> [!IMPORTANT]
> To build the container locally, you must have the Docker daemon running. If it isn't running when you attempt to publish the app as a container, you'll experience an error similar to the following:
>
> ```console
> ..\build\Microsoft.NET.Build.Containers.targets(66,9): error MSB4018:
>    The "CreateNewImage" task failed unexpectedly. [..\Worker\DotNet.ContainerImage.csproj]
> ```

> [!TIP]
> Depending on the type of app you're containerizing, the command-line switches (options) might vary. For example, the `/t:PublishContainer` argument is only required for non-web .NET apps, such as `console` and `worker` templates. For web templates, replace the `/t:PublishContainer` argument with `-p:PublishProfile=DefaultContainer`. For more information, see [.NET SDK container builds, issue #141](https://github.com/dotnet/sdk-container-builds/issues/141).

The command will produce output similar to the following:

```dotnetcli
Determining projects to restore...
  All projects are up-to-date for restore.
  DotNet.ContainerImage -> .\Worker\bin\Release\net7.0\linux-x64\DotNet.ContainerImage.dll
  DotNet.ContainerImage -> .\Worker\bin\Release\net7.0\linux-x64\publish\
  Pushed container 'dotnet-worker-image:1.0.0' to registry 'docker://'
```

This command compiles your worker app to the *publish- folder and pushes the container to your local docker registry.

## Configure container image

You can control many aspects of the generated container through MSBuild properties. In general, if you could use a command in a _Dockerfile_ to set some configuration, you can do the same via MSBuild.

> [!NOTE]
> The only exceptions to this are `RUN` commands. Due to the way containers are built, those cannot be emulated. If you need this functionality, you'll need to use a _Dockerfile_ to build your container images.

> [!IMPORTANT]
> Currently, only Linux containers are supported.

### `ContainerBaseImage`

The container base image property controls the image used as the basis for your image. By default, the following values are inferred based on the properties of your project:

- If your project is self-contained, the `mcr.microsoft.com/dotnet/runtime-deps` image is used as the base image.
- If your project is an ASP.NET Core project, the `mcr.microsoft.com/dotnet/aspnet` image is used as the base image.
- Otherwise the `mcr.microsoft.com/dotnet/runtime` image is used as the base image.

The tag of the image is inferred to be the numeric component of your chosen `TargetFramework`. For example, a project targeting `.net6.0` will result in the `6.0` tag of the inferred base image, and a `.net7.0-linux` project will use the `7.0` tag.

If you set a value here, you should set the fully qualified name of the image to use as the base, including any tag you prefer:

```xml
<ContainerBaseImage>mcr.microsoft.com/dotnet/runtime:6.0</ContainerBaseImage>
```

### `ContainerRegistry`

The container registry property controls the destination registry, the place that the newly created image will be pushed to. Be default, it's pushed to the local Docker daemon (`docker://`), ut you can also specify a remote registry. For example, consider the following XML example:

```xml
<ContainerRegistry>registry.mycorp.com:1234</ContainerRegistry>
```

> [!IMPORTANT]
> There is no authentication currently supported. This is planned for [a future release](https://github.com/dotnet/sdk-container-builds/issues/70), so make sure you're pointing to a local Docker daemon.

### `ContainerImageName`

The container image name controls the name of the image itself, e.g `dotnet/runtime` or `my-app`. By default, the `AssemblyName` of the project is used.

```xml
<ContainerImageName>my-app</ContainerImageName>
```

Image names consist of one or more slash-delimited segments, each of which can only contain lowercase alphanumeric characters, periods, underscores, and dashes, and must start with a letter or number. Any other characters will result in an error being thrown.

### `ContainerImageTags`

The container image tag property controls the tags that are generated for the image. Tags are often used to refer to different versions of an application, but they can also refer to different operating system distributions, or even different configurations. By default, the `Version` of the project is used as the tag value. To override the default, specify either of the following:

```xml
<ContainerImageTag>1.2.3-alpha2</ContainerImageTag>
```

To specify multiple tags, use a semicolon-delimited set of tags in the `ContainerImageTags` property, similar to setting multiple `TargetFrameworks`:

```xml
<ContainerImageTags>1.2.3-alpha2;latest</ContainerImageTags>
```

Tags can only contain up to 127 alphanumeric characters, periods, underscores, and dashes. They must start with an alphanumeric character or an underscore. Any other form will result in an error being thrown.

### `ContainerWorkingDirectory`

The container working directory node controls the working directory of the container, the directory that commands are executed within if not other command is run.

By default, the `/app` directory value is used as the working directory.

```xml
<ContainerWorkingDirectory>/bin</ContainerWorkingDirectory>
```

### `ContainerPort`

The container port adds TCP or UDP ports to the list of known ports for the container. This enables container runtimes like Docker to map these ports to the host machine automatically. This is often used as documentation for the container, but can also be used to enable automatic port mapping.

The `ContainerPort` node has two attributes:

- `Include`: The port number to expose.
- `Type`: Defaults to `tcp`, valid values are either `tcp` or `udp`.

```xml
<ItemGroup>
    <ContainerPort Include="80" Type="tcp" />
</ItemGroup>
```

### `ContainerLabel`

The container label adds a metadata label to the container. Labels have no impact on the container at runtime, but are often used to store version and authoring metadata for use by security scanners and other infrastructure tools. You can specify any number of container labels.

The `ContainerLabel` node has two attributes:

- `Include`: The key of the label.
- `Value`: The value of the label (this may be empty).

```xml
<ItemGroup>
    <ContainerLabel Include="org.contoso.businessunit" Value="contoso-university" />
</ItemGroup>
```

For a list of labels that are created by default, see [default container labels](#default-container-labels).

### `ContainerEnvironmentVariable`

The container environment variable node allows you to add environment variables to the container. Environment variables are accessible to the application running in the container immediately, and are often used to change the run-time behavior of the running application.

The `ContainerEnvironmentVariable` node has two attributes:

- `Include`: The name of the environment variable.
- `Value`: The value of the environment variable.

```xml
<ItemGroup>
  <ContainerEnvironmentVariable Include="LOGGER_VERBOSITY" Value="Trace" />
</ItemGroup>
```

For more information, see [.NET environment variables](../tools/dotnet-environment-variables.md).

### `ContainerEntrypoint`

The container entry point can be used to customize the `ENTRYPOINT` of the container, which is the executable that is called when the container is started. By default, for builds that create an app host, it's set as the `ContainerEntrypoint`. For builds that don't create an executable, the `dotnet path/to/application.dll` is used as the `ContainerEntrypoint`.

The `ContainerEntrypoint` node has a single attribute:

- `Include`: The command, option, or argument to use in the `ContainerEntrypoint` command.

For example, consider the following sample .NET project item group:

```xml
<ItemGroup Label="Entrypoint Assignment">
  <!-- This is how you would start the dotnet ef tool in your container -->
  <ContainerEntrypoint Include="dotnet" />
  <ContainerEntrypoint Include="ef" />

  <!-- This shorthand syntax means the same thing.
       Note the semicolon separating the tokens. -->
  <ContainerEntrypoint Include="dotnet;ef" />
</ItemGroup>
```

### `ContainerEntrypointArgs`

The container entry point args node controls the default arguments provided to the `ContainerEntrypoint`. This should be used when the `ContainerEntrypoint` is a program that the user might want to use on its own. By default, no `ContainerEntrypointArgs` are created on your behalf.

The `ContainerEntrypointArg` node has a single attribute:

- `Include`: The option or argument to apply to the `ContainerEntrypoint` command.

Consider the following example .NET project item group:

```xml
<ItemGroup>
  <!-- Assuming the ContainerEntrypoint defined above, 
       this would be the way to update the database by 
       default, but let the user run a different EF command. -->
  <ContainerEntrypointArgs Include="database" />
  <ContainerEntrypointArgs Include="update" />

  <!-- This is the shorthand syntax for the same idea -->
  <ContainerEntrypointArgs Include="database;update" />
</ItemGroup>
```

### Default container labels

Labels are often used to provide consistent metadata on container images. This package provides some default labels to encourage better maintainability of the generated images.

- `org.opencontainers.image.created` is set to the ISO 8601 format of the current UTC `DateTime`.

For more information, see [Implement conventional labels on top of existing label infrastructure](https://github.com/dotnet/sdk-container-builds/issues/96).

## Clean up resources

In this article, you published a .NET worker as a container image. If you want, delete this resource. Use the `docker images` command to see a list of images installed.

```dockerfile
docker images
```

Consider the following example output:

```console
REPOSITORY            TAG       IMAGE ID       CREATED          SIZE
dotnet-worker-image   1.0.0     25aeb97a2e21   12 seconds ago   191MB
```

> [!TIP]
> Image files can be large. Typically, you would remove temporary containers you created while testing and developing your app. You usually keep the base images with the runtime installed if you plan on building other images based on that runtime.

To delete the image, copy the image id and run the `docker image rm` command:

```console
docker image rm 25aeb97a2e21
```

## Next steps

- [Announcing built-in container support for the .NET SDK](https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk)
- [Tutorial: Containerize a .NET app](build-container.md)
- [Review the Azure services that support containers](https://azure.microsoft.com/overview/containers/)
- [Read about Dockerfile commands](https://docs.docker.com/engine/reference/builder/)
- [Explore the container tools in Visual Studio](/visualstudio/containers/overview)

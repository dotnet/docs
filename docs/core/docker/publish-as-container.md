---
title: Containerize an app with dotnet publish
description: In this tutorial, you'll learn how to containerize a .NET application with dotnet publish.
ms.date: 10/18/2022
ms.topic: tutorial
---

# Containerize a .NET app with dotnet publish

Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud. In this tutorial, you'll learn how to containerize a .NET application using the [dotnet publish](../tools/dotnet-publish.md) command.

## Prerequisites

Install the following prerequisites:

- [.NET SDK](https://dotnet.microsoft.com/download)\
If you have .NET installed, use the `dotnet --info` command to determine which SDK you're using.
- [Docker Community Edition](https://www.docker.com/products/docker-desktop)
- Familiarity with [Worker Services in .NET](../extensions/workers.md)

## Create .NET app

You need a .NET app to containerize, so you'll start by creating a new app from a template. Open your terminal, create a working folder (*sample-directory*) if you haven't already, and change directories so that you're in it. In the working folder, run the following command to create a new project in a subdirectory named *Worker*:

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

The `dotnet new` command creates a new folder named *Worker* and generates a worker service that when ran will log a message every second. Change directories and navigate into the *Worker* folder, from your terminal session. Use the `dotnet run` command to start the app. The application will run, and print `Hello World!` below the command:

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

The .NET 7 SDK will eventually be capable of publishing .NET apps as containers without the use of the [Microsoft.NET.Build.Containers NuGet package](https://libraries.io/nuget/Microsoft.NET.Build.Containers). Until that time, this package is required. To add the `Microsoft.NET.Build.Containers` NuGet package to the worker template, run the following [dotnet add package](../tools/dotnet-add-package.md) command:

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

The preceding .NET CLI command, publishes the app as a container:

- Targeting Linux as the OS (`--os linux`).
- Specifying an x64 architecture (`--arch x64`).
- Using the release configuration (`-c Release`).

> [!IMPORTANT]
> To build the container locally, you must have the Docker daemon running. If it isn't running when you attempt to publish the app as a container, you'll experience an error similar to the following:
>
> ```console
> ..\.nuget\packages\microsoft.net.build.containers\0.1.8\build\Microsoft.NET.Build.Containers.targets(66,9): error MSB4018: The "CreateNewImage" task failed unexpectedly. [..\Worker\DotNet.ContainerImage.csproj]
> ```

> [!TIP]
> Depending on the type of app you're containerizing, the command-line switches (options) might vary. For example, the `/t:PublishContainer` argument is only required for non-web .NET apps, such as `console` and `worker` templates. For web templates, replace the `/t:PublishContainer` argument with `-p:PublishProfile=DefaultContainer`. For more information, see [.NET SDK container builds, issue #141](https://github.com/dotnet/sdk-container-builds/issues/141).

The command will output similar to the following:

```dotnetcli
Determining projects to restore...
  All projects are up-to-date for restore.
  DotNet.ContainerImage -> .\Worker\bin\Release\net7.0\linux-x64\DotNet.ContainerImage.dll
  DotNet.ContainerImage -> .\Worker\bin\Release\net7.0\linux-x64\publish\
  Pushed container 'dotnet-worker-image:1.0.0' to registry 'docker://'
```

This command compiles your worker app to the *publish* folder and pushes the container to your local docker registry.

## Configure container image

You can control many aspects of the generated container through MSBuild properties. In general, if you could use a command in a _Dockerfile_ to set some configuration, you can do the same via MSBuild.

> [!NOTE]
> The only exception to this are `RUN` commands, due to the way containers are built, those cannot be emulated. If you need this functionality, you will need to use a _Dockerfile_ to build your container images.

> [!IMPORTANT]
> Only Linux containers are currently supported.

### `ContainerBaseImage`

This property controls the image used as the basis for your image. By default, we will infer the following values for you based on the properties of your project:

* if your project is self-contained, we use the `mcr.microsoft.com/dotnet/runtime-deps` image as the base image
* if your project is an ASP.NET Core project, we use the `mcr.microsoft.com/dotnet/aspnet` image as the base image
* otherwise we use the `mcr.microsoft.com/dotnet/runtime` image as the base image

We infer the tag of the image to be the numeric component of your chosen `TargetFramework` - so a `.net6.0` project will use the `6.0` tag of the inferred base image, a `.net7.0-linux` project will use the `7.0` tag, and so on.

If you set a value here, you should set the fully-qualified name of the image to use as the base, including any tag you prefer:

```xml
<ContainerBaseImage>mcr.microsoft.com/dotnet/runtime:6.0</ContainerBaseImage>
```

### `ContainerRegistry`

This property controls the destination registry - the place that the newly-created image will be pushed to.

Be default, we push to the local Docker daemon (annotated by `docker://`), but for this release you can specify any _unauthenticated_ registry. For example:

```xml
<ContainerRegistry>registry.mycorp.com:1234</ContainerRegistry>
```

> [!IMPORTANT]
> There is no authentication currently supported. This is planned for [a future release](https://github.com/dotnet/sdk-container-builds/issues/70), so make sure you're pointing to a local Docker daemon.

### `ContainerImageName`

This property controls the name of the image itself, e.g `dotnet/runtime` or `my-awesome-app`.

By default, the value used will be the `AssemblyName` of the project.

```xml
<ContainerImageName>my-super-awesome-app</ContainerImageName>
```

> [!CAUTION]
> Image names can only contain lowercase alphanumeric characters, periods, underscores, and dashes, and must start with a letter or number, any other characters will result in an error being thrown.

## `ContainerImageTag(s)`

This property controls the tag that is generated for the image. Tags are often used to refer to different versions of an application, but they can also refer to different operating system distributions, or even just different baked-in configuration. This property also can be used to push multiple tags - simply use a semicolon-delimited set of tags in the `ContainerImageTags` property, similar to setting multiple `TargetFrameworks`.

By default, the value used will be the `Version` of the project.

```xml
<ContainerImageTag>1.2.3-alpha2</ContainerImageTag>
```

```xml
<ContainerImageTags>1.2.3-alpha2;latest</ContainerImageTags>
```

Tags can only contain up to 127 alphanumeric characters, periods, underscores, and dashes. They must start with an alphanumeric character or an underscore. Any other form will result in an error being thrown.

### `ContainerWorkingDirectory`

This property controls the working directory of the container - the directory that commands are executed within if not other command is run.

By default, we use the `/app` directory as the working directory.

```xml
<ContainerWorkingDirectory>/bin</ContainerWorkingDirectory>
```

## `ContainerPort`

This item adds TCP or UDP ports to the list of known ports for the container. This enables container runtimes like Docker to map these ports to the host machine automatically. This is often used as documentation for the container, but can also be used to enable automatic port mapping.

ContainerPort items have two properties:

* Include
  * The port number to expose
* Type
  * One of `tcp` or `udp` - the default is `tcp`

```xml
<ItemGroup>
    <ContainerPort Include="80" Type="tcp" />
</ItemGroup>
```

> **Note**
> This item does nothing for the container by default and should be considered advisory at best.

### `ContainerLabel`

This item adds a metadata label to the container. Labels have no impact on the container at runtime, but are often used to store version and authoring metadata for use by security scanners and other infrastructure tools.

ContainerLabel items have two properties:

* Include
  * The key of the label
* Value
  * The value of the label - this may be empty

See [default container labels](#default-container-labels) for a list of labels that are created by default.

```xml
<ItemGroup>
    <ContainerLabel Include="org.contoso.businessunit" Value="contoso-university" />
<ItemGroup>
```

## `ContainerEnvironmentVariable`

This item adds a new environment variable to the container. Environment variables will be accessible to the application running in the container immediately, and are often used to change the runtime behavior of the running application.

ContainerEnvironmentVariable items have two properties:

* Include
  * The name of the environment variable
* Value
  * The value of the environment variable

```xml
<ItemGroup>
  <ContainerEnvironmentVariable Include="LOGGER_VERBOSITY" Value="Trace" />
</ItemGroup>
```

## `ContainerEntrypoint`

This item can be used to customize the entrypoint of the container - the binary that is run by default when the container is started.

By default, for builds that create an executable binary that binary is set as the ContainerEntrypoint. For builds that do not create an executable binary `dotnet path/to/application.dll` is used as the ContainerEntrypoint.

ContainerEntrypoint items have one property:

* Include
  * The command, option, or argument to use in the entrypoint command

```xml
<ItemGroup Label="Entrypoint Assignment">
  <!-- This is how you would start the dotnet ef tool in your container -->
  <ContainerEntrypoint Include="dotnet" />
  <ContainerEntrypoint Include="ef" />

  <!-- This shorthand syntax means the same thing - note the semicolon separating the tokens. -->
  <ContainerEntrypoint Include="dotnet;ef" />
</ItemGroup>
```

## `ContainerEntrypointArgs`

This item controls the default arguments provided to the `ContainerEntrypoint`. This should be used when the ContainerEntrypoint is a program that the user might want to use on its own.

By default, no ContainerEntrypointArgs are created on your behalf.

ContainerEntrypointArg items have one property:

* Include
  * The option or argument to apply to the ContainerEntrypoint command

```xml
<ItemGroup>
  <!-- Assuming the ContainerEntrypoint defined above, this would be the way to update the database by default, but let the user run a different EF command. -->
  <ContainerEntrypointArgs Include="database" />
  <ContainerEntrypointArgs Include="update" />

  <!-- This is the shorthand syntax for the same idea -->
  <ContainerEntrypointArgs Include="database;update" />
</ItemGroup>
```

### Default container labels

Labels are often used to provide consistent metadata on container images. This package provides some default labels to encourage better maintainability of the generated images.

* `org.opencontainers.image.created` is set to the ISO 8601 format of the current UTC DateTime

## Clean up resources

During this tutorial, you created containers and images. If you want, delete these resources. Use the following commands to

01. List all containers

    ```console
    docker ps -a
    ```

01. Stop containers that are running by their name.

    ```console
    docker stop counter-image
    ```

01. Delete the container

    ```console
    docker rm counter-image
    ```

Next, delete any images that you no longer want on your machine. Delete the image created by your _Dockerfile_ and then delete the .NET image the _Dockerfile_ was based on. You can use the **IMAGE ID** or the **REPOSITORY:TAG** formatted string.

```console
docker rmi counter-image:latest
docker rmi mcr.microsoft.com/dotnet/aspnet:6.0
```

Use the `docker images` command to see a list of images installed.

> [!TIP]
> Image files can be large. Typically, you would remove temporary containers you created while testing and developing your app. You usually keep the base images with the runtime installed if you plan on building other images based on that runtime.

## Next steps

- [Learn how to containerize an ASP.NET Core application.](/aspnet/core/host-and-deploy/docker/building-net-docker-images)
- [Try the ASP.NET Core Microservice Tutorial.](https://dotnet.microsoft.com/learn/web/aspnet-microservice-tutorial/intro)
- [Review the Azure services that support containers.](https://azure.microsoft.com/overview/containers/)
- [Read about Dockerfile commands.](https://docs.docker.com/engine/reference/builder/)
- [Explore the Container Tools for Visual Studio](/visualstudio/containers/overview)

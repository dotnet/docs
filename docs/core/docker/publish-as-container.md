---
title: Containerize an app with dotnet publish
description: In this tutorial, you learn how to containerize a .NET application with dotnet publish command without the use of a Dockerfile.
ms.date: 01/07/2025
ms.topic: tutorial
---

# Containerize a .NET app with dotnet publish

Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud. In this tutorial, you learn how to containerize a .NET application using the [dotnet publish](../tools/dotnet-publish.md) command without the use of a Dockerfile. Additionally, you explore how to configure the [container image](container-images.md) and execution, and how to clean up resources.

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

## Publishing project considerations

Now that you have a .NET app, you can publish it as a container. Before doing so, there are several important considerations to keep in mind. Prior to .NET SDK version 8.0.200, you needed the [📦 Microsoft.NET.Build.Containers](https://www.nuget.org/packages/Microsoft.NET.Build.Containers) NuGet package. This package isn't required for .NET SDK version 8.0.200 and later, as the container support is included by default.

To enable publishing a .NET app as a container, the following build properties are required:

- `IsPublishable`: Set to `true`. This property is implicitly set to `true` for executable project types, such as `console`, `webapp`, and `worker`.
- `EnableSdkContainerSupport`: Set to `true` when your project type is a console app.

To explicitly enable SDK container support, consider the following project file snippet:

```xml
<PropertyGroup>
  <IsPublishable>true</IsPublishable>
  <EnableSdkContainerSupport>true</EnableSdkContainerSupport>
</PropertyGroup>
```

## Publish switches and build properties

As with all .NET CLI commands, you can specify [MSBuild properties on the command line](/visualstudio/msbuild/msbuild-command-line-reference). There are many valid syntax forms available to provide properties, such as:

- `/p:PropertyName=Value`
- `-p:PropertyName=Value`
- `-p PropertyName=Value`
- `--property PropertyName=Value`

You're free to use whichever syntax you prefer, but the documentation shows examples using the `-p` form.

> [!TIP]
> To help troubleshoot, consider using the MSBuid logs. To generate a binary log (binlog) file, add the `-bl` switch to the `dotnet publish` command. Binlog files are useful for diagnosing build issues and can be opened in the [MSBuild Structured Log Viewer](https://msbuildlog.com/). They provide a detailed trace of the build process, essential for MSBuild analysis. For more information, see [Troubleshoot and create logs for MSBuild](/visualstudio/ide/msbuild-logs#provide-msbuild-binary-logs-for-investigation).

### Publish profiles and targets

When using `dotnet publish`, specifying a profile with `-p PublishProfile=DefaultContainer` can set a property that causes the SDK to trigger another target after the publish process. This is an indirect way of achieving the desired result. On the other hand, using `dotnet publish /t:PublishContainer` directly invokes the `PublishContainer` target, achieving the same outcome but in a more straightforward manner.

In other words, the following .NET CLI command:

```dotnetcli
dotnet publish -p PublishProfile=DefaultContainer
```

Which sets the `PublishProfile` property to `DefaultContainer`, is equivalent to the following command:

```dotnetcli
dotnet publish /t:PublishContainer
```

The difference between the two methods is that the former uses a profile to set the property, while the latter directly invokes the target. The reason this is important is that profiles are a feature of MSBuild, and they can be used to set properties in a more complex way than just setting them directly.

One key issue is that not all project types support profiles or have the same set of profiles available. Additionally, there's a disparity in the level of support for profiles between different tooling, such as Visual Studio and the .NET CLI. Therefore, using targets is generally a clearer and more widely supported method to achieve the same result.

## Set the container image name

There are various configuration options available when publishing an app as a container. By default, the container image name is the `AssemblyName` of the project. If that name is invalid as a container image name, you can override it by specifying a `ContainerRepository` as shown in the following project file:

:::code language="xml" source="snippets/Worker/DotNet.ContainerImage.csproj" highlight="8":::

For further reference, see [ContainerRepository](#containerrepository).

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

This command compiles your worker app to the _publish_ folder and pushes the container image to your local Docker daemon by default. If you're using Podman, an alias

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

The command doesn't require a running OCI-compliant daemon. For more information, see [ContainerArchiveOutputPath](#containerarchiveoutputpath).

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

For more information, see [ContainerRegistry](#containerregistry).

## Configure container image

You can control many aspects of the generated container through MSBuild properties. In general, if you can use a command in a _Dockerfile_ to set some configuration, you can do the same via MSBuild.

> [!NOTE]
> The only exceptions to this are `RUN` commands. Due to the way containers are built, those can't be emulated. If you need this functionality, you might consider using a _Dockerfile_ to build your container images.

There's no way of performing `RUN` commands with the .NET SDK. These commands are often used to install some OS packages or create a new OS user, or any number of arbitrary things. If you would like to keep using the .NET SDK container building feature, you can instead create a custom base image with these changes and then using this base image. For more information, see [`ContainerBaseImage`](#containerbaseimage).

### `ContainerArchiveOutputPath`

To create a container image within a _tar.gz_ archive, use the `ContainerArchiveOutputPath` property. This feature is useful if your workflow isn't straightforward and requires that you, for example, run a scanning tool over your images before pushing them. Once the archive is created, you can move it, scan it, or load it into a local Docker toolchain.

To publish to an archive, add the `ContainerArchiveOutputPath` property to your `dotnet publish` command, for example:

```dotnetcli
dotnet publish \
  -p PublishProfile=DefaultContainer \
  -p ContainerArchiveOutputPath=./images/sdk-container-demo.tar.gz
```

You can specify either a folder name or a path with a specific file name. If you specify the folder name, the filename generated for the image archive file is named `$(ContainerRepository).tar.gz`. These archives can contain multiple tags inside them, only as single file is created for all `ContainerImageTags`.

### Container image naming configuration

Container images follow a specific naming convention. The name of the image is composed of several parts, the registry, optional port, repository, and optional tag and family.

```dockerfile
REGISTRY[:PORT]/REPOSITORY[:TAG[-FAMILY]]
```

For example, consider the fully qualified `mcr.microsoft.com/dotnet/runtime:8.0-alpine` image name:

- `mcr.microsoft.com` is the registry (and in this case represents the Microsoft container registry).
- `dotnet/runtime` is the repository (but some consider this the `user/repository`).
- `8.0-alpine` is the tag and family (the family is an optional specifier that helps disambiguate OS packaging).

Some properties described in the following sections correspond to managing parts of the generated image name. Consider the following table that maps the relationship between the image name and the build properties:

| Image name part   | MSBuild property      | Example values          |
|-------------------|-----------------------|-------------------------|
| `REGISTRY[:PORT]` | `ContainerRegistry`   | `mcr.microsoft.com:443` |
| `PORT`            | `ContainerPort`       | `:443`                  |
| `REPOSITORY`      | `ContainerRepository` | `dotnet/runtime`        |
| `TAG`             | `ContainerImageTag`   | `8.0`                   |
| `FAMILY`          | `ContainerFamily`     | `-alpine`               |

The following sections describe the various properties that can be used to control the generated container image.

### `ContainerBaseImage`

The container base image property controls the image used as the basis for your image. By default, the following values are inferred based on the properties of your project:

- If your project is self-contained, the `mcr.microsoft.com/dotnet/runtime-deps` image is used as the base image.
- If your project is an ASP.NET Core project, the `mcr.microsoft.com/dotnet/aspnet` image is used as the base image.
- Otherwise the `mcr.microsoft.com/dotnet/runtime` image is used as the base image.

The tag of the image is inferred to be the numeric component of your chosen `TargetFramework`. For example, a project targeting `net6.0` results in the `6.0` tag of the inferred base image, and a `net7.0-linux` project uses the `7.0` tag, and so on.

If you set a value here, you should set the fully qualified name of the image to use as the base, including any tag you prefer:

```xml
<PropertyGroup>
    <ContainerBaseImage>mcr.microsoft.com/dotnet/runtime:8.0</ContainerBaseImage>
</PropertyGroup>
```

With .NET SDK version 8.0.200, the `ContainerBaseImage` inference is improved to optimize the size and security:

- Targeting the `linux-musl-x64` or `linux-musl-arm64` Runtime Identifiers, automatically chooses the `alpine` image variants to ensure your project runs:
  - If the project uses `PublishAot=true` then the `nightly/runtime-deps` `jammy-chiseled-aot` variant of the base image for best size and security.
  - If the project uses `InvariantGlobalization=false` then the `-extra` variants is used to ensure localization still works.

For more information regarding the image variants sizes and characteristics, see [.NET 8.0 Container Image Size Report](https://github.com/dotnet/dotnet-docker/blob/main/documentation/sample-image-size-report.md).

### `ContainerFamily`

Starting with .NET 8, you can use the `ContainerFamily` MSBuild property to choose a different family of Microsoft-provided container images as the base image for your app. When set, this value is appended to the end of the selected TFM-specific tag, changing the tag provided. For example, to use the Alpine Linux variants of the .NET base images, you can set `ContainerFamily` to `alpine`:

```xml
<PropertyGroup>
    <ContainerFamily>alpine</ContainerFamily>
</PropertyGroup>
```

The preceding project configuration results in a final tag of `8.0-alpine` for a .NET 8-targeting app.

This field is free-form, and often can be used to select different operating system distributions, default package configurations, or any other _flavor_ of changes to a base image. This field is ignored when `ContainerBaseImage` is set. For more information, see [.NET container images](container-images.md).

### `ContainerRuntimeIdentifier`

The `ContainerRuntimeIdentifier` property specifies the OS and architecture for your container if the `ContainerBaseImage` supports multiple platforms. For example, the `mcr.microsoft.com/dotnet/runtime` image supports `linux-x64`, `linux-arm`, `linux-arm64`, and `win10-x64`. By default, this is set to the `RuntimeIdentifier` used when publishing the container. Typically, you don't need to set this property explicitly; instead, use the `-r` option with the `dotnet publish` command. If the chosen image doesn't support the specified `RuntimeIdentifier`, an error indicates the supported identifiers.

You can always set the `ContainerBaseImage` property to a fully qualified image name, including the tag, to avoid needing to use this property at all.

```xml
<PropertyGroup>
    <ContainerRuntimeIdentifier>linux-arm64</ContainerRuntimeIdentifier>
</PropertyGroup>
```

For more information regarding the runtime identifiers supported by .NET, see [RID catalog](../rid-catalog.md).

### `ContainerRegistry`

The container registry property controls the destination registry, the place that the newly created image will be pushed to. By default it's pushed to the local Docker daemon, but you can also specify a remote registry. When using a remote registry that requires authentication, you authenticate using the well-known `docker login` mechanisms. For more information, See [authenticating to container registries](https://aka.ms/dotnet/containers/auth) for more details. For a concrete example of using this property, consider the following XML example:

```xml
<PropertyGroup>
    <ContainerRegistry>registry.mycorp.com:1234</ContainerRegistry>
</PropertyGroup>
```

This tooling supports publishing to any registry that supports the [Docker Registry HTTP API V2](https://docs.docker.com/registry/spec/api/). This includes the following registries explicitly (and likely many more implicitly):

- [Azure Container Registry](https://azure.microsoft.com/products/container-registry)
- [Amazon Elastic Container Registry](https://aws.amazon.com/ecr/)
- [Google Artifact Registry](https://cloud.google.com/artifact-registry)
- [Docker Hub](https://hub.docker.com/)
- [GitHub Packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry)
- [GitLab-hosted Container Registry](https://docs.gitlab.com/ee/user/packages/container_registry/)
- [Quay.io](https://quay.io/)

For notes on working with these registries, see the [registry-specific notes](https://aka.ms/dotnet/containers/auth#notes-for-specific-registries).

### `ContainerRepository`

The container repository is the name of the image itself, for example, `dotnet/runtime` or `my-app`. By default, the `AssemblyName` of the project is used.

```xml
<PropertyGroup>
    <ContainerRepository>my-app</ContainerRepository>
</PropertyGroup>
```

Image names consist of one or more slash-delimited segments, each of which can only contain lowercase alphanumeric characters, periods, underscores, and dashes, and must start with a letter or number. Any other characters result in an error being thrown.

### `ContainerImageTag(s)`

The container image tag property controls the tags that are generated for the image. To specify a single tag use `ContainerImageTag` and for multiple tags use `ContainerImageTags`.

> [!IMPORTANT]
> When you use `ContainerImageTags`, you'll end up with multiple images, one per unique tag.

Tags are often used to refer to different versions of an app, but they can also refer to different operating system distributions, or even different configurations.

Starting with .NET 8, when a tag isn't provided the default is `latest`.

To override the default, specify either of the following:

```xml
<PropertyGroup>
    <ContainerImageTag>1.2.3-alpha2</ContainerImageTag>
</PropertyGroup>
```

To specify multiple tags, use a semicolon-delimited set of tags in the `ContainerImageTags` property, similar to setting multiple `TargetFrameworks`:

```xml
<PropertyGroup>
    <ContainerImageTags>1.2.3-alpha2;latest</ContainerImageTags>
</PropertyGroup>
```

Tags can only contain up to 127 alphanumeric characters, periods, underscores, and dashes. They must start with an alphanumeric character or an underscore. Any other form results in an error being thrown.

> [!NOTE]
> When using `ContainerImageTags`, the tags are delimited by a `;` character. If you're calling `dotnet publish` from the command line (as is the case with most CI/CD environments), you need to outer wrap the values in a single `'` and inner wrap with double quotes `"`, for example (`='"tag-1;tag-2"'`). Consider the following `dotnet publish` command:
>
> ```dotnetcli
> dotnet publish -p ContainerImageTags='"1.2.3-alpha2;latest"'
> ```
>
> This results in two images being generated: `my-app:1.2.3-alpha2` and `my-app:latest`.

> [!TIP]
> If you experience issues with the `ContainerImageTags` property, consider scoping an environment variable `ContainerImageTags` instead:
>
> ```powershell
> $Env:ContainerImageTags='1.2.3;latest'; dotnet publish --os linux --arch x64 /t:PublishContainer
> ```

### `ContainerLabel`

The container label adds a metadata label to the container. Labels are often used to store version and authoring metadata for use by security scanners and other infrastructure tools. You can specify any number of container labels.

The `ContainerLabel` node has two attributes:

- `Include`: The key of the label.
- `Value`: The value of the label (this might be empty).

```xml
<ItemGroup>
    <ContainerLabel Include="org.contoso.businessunit" Value="contoso-university" />
</ItemGroup>
```

For a list of labels that are created by default, see [default container labels](#default-container-labels).

## Configure container execution

To control the execution of the container, you can use the following MSBuild properties.

### `ContainerWorkingDirectory`

The container working directory node controls the working directory of the container, the directory that commands are executed within if not other command is run.

By default, the `/app` directory value is used as the working directory.

```xml
<PropertyGroup>
    <ContainerWorkingDirectory>/bin</ContainerWorkingDirectory>
</PropertyGroup>
```

### `ContainerPort`

The container port adds Transmission Control Protocol (TCP) or User Datagram Protocol (UDP) ports to the list of known ports for the container. This enables container runtimes like Docker to map these ports to the host machine automatically. This is often used as documentation for the container, but can also be used to enable automatic port mapping.

The `ContainerPort` node has two attributes:

- `Include`: The port number to expose.
- `Type`: Defaults to `tcp`, valid values are either `tcp` or `udp`.

```xml
<ItemGroup>
    <ContainerPort Include="80" Type="tcp" />
</ItemGroup>
```

Starting with .NET 8, the `ContainerPort` is inferred when not explicitly provided based on several well-known ASP.NET environment variables:

- `ASPNETCORE_URLS`
- `ASPNETCORE_HTTP_PORTS`
- `ASPNETCORE_HTTPS_PORTS`

If these environment variables are present, their values are parsed and converted to TCP port mappings. These environment variables are read from your base image, if present, or from the environment variables defined in your project through `ContainerEnvironmentVariable` items. For more information, see [ContainerEnvironmentVariable](#containerenvironmentvariable).

### `ContainerEnvironmentVariable`

The container environment variable node allows you to add environment variables to the container. Environment variables are accessible to the app running in the container immediately, and are often used to change the run-time behavior of the running app.

The `ContainerEnvironmentVariable` node has two attributes:

- `Include`: The name of the environment variable.
- `Value`: The value of the environment variable.

```xml
<ItemGroup>
  <ContainerEnvironmentVariable Include="LOGGER_VERBOSITY" Value="Trace" />
</ItemGroup>
```

For more information, see [.NET environment variables](../tools/dotnet-environment-variables.md).

> [!NOTE]
> It's currently not possible to set environment variables from the .NET CLI when publishing a container image. For more information, see [GitHub: .NET SDK container builds](https://github.com/dotnet/sdk-container-builds/issues/451).

## Configure container commands

By default, the container tools launch your app using either the generated AppHost binary for your app (if your app uses an AppHost), or the `dotnet` command plus your app's DLL.

However, you can control how your app is executed by using some combination of `ContainerAppCommand`, `ContainerAppCommandArgs`, `ContainerDefaultArgs`, and `ContainerAppCommandInstruction`.

These different configuration points exist because different base images use different combinations of the container `ENTRYPOINT` and `COMMAND` properties, and you want to be able to support all of them. The defaults should be useable for most apps, but if you want to customize your app launch behavior you should:

- Identify the binary to run and set it as `ContainerAppCommand`
- Identify which arguments are _required_ for your application to run and set them as `ContainerAppCommandArgs`
- Identify which arguments (if any) are _optional_ and could be overridden by a user and set them as `ContainerDefaultArgs`
- Set `ContainerAppCommandInstruction` to `DefaultArgs`

For more information, see the following configuration items.

### `ContainerAppCommand`

The app command configuration item is the logical entry point of your app. For most apps, this is the AppHost, the generated executable binary for your app. If your app doesn't generate an AppHost, then this command is typically `dotnet <your project dll>`. These values are applied after any `ENTRYPOINT` in your base container, or directly if no `ENTRYPOINT` is defined.

The `ContainerAppCommand` configuration has a single `Include` property, which represents the command, option, or argument to use in the entrypoint command:

```xml
<ItemGroup Label="ContainerAppCommand Assignment">
  <!-- This is how you would start the dotnet ef tool in your container -->
  <ContainerAppCommand Include="dotnet" />
  <ContainerAppCommand Include="ef" />

  <!-- This shorthand syntax means the same thing, note the semicolon separating the tokens. -->
  <ContainerAppCommand Include="dotnet;ef" />
</ItemGroup>
```

### `ContainerAppCommandArgs`

This app command args configuration item represents any logically required arguments for your app that should be applied to the `ContainerAppCommand`. By default, none are generated for an app. When present, the args are applied to your container when it's run.

The `ContainerAppCommandArgs` configuration has a single `Include` property, which represents the option or argument to apply to the `ContainerAppCommand` command.

```xml
<ItemGroup>
  <!-- Assuming the ContainerAppCommand defined above,
       this would be the way to force the database to update.
  -->
  <ContainerAppCommandArgs Include="database" />
  <ContainerAppCommandArgs Include="update" />

  <!-- This is the shorthand syntax for the same idea -->
  <ContainerAppCommandArgs Include="database;update" />
</ItemGroup>
```

### `ContainerDefaultArgs`

This default args configuration item represents any user-overridable arguments for your app. This is a good way to provide defaults that your app might need to run in a way that makes it easy to start, yet still easy to customize.

The `ContainerDefaultArgs` configuration has a single `Include` property, which represents the option or argument to apply to the `ContainerAppCommand` command.

```xml
<ItemGroup>
  <!-- Assuming the ContainerAppCommand defined above,
       this would be the way to force the database to update.
  -->
  <ContainerDefaultArgs Include="database" />
  <ContainerDefaultArgs Include="update" />

  <!-- This is the shorthand syntax for the same idea -->
  <ContainerDefaultArgs Include="database;update" />
</ItemGroup>
```

### `ContainerAppCommandInstruction`

The app command instruction configuration helps control the way the `ContainerEntrypoint`, `ContainerEntrypointArgs`, `ContainerAppCommand`, `ContainerAppCommandArgs`, and `ContainerDefaultArgs` are combined to form the final command that is run in the container. This depends greatly on if an `ENTRYPOINT` is present in the base image. This property takes one of three values: `"DefaultArgs"`, `"Entrypoint"`, or `"None"`.

- `Entrypoint`:
  - In this mode, the entrypoint is defined by `ContainerAppCommand`, `ContainerAppCommandArgs`, and `ContainerDefaultArgs`.
- `None`:
  - In this mode, the entrypoint is defined by `ContainerEntrypoint`, `ContainerEntrypointArgs`, and `ContainerDefaultArgs`.
- `DefaultArgs`:
  - This is the most complex mode—if none of the `ContainerEntrypoint[Args]` items are present, the `ContainerAppCommand[Args]` and `ContainerDefaultArgs` are used to create the entrypoint and command. The base image entrypoint for base images that have it hard-coded to `dotnet` or `/usr/bin/dotnet` is skipped so that you have complete control.
  - If both `ContainerEntrypoint` and `ContainerAppCommand` are present, then `ContainerEntrypoint` becomes the entrypoint, and `ContainerAppCommand` becomes the command.

> [!NOTE]
> The `ContainerEntrypoint` and `ContainerEntrypointArgs` configuration items are deprecated as of .NET 8.

> [!IMPORTANT]
> This is for advanced users-most apps shouldn't need to customize their entrypoint to this degree. For more information and if you'd like to provide use cases for your scenarios, see [GitHub: .NET SDK container builds discussions](https://github.com/dotnet/sdk-container-builds/discussions).

### `ContainerUser`

The user configuration property controls the default user that the container runs as. This is often used to run the container as a non-root user, which is a best practice for security. There are a few constraints for this configuration to be aware of:

- It can take various forms—username, linux user IDs, group name, linux group ID, `username:groupname`, and other ID variants.
- There's no verification that the user or group specified exists on the image.
- Changing the user can alter the behavior of the app, especially in regards to things like _File System_ permissions.

The default value of this field varies by project TFM and target operating system:

- If you're targeting .NET 8 or higher and using the Microsoft runtime images, then:
  - on Linux, the rootless user `app` is used (though it's referenced by its user ID)
  - on Windows the rootless user `ContainerUser` is used
- Otherwise, no default `ContainerUser` is used

```xml
<PropertyGroup>
  <ContainerUser>my-existing-app-user</ContainerUser>
</PropertyGroup>
```

> [!TIP]
> The `APP_UID` environment variable is used to set user information in your container. This value can come from environment variables defined in your base image (like that Microsoft .NET images do), or you can set it yourself via the `ContainerEnvironmentVariable` syntax.

To configure your app to run as a root user, set the `ContainerUser` property to `root`. In your project file, add the following:

```xml
<PropertyGroup>
  <ContainerUser>root</ContainerUser>
</PropertyGroup>
```

Alternatively, you can set this value when calling `dotnet publish` from the command line:

```dotnetcli
dotnet publish -p ContainerUser=root
```

### Default container labels

Labels are often used to provide consistent metadata on container images. This package provides some default labels to encourage better maintainability of the generated images.

- `org.opencontainers.image.created` is set to the ISO 8601 format of the current UTC `DateTime`.

For more information, see [Implement conventional labels on top of existing label infrastructure](https://github.com/dotnet/sdk-container-builds/issues/96).

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
- [Tutorial: Containerize a .NET app](build-container.md)
- [.NET container images](container-images.md)
- [Review the Azure services that support containers](https://azure.microsoft.com/overview/containers/)
- [Read about Dockerfile commands](https://docs.docker.com/engine/reference/builder/)
- [Explore the container tools in Visual Studio](/visualstudio/containers/overview)

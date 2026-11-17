---
title: Containerize a .NET app reference
description: Reference material for containerizing a .NET app and configuring the container image.
ms.topic: reference
ms.date: 11/17/2026
ai-usage: ai-assisted
---

# Containerize a .NET app reference

In this reference article, you learn how to configure the container image generated when you publish a .NET app as a container. This article covers the various properties that you can set to control the image, the execution environment, and the commands that are run when the container starts.

The following MSBuild properties and items are available for container configuration:

| Property or item | Description |
|---|---|
| [`ContainerAppCommand`](#containerappcommand) | The logical entry point of the app. |
| [`ContainerAppCommandArgs`](#containerappcommandargs) | Logically required arguments for the app. |
| [`ContainerAppCommandInstruction`](#containerappcommandinstruction) | Controls how the entrypoint and command are combined. |
| [`ContainerArchiveOutputPath`](#containerarchiveoutputpath) | Path to write the container image as a tar archive. |
| [`ContainerBaseImage`](#containerbaseimage) | The base image to use for the container. |
| [`ContainerDefaultArgs`](#containerdefaultargs) | User-overridable default arguments for the app. |
| [`ContainerEntrypoint`](#containerentrypoint) | (**Deprecated**) The binary run when the container starts. |
| [`ContainerEntrypointArgs`](#containerentrypointargs) | (**Deprecated**) Default arguments for `ContainerEntrypoint`. |
| [`ContainerEnvironmentVariable`](#containerenvironmentvariable) | Environment variables added to the container. |
| [`ContainerFamily`](#containerfamily) | The family variant of the base image, for example `alpine`. |
| [`ContainerImageFormat`](#containerimageformat) | The image format: `Docker` or `OCI`. |
| [`ContainerImageTag`](#containerimagetag) | The tag or tags generated for the image. |
| [`ContainerLabel`](#containerlabel) | Metadata labels added to the container image. |
| [`ContainerPort`](#containerport) | TCP or UDP ports exposed by the container. |
| [`ContainerPublishInParallel`](#containerpublishinparallel) | Controls whether multi-RID publishing runs in parallel. |
| [`ContainerPushNoCache`](#containerpushnocache) | Disables reuse of an image that already exists in the destination registry (.NET 11 and later). |
| [`ContainerRegistry`](#containerregistry) | The destination registry for the published image. |
| [`ContainerRepository`](#containerrepository) | The name of the container image. |
| [`ContainerRuntimeIdentifier(s)`](#containerruntimeidentifiers) | The OS and architecture for the container. |
| [`ContainerUser`](#containeruser) | The default user the container runs as. |
| [`ContainerWorkingDirectory`](#containerworkingdirectory) | The working directory inside the container. |
| [`LocalRegistry`](#localregistry) | The local container tool to use, such as Docker, Podman, `wslc`, or Apple's `container` CLI. |

## Configure container properties

You can control many aspects of the generated container through MSBuild properties. In general, if you can use a command in a _Dockerfile_ to set some configuration, you can do the same via MSBuild.

> [!NOTE]
> The only exceptions to this are `RUN` commands. Due to the way containers are built, those commands can't be emulated. If you need this functionality, consider using a _Dockerfile_ to build your container images.

There's no way of performing `RUN` commands with the .NET SDK. These commands are often used to install some OS packages or create a new OS user, or any number of arbitrary things. If you would like to keep using the .NET SDK container building feature, you can instead create a custom base image with these changes and then using this base image. For more information, see [`ContainerBaseImage`](#containerbaseimage).

## Flags that control the base image

The following properties control which base image is used for your container and how it's selected:

- [`ContainerBaseImage`](#containerbaseimage)
- [`ContainerFamily`](#containerfamily)
- [`ContainerRuntimeIdentifier(s)`](#containerruntimeidentifiers)

### `ContainerBaseImage`

The container base image property controls the image used as the basis for your image. By default, the following values are inferred based on the properties of your project:

- If your project is self-contained, the `mcr.microsoft.com/dotnet/runtime-deps` image is used as the base image.
- If your project is an ASP.NET Core project, the `mcr.microsoft.com/dotnet/aspnet` image is used as the base image.
- Otherwise the `mcr.microsoft.com/dotnet/runtime` image is used as the base image.

The SDK infers the base image tag from the numeric version of your `TargetFramework`. For example, a project that targets `net10.0` uses the `10.0` tag of the inferred base image, and a project that targets `net11.0-linux` uses the `11.0` tag.

If you set a value here, you should set the fully qualified name of the image to use as the base, including any tag you prefer:

```xml
<PropertyGroup>
    <ContainerBaseImage>mcr.microsoft.com/dotnet/runtime:10.0</ContainerBaseImage>
</PropertyGroup>
```

When you set `ContainerBaseImage` for a framework-dependent app, choose an image that contains a .NET runtime compatible with your app's target framework. For example, an app that targets `net10.0` fails to start on `mcr.microsoft.com/dotnet/runtime:8.0` because that image contains only the .NET 8 runtime. Publishing succeeds, and the error occurs when the container starts.

Starting with .NET SDK version 8.0.200, the `ContainerBaseImage` inference is improved to optimize the size and security:

- If the project targets the `linux-musl-x64` or `linux-musl-arm64` runtime identifier, the SDK selects the `alpine` image variant (for example, `10.0-alpine`) so that your project can run.
- If the project sets `PublishAot=true` or `PublishTrimmed=true` and targets a non-musl Linux runtime identifier, the SDK selects the `noble-chiseled` variant of the `runtime-deps` image (for example, `mcr.microsoft.com/dotnet/runtime-deps:10.0-noble-chiseled`) to minimize image size and improve security.
- If the project sets `PublishAot=true` or `PublishTrimmed=true` and doesn't set `InvariantGlobalization` to `true`, the SDK selects the `-extra` variant (for example, `10.0-noble-chiseled-extra` or `10.0-alpine-extra`) to preserve globalization support.

For more information about image variant sizes and characteristics, see [.NET container image size report](https://github.com/dotnet/dotnet-docker/blob/main/documentation/sample-image-size-report.md).

### `ContainerFamily`

Starting with .NET 8, you can use the `ContainerFamily` MSBuild property to choose a different family of Microsoft-provided container images as the base image for your app. When set, this value is appended to the end of the selected TFM-specific tag, changing the tag provided. For example, to use the Alpine Linux variants of the .NET base images, you can set `ContainerFamily` to `alpine`:

```xml
<PropertyGroup>
    <ContainerFamily>alpine</ContainerFamily>
</PropertyGroup>
```

For an app that targets .NET 10, the preceding configuration produces a base image tag of `10.0-alpine`.

This field is free-form, and often can be used to select different operating system distributions, default package configurations, or any other _flavor_ of changes to a base image. This field is ignored when `ContainerBaseImage` is set. For more information, see [.NET container images](../docker/container-images.md).

### `ContainerRuntimeIdentifier(s)`

The `ContainerRuntimeIdentifier` property specifies the OS and architecture for your container if the `ContainerBaseImage` supports multiple platforms. For example, the default `mcr.microsoft.com/dotnet/runtime:10.0` image supports `linux-x64`, `linux-arm`, and `linux-arm64`. By default, this is set to the `RuntimeIdentifier` used when publishing the container. Typically, you don't need to set this property explicitly; instead, use the `-r` option with the `dotnet publish` command. If the chosen image doesn't support the specified `RuntimeIdentifier`, an error indicates the supported identifiers.

You can always set the `ContainerBaseImage` property to a fully qualified image name, including the tag, to avoid needing to use this property at all.

```xml
<PropertyGroup>
    <ContainerRuntimeIdentifier>linux-arm64</ContainerRuntimeIdentifier>
</PropertyGroup>
```

To specify multiple container runtime identifiers for multi-architecture images, use a semicolon-delimited set of runtime identifiers in the `ContainerRuntimeIdentifiers` property, similar to setting multiple `TargetFrameworks`:

```xml
<PropertyGroup>
    <ContainerRuntimeIdentifiers>linux-x64;linux-arm64</ContainerRuntimeIdentifiers>
</PropertyGroup>
```

> [!IMPORTANT]
> The `ContainerRuntimeIdentifiers` property must be a subset of the `RuntimeIdentifiers` property. If this condition isn't met, critical parts of the build pipeline might fail.
>
> Setting multiple `ContainerRuntimeIdentifiers` results in a multi-architecture image being created. For more information, see [Multi-architecture images](#multi-architecture-images).

> [!NOTE]
> Starting with .NET 8, Microsoft container images no longer include Windows variants in the manifest list. To target Windows, set `ContainerBaseImage` to a Windows-specific image tag, such as `mcr.microsoft.com/dotnet/aspnet:10.0-nanoserver-ltsc2025`.

For more information regarding the runtime identifiers supported by .NET, see [RID catalog](../rid-catalog.md).

#### Multi-architecture images

Multi-architecture images enable a single container image to support multiple architectures, simplifying cross-platform development and deployment. The .NET SDK supports this through the `ContainerRuntimeIdentifiers` property.

Beginning with SDK versions 8.0.405, 9.0.102, and 9.0.2xx, multi-RID container publishing is supported. When publishing with `/t:PublishContainer`:

- If a single `RuntimeIdentifier` or `ContainerRuntimeIdentifier` is specified, a single-architecture container is generated as before.
- If no single `RuntimeIdentifier` is specified but multiple `RuntimeIdentifiers` or `ContainerRuntimeIdentifiers` are set, the SDK publishes the app for each specified RID and combines the resulting images into an [OCI Image Index](https://specs.opencontainers.org/image-spec/image-index/). This index allows multiple architecture-specific images to share a single name.

> [!NOTE]
> The `ContainerRuntimeIdentifiers` property must be a subset of the `RuntimeIdentifiers` property. For more information, see [ContainerRuntimeIdentifiers](#containerruntimeidentifiers).

This feature streamlines container workflows in mixed-architecture environments. For example, a developer on a `linux-x64` host can publish a container supporting both `linux-x64` and `linux-arm64`, enabling deployment to either architecture without changing image names or labels.

The generated OCI Image Index is widely supported with modern container tooling, enhancing compatibility and ease of use.

> [!WARNING]
> When you publish a multi-architecture image, the SDK truncates [`ContainerEnvironmentVariable`](#containerenvironmentvariable) values that contain a colon (`:`) at the first colon in each architecture-specific image. For example, `https://contoso.com` becomes `https`. The .NET 10 SDK also truncates [`ContainerLabel`](#containerlabel) values at the first colon, whereas the .NET 11 SDK preserves full label values. Single-architecture images aren't affected. If your values contain colons, inspect the generated image configuration.

## Flags that control generated-image-independent metadata

The following properties control metadata and configuration that applies to the generated container image regardless of the target runtime identifier:

- [`ContainerImageFormat`](#containerimageformat)
- [`ContainerImageTag`](#containerimagetag)
- [`ContainerLabel`](#containerlabel)
- [`ContainerRepository`](#containerrepository)

### `ContainerImageFormat`

You can use the `ContainerImageFormat` MSBuild property to specify the image format as either `Docker` or `OCI`. By default, the .NET tooling infers the format from the base image. For example, .NET base images use the Docker-specific format `application/vnd.docker.distribution.manifest.v2+json`. However, many modern tools prefer the OCI format `application/vnd.oci.image.manifest.v1+json`. To force a specific format, set the property as shown:

```xml
<PropertyGroup>
  <ContainerImageFormat>OCI</ContainerImageFormat>
</PropertyGroup>
```

Both formats are largely interchangeable without loss of information.

> [!NOTE]
> When building a multi-architecture image, the resulting image format is always OCI.

### `ContainerImageTag`

The container image tag property controls the tags that are generated for the image. To specify a single tag use `ContainerImageTag` and for multiple tags use `ContainerImageTags`.

> [!IMPORTANT]
> When you use `ContainerImageTags`, the SDK publishes a single image and applies each unique tag to it. All tags refer to the same image.

Tags are often used to refer to different versions of an app, but they can also refer to different operating system distributions, or even different configurations.

Starting with .NET 8, when a tag isn't provided the default is `latest`. In prior versions, the default tag was the `Version` of the project.

To override the default, specify either of the following properties:

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

Tags can be up to 128 characters long and can contain only alphanumeric characters, periods, underscores, and hyphens. They must start with an alphanumeric character or an underscore. Any other format causes an error.

> [!NOTE]
> When using `ContainerImageTags` or any MSBuild property requiring `;`-delimited values, ensure proper escaping when calling `dotnet publish` from the command line, especially in CI/CD environments. Escaping rules differ between PowerShell and Bash. For example:
>
> ```powershell
> dotnet publish --os linux --arch x64 -t:PublishContainer -p:ContainerImageTags=`"1.2.3-alpha2`;latest`"
> ```
>
> In PowerShell, both the `;` and `"` characters need to be escaped.
>
> ```bash
> dotnet publish --os linux --arch x64 -t:PublishContainer -p:ContainerImageTags='"1.2.3-alpha2;latest"'
> ```
>
> In Bash, escape only the `"` character. To prevent shells such as Git Bash on Windows from converting `/` arguments into file paths and causing MSBuild to fail, prefix MSBuild switches with `-` instead of `/` (for example, `-t` and `-p`).
>
> Both commands publish one image with two tags: `my-app:1.2.3-alpha2` and `my-app:latest`.

> [!TIP]
> If you experience issues with the `ContainerImageTags` property, consider scoping an environment variable `ContainerImageTags` instead:
>
> ```powershell
> $Env:ContainerImageTags='1.2.3;latest'; dotnet publish --os linux --arch x64 -t:PublishContainer
> ```

### `ContainerLabel`

The container label adds a metadata label to the container. Labels have no impact on the container at runtime, but are often used to store version and authoring metadata for use by security scanners and other infrastructure tools. You can specify any number of container labels.

The `ContainerLabel` node has two attributes:

- `Include`: The key of the label.
- `Value`: The value of the label (this might be empty).

```xml
<ItemGroup>
    <ContainerLabel Include="org.contoso.businessunit" Value="contoso-university" />
</ItemGroup>
```

For a list of labels that are created by default, see [default container labels](#default-container-labels).

> [!NOTE]
> When you publish a multi-architecture image with the .NET 10 SDK, the SDK truncates label values that contain a colon (`:`). For more information, see [Multi-architecture images](#multi-architecture-images).

### `ContainerRepository`

The container repository is the name of the image itself, for example, `dotnet/runtime` or `my-app`. By default, the `AssemblyName` of the project is used.

```xml
<PropertyGroup>
    <ContainerRepository>my-app</ContainerRepository>
</PropertyGroup>
```

Image names consist of one or more slash-delimited segments, each of which can only contain lowercase alphanumeric characters, periods, underscores, and dashes, and must start with a letter or number. Any other characters result in an error being thrown.

## Flags that control execution metadata

The following properties control runtime-specific execution behavior and multi-architecture image generation:

- [`ContainerAppCommand`](#containerappcommand)
- [`ContainerAppCommandArgs`](#containerappcommandargs)
- [`ContainerAppCommandInstruction`](#containerappcommandinstruction)
- [`ContainerDefaultArgs`](#containerdefaultargs)
- [`ContainerEntrypoint`](#containerentrypoint) (deprecated)
- [`ContainerEntrypointArgs`](#containerentrypointargs) (deprecated)
- [`ContainerEnvironmentVariable`](#containerenvironmentvariable)
- [`ContainerPort`](#containerport)
- [`ContainerPublishInParallel`](#containerpublishinparallel)
- [`ContainerUser`](#containeruser)
- [`ContainerWorkingDirectory`](#containerworkingdirectory)

### `ContainerAppCommand`

The `ContainerAppCommand` item specifies the logical entry point of your app. By default, the container starts a framework-dependent app with `dotnet` followed by the path to the app's DLL (for example, `dotnet /app/MyApp.dll`), even when the publish output includes an apphost executable. The container starts a self-contained app with its native executable (for example, `/app/MyApp`). The [`ContainerAppCommandInstruction`](#containerappcommandinstruction) property controls whether these values become the image's `ENTRYPOINT` or `CMD`.

The `ContainerAppCommand` configuration has a single `Include` property, which represents the command, option, or argument to use in the entrypoint command. You can add one item per token:

```xml
<ItemGroup Label="ContainerAppCommand Assignment">
  <!-- This is how you would start the dotnet ef tool in your container -->
  <ContainerAppCommand Include="dotnet" />
  <ContainerAppCommand Include="ef" />
</ItemGroup>
```

Alternatively, use a single item with semicolon-separated tokens. This shorthand produces the same result as the preceding example:

```xml
<ItemGroup Label="ContainerAppCommand Assignment">
  <ContainerAppCommand Include="dotnet;ef" />
</ItemGroup>
```

Use only one of these forms. MSBuild adds every item that you declare, so combining both forms duplicates the tokens in the command.

### `ContainerAppCommandArgs`

This app command args configuration item represents any logically required arguments for your app that should be applied to the `ContainerAppCommand`. By default, none are generated for an app. When present, the args are applied to your container when it runs.

The `ContainerAppCommandArgs` configuration has a single `Include` property, which represents the option or argument to apply to the `ContainerAppCommand` command.

```xml
<ItemGroup>
  <!-- Assuming the ContainerAppCommand defined above,
       this would be the way to force the database to update.
  -->
  <ContainerAppCommandArgs Include="database" />
  <ContainerAppCommandArgs Include="update" />
</ItemGroup>
```

As with `ContainerAppCommand`, you can instead use a single item with semicolon-separated tokens, such as `<ContainerAppCommandArgs Include="database;update" />`. Don't combine both forms.

### `ContainerAppCommandInstruction`

The `ContainerAppCommandInstruction` property controls how the SDK combines `ContainerEntrypoint`, `ContainerEntrypointArgs`, `ContainerAppCommand`, `ContainerAppCommandArgs`, and `ContainerDefaultArgs` to form the `ENTRYPOINT` and `CMD` of the generated image. This property accepts `Entrypoint`, `DefaultArgs`, or `None`. It defaults to `Entrypoint`, unless you set the deprecated `ContainerEntrypoint` item, in which case it defaults to `DefaultArgs`.

| Value | `ENTRYPOINT` | `CMD` |
|-------|--------------|-------|
| `Entrypoint` | `ContainerAppCommand` followed by `ContainerAppCommandArgs`. Replaces any `ENTRYPOINT` in the base image. | `ContainerDefaultArgs` |
| `DefaultArgs` | `ContainerEntrypoint` followed by `ContainerEntrypointArgs`, if set. Otherwise, the base image's `ENTRYPOINT`. | `ContainerAppCommand`, followed by `ContainerAppCommandArgs`, followed by `ContainerDefaultArgs`. |
| `None` | `ContainerEntrypoint` followed by `ContainerEntrypointArgs`, if set. Otherwise, the base image's `ENTRYPOINT`. | `ContainerDefaultArgs` |

The following rules also apply:

- In `Entrypoint` mode, if you set `ContainerEntrypoint` or `ContainerEntrypointArgs`, the build fails with an error.
- In `None` mode, the SDK doesn't generate a default `ContainerAppCommand`. If you set `ContainerAppCommand` or `ContainerAppCommandArgs`, the build fails with an error.
- To give you full control over the command, the SDK ignores a base image `ENTRYPOINT` that is set only to `dotnet` or `/usr/bin/dotnet`.

Arguments that you pass to `docker run` after the image name replace the image's `CMD`. In `Entrypoint` mode, runtime arguments replace only `ContainerDefaultArgs`, so the app command and its required arguments still run. In `DefaultArgs` mode, the app command and its arguments are part of `CMD`, so arguments passed to `docker run` replace them as well. To allow users to override only the default arguments, use `Entrypoint` mode.

> [!NOTE]
> The `ContainerEntrypoint` and `ContainerEntrypointArgs` configuration items are deprecated as of .NET 8.

> [!IMPORTANT]
> This is for advanced users-most apps shouldn't need to customize their entrypoint to this degree. For more information and if you'd like to provide use cases for your scenarios, see [GitHub: .NET SDK container builds discussions](https://github.com/dotnet/sdk-container-builds/discussions).

### `ContainerDefaultArgs`

The `ContainerDefaultArgs` item specifies overridable default arguments for your app. In the default `Entrypoint` mode, these arguments become the image's `CMD`, so users can replace them by passing arguments when they start the container. Use `ContainerDefaultArgs` to provide sensible defaults that users can still customize at runtime. For information about how other modes combine these arguments, see [`ContainerAppCommandInstruction`](#containerappcommandinstruction).

The `ContainerDefaultArgs` configuration has a single `Include` property, which represents the option or argument to apply to the `ContainerAppCommand` command.

```xml
<ItemGroup>
  <!-- Assuming the ContainerAppCommand defined above,
       this would be the way to update the database by default.
  -->
  <ContainerDefaultArgs Include="database" />
  <ContainerDefaultArgs Include="update" />
</ItemGroup>
```

You can instead use a single item with semicolon-separated tokens, such as `<ContainerDefaultArgs Include="database;update" />`. Don't combine both forms.

### `ContainerEntrypoint`

> [!NOTE]
> This item is deprecated as of .NET 8. Use [`ContainerAppCommand`](#containerappcommand) instead, with [`ContainerAppCommandInstruction`](#containerappcommandinstruction) set to `Entrypoint` or `DefaultArgs`.

The `ContainerEntrypoint` item specifies the binary that runs by default when the container starts. If you don't set this item, the default [`ContainerAppCommand`](#containerappcommand) starts the app: `dotnet` followed by the app's DLL for framework-dependent apps, or the app's native executable for self-contained apps.

The `ContainerEntrypoint` configuration has a single `Include` property, which represents the command, option, or argument to use in the entrypoint command:

```xml
<ItemGroup>
  <ContainerEntrypoint Include="dotnet" />
  <ContainerEntrypoint Include="ef" />
</ItemGroup>
```

You can instead use a single item with semicolon-separated tokens, such as `<ContainerEntrypoint Include="dotnet;ef" />`. Don't combine both forms.

If you set `ContainerEntrypoint` without setting `ContainerAppCommandInstruction`, the SDK uses `DefaultArgs` mode. In `DefaultArgs` mode, the app command (including the default app command if you didn't set one) becomes the image's `CMD` and is passed as arguments to your entrypoint. For example, for a framework-dependent app named _MyApp_, the preceding configuration produces an `ENTRYPOINT` of `dotnet ef` and a `CMD` of `dotnet /app/MyApp.dll`.

### `ContainerEntrypointArgs`

> [!NOTE]
> This item is deprecated as of .NET 8. Use [`ContainerAppCommandArgs`](#containerappcommandargs) instead, with [`ContainerAppCommandInstruction`](#containerappcommandinstruction) set to `Entrypoint` or `DefaultArgs`.

The container entrypoint args item controls the default arguments provided to the `ContainerEntrypoint`. Use this when the `ContainerEntrypoint` is a program the user might want to use on its own.

The `ContainerEntrypointArgs` configuration has a single `Include` property, which represents the option or argument to apply to the `ContainerEntrypoint` command:

```xml
<ItemGroup>
  <ContainerEntrypointArgs Include="database" />
  <ContainerEntrypointArgs Include="update" />
</ItemGroup>
```

You can instead use a single item with semicolon-separated tokens, such as `<ContainerEntrypointArgs Include="database;update" />`. Don't combine both forms.

### `ContainerEnvironmentVariable`

The container environment variable node allows you to add environment variables to the container. Environment variables are accessible to the app running in the container immediately, and are often used to change the runtime behavior of the running app.

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
> When you publish a multi-architecture image, the SDK truncates environment variable values that contain a colon (`:`). For more information, see [Multi-architecture images](#multi-architecture-images).

> [!NOTE]
> It's currently not possible to set environment variables from the .NET CLI when publishing a container image. For more information, see [GitHub: .NET SDK container builds](https://github.com/dotnet/sdk-container-builds/issues/451).

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

Starting with .NET 8, the SDK also infers TCP ports from several well-known ASP.NET Core environment variables:

- `ASPNETCORE_URLS`
- `ASPNETCORE_HTTP_PORTS`
- `ASPNETCORE_HTTPS_PORTS`

If these environment variables are present, the SDK parses their values and converts them to TCP port mappings. If `ASPNETCORE_URLS` is set, it takes precedence and the SDK ignores the other two variables. The SDK reads these environment variables from your base image, if present, or from `ContainerEnvironmentVariable` items in your project. For more information, see [ContainerEnvironmentVariable](#containerenvironmentvariable).

The SDK adds inferred ports to any ports that you declare with `ContainerPort` items; adding `ContainerPort` items doesn't disable port inference. For example, the Microsoft `aspnet` images set `ASPNETCORE_HTTP_PORTS=8080`, so an image based on them exposes `8080/tcp` in addition to any ports that you add. To change an inferred port, override its environment variable:

```xml
<ItemGroup>
    <ContainerEnvironmentVariable Include="ASPNETCORE_HTTP_PORTS" Value="5000" />
</ItemGroup>
```

### `ContainerPublishInParallel`

For multi-RID containers, certain project types (like Blazor WebAssembly) might encounter build race conditions. To address this, starting with .NET SDK versions 8.0.408, 9.0.300, and 10.0, you can control the parallelism of the publish process using the `ContainerPublishInParallel` property. By default, publishing occurs in parallel for each Runtime Identifier (RID). Setting this property to `false` ensures sequential publishing, which increases stability but might take longer.

```xml
<PropertyGroup>
  <ContainerPublishInParallel>false</ContainerPublishInParallel>
</PropertyGroup>
```

For more information on multi-RID publishing, see [ContainerRuntimeIdentifier(s)](#containerruntimeidentifiers).

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

Alternatively, set this property on the command line when you publish the container:

```dotnetcli
dotnet publish -t:PublishContainer -p ContainerUser=root
```

### `ContainerWorkingDirectory`

The `ContainerWorkingDirectory` property sets the container's working directory, where commands run by default and where the SDK copies your app's published files.

The working directory defaults to `/app/` on Linux and `C:\app\` on Windows.

```xml
<PropertyGroup>
    <ContainerWorkingDirectory>/srv/app/</ContainerWorkingDirectory>
</PropertyGroup>
```

> [!IMPORTANT]
> End the value with a trailing directory separator, such as `/srv/app/`. When the SDK generates the default [`ContainerAppCommand`](#containerappcommand), it appends the app's file name directly to this value. For example, a value of `/srv/app` produces a command that runs `/srv/appMyApp.dll`, and the container fails to start.

## Flags that control the destination of the generated image

The following properties control where the generated container image is stored or published:

- [`ContainerArchiveOutputPath`](#containerarchiveoutputpath)
- [`ContainerPushNoCache`](#containerpushnocache)
- [`ContainerRegistry`](#containerregistry)
- [`LocalRegistry`](#localregistry)

### `ContainerArchiveOutputPath`

To write the container image to a tar archive instead of pushing it to a local container tool or remote registry, set the `ContainerArchiveOutputPath` property. Exporting an archive is useful when your workflow scans or transfers images before pushing them. After the SDK creates the archive, you can move it, scan it, or load it into a local container tool (for example, with `docker load`).

To publish to an archive, add the `ContainerArchiveOutputPath` property to your `dotnet publish` command, for example:

```dotnetcli
dotnet publish \
  -t:PublishContainer \
  -p ContainerArchiveOutputPath=./images/sdk-container-demo.tar
```

You can specify either a folder path or a file path. The SDK treats any path without a file extension as a folder and names the archive file `$(ContainerRepository).tar.gz`. The SDK writes a single archive file for all `ContainerImageTags`. When you publish a multi-architecture image, the archive contains an OCI Image Index for all target architectures.

> [!NOTE]
> The SDK writes an uncompressed tar archive even when the file name ends in _.tar.gz_, such as the default file name. If you need a gzip-compressed archive, compress the file after you publish it (for example, with `gzip ./images/sdk-container-demo.tar`).

### `ContainerPushNoCache`

Starting with .NET 11, when you push an image to a remote registry with [`ContainerRegistry`](#containerregistry), the SDK checks whether the destination repository already has an image manifest with the same digest. If a matching manifest exists, the SDK skips uploading the image layers and configuration and applies the requested tags to the existing manifest, which avoids redundant uploads when you republish an unchanged image.

The `ContainerPushNoCache` property defaults to `false`. To skip this manifest check and always run the full upload workflow, set `ContainerPushNoCache` to `true`:

```xml
<PropertyGroup>
  <ContainerPushNoCache>true</ContainerPushNoCache>
</PropertyGroup>
```

Even when `ContainerPushNoCache` is `true`, the SDK doesn't re-upload individual layers that already exist in the destination repository. This property has no effect when you publish to a local container tool or a tar archive.

### `ContainerRegistry`

The `ContainerRegistry` property specifies the destination registry where the SDK pushes the generated image. By default, the SDK loads the image into a local container tool, such as Docker (see [`LocalRegistry`](#localregistry)), or you can specify a remote registry. To push to a remote registry that requires authentication, sign in first with `docker login` or configure environment variables. For more information, see [Authenticate to container registries](overview.md#authenticate-to-container-registries). The following example sets a remote registry:

```xml
<PropertyGroup>
    <ContainerRegistry>registry.mycorp.com:1234</ContainerRegistry>
</PropertyGroup>
```

This tooling supports publishing to any registry that supports the [Docker Registry HTTP API V2](https://distribution.github.io/distribution/spec/api/). This includes the following registries explicitly (and likely many more implicitly):

- [Azure Container Registry](https://azure.microsoft.com/products/container-registry)
- [Amazon Elastic Container Registry](https://aws.amazon.com/ecr/)
- [Google Artifact Registry](https://cloud.google.com/artifact-registry)
- [Docker Hub](https://hub.docker.com/)
- [GitHub Packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry)
- [GitLab-hosted Container Registry](https://docs.gitlab.com/ee/user/packages/container_registry/)
- [Quay.io](https://quay.io/)

For notes on working with these registries, see the [registry-specific notes](https://aka.ms/dotnet/containers/auth#notes-for-specific-registries).

### `LocalRegistry`

The `LocalRegistry` MSBuild property specifies the local container tooling to use when pushing to local sources. Supported values are `Docker`, `Podman`, `Wslc`, and `MacOSContainer`.

If not set, the SDK determines the tool based on availability. Starting in .NET 11, the SDK prefers platform-native tools before Docker and Podman:

- On Windows, if `wslc` exists and its service runs, `wslc` is used.
- On macOS, if Apple's `container` CLI exists and its service runs, `container` is used.
- If both `docker` and `podman` exist, and `docker` is an alias for `podman`, then `podman` is used.
- If only `docker` exists, `docker` is used.
- If only `podman` exists, `podman` is used.
- If no supported local tool exists, an error is thrown.

To explicitly set the local registry tool, use the following configuration:

```xml
<PropertyGroup>
  <LocalRegistry>Podman</LocalRegistry>
</PropertyGroup>
```

## Container image naming configuration

Container images follow a specific naming convention. The name of the image is composed of several parts: the registry, an optional port, the repository, and an optional tag.

```dockerfile
REGISTRY[:PORT]/REPOSITORY[:TAG]
```

For example, consider the fully qualified `mcr.microsoft.com/dotnet/runtime:10.0-alpine` image name:

- `mcr.microsoft.com` is the registry (and in this case represents the Microsoft container registry).
- `dotnet/runtime` is the repository (but some consider this the `user/repository`).
- `10.0-alpine` is the tag. Microsoft .NET image tags often end with a family suffix, such as `-alpine`, that identifies the OS variant.

The following table maps each part of the generated image name to its MSBuild property:

| Image name part   | MSBuild property                                                         | Example values             |
|-------------------|--------------------------------------------------------------------------|----------------------------|
| `REGISTRY[:PORT]` | [`ContainerRegistry`](#containerregistry)                                | `registry.mycorp.com:1234` |
| `REPOSITORY`      | [`ContainerRepository`](#containerrepository)                            | `my-app`                   |
| `TAG`             | [`ContainerImageTag` or `ContainerImageTags`](#containerimagetag)        | `1.2.3-alpha2`             |

The port of a registry is part of the `ContainerRegistry` value. The [`ContainerPort`](#containerport) property is unrelated to the image name; it controls the ports that the container exposes. Similarly, [`ContainerFamily`](#containerfamily) doesn't change the tag of the generated image. It selects the family suffix of the inferred _base_ image tag, such as `10.0-alpine`.

## Default container labels

Labels are often used to provide consistent metadata on container images. The built-in container tools provide some default labels to increase the quality of the generated images. All default label generation can be disabled by setting `ContainerGenerateLabels` to `false`. In addition, each default label has an individual enablement flag that can be set to `false` to disable that specific label.

Where possible, existing MSBuild properties provide the values for these labels. Other properties allow for explicit control of their values.

| Annotation | Default value | Dedicated property name | Fallback property name | Enabled property name | Notes |
|------------|---------------|-------------------------|------------------------|-----------------------|-------|
| `org.opencontainers.image.created` and `org.opencontainers.artifact.created` | The [RFC 3339](https://tools.ietf.org/html/rfc3339#section-5.6) format of the current UTC DateTime | | | `ContainerGenerateLabelsImageCreated` | |
| `org.opencontainers.artifact.description` and `org.opencontainers.image.description` | | `ContainerDescription` | `Description` | `ContainerGenerateLabelsImageDescription` | |
| `org.opencontainers.image.authors` | | `ContainerAuthors` | `Authors` | `ContainerGenerateLabelsImageAuthors` | |
| `org.opencontainers.image.url` | | `ContainerInformationUrl` | `PackageProjectUrl` | `ContainerGenerateLabelsImageUrl` | |
| `org.opencontainers.image.documentation` |                                                                                                    | `ContainerDocumentationUrl`  | `PackageProjectUrl` | `ContainerGenerateLabelsImageDocumentation` | |
| `org.opencontainers.image.version` | | `ContainerVersion` | `PackageVersion` | `ContainerGenerateLabelsImageVersion` | |
| `org.opencontainers.image.vendor` | | `ContainerVendor` | | `ContainerGenerateLabelsImageVendor` | |
| `org.opencontainers.image.licenses` |                                                                                                    | `ContainerLicenseExpression` | `PackageLicenseExpression` | `ContainerGenerateLabelsImageLicenses` | |
| `org.opencontainers.image.title` | | `ContainerTitle` | `Title` | `ContainerGenerateLabelsImageTitle` | |
| `org.opencontainers.image.base.name` | | `ContainerBaseImage` | |`ContainerGenerateLabelsImageBaseName` | |
| `org.opencontainers.image.base.digest` | | | | `ContainerGenerateLabelsImageBaseDigest` | This is the SHA digest of the chosen base image. Available from .NET SDK 9.0.100 onwards. |
| `org.opencontainers.image.source` |                                                                                                    | `PrivateRepositoryUrl` | | `ContainerGenerateLabelsImageSource` | Only written if `PublishRepositoryUrl` is `true`. Also relies on Sourcelink infrastructure being part of the build. |
| `org.opencontainers.image.revision` | | `SourceRevisionId` | | `ContainerGenerateLabelsImageRevision` | Only written if `PublishRepositoryUrl` is `true`. Also relies on Sourcelink infrastructure being part of the build. |
| `net.dot.runtime.majorminor` | The major and minor version of the target framework, for example, `10.0` | | | `ContainerGenerateLabelsDotnetToolset` | Written only for .NET (not .NET Framework) target frameworks. |
| `net.dot.sdk.version` | The version of the .NET SDK used to build the image, for example, `10.0.100` | | | `ContainerGenerateLabelsDotnetToolset` | |

## See also

- [Containerize a .NET app with dotnet publish](sdk-publish.md)
- [.NET container images](../docker/container-images.md)

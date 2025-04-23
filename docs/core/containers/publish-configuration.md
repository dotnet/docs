---
title: Containerize a .NET app reference
description: Reference material for containerizing a .NET app and configuring the container image.
ms.topic: reference
ms.date: 04/22/2025
---

# Containerize a .NET app reference

In this reference article, you learn how to configure the container image generated when you publish a .NET app as a container. This article covers the various properties that you can set to control the image, the execution environment, and the commands that are run when the container starts.

## Configure container image

You can control many aspects of the generated container through MSBuild properties. In general, if you can use a command in a _Dockerfile_ to set some configuration, you can do the same via MSBuild.

> [!NOTE]
> The only exceptions to this are `RUN` commands. Due to the way containers are built, those commands can't be emulated. If you need this functionality, consider using a _Dockerfile_ to build your container images.

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
| ----------------- | --------------------- | ----------------------- |
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

This field is free-form, and often can be used to select different operating system distributions, default package configurations, or any other _flavor_ of changes to a base image. This field is ignored when `ContainerBaseImage` is set. For more information, see [.NET container images](../docker/container-images.md).

### `ContainerRuntimeIdentifier(s)`

The `ContainerRuntimeIdentifier` property specifies the OS and architecture for your container if the `ContainerBaseImage` supports multiple platforms. For example, the `mcr.microsoft.com/dotnet/runtime` image supports `linux-x64`, `linux-arm`, `linux-arm64`, and `win10-x64`. By default, this is set to the `RuntimeIdentifier` used when publishing the container. Typically, you don't need to set this property explicitly; instead, use the `-r` option with the `dotnet publish` command. If the chosen image doesn't support the specified `RuntimeIdentifier`, an error indicates the supported identifiers.

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
> The `ContainerRuntimeIdentifiers` property must be a subset of the `RuntimeIdentifiers` property. If this condition isn't met, critical parts of the build pipeline may fail.
>
> Setting multiple `ContainerRuntimeIdentifiers` results in a multi-architecture image being created. For more information, see [Multi-architecture images](#multi-architecture-images).

For more information regarding the runtime identifiers supported by .NET, see [RID catalog](../rid-catalog.md).

### `ContainerRegistry`

The container registry property controls the destination registry, the place that the newly created image is to be pushed to. By default it's pushed to the local Docker daemon, but you can also specify a remote registry. When using a remote registry that requires authentication, you authenticate using the well-known `docker login` mechanisms. For more information, See [authenticating to container registries](https://aka.ms/dotnet/containers/auth) for more details. For a concrete example of using this property, consider the following XML example:

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
> When you use `ContainerImageTags`, you end up with multiple images, one per unique tag.

Tags are often used to refer to different versions of an app, but they can also refer to different operating system distributions, or even different configurations.

Starting with .NET 8, when a tag isn't provided the default is `latest`.

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

Tags can only contain up to 127 alphanumeric characters, periods, underscores, and dashes. They must start with an alphanumeric character or an underscore. Any other form results in an error being thrown.

> [!NOTE]
> When using `ContainerImageTags` or any MSBuild property requiring `;`-delimited values, ensure proper escaping when calling `dotnet publish` from the command line, especially in CI/CD environments. Escaping rules differ between PowerShell and Bash. For example:
>
> ```powershell
> dotnet publish --os linux --arch x64 /t:PublishContainer /p:ContainerImageTags=`"1.2.3-alpha2`;latest`"
> ```
>
> In PowerShell, both the `;` and `"` characters need to be escaped.
>
> ```bash
> dotnet publish --os linux --arch x64 /t:PublishContainer /p:ContainerImageTags=\"1.2.3-alpha2;latest\"
> ```
>
> In Bash, only the `"` character needs to be escaped.
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

### `LocalRegistry`

The `LocalRegistry` MSBuild property specifies the local container tooling to use when pushing to local sources. Supported values are `docker` and `podman`. If not set, the SDK determines the tool based on availability:

- If both `docker` and `podman` exist, and `docker` is an alias for `podman`, then `podman` is used.
- If only `docker` exists, `docker` is used.
- If only `podman` exists, `podman` is used.
- If neither exists, an error is thrown.

To explicitly set the local registry tool, use the following configuration:

```xml
<PropertyGroup>
  <LocalRegistry>podman</LocalRegistry>
</PropertyGroup>
```

## Configure container commands

By default, the container tools launch your app using either the generated AppHost binary for your app (if your app uses an AppHost), or the `dotnet` command plus your app's DLL.

However, you can control how your app is executed by using some combination of `ContainerAppCommand`, `ContainerAppCommandArgs`, `ContainerDefaultArgs`, and `ContainerAppCommandInstruction`.

These different configuration points exist because different base images use different combinations of the container `ENTRYPOINT` and `COMMAND` properties, and you want to be able to support all of them. The defaults should be useable for most apps, but if you want to customize your app launch behavior you should:

- Identify the binary to run and set it as `ContainerAppCommand`
- Identify which arguments are _required_ for your application to run and set them as `ContainerAppCommandArgs`
- Identify which arguments (if any) are _optional_ and are able to be overridden by a user and set them as `ContainerDefaultArgs`
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

This app command args configuration item represents any logically required arguments for your app that should be applied to the `ContainerAppCommand`. By default, none are generated for an app. When present, the args are applied to your container when it runs.

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

Labels are often used to provide consistent metadata on container images. The built-in container tools provide some default labels to increase the quality of the generated images. All default label generation can be disabled by setting `ContainerGenerateLabels` to `false`. In addition, each default label has an  individual enablement flag that can be set to `false` to disable that specific label.

Where possible, existing MSBuild properties provide the values for these labels. Other properties allow for explicit control of their values.

| Annotation                                                                           | Default Value                                                                                      | Dedicated Property Name      | Fallback Property Name     | Enabled Property Name                       | Notes                                                                                                               |
| ------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------- | ---------------------------- | -------------------------- | ------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| `org.opencontainers.image.created` and `org.opencontainers.artifact.created`         | The [RFC 3339](https://tools.ietf.org/html/rfc3339#section-5.6) format of the current UTC DateTime |                              |                            | `ContainerGenerateLabelsImageCreated`       |                                                                                                                     |
| `org.opencontainers.artifact.description` and `org.opencontainers.image.description` |                                                                                                    | `ContainerDescription`       | `Description`              | `ContainerGenerateLabelsImageDescription`   |                                                                                                                     |
| `org.opencontainers.image.authors`                                                   |                                                                                                    | `ContainerAuthors`           | `Authors`                  | `ContainerGenerateLabelsImageAuthors`       |                                                                                                                     |
| `org.opencontainers.image.url`                                                       |                                                                                                    | `ContainerInformationUrl`    | `PackageProjectUrl`        | `ContainerGenerateLabelsImageUrl`           |                                                                                                                     |
| `org.opencontainers.image.documentation`                                             |                                                                                                    | `ContainerDocumentationUrl`  | `PackageProjectUrl`        | `ContainerGenerateLabelsImageDocumentation` |                                                                                                                     |
| `org.opencontainers.image.version`                                                   |                                                                                                    | `ContainerVersion`           | `PackageVersion`           | `ContainerGenerateLabelsImageVersion`       |                                                                                                                     |
| `org.opencontainers.image.vendor`                                                    |                                                                                                    | `ContainerVendor`            |                            | `ContainerGenerateLabelsImageVendor`        |                                                                                                                     |
| `org.opencontainers.image.licenses`                                                  |                                                                                                    | `ContainerLicenseExpression` | `PackageLicenseExpression` | `ContainerGenerateLabelsImageLicenses`      |                                                                                                                     |
| `org.opencontainers.image.title`                                                     |                                                                                                    | `ContainerTitle`             | `Title`                    | `ContainerGenerateLabelsImageTitle`         |                                                                                                                     |
| `org.opencontainers.image.base.name`                                                 |                                                                                                    | `ContainerBaseImage`         |                            | `ContainerGenerateLabelsImageBaseName`      |                                                                                                                     |
| `org.opencontainers.image.base.digest`                                               |                                                                                                    |                              |                            | `ContainerGenerateLabelsImageBaseDigest`    | This is the SHA digest of the chosen base image. Available from .NET SDK 9.0.100 onwards.                      |
| `org.opencontainers.image.source`                                                    |                                                                                                    | `PrivateRepositoryUrl`       |                            | `ContainerGenerateLabelsImageSource`        | Only written if `PublishRepositoryUrl` is `true`. Also relies on Sourcelink infrastructure being part of the build. |
| `org.opencontainers.image.revision`                                                  |                                                                                                    | `SourceRevisionId`           |                            | `ContainerGenerateLabelsImageRevision`      | Only written if `PublishRepositoryUrl` is `true`. Also relies on Sourcelink infrastructure being part of the build. |

## Multi-architecture images

Multi-architecture images enable a single container image to support multiple architectures, simplifying cross-platform development and deployment. The .NET SDK supports this through the `ContainerRuntimeIdentifiers` property.

Beginning with SDK versions 8.0.405, 9.0.102, and 9.0.2xx, multi-RID container publishing is supported. When publishing with `/t:PublishContainer`:

- If a single `RuntimeIdentifier` or `ContainerRuntimeIdentifier` is specified, a single-architecture container is generated as before.
- If no single `RuntimeIdentifier` is specified but multiple `RuntimeIdentifiers` or `ContainerRuntimeIdentifiers` are set, the SDK publishes the app for each specified RID and combines the resulting images into an [OCI Image Index](https://specs.opencontainers.org/image-spec/image-index/). This index allows multiple architecture-specific images to share a single name.

> [!NOTE]
> The `ContainerRuntimeIdentifiers` property must be a subset of the `RuntimeIdentifiers` property. For more information, see [ContainerRuntimeIdentifiers](#containerruntimeidentifiers).

This feature streamlines container workflows in mixed-architecture environments. For example, a developer on a `linux-x64` host can publish a container supporting both `linux-x64` and `linux-arm64`, enabling deployment to either architecture without changing image names or labels.

The generated OCI Image Index is widely supported with modern container tooling, enhancing compatibility and ease of use.

## See also

- [Containerize a .NET app with dotnet publish](sdk-publish.md)
- [.NET container images](../docker/container-images.md)

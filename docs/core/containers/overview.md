---
title: .NET SDK container creation overview
description: Learn about the .NET SDK container creation feature, including telemetry, publishing considerations, and build properties.
ms.date: 11/17/2026
ms.topic: overview
ai-usage: ai-assisted
---

# .NET SDK container creation overview

While it's possible to [containerize .NET apps with a _Dockerfile_](../docker/build-container.md), there are compelling reasons for [containerizing apps directly with the .NET SDK](sdk-publish.md). This article provides an overview of the .NET SDK container creation feature, with details related to telemetry, publishing considerations, build properties, and authentication to container registries.

## Publishing project considerations

Container support is built into the .NET SDK, so you don't need to add any packages to your project. The [📦 Microsoft.NET.Build.Containers](https://www.nuget.org/packages/Microsoft.NET.Build.Containers) NuGet package was required only for .NET SDK versions earlier than 8.0.200.

To publish a .NET app as a container, the following build properties must be `true`:

- `IsPublishable`: The SDK sets this property to `true` by default for executable project types, such as `console`, `webapp`, and `worker`.
- `EnableSdkContainerSupport`: The SDK sets this property to `true` by default for every project that isn't a class library, including console apps. In the .NET 9 SDK and earlier versions, you must set this property explicitly for console apps.

For console, web, and worker projects, you don't need to set either property. If your project or an imported file, such as _Directory.Build.props_, sets either property to `false`, enable SDK container support explicitly in your project file:

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
> To help troubleshoot, consider using the MSBuild logs. To generate a binary log (binlog) file, add the `-bl` switch to the `dotnet publish` command. Binlog files are useful for diagnosing build issues and can be opened in the [MSBuild Structured Log Viewer](https://msbuildlog.com/). They provide a detailed trace of the build process, essential for MSBuild analysis. For more information, see [Troubleshoot and create logs for MSBuild](/visualstudio/ide/msbuild-logs#provide-msbuild-binary-logs-for-investigation).

### Publish profiles and targets

To publish an app as a container, invoke the `PublishContainer` target directly. The following command works for every project type that supports SDK container publishing, including console apps:

```dotnetcli
dotnet publish /t:PublishContainer
```

Projects that use `Microsoft.NET.Sdk.Web` or `Microsoft.NET.Sdk.Worker` also have a `DefaultContainer` publish profile. When you specify this profile, it sets a property that causes the SDK to run the `PublishContainer` target after the publish process:

```dotnetcli
dotnet publish -p PublishProfile=DefaultContainer
```

The `DefaultContainer` profile isn't available to console apps and other projects that use `Microsoft.NET.Sdk`. If you specify the profile for one of these projects, the SDK reports warning `NETSDK1198` and doesn't create a container image.

Publish profiles are an MSBuild feature that can set properties in more complex ways than setting them directly. However, not all project types support profiles or have the same set of profiles available, and support for profiles differs between tools, such as Visual Studio and the .NET CLI. Because the `PublishContainer` target works the same way for all supported project types and tools, use the target instead of the profile.

## Authenticate to container registries

Interacting with private container registries requires authenticating with those registries.

Docker handles registry authentication through the [`docker login`](https://docs.docker.com/engine/reference/commandline/login/) command, which updates a Docker configuration file with rules for authenticating with specific registries. The .NET SDK container tooling supports this file and the authentication types it encodes, so the tooling works with any registry that you can `docker pull` from and `docker push` to. Docker normally stores this file at _~/.docker/config.json_, or you can set the `DOCKER_CONFIG` environment variable to a directory that contains a _config.json_ file.

## Kinds of authentication

The _config.json_ file contains three kinds of authentication:

- [Explicit username/password](#explicit-usernamepassword)
- [Credential helpers](#credential-helpers)
- [System keychain](#system-keychains)

### Explicit username/password

The `auths` section of the _config.json_ file is a key/value map between registry names and Base64-encoded username:password strings. In a common Docker scenario, running `docker login <registry> -u <username> -p <password>` creates new items in this map. These credentials are popular in continuous integration (CI) systems, where logging in is done by tokens at the start of a run. However, they are less popular for end-user development machines due to the security risk of having bare credentials in a file.

### Credential helpers

The `credHelpers` section of the _config.json_ file is a key/value map between registry names and the names of specific programs that can be used to create and retrieve credentials for that registry. This is often used when particular registries have complex authentication requirements. In order for this kind of authentication to work, you must have an application named `docker-credential-{name}` on your system's `PATH`. These kinds of credentials tend to be secure, but can be hard to set up on development or CI machines.

### System keychains

The `credsStore` section is a single string property whose value is the name of a docker credential helper program that knows how to interface with the system's password manager. For Windows this might be `wincred` for example. These are popular with Docker installers for macOS and Windows.

## Authentication via environment variables

In some scenarios, such as when you run the .NET SDK container tooling inside a container, the standard Docker authentication mechanism doesn't work. For these scenarios, the tooling can read registry credentials from environment variables instead. When you set the applicable environment variables, the tooling uses them instead of the Docker configuration file. The tooling supports the following environment variables:

- `DOTNET_CONTAINER_REGISTRY_UNAME` and `DOTNET_CONTAINER_REGISTRY_PWORD`: Specify the username and the password or token for the registry. If you use a token, set the username to the value that your registry requires for that token type.
- `DOTNET_CONTAINER_PUSH_REGISTRY_UNAME` and `DOTNET_CONTAINER_PUSH_REGISTRY_PWORD`: Specify the username and the password or token for the _destination_ registry where you push your final image.
- `DOTNET_CONTAINER_PULL_REGISTRY_UNAME` and `DOTNET_CONTAINER_PULL_REGISTRY_PWORD`: Specify the username and the password or token for the _source_ registry that hosts your base image.

Set both variables in each pair. The tooling ignores a pair if either value is empty. For each registry operation, the tooling checks the following pairs in order and uses the first one that's set:

| Operation | Environment variables, in order of precedence |
|--|--|
| Push the final image to the destination registry | `DOTNET_CONTAINER_PUSH_REGISTRY_*`, then `DOTNET_CONTAINER_REGISTRY_*` |
| Pull the base image from the destination registry | `DOTNET_CONTAINER_PULL_REGISTRY_*`, then `DOTNET_CONTAINER_REGISTRY_*` |
| Pull the base image from a different registry | `DOTNET_CONTAINER_PULL_REGISTRY_*` |

If none of the applicable variables are set, the tooling uses the Docker configuration file. The `DOTNET_CONTAINER_REGISTRY_*` variables apply to the source registry only when it's the same as the destination registry. If your base image is in a different registry that requires credentials, set the `DOTNET_CONTAINER_PULL_REGISTRY_*` variables.

> [!NOTE]
> As of .NET SDK 8.0.400, the environment variables for container operations have been updated. The `SDK_CONTAINER_*` variables are now prefixed with `DOTNET_CONTAINER_*`.

Environment variables can leak credentials, so use them only in scenarios where the Docker configuration file isn't available.

## Using insecure registries

Most registry access is assumed to be secure, meaning HTTPS is used to interact with the registry. However, not all registries are configured with TLS certificates - especially in situations like a
private corporate registry behind a VPN. To support these use cases, container tools provide ways of declaring that a specific registry uses insecure communication.

Starting in .NET 8.0.400, the SDK understands these configuration files and formats and will automatically use that configuration to determine if HTTP or HTTPS should be used.
Configuring a registry for insecure communication varies based on your container tool of choice.

### Docker

Docker stores its registry configuration in the [daemon configuration](https://docs.docker.com/config/daemon/#configuration-file). To add new insecure registries, new hosts are added to the `"insecure-registries"` array property:

```json
{
  "insecure-registries": [
    "registry.mycorp.net"
  ]
}
```

> [!NOTE]
> You must restart the Docker daemon to apply any changes to this file.

### Podman

Podman uses a [`registries.conf`](https://podman-desktop.io/docs/containers/registries#setting-up-a-registry-with-an-insecure-certificate) TOML file to store registry connection information. This file typically lives at `/etc/containers/registries.conf`. To add new insecure registries, a TOML section is added to hold the settings for the registry, then the `insecure` option must be set to `true`.

```toml
[[registry]]
location = "registry.mycorp.net"
insecure = true
```

> [!NOTE]
> You must restart Podman to apply any changes to the _registries.conf_ file.

### Environment variables

Starting in .NET SDK 9.0.100, the SDK recognizes insecure registries passed through the `DOTNET_CONTAINER_INSECURE_REGISTRIES` environment variable. This variable takes a semicolon-separated list of registry names to treat as insecure in the same manner as the preceding Docker and Podman examples. The SDK always treats `localhost` registries as insecure, so you don't need to add them to the list.

The following examples pull a base image from one insecure registry and push the final image to another. To prevent your shell from interpreting the semicolon as a command separator, enclose the value in quotes. The .NET version in the base image tag must match your app's target framework (for example, `10.0` for an app that targets `net10.0` or `11.0` for an app that targets `net11.0`).

#### [Windows](#tab/windows)

```powershell
$Env:DOTNET_CONTAINER_INSECURE_REGISTRIES='registry.mycorp.com;mirror.mycorp.com'
dotnet publish -t:PublishContainer -p:ContainerRegistry=registry.mycorp.com -p:ContainerBaseImage=mirror.mycorp.com/dotnet/runtime:10.0
```

#### [Linux](#tab/linux)

```bash
DOTNET_CONTAINER_INSECURE_REGISTRIES='registry.mycorp.com;mirror.mycorp.com' dotnet publish -t:PublishContainer -p:ContainerRegistry=registry.mycorp.com -p:ContainerBaseImage=mirror.mycorp.com/dotnet/runtime:10.0
```

---

## Telemetry

When you publish a .NET app as a container, the .NET SDK container tooling collects and sends usage telemetry about how the tools are used. The collected data is in addition to the [telemetry sent by the .NET CLI](../tools/telemetry.md), but uses the same mechanisms and, importantly, adheres to the same [opt-out controls](../tools/telemetry.md#how-to-opt-out).

The telemetry gathered is intended to be general in nature and not leak any personal information—the intended purpose is to help measure:

- Usage of the .NET SDK containerization feature overall.
- Success and failure rates, along with general information about what kinds of failures happen most frequently.
- Usage of specific features of the tech, like publishing to various registry kinds, or how the publish was invoked.

To opt-out of telemetry, set the `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `true`. For more information, see [.NET CLI telemetry](../tools/telemetry.md).

### Inference telemetry

The following information about how the base image inference process occurred is logged:

| Data point | Explanation | Sample value |
|--|--|--|
| `InferencePerformed` | If users are manually specifying base images vs making use of inference. | `true` |
| `TargetFramework` | The `TargetFramework` used for base image inference. | `net10.0` |
| `BaseImage` | The value of the base image chosen, but only if that base image is one of the Microsoft-produced images. If a user specifies any image other than the Microsoft-produced images on mcr.microsoft.com, this value is null. | `mcr.microsoft.com/dotnet/aspnet` |
| `BaseImageTag` | The tag of the selected base image, recorded only when the image is a Microsoft-produced image on `mcr.microsoft.com`; otherwise, `null`. | `10.0` |
| `ContainerFamily` | The value of the `ContainerFamily` property when used to select a variant of a Microsoft-produced .NET base image from `mcr.microsoft.com`. | `noble-chiseled` |
| `ProjectType` | The kind of project that's being containerized. | `AspNetCore` or `Console` |
| `PublishMode` | How the application was packaged. | `Aot`, `Trimmed`, `SelfContained`, or `FrameworkDependent` |
| `IsInvariant` | If the image chosen requires invariant globalization or the user opted into it manually. | `true` |
| `TargetRuntime` | The RID that this application was published for. | `linux-x64` |

### Image creation telemetry

The following information about how the container creation and publishing process occurred is logged:

| Data point | Explanation | Sample value |
|--|--|--|
| `RemotePullType` | The kind of remote registry that the base image came from. | Azure, AWS, Google, GitHub, DockerHub, MCR, or Other |
| `LocalPullType` | Reserved for a base image from a local source, such as a container daemon or a tarball. Because the SDK doesn't currently support local base images, it doesn't set this value. | Not set |
| `RemotePushType` | The kind of remote registry that the image was pushed to. | Azure, AWS, Google, GitHub, DockerHub, MCR, or Other |
| `LocalPushType` | If the image was pushed to a local destination, what was it? | Docker, Podman, Tarball |

In addition, if various kinds of errors occur during the process that data is collected about what kind of error it was:

| Data point | Explanation | Sample value |
|--|--|--|
| `Error` | The kind of error that occurred | `unknown_repository`, `credential_failure`, `rid_mismatch`, `local_load`. |
| `Direction` | If the error is a `credential_failure`, was it to the push or pull registry? | `push` |
| Target RID | If the error was a `rid_mismatch`, what RID was requested | `linux-x64` |
| Available RIDs | If the error was a `rid_mismatch`, what RIDs did the base image support? | `linux-x64,linux-arm64` |

## See also

- [Publish .NET apps as containers](sdk-publish.md)
- [Containerize a .NET app reference](publish-configuration.md)

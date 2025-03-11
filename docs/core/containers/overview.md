---
title: .NET SDK container creation overview
description: Learn about the .NET SDK container creation feature, including telemetry, publishing considerations, and build properties.
ms.date: 01/07/2025
ms.topic: overview
---

# .NET SDK container creation overview

While it's possible to [containerize .NET apps with a _Dockerfile_](../docker/build-container.md), there are compelling reasons for [containerizing apps directly with the .NET SDK](sdk-publish.md). This article provides an overview of the .NET SDK container creation feature, with details related to telemetry, publishing considerations, build properties, and authentication to container registries.

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

## Authenticate to container registries

Interacting with private container registries requires authenticating with those registries.

Docker has an established pattern with this via the [`docker login`](https://docs.docker.com/engine/reference/commandline/login/) command, which is a way of interacting with a Docker config file that contains rules for authenticating with specific registries. This file, and the authentication types it encodes, are supported by Microsoft.Net.Build.Containers for registry authentication. This should ensure that this package works seamlessly with any registry you can `docker pull` from and `docker push`. This file is normally stored at _~/.docker/config.json_, but it can be specified additionally through the `DOCKER_CONFIG` variable, which points to a directory containing a _config.json_ file.

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

In some scenarios the standard Docker authentication mechanism described above just doesn't cut it. This tooling has an additional mechanism for providing credentials to registries: environment variables. If environment variables are used, the credential provide mechanism won't be used at all. The following environment variables are supported:

- `DOTNET_CONTAINER_REGISTRY_UNAME`: This should be the username for the registry. If the password for the registry is a token, then the username should be `"<token>"`.
- `DOTNET_CONTAINER_REGISTRY_PWORD`: This should be the password or token for the registry.

> [!NOTE]
> As of .NET SDK 8.0.400, the environment variables for container operations have been updated. The `SDK_CONTAINER_*` variables are now prefixed with `DOTNET_CONTAINER_*`.

This mechanism is potentially vulnerable to credential leakage, so it should only be used in scenarios where the other mechanism isn't available. For example, if you're using the SDK Container tooling inside a Docker container itself. In addition, this mechanism isn't namespaced—it attempts to use the same credentials for both the _source_ registry (where your base image is located) and the _destination_ registry (where you're pushing your final image).

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

Starting in 9.0.100, the .NET SDK recognizes insecure registries passed through the `DOTNET_CONTAINER_INSECURE_REGISTRIES` environment variable. This variable takes a comma-separated list of domains to treat as insecure in the same manner as the Docker and Podman examples above.

#### [Windows](#tab/windows)

```powershell
$Env:DOTNET_CONTAINER_INSECURE_REGISTRIES=localhost:5000,registry.mycorp.com; dotnet publish -t:PublishContainer -p:ContainerRegistry=registry.mycorp.com -p:ContainerBaseImage=localhost:5000/dotnet/runtime:9.0
```

#### [Linux](#tab/linux)

```bash
DOTNET_CONTAINER_INSECURE_REGISTRIES=localhost:5000,registry.mycorp.com dotnet publish -t:PublishContainer -p:ContainerRegistry=registry.mycorp.com -p:ContainerBaseImage=localhost:5000/dotnet/runtime:9.0
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

| Date point | Explanation | Sample value |
|--|--|--|
| `InferencePerformed` | If users are manually specifying base images vs making use of inference. | `true` |
| `TargetFramework` | The `TargetFramework` chosen when doing base image inference. | `net8.0` |
| `BaseImage` | The value of the base image chosen, but only if that base image is one of the Microsoft-produced images. If a user specifies any image other than the Microsoft-produced images on mcr.microsoft.com, this value is null. | `mcr.microsoft.com/dotnet/aspnet` |
| `BaseImageTag` | The value of the tag chosen, but only if that tag is for one of the Microsoft-produced images. If a user specifies any image other than the Microsoft-produced images on mcr.microsoft.com, this value is null. | `8.0` |
| `ContainerFamily` | The value of the `ContainerFamily` property if a user used the `ContainerFamily` feature to pick a 'flavor' of one of our base images. This is only set if the user picked or inferred one of the Microsoft-produced .NET images from mcr.microsoft.com | `jammy-chiseled` |
| `ProjectType` | The kind of project that's being containerized. | `AspNetCore` or `Console` |
| `PublishMode` | How the application was packaged. | `Aot`, `Trimmed`, `SelfContained`, or `FrameworkDependent` |
| `IsInvariant` | If the image chosen requires invariant globalization or the user opted into it manually. | `true` |
| `TargetRuntime` | The RID that this application was published for. | `linux-x64` |

### Image creation telemetry

The following information about how the container creation and publishing process occurred is logged:

| Date point | Explanation | Sample value |
|--|--|--|
| `RemotePullType` | If the base image came from a remote registry, what kind of registry was it? | Azure, AWS, Google, GitHub, DockerHub, MRC, or Other |
| `LocalPullType` | If the base image came from a local source, like a container daemon or a tarball. | Docker, Podman, Tarball |
| `RemotePushType` | If the image was pushed to a remote registry, what kind of registry was it? | Azure, AWS, Google, GitHub, DockerHub, MRC, or Other |
| `LocalPushType` | If the image was pushed to a local destination, what was it? | Docker, Podman, Tarball |

In addition, if various kinds of errors occur during the process that data is collected about what kind of error it was:

| Date point | Explanation | Sample value |
|--|--|--|
| `Error` | The kind of error that occurred | `unknown_repository`, `credential_failure`, `rid_mismatch`, `local_load`. |
| `Direction` | If the error is a `credential_failure`, was it to the push or pull registry? | `push` |
| Target RID | If the error was a `rid_mismatch`, what RID was requested | `linux-x64` |
| Available RIDs | If the error was a `rid_mismatch`, what RIDs did the base image support? | `linux-x64,linux-arm64` |

## See also

- [Publish .NET apps as containers](sdk-publish.md)
- [Containerize a .NET app reference](publish-configuration.md)

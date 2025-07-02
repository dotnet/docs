---
title: Application publishing
description: Learn about the ways to publish a .NET application. .NET can publish platform-specific or cross-platform apps. You can publish an app as self-contained or as framework-dependent. Each mode affects how a user runs your app.
ms.date: 07/01/2025
---

# .NET application publishing overview

INTRO PARA

## What is publishing

Publishing a .NET app means compiling source code to create an executable or binary, along with its dependencies and related files, for distribution. After publishing, you deploy the app to a server, distribution platform, container, or cloud environment. The publishing process prepares an app for deployment and use outside of your development environment.

## Publishing modes

There are two primary ways to publish an app, and depending on how the app is deployed, one or the other is chosen. The choice largely depends on whether the deployment environment has the appropriate .NET Runtime installed. The two publishing modes are:

- Publish *self-contained*\
This mode produces a publishing folder that includes a platform-specific executable used to start the app, a compiled binary containing app code, any app dependencies, and the .NET runtime required to run the app. The environment that runs the app doesn't need to have the .NET runtime pre-installed.

- Publish *framework-dependent*\
This mode produces a publishing folder that includes a platform-specific executable used to start the app, a compiled binary containing app code, and any app dependencies. The environment that runs the app must have a version of the .NET runtime installed that the app can use. An optional platform-specific executable can be produced.

> [!IMPORTANT]
> You specify the target platform with a runtime identifier (RID). For more information about RIDs, see [.NET RID Catalog](../rid-catalog.md).

The following table outlines the commands used to publish an app as framework-dependent or self-contained:

| Type                                                                                     | Command                                                                  |
|------------------------------------------------------------------------------------------|--------------------------------------------------------------------------|
| [framework-dependent executable](#publish-framework-dependent) for the current platform. | [`dotnet publish`](../tools/dotnet-publish.md)                           |
| [framework-dependent executable](#publish-framework-dependent) for a specific platform.  | [`dotnet publish -r <RID>`](../tools/dotnet-publish.md)                  |
| [framework-dependent binary](#publish-framework-dependent).                              | [`dotnet publish`](../tools/dotnet-publish.md)                           |
| [self-contained executable](#publish-self-contained).                                    | [`dotnet publish -r <RID> --self-contained`](../tools/dotnet-publish.md) |

For more information, see [.NET dotnet publish command](../tools/dotnet-publish.md).

## Produce an executable

Executables aren't cross-platform; they're specific to an operating system and CPU architecture. Executables are produced as either [self-contained](#publish-self-contained) or [framework-dependent](#publish-framework-dependent). Publishing as self-contained includes the .NET runtime with the app, so users don't have to install .NET before running it. Publishing as framework-dependent doesn't include the .NET runtime; only the app and third-party dependencies are included.

The following commands produce an executable:

| Type | Command |
|--|--|
| [framework-dependent executable](#publish-framework-dependent) for the current platform. | [`dotnet publish`](../tools/dotnet-publish.md) |
| [framework-dependent executable](#publish-framework-dependent) for a specific platform. | [`dotnet publish -r <RID>`](../tools/dotnet-publish.md) |
| [self-contained executable](#publish-self-contained). | [`dotnet publish -r <RID> --self-contained`](../tools/dotnet-publish.md) |

## Produce a cross-platform binary

Cross-platform binaries are created when the app is published as [framework-dependent](#publish-framework-dependent), in the form of a *dll* file. The *dll* file is named after the project. For example, if you have an app named **word_reader**, a file named *word_reader.dll* is created. Apps published in this way are run with the `dotnet <filename.dll>` command.

Cross-platform binaries can run on any operating system as long as the targeted .NET runtime is already installed. If the targeted .NET runtime isn't installed, the app might run using a newer runtime if configured to roll-forward. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

Choose to run the app as a platform-specific executable or as a cross-platform binary via the `dotnet` command. There should be no app behavior difference when launching the platform-specific executable versus the `dotnet` command. Launching via a platform-specific executable gives better integration with the underlying OS. For example:

- The application executable name appears in the process list instead of `dotnet`, which could be confusing if there's more than one.
- The platform-specific executable can be customized with OS-specific features. For example, see [this discussion about configuring default stack size on Windows](https://github.com/dotnet/runtime/issues/96347#issuecomment-1981470713).

The following command produces a cross-platform binary:

| Type | Command |
|--|--|
| [framework-dependent cross-platform binary](#publish-framework-dependent). | [`dotnet publish`](../tools/dotnet-publish.md) |

## Publish framework-dependent

Apps published as framework-dependent are cross-platform and don't include the .NET runtime. The user is required to install the .NET runtime.

Publishing as framework-dependent produces a [cross-platform binary](#produce-a-cross-platform-binary) as a *dll* file, and a [platform-specific executable](#produce-an-executable) that targets the current platform. The *dll* is cross-platform while the executable isn't. For example, if the app is named **word_reader** and targets Windows, a *word_reader.exe* executable is created along with *word_reader.dll*. When targeting Linux or macOS, a *word_reader* executable is created along with *word_reader.dll*. If the app uses a NuGet package that has platform-specific implementations, dependencies for all platforms are copied to the *publish\\runtimes\\{platform}* folder.

The cross-platform binary can be run with the `dotnet <filename.dll>` command, and can run on any platform.

### Platform-specific and framework-dependent

Publish a framework-dependent app that's platform-specific by passing the `-r <RID>` parameters to the [`dotnet publish`](../tools/dotnet-publish.md) command. Publishing in this way is the same as [publish framework-dependent](#publish-framework-dependent), except that platform-specific dependencies are handled differently. If the app uses a NuGet package that has platform-specific implementations, only the targeted platform's dependencies are copied. These dependencies are copied directly to the *publish* folder.

While technically the binary produced is cross-platform, by targeting a specific platform, the app isn't guaranteed to run cross-platform. The app can be run with `dotnet <filename.dll>`, but it might crash when it tries to access platform-specific dependencies that are missing.

For more information about RIDs, see [.NET RID Catalog](../rid-catalog.md).

### Advantages

- **Small deployment**\
Only the app and its dependencies are distributed. The .NET runtime and libraries are installed by the user and all apps share the runtime.

- **Cross-platform**\
The app and any .NET-based library runs on other operating systems. There's no need to define a target platform for the app. For information about the .NET file format, see [.NET Assembly File Format](../../standard/assembly/file-format.md).

- **Uses the latest patched runtime**\
The app uses the latest runtime (within the targeted major-minor family of .NET) installed on the target system. This means the app automatically uses the latest patched version of the .NET runtime. This default behavior can be overridden. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

### Disadvantages

- **Requires pre-installing the runtime**\
The app can run only if the version of .NET it targets is already installed on the enviornment running the app. Configure roll-forward behavior for the app to either require a specific version of .NET or allow a newer version of .NET. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

- **.NET may change**\
It's possible that the environment where the app is run is using a newer .NET runtime. In rare cases, this might change the behavior of the app if it uses the .NET libraries, which most apps do. You can configure how an app uses newer versions of .NET, known as rolling forward. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

### Examples

Publish an app as cross-platform and framework-dependent. An executable that targets the current platform is created along with the *dll* file. Any platform-specific dependencies are published with the app.

```dotnetcli
dotnet publish
```

Publish an app as platform-specific and framework-dependent. A Linux 64-bit executable is created along with the *dll* file. Only the targeted platform's dependencies are published with the app.

```dotnetcli
dotnet publish -r linux-x64
```

## Publish self-contained

Publishing as self-contained produces a platform-specific executable. The output publishing folder contains all components of the app, including the .NET libraries and target runtime. The app is isolated from other .NET apps and doesn't use a locally installed shared runtime. The user isn't required to download and install .NET.

Publish a self-contained app by passing the `--self-contained` parameter to the [`dotnet publish`](../tools/dotnet-publish.md) command. The executable binary is produced for the specified target platform. For example, if the app is named **word_reader**, and a self-contained executable is published for Windows, a *word_reader.exe* file is created. Publishing for Linux or macOS, a *word_reader* file is created. The target platform and architecture is specified with the `-r <RID>` parameter for the [`dotnet publish`](../tools/dotnet-publish.md) command. For more information about RIDs, see [.NET RID Catalog](../rid-catalog.md).

If the app has platform-specific dependencies, such as a NuGet package containing platform-specific dependencies, these are copied to the publish folder along with the app.

### Advantages

- **Control .NET version**\
Control which version of .NET is deployed with the app.

- **Platform-specific targeting**\
Because the app must be published for each platform, it's clear where the app runs. If .NET introduces a new platform, users can't run the app on that platform until a version targeting that platform is released. Test the app for compatibility problems before users run it on the new platform.

### Disadvantages

- **Larger deployments**\
Because the app includes the .NET runtime and all dependencies, the download size and hard drive space required is greater than a [framework-dependent](#publish-framework-dependent) version.

  > [!TIP]
  > Reduce the size of the deployment on Linux systems by approximately 28 MB by using .NET [*globalization invariant mode*](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md). This forces the app to treat all cultures like the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType).
  >
  > [IL trimming](trimming/trim-self-contained.md) can further reduce the size of the deployment.

- **Harder to update the .NET version**\
The .NET Runtime (distributed with the app) can only be upgraded by releasing a new version of the app.

### Examples

Publish an app self-contained. A macOS 64-bit executable is created.

```dotnetcli
dotnet publish -r osx-x64 --self-contained
```

Publish an app self-contained. A Windows 64-bit executable is created.

```dotnetcli
dotnet publish -r win-x64 --self-contained
```

## Publish with ReadyToRun images

Publishing with ReadyToRun images improves the startup time of the application at the cost of increasing the size of the application. For more information, see [ReadyToRun](ready-to-run.md).

### Advantages

- **Improved startup time**\
The application spends less time running the JIT.

### Disadvantages

- **Larger size**\
The application is larger on disk.

### Examples

Publish an app self-contained and ReadyToRun. A macOS 64-bit executable is created.

```dotnetcli
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishReadyToRun=true
```

Publish an app self-contained and ReadyToRun. A Windows 64-bit executable is created.

```dotnetcli
dotnet publish -c Release -r win-x64 --self-contained -p:PublishReadyToRun=true
```

## See also

- [Deploying .NET Apps with .NET CLI.](deploy-with-cli.md)
- [Deploying .NET Apps with Visual Studio.](deploy-with-vs.md)
- [.NET Runtime Identifier (RID) catalog.](../rid-catalog.md)
- [Select the .NET version to use.](../versions/selection.md)

---
title: Application publishing
description: Learn about the ways to publish a .NET application. .NET can publish platform-specific or cross-platform apps. You can publish an app as self-contained or as framework-dependent. Each mode affects how a user runs your app.
ms.date: 12/23/2022
---
# .NET application publishing overview

Applications you create with .NET can be published in two different modes, and the mode affects how a user runs your app.

Publishing your app as *self-contained* produces an application that includes the .NET runtime and libraries, and your application and its dependencies. Users of the application can run it on a machine that doesn't have the .NET runtime installed.

Publishing your app as *framework-dependent* produces an application that includes only your application itself and its dependencies. Users of the application have to separately install the .NET runtime.

Both publishing modes produce a platform-specific executable by default. Framework-dependent applications can be created without an executable, and these applications are cross-platform.

When an executable is produced, you can specify the target platform with a runtime identifier (RID). For more information about RIDs, see [.NET RID Catalog](../rid-catalog.md).

The following table outlines the commands used to publish an app as framework-dependent or self-contained, per SDK version:

| Type                                                                                     | Command                                                                        |
|------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------|
| [framework-dependent executable](#publish-framework-dependent) for the current platform. | [`dotnet publish`](../tools/dotnet-publish.md)                                 |
| [framework-dependent executable](#publish-framework-dependent) for a specific platform.  | [`dotnet publish -r <RID> --self-contained false`](../tools/dotnet-publish.md) |
| [framework-dependent binary](#publish-framework-dependent).                              | [`dotnet publish`](../tools/dotnet-publish.md)                                 |
| [self-contained executable](#publish-self-contained).                                    | [`dotnet publish -r <RID>`](../tools/dotnet-publish.md)                        |

For more information, see [.NET dotnet publish command](../tools/dotnet-publish.md).

## Produce an executable

Executables aren't cross-platform, they're specific to an operating system and CPU architecture. When publishing your app and creating an executable, you can publish the app as [self-contained](#publish-self-contained) or [framework-dependent](#publish-framework-dependent). Publishing an app as self-contained includes the .NET runtime with the app, and users of the app don't have to worry about installing .NET before running the app. Publishing an app as framework-dependent doesn't include the .NET runtime; only the app and 3rd-party dependencies are included.

The following commands produce an executable:

| Type                                                                                     | Command |
| ---------------------------------------------------------------------------------------- | ------- |
| [framework-dependent executable](#publish-framework-dependent) for the current platform. |  [`dotnet publish`](../tools/dotnet-publish.md) |
| [framework-dependent executable](#publish-framework-dependent) for a specific platform.  |  [`dotnet publish -r <RID> --self-contained false`](../tools/dotnet-publish.md) |
| [self-contained executable](#publish-self-contained).                                    |  [`dotnet publish -r <RID>`](../tools/dotnet-publish.md) |

## Produce a cross-platform binary

Cross-platform binaries are created when you publish your app as [framework-dependent](#publish-framework-dependent), in the form of a *dll* file. The *dll* file is named after your project. For example, if you have an app named **word_reader**, a file named *word_reader.dll* is created. Apps published in this way are run with the `dotnet <filename.dll>` command and can be run on any platform.

Cross-platform binaries can be run on any operating system as long as the targeted .NET runtime is already installed. If the targeted .NET runtime isn't installed, the app may run using a newer runtime if the app is configured to roll-forward. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

The following command produces a cross-platform binary:

| Type                                                                                | Command |
| ----------------------------------------------------------------------------------- | ------- |
| [framework-dependent cross-platform binary](#publish-framework-dependent).          | [`dotnet publish`](../tools/dotnet-publish.md) |

## Publish framework-dependent

Apps published as framework-dependent are cross-platform and don't include the .NET runtime. The user of your app is required to install the .NET runtime.

Publishing an app as framework-dependent produces a [cross-platform binary](#produce-a-cross-platform-binary) as a *dll* file, and a [platform-specific executable](#produce-an-executable) that targets your current platform. The *dll* is cross-platform while the executable isn't. For example, if you publish an app named **word_reader** and target Windows, a *word_reader.exe* executable is created along with *word_reader.dll*. When targeting Linux or macOS, a *word_reader* executable is created along with *word_reader.dll*. If the app uses a NuGet package that has platform-specific implementations, all platforms' dependencies are copied to the *publish\\runtimes\\{platform}* folder.

The cross-platform binary of your app can be run with the `dotnet <filename.dll>` command, and can be run on any platform.

### Platform-specific framework-dependent

You can publish a framework-dependent app that is platform-specific by passing the `-r <RID> --self-contained false` parameters to the [`dotnet publish`](../tools/dotnet-publish.md) command. Publishing in this way is the same as [publish framework-dependent](#publish-framework-dependent), except that platform-specific dependencies are handled differently. If the app uses a NuGet package that has platform-specific implementations, only the targeted platform's dependencies are copied. These dependencies are copied directly to the *publish* folder.

While technically the binary produced is cross-platform, by targeting a specific platform, your app isn't guaranteed to run cross-platform. So you can run `dotnet <filename.dll>`, but the app may crash once it tries to access platform-specific dependencies that are missing.

For more information about RIDs, see [.NET RID Catalog](../rid-catalog.md).

### Advantages

- **Small deployment**\
Only your app and its dependencies are distributed. The .NET runtime and libraries are installed by the user and all apps share the runtime.

- **Cross-platform**\
Your app and any .NET-based library runs on other operating systems. You don't need to define a target platform for your app. For information about the .NET file format, see [.NET Assembly File Format](../../standard/assembly/file-format.md).

- **Uses the latest patched runtime**\
The app uses the latest runtime (within the targeted major-minor family of .NET) installed on the target system. This means your app automatically uses the latest patched version of the .NET runtime. This default behavior can be overridden. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

### Disadvantages

- **Requires pre-installing the runtime**\
Your app can run only if the version of .NET your app targets is already installed on the host system. You can configure roll-forward behavior for the app to either require a specific version of .NET or allow a newer version of .NET. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

- **.NET may change**\
It's possible for the .NET runtime and libraries to be updated on the machine where the app is run. In rare cases, this may change the behavior of your app if you use the .NET libraries, which most apps do. You can configure how your app uses newer versions of .NET. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

### Examples

Publish an app cross-platform framework-dependent. An executable that targets your current platform is created along with the *dll* file. Any platform-specific dependencies are published with the app.

```dotnetcli
dotnet publish
```

Publish an app platform-specific framework-dependent. A Linux 64-bit executable is created along with the *dll* file. Only the targeted platform's dependencies are published with the app.

```dotnetcli
dotnet publish -r linux-x64 --self-contained false
```

## Publish self-contained

Publishing your app as self-contained produces a platform-specific executable. The output publishing folder contains all components of the app, including the .NET libraries and target runtime. The app is isolated from other .NET apps and doesn't use a locally installed shared runtime. The user of your app isn't required to download and install .NET.

The executable binary is produced for the specified target platform. For example, if you have an app named **word_reader**, and you publish a self-contained executable for Windows, a *word_reader.exe* file is created. Publishing for Linux or macOS, a *word_reader* file is created. The target platform and architecture is specified with the `-r <RID>` parameter for the [`dotnet publish`](../tools/dotnet-publish.md) command. For more information about RIDs, see [.NET RID Catalog](../rid-catalog.md).

If the app has platform-specific dependencies, such as a NuGet package containing platform-specific dependencies, these are copied to the publish folder along with the app.

### Advantages

- **Control .NET version**\
You control which version of .NET is deployed with your app.

- **Platform-specific targeting**\
Because you have to publish your app for each platform, you know where your app will run. If .NET introduces a new platform, users can't run your app on that platform until you release a version targeting that platform. You can test your app for compatibility problems before your users run your app on the new platform.

### Disadvantages

- **Larger deployments**\
Because your app includes the .NET runtime and all of your app dependencies, the download size and hard drive space required is greater than a [framework-dependent](#publish-framework-dependent) version.

  > [!TIP]
  > You can reduce the size of your deployment on Linux systems by approximately 28 MB by using .NET [*globalization invariant mode*](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md). This forces your app to treat all cultures like the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType).

  > [!TIP]
  > [IL trimming](trimming/trim-self-contained.md) can further reduce the size of your deployment.

- **Harder to update the .NET version**\
.NET Runtime (distributed with your app) can only be upgraded by releasing a new version of your app.

### Examples

Publish an app self-contained. A macOS 64-bit executable is created.

```dotnetcli
dotnet publish -r osx-x64
```

Publish an app self-contained. A Windows 64-bit executable is created.

```dotnetcli
dotnet publish -r win-x64
```

## Publish with ReadyToRun images

Publishing with ReadyToRun images will improve the startup time of your application at the cost of increasing the size of your application. For more information, see [ReadyToRun](ready-to-run.md).

### Advantages

- **Improved startup time**\
The application will spend less time running the JIT.

### Disadvantages

- **Larger size**\
The application will be larger on disk.

### Examples

Publish an app self-contained and ReadyToRun. A macOS 64-bit executable is created.

```dotnetcli
dotnet publish -c Release -r osx-x64 -p:PublishReadyToRun=true
```

Publish an app self-contained and ReadyToRun. A Windows 64-bit executable is created.

```dotnetcli
dotnet publish -c Release -r win-x64 -p:PublishReadyToRun=true
```

## See also

- [Deploying .NET Apps with .NET CLI.](deploy-with-cli.md)
- [Deploying .NET Apps with Visual Studio.](deploy-with-vs.md)
- [.NET Runtime Identifier (RID) catalog.](../rid-catalog.md)
- [Select the .NET version to use.](../versions/selection.md)

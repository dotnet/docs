---
title: Application publishing
description: Learn about the ways to publish a .NET Core application. .NET Core can publish platform-specific or cross-platform apps. You can publish an app as self-contained or as framework-dependent. Each mode affects how a user runs your app.
ms.date: 04/01/2020
---
# .NET Core application publishing overview

Applications you create with .NET Core can be published in two different modes, and the mode affects how a user runs your app.

Publishing your app as *self-contained* produces an application that includes the .NET Core runtime and libraries, and your application and its dependencies. Users of the application can run it on a machine that doesn't have the .NET Core runtime installed.

Publishing your app as *framework-dependent* produces an application that includes only your application itself and its dependencies. Users of the application have to separately install the .NET Core runtime.

Both publishing modes produce a platform-specific executable by default. Framework-dependent applications can be created without an executable, and these applications are cross-platform.

When an executable is produced, you can specify the target platform with a runtime identifier (RID). For more information about RIDs, see [.NET Core RID Catalog](../rid-catalog.md).

The following table outlines the commands used to publish an app as framework-dependent or self-contained, per SDK version:

| Type                                                                                     | SDK 2.1 | SDK 3.x | Command |
| ---------------------------------------------------------------------------------------  | ------- | ------- | ------- |
| [framework-dependent executable](#publish-framework-dependent) for the current platform. |         | ✔️      | [`dotnet publish`](../tools/dotnet-publish.md) |
| [framework-dependent executable](#publish-framework-dependent) for a specific platform.  |         | ✔️      | [`dotnet publish -r <RID> --self-contained false`](../tools/dotnet-publish.md) |
| [framework-dependent cross-platform binary](#publish-framework-dependent).               | ✔️      | ✔️      | [`dotnet publish`](../tools/dotnet-publish.md) |
| [self-contained executable](#publish-self-contained).                                    | ✔️      | ✔️      | [`dotnet publish -r <RID>`](../tools/dotnet-publish.md) |

For more information, see [.NET Core dotnet publish command](../tools/dotnet-publish.md).

## Produce an executable

Executables aren't cross-platform. They're specific to an operating system and CPU architecture. When publishing your app and creating an executable, you can publish the app as [self-contained](#publish-self-contained) or [framework-dependent](#publish-framework-dependent). Publishing an app as self-contained includes the .NET Core runtime with the app, and users of the app don't have to worry about installing .NET Core before running the app. Apps published as framework-dependent don't include the .NET Core runtime and libraries; only the app and 3rd-party dependencies are included.

The following commands produce an executable:

| Type                                                                                     | SDK 2.1 | SDK 3.x | Command |
| ---------------------------------------------------------------------------------------- | ------- | ------- | ------- |
| [framework-dependent executable](#publish-framework-dependent) for the current platform. |         | ✔️      | [`dotnet publish`](../tools/dotnet-publish.md) |
| [framework-dependent executable](#publish-framework-dependent) for a specific platform.  |         | ✔️      | [`dotnet publish -r <RID> --self-contained false`](../tools/dotnet-publish.md) |
| [self-contained executable](#publish-self-contained).                                    | ✔️      | ✔️      | [`dotnet publish -r <RID>`](../tools/dotnet-publish.md) |

## Produce a cross-platform binary

Cross-platform binaries are created when you publish your app as [framework-dependent](#publish-framework-dependent), in the form of a *dll* file. The *dll* file is named after your project. For example, if you have an app named **word_reader**, a file named *word_reader.dll* is created. Apps published in this way are run with the `dotnet <filename.dll>` command and can be run on any platform.

Cross-platform binaries can be run on any operating system as long as the targeted .NET Core runtime is already installed. If the targeted .NET Core runtime isn't installed, the app may run using a newer runtime if the app is configured to roll-forward. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

The following command produces a cross-platform binary:

| Type                                                                                 | SDK 2.1 | SDK 3.x | Command |
| -----------------------------------------------------------------------------------  | ------- | ------- | ------- |
| [framework-dependent cross-platform binary](#publish-framework-dependent).           | ✔️      | ✔️      | [`dotnet publish`](../tools/dotnet-publish.md) |

## Publish framework-dependent

Apps published as framework-dependent are cross-platform and don't include the .NET Core runtime. The user of your app is required to install the .NET Core runtime.

Publishing an app as framework-dependent produces a [cross-platform binary](#produce-a-cross-platform-binary) as a *dll* file, and a [platform-specific executable](#produce-an-executable) that targets your current platform. The *dll* is cross-platform while the executable isn't. For example, if you publish an app named **word_reader** and target Windows, a *word_reader.exe* executable is created along with *word_reader.dll*. When targeting Linux or macOS, a *word_reader* executable is created along with *word_reader.dll*. For more information about RIDs, see [.NET Core RID Catalog](../rid-catalog.md).

> [!IMPORTANT]
> .NET Core SDK 2.1 doesn't produce platform-specific executables when you publish an app framework-dependent.

The cross-platform binary of your app can be run with the `dotnet <filename.dll>` command, and can be run on any platform. If the app uses a NuGet package that has platform-specific implementations, all platforms' dependencies are copied to the publish folder along with the app.

You can create an executable for a specific platform by passing the `-r <RID> --self-contained false` parameters to the [`dotnet publish`](../tools/dotnet-publish.md) command. When the `-r` parameter is omitted, an executable is created for your current platform. Any NuGet packages that have platform-specific dependencies for the targeted platform are copied to the publish folder.

### Advantages

- **Small deployment**\
Only your app and its dependencies are distributed. The .NET Core runtime and libraries are installed by the user and all apps share the runtime.

- **Cross-platform**\
Your app and any .NET-based library runs on other operating systems. You don't need to define a target platform for your app. For information about the .NET file format, see [.NET Assembly File Format](../../standard/assembly/file-format.md).

- **Uses the latest patched runtime**\
The app uses the latest runtime (within the targeted major-minor family of .NET Core) installed on the target system. This means your app automatically uses the latest patched version of the .NET Core runtime. This default behavior can be overridden. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

### Disadvantages

- **Requires pre-installing the runtime**\
Your app can run only if the version of .NET Core your app targets is already installed on the host system. You can configure roll-forward behavior for the app to either require a specific version of .NET Core or allow a newer version of .NET Core. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

- **.NET Core may change**\
It's possible for the .NET Core runtime and libraries to be updated on the machine where the app is run. In rare cases, this may change the behavior of your app if you use the .NET Core libraries, which most apps do. You can configure how your app uses newer versions of .NET Core. For more information, see [framework-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

The following disadvantage only applies to .NET Core 2.1 SDK.

- **Use the `dotnet` command to start the app**\
Users must run the `dotnet <filename.dll>` command to start your app. .NET Core 2.1 SDK doesn't produce platform-specific executables for apps published framework-dependent.

### Examples

Publish an app cross-platform framework-dependent. An executable that targets your current platform is created along with the *dll* file.

```dotnet
dotnet publish
```

Publish an app cross-platform framework-dependent. A Linux 64-bit executable is created along with the *dll* file. This command doesn't work with .NET Core SDK 2.1.

```dotnet
dotnet publish -r linux-x64 --self-contained false
```

## Publish self-contained

Publishing your app as self-contained produces a platform-specific executable. The output publishing folder contains all components of the app, including the .NET Core libraries and target runtime. The app is isolated from other .NET Core apps and doesn't use a locally installed shared runtime. The user of your app isn't required to download and install .NET Core.

The executable binary is produced for the specified target platform. For example, if you have an app named **word_reader**, and you publish a self-contained executable for Windows, a *word_reader.exe* file is created. Publishing for Linux or macOS, a *word_reader* file is created. The target platform and architecture is specified with the `-r <RID>` parameter for the [`dotnet publish`](../tools/dotnet-publish.md) command. For more information about RIDs, see [.NET Core RID Catalog](../rid-catalog.md).

If the app has platform-specific dependencies, such as a NuGet package containing platform-specific dependencies, these are copied to the publish folder along with the app.

### Advantages

- **Control .NET Core version**\
You control which version of .NET Core is deployed with your app.

- **Platform-specific targeting**\
Because you have to publish your app for each platform, you know where your app will run. If .NET Core introduces a new platform, users can't run your app on that platform until you release a version targeting that platform. You can test your app for compatibility problems before your users run your app on the new platform.

### Disadvantages

- **Larger deployments**\
Because your app includes the .NET Core runtime and all of your app dependencies, the download size and hard drive space required is greater than a [framework-dependent](#publish-framework-dependent) version.

  > [!TIP]
  > You can reduce the size of your deployment on Linux systems by approximately 28 MB by using .NET Core [*globalization invariant mode*](https://github.com/dotnet/runtime/blob/master/docs/design/features/globalization-invariant-mode.md). This forces your app to treat all cultures like the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType).

- **Harder to update the .NET Core version**\
.NET Core Runtime (distributed with your app) can only be upgraded by releasing a new version of your app. You're responsible for supplying an updated version of your application for security patches to the .NET Core Runtime.

### Examples

Publish an app self-contained. A macOS 64-bit executable is created.

```dotnet
dotnet publish -r osx-x64
```

Publish an app self-contained. A Windows 64-bit executable is created.

```dotnet
dotnet publish -r win-x64
```

## See also

- [Deploying .NET Core Apps with .NET Core CLI.](deploy-with-cli.md)
- [Deploying .NET Core Apps with Visual Studio.](deploy-with-vs.md)
- [.NET Core Runtime IDentifier (RID) catalog.](../rid-catalog.md)
- [Select the .NET Core version to use.](../versions/selection.md)

---
title: Application publishing
description: Learn about the ways to publish a .NET Core application. You can publish either a self-contained app or a runtime-dependent app.
ms.date: 01/31/2020
---
# .NET Core application publishing overview

Applications you create with .NET Core can be published in two different ways. Each way affects how a user installs and runs your app:

01. A platform-specific executable.

    Depending on the commands used, platform-specific executables can be published [self-contained](#self-contained) or [runtime-dependent](#runtime-dependent).

    Commands that produce an executable:

    | Type                                    | SDK Version   | Command |
    | --------------------------------------- | ------------- | ------- |
    | [runtime-dependent](#runtime-dependent) | 3.1, 3.0      | [`dotnet publish`](../tools/dotnet-publish.md) |
    |                                         | 2.1           | Not supported. |
    | [self-contained](#self-contained)       | 3.1, 3.0, 2.1 | [`dotnet publish -r <RID>`](../tools/dotnet-publish.md) |

    In general, platform-specific apps can be created for platforms other than your current platform. The `-r <RID>` switch sets the target [runtime-identifier](../rid-catalog.md).

01. A cross-platform *dll* file.

    Commands that produce a runtime-dependent *dll* app:

    | Type                                    | SDK Version    | Command |
    | --------------------------------------- | -------------- | ------- |
    | [runtime-dependent](#runtime-dependent) | 3.1, 3.0, 2.1  | [`dotnet publish`](../tools/dotnet-publish.md) |

    Cross-platform *dll* apps are run with the `dotnet file.dll` command.

## Self-contained

Self-contained publishing always produces a platform-specific executable. The output publishing folder contains all components of the app, including the .NET Core libraries and target runtime. The app is isolated from other .NET Core apps and doesn't use a locally installed shared runtime. The user of your app isn't required to download and install .NET Core.

The executable binary produced is either for the specified target platform. For example, if you have an app named **word_reader**, and you publish a self-contained executable for Windows, a *word_reader.exe* file is created. Publishing for Linux or macOS, a *word_reader* file is created. The target platform and architecture is specified with the `-r <RID>` parameter. For more information about RIDs, see [.NET Core RID Catalog](../rid-catalog.md).

If the app has platform-specific dependencies, such as a NuGet package containing platform-specific dependencies, these are copied to the publish folder along with the app.

A self-contained app can be created with the [`dotnet publish`](../tools/dotnet-publish.md) command.

```dotnet
dotnet publish -r <RID>
```

### Advantages

- **Control .NET Core version**\
You control which version of .NET Core is deployed with your app. .NET Core can only be upgraded by releasing a new version of your app.

- **Platform-specific targeting**\
Because you have to publish your app for each platform, you know where your app will run. If .NET Core introduces a new platform, users can't run your app on that platform until you release a version that is published that platform. You can test your app for compatibility problems before your users run your app on the new platform.

### Disadvantages

- **Larger deployments**\
Because your app includes the .NET Core runtime and all of your app dependencies, the hard drive space required is greater than a [runtime-dependent](#runtime-dependent) version.

  > [!TIP]
  > You can reduce the size of your deployment on Linux systems by approximately 28 MB by using .NET Core [*globalization invariant mode*](https://github.com/dotnet/runtime/blob/master/docs/design/features/globalization-invariant-mode.md). This forces your app to treat all cultures like the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType).

- **More space required across all apps**\
Each copy of a self-contained app includes its own copy of the .NET Core files, more disk space is consumed.

## Runtime-dependent

Runtime-dependent apps are cross-platform and don't include the .NET Core runtime, but require the user of your app to install the .NET Core runtime.

A *dll* file is created when you publish your app. For example, if you have an app named **word_reader**, a file named *word_reader.dll* is created. Apps built in this way are run with the `dotnet file.dll` command and can be run on any platform.

Along with the *dll* file containing your app, a platform-specific executable can be published if the `-r <RID>` parameter is used. The *dll* is still created and remains cross-platform while the executable isn't. Continuing the example above, if you publish the **word_reader** app and target Windows, a *word_reader.exe* executable is created along with *word_reader.dll*. When targeting Linux or macOS, a *word_reader* executable is created along with *word_reader.dll*. For more information about RIDs, see [.NET Core RID Catalog](../rid-catalog.md).

Starting with .NET Core 3.0 SDK, an executable is always created for your current platform when you omit the `-r` parameter.

If the app uses a NuGet package that has platform-specific implementations, dependencies for all platforms are copied to the publish folder along with the app.

A runtime-dependent app can be created with the [`dotnet publish`](../tools/dotnet-publish.md) command. With .NET Core 3.0 SDK or higher, both a *dll* and executable file will be created.

```dotnet
dotnet publish
```

A runtime-dependent app can be created for a specific platform, for example, Linux 64-bit.

```dotnet
dotnet publish -r linux-x64 --self-contained false
```

### Advantages

- **Small deployment**\
Only your app and its dependencies are distributed. The .NET Core runtime and libraries are installed by the user and all apps share the runtime.

- **Cross-platform**\
Your app and any .NET-based library is easy run on other operating systems. You don't need to define a target platform for your app. For more information about the .NET file format, see [.NET Assembly File Format](../../standard/assembly/file-format.md).

- **Uses the latest patched runtime**\
Unless overridden, the app will use the latest runtime (within the targeted major-minor family of .NET Core) installed on the target system. This allows your app to use the latest patched version of the .NET Core runtime.

### Disadvantages

- **Requires pre-installing the runtime**\
Your app can run only if the version of .NET Core your app targets is already installed on the host system. You can configure roll-forward behavior for the app to either require a specific version of .NET Core or allow a newer version of .NET Core. For more information, see [runtime-dependent apps roll forward](../versions/selection.md#framework-dependent-apps-roll-forward).

- **.NET Core may change**\
It's possible for the .NET Core runtime and libraries to be updated on the machine where the app is run. In rare cases, this may change the behavior of your app if you use the .NET Core libraries, which most apps do.

- **Per-platform executables**\
*.NET Core 3.0 and later versions*\
If you want your users to start your app directly and avoid the `dotnet file.dll` command, you must publish your app for every platform.

## See also

- [Deploying .NET Core Apps with .NET Core CLI.](deploy-with-cli.md)
- [Deploying .NET Core Apps with Visual Studio.](deploy-with-vs.md)
- [Packages, Metapackages, and Frameworks.](../packages.md)
- [.NET Core Runtime IDentifier (RID) catalog.](../rid-catalog.md)
- [Select the .NET Core version to use.](../versions/selection.md)

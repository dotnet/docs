---
title: Publish apps with the .NET CLI
description: Learn to publish a .NET application using the .NET CLI commands.
author: adegeo
ms.author: adegeo
ms.date: 08/07/2025
ms.custom: updateeachrelease
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
---

# Publish .NET apps with the .NET CLI

This article demonstrates how you can publish your .NET application from the command line. .NET provides several ways to publish your applications. Framework-dependent deployment produces a cross-platform .dll file that uses the locally installed .NET runtime. Framework-dependent executable produces a platform-specific executable that uses the locally installed .NET runtime. Self-contained executable produces a platform-specific executable and includes a local copy of the .NET runtime.

For an overview of these publishing modes, see [.NET Application Deployment](index.md).

Looking for some quick help on using the CLI? The following table shows some examples of how to publish your app. You can specify the target framework with the `-f <TFM>` parameter or by editing the project file. For more information, see [Publishing basics](#publishing-basics).

| Publish Mode                                                      | Command                                                        |
|-------------------------------------------------------------------|----------------------------------------------------------------|
| [Framework-dependent deployment](#framework-dependent-deployment) | `dotnet publish -c Release [-r <RID>] -p:UseAppHost=false`                |
| [Framework-dependent executable](#framework-dependent-executable) | `dotnet publish -c Release [-r <RID>]`<br>`dotnet publish -c Release [-r <RID>] --self-contained false`<br> |
| [Self-contained deployment](#self-contained-deployment)           | `dotnet publish -c Release [-r <RID>] --self-contained true`     |
| [Single-file deployment](#single-file-deployment)                 | `dotnet publish -c Release [-r <RID>] -p:PublishSingleFile=true` |
| [Native AOT deployment](#native-aot-deployment)                   | `dotnet publish -c Release [-r <RID>] -p:PublishAot=true`        |
| [ReadyToRun deployment](#readytorun-deployment)                   | `dotnet publish -c Release [-r <RID>] -p:PublishReadyToRun=true` |

> [!NOTE]
> The `-c Release` parameter isn't required and is only provided as a reminder to publish the **Release** build of your app.

## Publishing basics

The [`<TargetFramework>`](../project-sdk/msbuild-props.md#targetframework) setting of the project file specifies the default target framework when you publish your app. You can change the target framework to any valid [Target Framework Moniker (TFM)](../../standard/frameworks.md). For example, if your project uses `<TargetFramework>net9.0</TargetFramework>`, a binary that targets .NET 9 is created. The TFM specified in this setting is the default target used by the [`dotnet publish`](../tools/dotnet-publish.md) command.

If you want to target more than one framework, you can set the [`<TargetFrameworks>`](../project-sdk/msbuild-props.md#targetframeworks) setting to multiple TFM values, separated by a semicolon. When you build your app, a build is produced for each target framework. However, when you publish your app, you must specify the target framework with the `dotnet publish -f <TFM>` command.

The default **BUILD-CONFIGURATION** mode is **Release** unless changed with the `-c` parameter.

The default output directory of the [`dotnet publish`](../tools/dotnet-publish.md) command is `./bin/<BUILD-CONFIGURATION>/<TFM>/publish/`. For example, `dotnet publish -c Release -f net9.0` publishes to `./bin/Release/net9.0/publish/`. However, you can opt in to a simplified output path and folder structure for all build outputs. For more information, see [Artifacts output layout](../sdk/artifacts-output.md).

### Native dependencies

If your app has native dependencies, it might not run on a different operating system. For example, apps that depend on the Windows API don't natively run on macOS or Linux. You would need to provide platform-specific code and compile an executable for each platform.

Consider also, if a library you referenced has a native dependency, your app might not run on every platform. However, it's possible a NuGet package you're referencing includes platform-specific versions to handle the required native dependencies for you.

To insure that your app is published with its native dependencies, use the `dotnet publish -r <RID>` switch to publish your app for a specific platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

More information about platform-specific binaries is covered in the [Framework-dependent executable](#framework-dependent-executable) and [Self-contained deployment](#self-contained-deployment) sections.

## Sample app

You can use the following app to explore the publishing commands. The app is created by running the following commands in your terminal:

```dotnetcli
dotnet new console -o apptest1
cd apptest1
dotnet add package Figgle.Fonts
```

Change the `Program.cs` or `Program.vb` code to the following snippet:

:::code language="csharp" source="./snippets/shared/publish/csharp/Program.cs":::

:::code language="vb" source="./snippets/shared/publish/vb/Program.vb":::

When you run the app ([`dotnet run`](../tools/dotnet-run.md)), the following output is displayed:

```terminal
  _   _      _ _         __        __         _     _ _
 | | | | ___| | | ___    \ \      / /__  _ __| | __| | |
 | |_| |/ _ \ | |/ _ \    \ \ /\ / / _ \| '__| |/ _` | |
 |  _  |  __/ | | (_) |    \ V  V / (_) | |  | | (_| |_|
 |_| |_|\___|_|_|\___( )    \_/\_/ \___/|_|  |_|\__,_(_)
                     |/
```

## Framework-dependent deployment

When you publish your app as a framework-dependent deployment (FDD), a `<PROJECT-NAME>.dll` file is created in the `./bin/<BUILD-CONFIGURATION>/<TFM>/publish/` folder. To run your app, navigate to the output folder and use the `dotnet <PROJECT-NAME>.dll` command.

Your app is configured to target a specific version of .NET. That targeted .NET runtime is required to be on any machine where your app runs. For example, if your app targets .NET 9, any machine that your app runs on must have the .NET 9 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDD creates an app that automatically rolls-forward to the latest .NET security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

| Publish Mode                   | Command                                                     |
|--------------------------------|-------------------------------------------------------------|
| Framework-dependent deployment | `dotnet publish -c Release -p:UseAppHost=false`             |

## Framework-dependent executable

Framework-dependent executable (FDE) is the default mode for the basic `dotnet publish` command. You don't need to specify any other parameters, as long as you want to target the current operating system.

In this mode, a platform-specific executable host is created to host your cross-platform app. This mode is similar to FDD, as FDD requires a host in the form of the `dotnet` command. The host executable filename varies per platform and is named something similar to `<PROJECT-FILE>.exe`. You can run this executable directly instead of calling `dotnet <PROJECT-FILE>.dll`, which is still an acceptable way to run the app.

Your app is configured to target a specific version of .NET. That targeted .NET runtime is required to be on any machine where your app runs. For example, if your app targets .NET 9, any machine that your app runs on must have the .NET 9 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDE creates an app that automatically rolls-forward to the latest .NET security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

| Publish Mode                   | Command                                                     |
|--------------------------------|-------------------------------------------------------------|
| Framework-dependent executable | `dotnet publish -c Release -r <RID> --self-contained false`<br>`dotnet publish -c Release` |

Whenever you use the `-r` switch, the output folder path changes to: `./bin/<BUILD-CONFIGURATION>/<TFM>/<RID>/publish/`

If you use the [example app](#sample-app), run `dotnet publish -f net9.0 -r win-x64 --self-contained false`. This command creates the following executable: `./bin/Debug/net9.0/win-x64/publish/apptest1.exe`

> [!NOTE]
> You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that aren't globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

### Configure .NET install search behavior

In .NET 9 and later versions, you can configure the .NET installation search paths of the published executable via the [`AppHostDotNetSearch`](../project-sdk//msbuild-props.md#apphostdotnetsearch) and [`AppHostRelativeDotNet`](../project-sdk//msbuild-props.md#apphostrelativedotnet) properties.

`AppHostDotNetSearch` allows specifying one or more locations where the executable looks for a .NET installation:

- `AppLocal`: app executable's folder
- `AppRelative`: path relative to the app executable
- `EnvironmentVariables`: value of [`DOTNET_ROOT[_<arch>]`](../tools/dotnet-environment-variables.md#dotnet_root-dotnet_rootx86-dotnet_root_x86-dotnet_root_x64) environment variables
- `Global`: [registered](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md#global-install-to-custom-location) and [default](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md#global-install-to-default-location) global install locations

`AppHostRelativeDotNet` specifies the path relative to the executable that's searched when `AppHostDotNetSearch` contains `AppRelative`.

For more information, see [`AppHostDotNetSearch`](../project-sdk//msbuild-props.md#apphostdotnetsearch), [`AppHostRelativeDotNet`](../project-sdk//msbuild-props.md#apphostrelativedotnet) and [install location options in apphost](https://github.com/dotnet/designs/blob/main/proposed/apphost-embed-install-location.md).

## Self-contained deployment

When you publish a self-contained deployment (SCD), the .NET SDK creates a platform-specific executable. Publishing an SCD includes all required .NET files to run your app but it doesn't include the native dependencies of .NET (for example, for [.NET 8 on Linux](https://github.com/dotnet/core/blob/main/release-notes/8.0/linux-packages.md)). These dependencies must be present on the system before the app runs.

Publishing an SCD creates an app that doesn't roll forward to the latest available .NET security patch. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#self-contained-deployments-include-the-selected-runtime).

You must use the following switches with the `dotnet publish` command to publish an SCD:

- `-r <RID>`

  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md). If this switch is omitted, the current platform is used.

- `--self-contained true`

  This switch tells the .NET SDK to create an executable as an SCD.

| Publish Mode                   | Command                                                     |
|--------------------------------|-------------------------------------------------------------|
| Self-contained deployment      | `dotnet publish -c Release -r <RID> --self-contained true`  |

> [!TIP]
>
> - You can reduce the total size of compatible self-contained apps by [publishing trimmed](trimming/trim-self-contained.md). This enables the trimmer to remove parts of the framework and referenced assemblies that aren't on any code path or potentially referenced in [runtime reflection](../../csharp/advanced-topics/reflection-and-attributes/index.md). See [trimming incompatibilities](./trimming/incompatibilities.md) to determine if trimming makes sense for your application.
> - You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that aren't globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Core Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

## Single-file deployment

When you publish your app as a single-file deployment, all application-dependent files are bundled into a single binary. This deployment model is available for both framework-dependent and self-contained applications, providing an attractive option to deploy and distribute your application as a single file.

Single-file apps are always OS and architecture specific. You need to publish for each configuration, such as Linux x64, Linux Arm64, Windows x64, and so forth. Runtime configuration files, such as _\*.runtimeconfig.json_ and _\*.deps.json_, are included in the single file.

The size of a single file in a self-contained application is large since it includes the runtime and framework libraries. You can combine single-file deployment with other publish options like [trimming](trimming/trim-self-contained.md) and [ReadyToRun](#readytorun-deployment) to optimize the deployment.

You must use the following switches with the `dotnet publish` command to publish a single-file app:

- `-r <RID>`

  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md). If this switch is omitted, the current platform is used.

- `-p:PublishSingleFile=true`

  This switch tells the .NET SDK to bundle the app into a single file.

| Publish Mode          | Command                                                     |
|-----------------------|-------------------------------------------------------------|
| Single-file deployment | `dotnet publish -c Release -r <RID> -p:PublishSingleFile=true` |

If you use the [example app](#sample-app), run `dotnet publish -f net9.0 -r win-x64 -p:PublishSingleFile=true`. This command creates a single executable file in the `./bin/Debug/net9.0/win-x64/publish/` folder.

For more information about single-file deployment, see [Single-file deployment](single-file/overview.md).

## Native AOT deployment

When you publish your app as Native AOT, your application is ahead-of-time (AOT) compiled to native code. Native AOT apps are [self-contained](index.md#publish-self-contained) and have faster startup time and smaller memory footprints. These apps can run on machines that don't have the .NET runtime installed.

Native AOT apps don't use a just-in-time (JIT) compiler when the application runs. The ahead-of-time compiler compiles IL to native code at publish time. Native AOT applications target a specific runtime environment, such as Linux x64 or Windows x64.

The benefit of Native AOT is most significant for workloads with a high number of deployed instances, such as cloud infrastructure and hyper-scale services.

You must use the following switches with the `dotnet publish` command to publish a Native AOT app:

- `-r <RID>`

  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md). If this switch is omitted, the current platform is used.

- `-p:PublishAot=true`

  This switch tells the .NET SDK to compile the app with Native AOT.

| Publish Mode          | Command                                                     |
|-----------------------|-------------------------------------------------------------|
| Native AOT deployment | `dotnet publish -c Release -r <RID> -p:PublishAot=true`    |

> [!NOTE]
> Native AOT has specific requirements and limitations. Not all .NET features are supported in Native AOT. For detailed information about prerequisites, limitations, and compatibility, see [Native AOT deployment](native-aot/index.md).

If you use the [example app](#sample-app), run `dotnet publish -f net9.0 -r win-x64 -p:PublishAot=true`. This command creates a native executable in the `./bin/Debug/net9.0/win-x64/publish/` folder.

For more information about Native AOT deployment, see [Native AOT deployment overview](native-aot/index.md).

## ReadyToRun deployment

When you publish your app with ReadyToRun compilation, your application assemblies are compiled as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation that improves startup performance by reducing the amount of work the just-in-time (JIT) compiler needs to do as your application loads.

ReadyToRun binaries contain both intermediate language (IL) code and the native version of the same code. While R2R binaries are larger than regular assemblies, they provide better startup performance. ReadyToRun is only available when you publish an app that targets specific runtime environments (RID) such as Linux x64 or Windows x64.

The startup improvement applies not only to application startup, but also to the first use of any code in the application. For instance, ReadyToRun can reduce the response latency of the first use of Web API in an ASP.NET application.

You must use the following switches with the `dotnet publish` command to publish a ReadyToRun app:

- `-r <RID>`

  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md). If this switch is omitted, the current platform is used.

- `-p:PublishReadyToRun=true`

  This switch tells the .NET SDK to compile assemblies with ReadyToRun.

| Publish Mode          | Command                                                     |
|-----------------------|-------------------------------------------------------------|
| ReadyToRun deployment | `dotnet publish -c Release -r <RID> -p:PublishReadyToRun=true` |

> [!NOTE]
> ReadyToRun compilation increases the size of your assemblies. The size of an assembly typically grows to between two to three times larger. This increase in physical size might reduce performance of loading the assembly from disk and increase working set of the process.

If you use the [example app](#sample-app), run `dotnet publish -f net9.0 -r win-x64 -p:PublishReadyToRun=true`. This command creates ReadyToRun compiled assemblies in the `./bin/Debug/net9.0/win-x64/publish/` folder.

ReadyToRun can be combined with other publish options like [single-file deployment](#single-file-deployment) and [trimming](trimming/trim-self-contained.md) for more optimizations.

For more information about ReadyToRun deployment, see [ReadyToRun compilation](ready-to-run.md).

## See also

- [.NET Application Deployment Overview](index.md)y
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)

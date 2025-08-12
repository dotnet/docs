---
title: .NET application publishing overview
description: Learn about the ways to publish a .NET application. .NET can publish platform-specific or cross-platform apps. You can publish an app as self-contained or as framework-dependent. Each mode affects how a user runs your app.
author: adegeo
ms.author: adegeo
ms.date: 08/11/2025
ms.custom: updateeachrelease
ai-usage: ai-assisted
zone_pivot_groups: development-environment-one
---

# .NET application publishing overview

This article explains the different ways to publish a .NET application. It covers publishing modes, how to produce executables and cross-platform binaries, and the impact of each approach on deployment and runtime environments. You can publish .NET applications using either the .NET CLI or Visual Studio.

## What is publishing

Publishing a .NET app means compiling source code to create an executable or binary, along with its dependencies and related files, for distribution. After publishing, deploy the app to a server, distribution platform, container, or cloud environment. The publishing process prepares an app for deployment and use outside of a development environment.

## Publishing modes

There are two primary ways to publish an app. The choice depends on both the deployment environment and the compilation options you want to use. Some factors that influence this decision include whether the deployment environment has the appropriate .NET Runtime installed and whether you need specific compilation features that require bundling the runtime with your app. The two publishing modes are:

- **Publish self-contained**\
This mode produces a publishing folder that includes a platform-specific executable used to start the app, a compiled binary containing app code, any app dependencies, and the .NET runtime required to run the app. The environment that runs the app doesn't need to have the .NET runtime preinstalled.

- **Publish framework-dependent**\
This mode produces a publishing folder that includes a platform-specific executable used to start the app, a compiled binary containing app code, and any app dependencies. The environment that runs the app must have a version of the .NET runtime installed that the app can use. An optional platform-specific executable can be produced.

> [!IMPORTANT]
> You specify the target platform with a runtime identifier (RID). For more information about RIDs, see [.NET RID Catalog](../rid-catalog.md).

## Publishing basics

The [`<TargetFramework>`](../project-sdk/msbuild-props.md#targetframework) setting of the project file specifies the default target framework when you publish your app. You can change the target framework to any valid [Target Framework Moniker (TFM)](../../standard/frameworks.md). For example, if your project uses `<TargetFramework>net9.0</TargetFramework>`, a binary that targets .NET 9 is created.

If you want to target more than one framework, you can set the [`<TargetFrameworks>`](../project-sdk/msbuild-props.md#targetframeworks) setting to multiple TFM values, separated by a semicolon. When you build your app, a build is produced for each target framework. However, when you publish your app, you must specify the target framework:

::: zone pivot="cli,vscode"

The default build configuration mode is **Release**, unless changed with the `-c` parameter.

```dotnet
dotnet publish -c Release -f net9.0
```

The default output directory of the [`dotnet publish`](../tools/dotnet-publish.md) command is `./bin/<BUILD-CONFIGURATION>/<TFM>/publish/`. For example, `dotnet publish -c Release -f net9.0` publishes to `./bin/Release/net9.0/publish/`. However, you can opt in to a simplified output path and folder structure for all build outputs. For more information, see [Artifacts output layout](../sdk/artifacts-output.md).

::: zone-end

::: zone pivot="visualstudio"

In Visual Studio, create separate publishing profiles for each target framework.

::: zone-end

### Portable binaries

When you publish a .NET app, you can target a specific platform or create a portable binary. By default, even when creating a portable binary, .NET publishes a platform-specific executable alongside the portable DLL unless you explicitly disable this behavior.

The platform-specific executable is created because of the `UseAppHost` property, which defaults to `true`. To publish only the portable DLL without the platform-specific executable, set `UseAppHost` to `false` either on the command line (`-p:UseAppHost=false`) or as a project property.

The benefit of targeting a specific platform is that it can handle [native dependencies](#native-dependencies) that your app might require, ensuring compatibility with the target platform's specific requirements.

### Native dependencies

If your app has native dependencies, it might not run on a different operating system. For example, apps that depend on the Windows API don't natively run on macOS or Linux. You would need to provide platform-specific code and compile an executable for each platform.

Consider also, if a library you referenced has a native dependency, your app might not run on every platform. However, it's possible a NuGet package you're referencing includes platform-specific versions to handle the required native dependencies for you.

To ensure that your app is published with its native dependencies:

::: zone pivot="cli,vscode"

```dotnetcli
dotnet publish -c Release -r <RID>
```

- [!INCLUDE [cli-c-release](includes/cli-c-release.md)]

- [!INCLUDE [cli-r-rid-native-deps](includes/cli-r-rid-native-deps.md)]

::: zone-end

::: zone pivot="visualstudio"

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Click **Save** and then **Publish**.

::: zone-end

For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

::: zone pivot="cli,vscode"

## Quick reference

The following table provides quick examples of how to publish your app.

| Publish Mode | Command |
|--|--|
| [Framework-dependent deployment](#framework-dependent-deployment) | `dotnet publish -c Release [-r <RID>]` |
| [Framework-dependent deployment (DLL)](#framework-dependent-deployment) | `dotnet publish -c Release -p:UseAppHost=false` |
| [Self-contained deployment](#self-contained-deployment) | `dotnet publish -c Release [-r <RID>] --self-contained true` |
| [Single-file deployment](#single-file-deployment) | `dotnet publish -c Release [-r <RID>] -p:PublishSingleFile=true` |
| [Native AOT deployment](#native-aot-deployment) | `dotnet publish -c Release [-r <RID>] -p:PublishAot=true` |
| [ReadyToRun deployment](#readytorun-deployment) | `dotnet publish -c Release [-r <RID>] -p:PublishReadyToRun=true` |

::: zone-end

## Framework-dependent deployment

Framework-dependent deployment is the default mode when you publish from either the CLI or Visual Studio. In this mode, a platform-specific executable host is created to host your cross-platform app. The host executable filename varies per platform and is named something similar to `<PROJECT-FILE>.exe`. You can run this executable directly instead of calling `dotnet <PROJECT-FILE>.dll`, which is still an acceptable way to run the app.

Your app is configured to target a specific version of .NET. That targeted .NET runtime is required to be on the environment where your app runs. For example, if your app targets .NET 9, any environment that your app runs on must have the .NET 9 runtime installed.

Publishing a framework-dependent deployment creates an app that automatically rolls-forward to the latest .NET security patch available on the environment that runs the app. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

### Advantages

- **Small deployment**: Only the app and its dependencies are distributed. The environment where the app is run must already have the .NET runtime installed.
- **Cross-platform**: The app and any .NET-based library runs on other operating systems.
- **Uses the latest patched runtime**: The app uses the latest runtime installed in the environment.

### Disadvantages

- **Requires pre-installing the runtime**: The app can run only if the version of .NET it targets is already installed in the environment.
- **.NET might change**: The environment where the app is run might use a newer .NET runtime, which could change app behavior.

### Publish

::: zone pivot="cli,vscode"

```dotnetcli
dotnet publish -c Release [-r <RID>]
```

- [!INCLUDE [cli-c-release](includes/cli-c-release.md)]

- [!INCLUDE [cli-r-rid](includes/cli-r-rid.md)]

Or explicitly:

```dotnetcli
dotnet publish -c Release [-r <RID>] --self-contained false
```

- `--self-contained false`

This switch explicitly tells the .NET SDK to create a framework-dependent deployment.

::: zone-end

::: zone pivot="visualstudio"

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Framework-dependent** (this is the default).
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Click **Save** and then **Publish**.

::: zone-end

### Cross-platform DLL deployment

Alternatively, you can publish your app as a cross-platform DLL without a platform-specific executable. In this mode, a `<PROJECT-NAME>.dll` file is created in the publish output folder. To run your app, navigate to the output folder and use the `dotnet <PROJECT-NAME>.dll` command.

To publish as a cross-platform DLL:

::: zone pivot="cli,vscode"

```dotnetcli
dotnet publish -c Release -p:UseAppHost=false
```

- [!INCLUDE [cli-c-release](includes/cli-c-release.md)]

- `-p:UseAppHost=false`

This property disables the creation of a platform-specific executable, producing only the portable DLL.

::: zone-end

::: zone pivot="visualstudio"

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Framework-dependent**.
01. Uncheck **Produce single file**.
01. Set **Target Runtime** to **Portable** (or leave blank).
01. Click **Save** and then **Publish**.

::: zone-end

## Self-contained deployment

When you publish a self-contained deployment (SCD), the publishing process creates a platform-specific executable. Publishing an SCD includes all required .NET files to run your app but it doesn't include the native dependencies of .NET. These dependencies must be present on the environment before the app runs.

Publishing an SCD creates an app that doesn't roll forward to the latest available .NET security patch. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#self-contained-deployments-include-the-selected-runtime).

### Advantages

- **Control .NET version**: Control which version of .NET is deployed with the app.
- **Platform-specific targeting**: Because the app must be published for each platform, it's clear where the app runs.

### Disadvantages

- **Larger deployments**: Because the app includes the .NET runtime and all dependencies, the download size and hard drive space required is greater than a **framework-dependent deployment**.
- **Harder to update the .NET version**: The .NET Runtime can only be upgraded by releasing a new version of the app.

> [!TIP]
> You can reduce the total size of compatible self-contained apps by [publishing trimmed](trimming/trim-self-contained.md) or by enabling **globalization invariant mode**. For more information about globalization invariant mode, see [.NET Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

### Publish

::: zone pivot="cli,vscode"

```dotnetcli
dotnet publish -c Release -r <RID> --self-contained true
```

- [!INCLUDE [cli-c-release](includes/cli-c-release.md)]

- [!INCLUDE [cli-r-rid](includes/cli-r-rid.md)]

- `--self-contained true`

This switch tells the .NET SDK to create an executable as a self-contained deployment (SCD).

::: zone-end

::: zone pivot="visualstudio"

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Self-contained**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Click **Save** and then **Publish**.

::: zone-end

## Single-file deployment

When you publish your app as a single-file deployment, all application-dependent files are bundled into a single binary. This deployment model is available for both framework-dependent and self-contained applications, providing an attractive option to deploy and distribute your application as a single file.

Single-file apps are always OS and architecture specific. You need to publish for each configuration, such as Linux x64, Linux Arm64, Windows x64, and so forth.

### Advantages

- **Simplified distribution**: Deploy and distribute your application as a single executable file.
- **Reduced file clutter**: All dependencies are bundled, eliminating the need to manage multiple files.
- **Easy deployment**: Copy a single file to deploy the application.

### Disadvantages

- **Larger file size**: The single file includes all dependencies, making it larger than individual files.
- **Slower startup**: Files must be extracted at runtime, which can impact startup performance.
- **Platform-specific**: Must publish separate files for each target platform.

Single-file deployment can be combined with other optimizations like [trimming](trimming/trim-self-contained.md) and [ReadyToRun compilation](#readytorun-deployment) for further optimization.

For more information about single-file deployment, see [Single-file deployment](single-file/overview.md).

### Publish

::: zone pivot="cli,vscode"

```dotnetcli
dotnet publish -c Release -r <RID> -p:PublishSingleFile=true
```

- [!INCLUDE [cli-c-release](includes/cli-c-release.md)]

- [!INCLUDE [cli-r-rid](includes/cli-r-rid.md)]

- `-p:PublishSingleFile=true`

This property bundles all application-dependent files into a single binary.

::: zone-end

::: zone pivot="visualstudio"

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Self-contained** or **Framework-dependent**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Check **Produce single file**.
01. Click **Save** and then **Publish**.

::: zone-end

## Native AOT deployment

Native AOT deployment compiles your app directly to native code, eliminating the need for a runtime. This publishing option uses **self-contained deployment** mode, as the compiled native code must include everything needed to run the application. This results in faster startup times and reduced memory usage, but comes with some limitations on supported features.

### Advantages

- **Fast startup**: No JIT compilation needed at runtime, leading to faster application startup.
- **Reduced memory usage**: Lower memory footprint compared to traditional .NET applications.
- **No runtime dependency**: The application runs without requiring .NET runtime installation.
- **Smaller deployment size**: Often smaller than **self-contained deployment** with the full runtime.

### Disadvantages

- **Limited framework support**: Not all .NET features and libraries are compatible with Native AOT.
- **Longer build times**: Compilation to native code takes significantly longer than regular builds.
- **Platform-specific**: Must compile separately for each target platform and architecture.
- **Debugging limitations**: More complex debugging experience compared to regular .NET applications.

For more information about Native AOT deployment, see [Native AOT deployment](native-aot/index.md).

### Publish

::: zone pivot="cli,vscode"

```dotnetcli
dotnet publish -c Release -r <RID> -p:PublishAot=true
```

- [!INCLUDE [cli-c-release](includes/cli-c-release.md)]

- [!INCLUDE [cli-r-rid](includes/cli-r-rid.md)]

- `-p:PublishAot=true`

This property enables Native AOT compilation, which compiles the app directly to native code.

::: zone-end

::: zone pivot="visualstudio"

Native AOT publishing must be configured in the project file. You cannot enable it through the Visual Studio publishing UI.

01. In **Solution Explorer**, right-click on your project and select **Edit Project File**.
01. Add the following property to a `<PropertyGroup>`:

    ```xml
    <PublishAot>true</PublishAot>
    ```

01. Save the project file.
01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Self-contained**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Click **Save** and then **Publish**.

For more information about the `PublishAot` property, see [MSBuild properties for Microsoft.NET.Sdk](../project-sdk/msbuild-props.md#publishaot).

::: zone-end

## ReadyToRun deployment

When you publish your app with ReadyToRun compilation, your application assemblies are compiled as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation that improves startup performance by reducing the amount of work the just-in-time (JIT) compiler needs to do as your application loads. This publishing option can be used with both **framework-dependent** and **self-contained** deployment modes.

ReadyToRun binaries contain both intermediate language (IL) code and the native version of the same code. While R2R binaries are larger than regular assemblies, they provide better startup performance.

### Advantages

- **Improved startup time**: The app spends less time running the JIT compiler during startup.
- **Better first-use performance**: Reduced latency for first-time execution of code paths.
- **Compatible with existing code**: Works with most .NET libraries and frameworks without modification.
- **Flexible deployment**: Can be combined with both **framework-dependent deployment** and **self-contained deployment** modes.

### Disadvantages

- **Larger size**: The app is larger on disk due to including both IL and native code.
- **Longer build times**: Compilation takes more time than standard publishing.
- **Platform-specific optimizations**: Best performance gains require targeting specific platforms.

### Publish

::: zone pivot="cli,vscode"

```dotnetcli
dotnet publish -c Release -r <RID> -p:PublishReadyToRun=true
```

- [!INCLUDE [cli-c-release](includes/cli-c-release.md)]

- [!INCLUDE [cli-r-rid](includes/cli-r-rid.md)]

- `-p:PublishReadyToRun=true`

This property enables ReadyToRun compilation, which improves startup performance by pre-compiling assemblies.

::: zone-end

::: zone pivot="visualstudio"

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Self-contained** or **Framework-dependent**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Check **Enable ReadyToRun compilation**.
01. Click **Save** and then **Publish**.

::: zone-end

For more information about ReadyToRun deployment, see [ReadyToRun compilation](ready-to-run.md).

## See also

- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)
- [Select the .NET version to use](../versions/selection.md)

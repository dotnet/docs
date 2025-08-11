---
title: Publish apps with Visual Studio
description: Learn to publish a .NET application using Visual Studio.
author: adegeo
ms.author: adegeo
ms.date: 08/08/2025
ms.custom: vs-dotnet, updateeachrelease
ai-usage: ai-generated
dev_langs:
  - "csharp"
  - "vb"
---

# Publish .NET apps with Visual Studio

This article demonstrates how you can publish your .NET application using Visual Studio. .NET provides several ways to publish your applications. Framework-dependent deployment produces a cross-platform .dll file that uses the locally installed .NET runtime. Framework-dependent executable produces a platform-specific executable that uses the locally installed .NET runtime. Self-contained executable produces a platform-specific executable and includes a local copy of the .NET runtime.

For an overview of these publishing modes, see [.NET Application Deployment](index.md).

Looking for some quick help on using Visual Studio? The following table shows some examples of how to publish your app using Visual Studio publishing profiles:

| Publish Mode                                                      | Visual Studio Configuration                                    |
|-------------------------------------------------------------------|----------------------------------------------------------------|
| [Framework-dependent deployment](#framework-dependent-deployment) | Set **Deployment Mode** to **Framework-dependent** and **Produce single file** to unchecked |
| [Framework-dependent executable](#framework-dependent-executable) | Set **Deployment Mode** to **Framework-dependent** (default)  |
| [Self-contained deployment](#self-contained-deployment)           | Set **Deployment Mode** to **Self-contained**                 |
| [Single-file deployment](#single-file-deployment)                 | Set **Deployment Mode** to **Self-contained** or **Framework-dependent** and **Produce single file** to checked |
| [ReadyToRun deployment](#readytorun-deployment)                   | Set **Deployment Mode** to **Self-contained** or **Framework-dependent** and **Enable ReadyToRun compilation** to checked |

## Publishing basics

The [`<TargetFramework>`](../project-sdk/msbuild-props.md#targetframework) setting of the project file specifies the default target framework when you publish your app. You can change the target framework to any valid [Target Framework Moniker (TFM)](../../standard/frameworks.md). For example, if your project uses `<TargetFramework>net9.0</TargetFramework>`, a binary that targets .NET 9 is created. The TFM specified in this setting is the default target used when you publish from Visual Studio.

If you want to target more than one framework, you can set the [`<TargetFrameworks>`](../project-sdk/msbuild-props.md#targetframeworks) setting to multiple TFM values, separated by a semicolon. When you build your app, a build is produced for each target framework. However, when you publish your app from Visual Studio, you must create separate publishing profiles for each target framework.

The default **BUILD-CONFIGURATION** mode is **Release** when publishing from Visual Studio.

### Native dependencies

If your app has native dependencies, it might not run on a different operating system. For example, apps that depend on the Windows API don't natively run on macOS or Linux. You would need to provide platform-specific code and compile an executable for each platform.

Consider also, if a library you referenced has a native dependency, your app might not run on every platform. However, it's possible a NuGet package you're referencing includes platform-specific versions to handle the required native dependencies for you.

To ensure that your app is published with its native dependencies, use the **Target Runtime** setting in Visual Studio to publish your app for a specific platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

More information about platform-specific binaries is covered in the [Framework-dependent executable](#framework-dependent-executable) and [Self-contained deployment](#self-contained-deployment) sections.

## Sample app

You can use the following app to explore the publishing options in Visual Studio. The app is created by doing the following in Visual Studio:

01. Select **File** > **New** > **Project**.
01. In the **Create a new project** dialog, search for "console" and select **Console App**.
01. Select **Next**.
01. Enter a project name, such as "AppTest1", and select **Next**.
01. Choose the latest framework version and select **Create**.
01. In **Solution Explorer**, right-click on the project and select **Manage NuGet Packages...**.
01. Select the **Browse** tab.
01. Search for "Figgle.Fonts" and install the package.

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

When you publish your app as a framework-dependent deployment (FDD), a `<PROJECT-NAME>.dll` file is created in the publish output folder. To run your app, navigate to the output folder and use the `dotnet <PROJECT-NAME>.dll` command.

Your app is configured to target a specific version of .NET. That targeted .NET runtime is required to be on any machine where your app runs. For example, if your app targets .NET 9, any machine that your app runs on must have the .NET 9 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDD creates an app that automatically rolls-forward to the latest .NET security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

To publish a framework-dependent deployment from Visual Studio:

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Framework-dependent**.
01. Uncheck **Produce single file**.
01. Set **Target Runtime** to **Portable** (or leave blank).
01. Click **Save** and then **Publish**.

## Framework-dependent executable

Framework-dependent executable (FDE) is the default mode when you publish from Visual Studio. You don't need to specify any other parameters, as long as you want to target the current operating system.

In this mode, a platform-specific executable host is created to host your cross-platform app. This mode is similar to FDD, as FDD requires a host in the form of the `dotnet` command. The host executable filename varies per platform and is named something similar to `<PROJECT-FILE>.exe`. You can run this executable directly instead of calling `dotnet <PROJECT-FILE>.dll`, which is still an acceptable way to run the app.

Your app is configured to target a specific version of .NET. That targeted .NET runtime is required to be on any machine where your app runs. For example, if your app targets .NET 9, any machine that your app runs on must have the .NET 9 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDE creates an app that automatically rolls-forward to the latest .NET security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

To publish a framework-dependent executable from Visual Studio:

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Framework-dependent** (this is the default).
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Click **Save** and then **Publish**.

> [!NOTE]
> You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that aren't globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

## Self-contained deployment

When you publish a self-contained deployment (SCD), Visual Studio creates a platform-specific executable. Publishing an SCD includes all required .NET files to run your app but it doesn't include the native dependencies of .NET. These dependencies must be present on the system before the app runs.

Publishing an SCD creates an app that doesn't roll forward to the latest available .NET security patch. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#self-contained-deployments-include-the-selected-runtime).

To publish a self-contained deployment from Visual Studio:

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Self-contained**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Click **Save** and then **Publish**.

> [!TIP]
>
> - You can reduce the total size of compatible self-contained apps by [publishing trimmed](trimming/trim-self-contained.md). This enables the trimmer to remove parts of the framework and referenced assemblies that aren't on any code path or potentially referenced in [runtime reflection](../../csharp/advanced-topics/reflection-and-attributes/index.md). See [trimming incompatibilities](trimming/incompatibilities.md) to determine if trimming makes sense for your application.
> - You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that aren't globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

## Single-file deployment

When you publish your app as a single-file deployment, all application-dependent files are bundled into a single binary. This deployment model is available for both framework-dependent and self-contained applications, providing an attractive option to deploy and distribute your application as a single file.

Single-file apps are always OS and architecture specific. You need to publish for each configuration, such as Linux x64, Linux Arm64, Windows x64, and so forth. Runtime configuration files, such as *\*.runtimeconfig.json* and *\*.deps.json*, are included in the single file.

The size of a single file in a self-contained application is large since it includes the runtime and framework libraries. You can combine single-file deployment with other publish options like [trimming](trimming/trim-self-contained.md) and [ReadyToRun](#readytorun-deployment) to optimize the deployment.

To publish a single-file deployment from Visual Studio:

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Self-contained** or **Framework-dependent**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Check **Produce single file**.
01. Click **Save** and then **Publish**.

For more information about single-file deployment, see [Single-file deployment](single-file/overview.md).

## ReadyToRun deployment

When you publish your app with ReadyToRun compilation, your application assemblies are compiled as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation that improves startup performance by reducing the amount of work the just-in-time (JIT) compiler needs to do as your application loads.

ReadyToRun binaries contain both intermediate language (IL) code and the native version of the same code. While R2R binaries are larger than regular assemblies, they provide better startup performance. ReadyToRun is only available when you publish an app that targets specific runtime environments (RID) such as Linux x64 or Windows x64.

The startup improvement applies not only to application startup, but also to the first use of any code in the application. For instance, ReadyToRun can reduce the response latency of the first use of Web API in an ASP.NET application.

To publish a ReadyToRun deployment from Visual Studio:

01. Right-click on the project in **Solution Explorer** and select **Publish**.
01. If this is your first time publishing, select **Folder** as the publish target and click **Next**.
01. Choose a folder location or accept the default, then click **Finish**.
01. In the publish profile, click **Show all settings**.
01. Set **Deployment Mode** to **Self-contained** or **Framework-dependent**.
01. Set **Target Runtime** to your desired platform (for example, **win-x64** for 64-bit Windows).
01. Check **Enable ReadyToRun compilation**.
01. Click **Save** and then **Publish**.

> [!NOTE]
> ReadyToRun compilation increases the size of your assemblies. The size of an assembly typically grows to between two to three times larger. This increase in physical size might reduce performance of loading the assembly from disk and increase working set of the process.

ReadyToRun can be combined with other publish options like [single-file deployment](#single-file-deployment) and [trimming](trimming/trim-self-contained.md) for more optimizations.

For more information about ReadyToRun deployment, see [ReadyToRun compilation](ready-to-run.md).

## See also

- [.NET Application Deployment](index.md)
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)

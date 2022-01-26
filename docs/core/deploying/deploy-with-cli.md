---
title: Publish apps with the .NET CLI
description: Learn to publish a .NET application using the .NET CLI commands.
author: adegeo
ms.author: adegeo
ms.date: 02/05/2021
ms.custom: updateeachrelease
dev_langs:
  - "csharp"
  - "vb"
---

# Publish .NET apps with the .NET CLI

This article demonstrates how you can publish your .NET application from the command line. .NET provides three ways to publish your applications. Framework-dependent deployment produces a cross-platform .dll file that uses the locally installed .NET runtime. Framework-dependent executable produces a platform-specific executable that uses the locally installed .NET runtime. Self-contained executable produces a platform-specific executable and includes a local copy of the .NET runtime.

For an overview of these publishing modes, see [.NET Application Deployment](index.md).

Looking for some quick help on using the CLI? The following table shows some examples of how to publish your app. You can specify the target framework with the `-f <TFM>` parameter or by editing the project file. For more information, see [Publishing basics](#publishing-basics).

| Publish Mode                   | SDK Version | Command                                                     |
|--------------------------------|-------------|-------------------------------------------------------------|
| [Framework-dependent deployment](#framework-dependent-deployment) | 2.1         | `dotnet publish -c Release`                                 |
|                                | 3.1         | `dotnet publish -c Release -p:UseAppHost=false`             |
|                                | 5.0         | `dotnet publish -c Release -p:UseAppHost=false`             |
| [Framework-dependent executable](#framework-dependent-executable) | 3.1         | `dotnet publish -c Release -r <RID> --self-contained false`<br>`dotnet publish -c Release` |
|                                | 5.0         | `dotnet publish -c Release -r <RID> --self-contained false`<br>`dotnet publish -c Release` |
| [Self-contained deployment](#self-contained-deployment)      | 2.1         | `dotnet publish -c Release -r <RID> --self-contained true`  |
|                                | 3.1         | `dotnet publish -c Release -r <RID> --self-contained true`  |
|                                | 5.0         | `dotnet publish -c Release -r <RID> --self-contained true`  |

\* When using **SDK version 3.1** or higher, framework-dependent executable is the default publishing mode when running the basic `dotnet publish` command.

> [!NOTE]
> The `-c Release` parameter isn't required. It's provided as a reminder to publish the **Release** build of your app.

## Publishing basics

The `<TargetFramework>` setting of the project file specifies the default target framework when you publish your app. You can change the target framework to any valid [Target Framework Moniker (TFM)](../../standard/frameworks.md). For example, if your project uses `<TargetFramework>netcoreapp2.1</TargetFramework>`, a binary that targets .NET Core 2.1 is created. The TFM specified in this setting is the default target used by the [`dotnet publish`](../tools/dotnet-publish.md) command.

If you want to target more than one framework, you can set the `<TargetFrameworks>` setting to multiple TFM values, separated by a semicolon. When you build your app, a build is produced for each target framework. However, when you publish your app, you must specify the target framework with the `dotnet publish -f <TFM>` command.

Unless otherwise set, the output directory of the [`dotnet publish`](../tools/dotnet-publish.md) command is `./bin/<BUILD-CONFIGURATION>/<TFM>/publish/`. The default **BUILD-CONFIGURATION** mode is **Debug** unless changed with the `-c` parameter. For example, `dotnet publish -c Release -f netcoreapp2.1` publishes to `./bin/Release/netcoreapp2.1/publish/`.

If you use .NET Core SDK 3.1 or later, the default publish mode is framework-dependent _executable_.

If you use .NET Core SDK 2.1, the default publish mode is framework-dependent _deployment_.

### Native dependencies

If your app has native dependencies, it may not run on a different operating system. For example, if your app uses the native Windows API, it won't run on macOS or Linux. You would need to provide platform-specific code and compile an executable for each platform.

Consider also, if a library you referenced has a native dependency, your app may not run on every platform. However, it's possible a NuGet package you're referencing has included platform-specific versions to handle the required native dependencies for you.

When distributing an app with native dependencies, you may need to use the `dotnet publish -r <RID>` switch to specify the target platform you want to publish for. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

More information about platform-specific binaries is covered in the [Framework-dependent executable](#framework-dependent-executable) and [Self-contained deployment](#self-contained-deployment) sections.

## Sample app

You can use the following app to explore the publishing commands. The app is created by running the following commands in your terminal:

```dotnetcli
mkdir apptest1
cd apptest1
dotnet new console
dotnet add package Figgle
```

The `Program.cs` or `Program.vb` file that is generated by the console template needs to be changed to the following:

```csharp
using System;

namespace apptest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Hello, World!"));
        }
    }
}
```

```vb
Module Program
    Sub Main(args As String())
        Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Hello, World!"))
    End Sub
End Module
```

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

For the .NET Core 2.1 SDK CLI, framework-dependent deployment (FDD) is the default mode for the basic `dotnet publish` command. In newer SDKs, [Framework-dependent executable](#framework-dependent-executable) is the default.

When you publish your app as an FDD, a `<PROJECT-NAME>.dll` file is created in the `./bin/<BUILD-CONFIGURATION>/<TFM>/publish/` folder. To run your app, navigate to the output folder and use the `dotnet <PROJECT-NAME>.dll` command.

Your app is configured to target a specific version of .NET. That targeted .NET runtime is required to be on any machine where your app runs. For example, if your app targets .NET Core 3.1, any machine that your app runs on must have the .NET Core 3.1 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDD creates an app that automatically rolls-forward to the latest .NET security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

| Publish Mode                   | SDK Version | Command                                                     |
|--------------------------------|-------------|-------------------------------------------------------------|
| Framework-dependent deployment | 2.1         | `dotnet publish -c Release`                                 |
|                                | 3.1         | `dotnet publish -c Release -p:UseAppHost=false`             |
|                                | 5.0         | `dotnet publish -c Release -p:UseAppHost=false`             |

## Framework-dependent executable

For the .NET 5 (and .NET Core 3.1) SDK CLI, framework-dependent executable (FDE) is the default mode for the basic `dotnet publish` command. You don't need to specify any other parameters, as long as you want to target the current operating system.

In this mode, a platform-specific executable host is created to host your cross-platform app. This mode is similar to FDD, as FDD requires a host in the form of the `dotnet` command. The host executable filename varies per platform and is named something similar to `<PROJECT-FILE>.exe`. You can run this executable directly instead of calling `dotnet <PROJECT-FILE>.dll`, which is still an acceptable way to run the app.

Your app is configured to target a specific version of .NET. That targeted .NET runtime is required to be on any machine where your app runs. For example, if your app targets .NET Core 3.1, any machine that your app runs on must have the .NET Core 3.1 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDE creates an app that automatically rolls-forward to the latest .NET security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

For .NET 2.1, you must use the following switches with the `dotnet publish` command to publish an FDE:

- `-r <RID>`
  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

- `--self-contained false`
  This switch disables the default behavior of the `-r` switch, which is to create a self-contained deployment (SCD). This switch creates an FDE.

| Publish Mode                   | SDK Version | Command                                                     |
|--------------------------------|-------------|-------------------------------------------------------------|
| Framework-dependent executable | 3.1         | `dotnet publish -c Release -r <RID> --self-contained false`<br>`dotnet publish -c Release` |
|                                | 5.0         | `dotnet publish -c Release -r <RID> --self-contained false`<br>`dotnet publish -c Release` |

Whenever you use the `-r` switch, the output folder path changes to: `./bin/<BUILD-CONFIGURATION>/<TFM>/<RID>/publish/`

If you use the [example app](#sample-app), run `dotnet publish -f net5.0 -r win10-x64 --self-contained false`. This command creates the following executable: `./bin/Debug/net5.0/win10-x64/publish/apptest1.exe`

> [!NOTE]
> You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that are not globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

## Self-contained deployment

When you publish a self-contained deployment (SCD), the .NET SDK creates a platform-specific executable. Publishing an SCD includes all required .NET files to run your app but it doesn't include the [native dependencies of .NET](https://github.com/dotnet/core/blob/main/Documentation/prereqs.md). These dependencies must be present on the system before the app runs.

Publishing an SCD creates an app that doesn't roll forward to the latest available .NET security patch. For more information on version binding at compile time, see [Select the .NET version to use](../versions/selection.md#self-contained-deployments-include-the-selected-runtime).

You must use the following switches with the `dotnet publish` command to publish an SCD:

- `-r <RID>`
  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

- `--self-contained true`
  This switch tells the .NET SDK to create an executable as an SCD.

| Publish Mode                   | SDK Version | Command                                                     |
|--------------------------------|-------------|-------------------------------------------------------------|
| Self-contained deployment      | 2.1         | `dotnet publish -c Release -r <RID> --self-contained true`  |
|                                | 3.1         | `dotnet publish -c Release -r <RID> --self-contained true`  |
|                                | 5.0         | `dotnet publish -c Release -r <RID> --self-contained true`  |

> [!NOTE]
> You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that are not globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Core Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

## See also

- [.NET Application Deployment Overview](index.md)
- [.NET Runtime IDentifier (RID) catalog](../rid-catalog.md)

---
title: Publish .NET Core apps with the CLI
description: Learn to publish a .NET Core app with the .NET Core SDK command-line interface (CLI) tools.
author: thraka
ms.author: adegeo
ms.date: 01/16/2019
dev_langs:
  - "csharp"
  - "vb"
ms.custom: seodec18
---

# Publish .NET Core apps with the CLI

This article demonstrates how you can publish your .NET Core application from the command line. .NET Core provides three ways to publish your applications. Framework-dependent deployment produces a cross-platform .dll file that uses the locally installed .NET Core runtime. Framework-dependent executable produces a platform-specific executable that uses the locally installed .NET Core runtime. Self-contained executable produces a platform-specific executable and includes a local copy of the .NET Core runtime.

For an overview of these publishing modes, see [.NET Core Application Deployment](index.md).

Looking for some quick help on using the CLI? The following table shows some examples of how to publish your app. You can specify the target framework with the `-f <TFM>` parameter or by editing the project file. For more information, see [Publishing basics](#publishing-basics).

| Publish Mode | SDK Version | Command |
| ------------ | ----------- | ------- |
| Framework-dependent deployment | 2.x | `dotnet publish -c Release` |
| Framework-dependent executable | 2.2 | `dotnet publish -c Release -r <RID> --self-contained false` |
|                                | 3.0 | `dotnet publish -c Release -r <RID> --self-contained false` |
|                                | 3.0* | `dotnet publish -c Release` |
| Self-contained deployment      | 2.1 | `dotnet publish -c Release -r <RID> --self-contained true` |
|                                | 2.2 | `dotnet publish -c Release -r <RID> --self-contained true` |
|                                | 3.0 | `dotnet publish -c Release -r <RID> --self-contained true` |

\* When using SDK version 3.0, framework-dependent executable is the default publishing mode when running the basic `dotnet publish` command. This only applies when the project targets either **.NET Core 2.1** or **.NET Core 3.0**.

## Publishing basics

The `<TargetFramework>` setting of the project file specifies the default target framework when you publish your app. You can change the target framework to any valid [Target Framework Moniker (TFM)](../../standard/frameworks.md). For example, if your project uses `<TargetFramework>netcoreapp2.2</TargetFramework>`, a binary that targets .NET Core 2.2 is created. The TFM specified in this setting is the default target used by the [`dotnet publish`](../tools/dotnet-publish.md) command.

If you want to target more than one framework, you can set the `<TargetFrameworks>` setting to more than one TFM value separated by a semicolon. You can publish one of the frameworks with the `dotnet publish -f <TFM>` command. For example, if you have `<TargetFrameworks>netcoreapp2.1;netcoreapp2.2</TargetFrameworks>` and run `dotnet publish -f netcoreapp2.1`, a binary that targets .NET Core 2.1 is created.

Unless otherwise set, the output directory of the [`dotnet publish`](../tools/dotnet-publish.md) command is `./bin/<BUILD-CONFIGURATION>/<TFM>/publish/`. The default **BUILD-CONFIGURATION** mode is **Debug** unless changed with the `-c` parameter. For example, `dotnet publish -c Release -f netcoreapp2.1` publishes to `myfolder/bin/Release/netcoreapp2.1/publish/`.

If you use .NET Core SDK 3.0, the default publish mode for apps that target .NET Core versions 2.1, 2.2, or 3.0 is framework-dependent executable.

If you use .NET Core SDK 2.1, the default publish mode for apps that target .NET Core versions 2.1, 2.2 is framework-dependent deployment.

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
Imports System

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

For the .NET Core SDK 2.x CLI, framework-dependent deployment (FDD) is the default mode for the basic `dotnet publish` command.

When you publish your app as an FDD, a `<PROJECT-NAME>.dll` file is created in the `./bin/<BUILD-CONFIGURATION>/<TFM>/publish/` folder. To run your app, navigate to the output folder and use the `dotnet <PROJECT-NAME>.dll` command.

Your app is configured to target a specific version of .NET Core. That targeted .NET Core runtime is required to be on the machine where you want to run your app. For example, if your app targets .NET Core 2.2, any machine that your app runs on must have the .NET Core 2.2 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDD creates an app that automatically rolls-forward to the latest .NET Core security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET Core version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

## Framework-dependent executable

For the .NET Core SDK 3.x CLI, framework-dependent executable (FDE) is the default mode for the basic `dotnet publish` command. You don't need to specify any other parameters as long as you want to target the current operating system.

In this mode, a platform-specific executable host is created to host your cross-platform app. This mode is similar to FDD as FDD requires a host in the form of the `dotnet` command. The host executable filename varies per platform, and is named something similar to `<PROJECT-FILE>.exe`. You can run this executable directly instead of calling `dotnet <PROJECT-FILE>.dll` which is still an acceptable way to run the app.

Your app is configured to target a specific version of .NET Core. That targeted .NET Core runtime is required to be on the machine where you want to run your app. For example, if your app targets .NET Core 2.2, any machine that your app runs on must have the .NET Core 2.2 runtime installed. As stated in the [Publishing basics](#publishing-basics) section, you can edit your project file to change the default target framework or to target more than one framework.

Publishing an FDE creates an app that automatically rolls-forward to the latest .NET Core security patch available on the system that runs the app. For more information on version binding at compile time, see [Select the .NET Core version to use](../versions/selection.md#framework-dependent-apps-roll-forward).

You must (except for .NET Core 3.x when you target the current platform) use the following switches with the `dotnet publish` command to publish an FDE:

- `-r <RID>`
  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

- `--self-contained false`
  This switch tells the .NET Core SDK to create an executable as an FDE.

Whenever you use the `-r` switch, the output folder path changes to: `./bin/<BUILD-CONFIGURATION>/<TFM>/<RID>/publish/`

If you use the [example app](#sample-app), run `dotnet publish -f netcoreapp2.2 -r win10-x64 --self-contained false`. This command creates the following executable: `./bin/Debug/netcoreapp2.2/win10-x64/publish/apptest1.exe`

> [!NOTE]
> You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that are not globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Core Globalization Invariant Mode](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md).

## Self-contained deployment

When you publish a self-contained deployment (SCD), the .NET Core SDK creates a platform-specific executable. Publishing an SCD includes all required .NET Core files to run your app but it doesn't include the [native dependencies of .NET Core](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md). These dependencies must be present on the system before the app runs.

Publishing an SCD creates an app that doesn't roll-forward to the latest available .NET Core security patch. For more information on version binding at compile time, see [Select the .NET Core version to use](../versions/selection.md#self-contained-deployments-include-the-selected-runtime).

You must use the following switches with the `dotnet publish` command to publish an SCD:

- `-r <RID>`
  This switch uses an identifier (RID) to specify the target platform. For a list of runtime identifiers, see [Runtime Identifier (RID) catalog](../rid-catalog.md).

- `--self-contained true`
  This switch tells the .NET Core SDK to create an executable as an SCD.

> [!NOTE]
> You can reduce the total size of your deployment by enabling **globalization invariant mode**. This mode is useful for applications that are not globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture). For more information about **globalization invariant mode** and how to enable it, see [.NET Core Globalization Invariant Mode](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md).

## See also

- [.NET Core Application Deployment Overview](index.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)

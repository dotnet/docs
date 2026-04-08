---
title: "Tutorial: Create a .NET tool"
description: Learn how to create a .NET tool. A tool is a console application that is installed by using the .NET CLI. In this tutorial, you build a tool that reports .NET runtime information, OS details, and key environment variable settings.
ms.topic: tutorial
ms.date: 04/08/2026
---

# Tutorial: Create a .NET tool using the .NET CLI

**This article applies to:** ✔️ .NET 8 SDK and later versions

This tutorial teaches you how to create and package a .NET tool. The .NET CLI lets you create a console application as a tool, which others can install and run. .NET tools are NuGet packages that are installed from the .NET CLI. For more information about tools, see [.NET tools overview](global-tools.md).

The tool that you'll create is a console application that takes information about the current .NET environment and displays it, including the .NET version, operating system details, and key environment variable settings.

This is the first in a series of three tutorials. In this tutorial, you create and package a tool. In the next two tutorials you [use the tool as a global tool](global-tools-how-to-use.md) and [use the tool as a local tool](local-tools-how-to-use.md). The procedures for creating a tool are the same whether you use it as a global tool or as a local tool.

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or a later version.

  This tutorial uses .NET SDK 8.0. Global tools are available starting in .NET Core SDK 2.1, and local tools are available starting in .NET Core SDK 3.0.

- A text editor or code editor of your choice.

## Create a project

1. Open a command prompt and create a folder named *repository*.

1. Navigate to the *repository* folder and enter the following command:

   ```dotnetcli
   dotnet new console -n dotnet-env -f net8.0
   ```

   The command creates a new folder named *dotnet-env* under the *repository* folder.

   > [!NOTE]
   > For this tutorial, the project is named *dotnet-env*. When you create your own tools, choose a unique package name. Avoid using company or organization name prefixes (such as `Microsoft.` or `Google.`) that you don't own, as those are reserved for those organizations on NuGet.org.

   > [!NOTE]
   > For this tutorial you create a tool that targets .NET 8. To target a different framework, change the `-f|--framework` option. To target multiple frameworks, change the `TargetFramework` element to a `TargetFrameworks` element in the project file, as shown in the following example:
   >
   > ```xml
   > <Project Sdk="Microsoft.NET.Sdk">
   >   <PropertyGroup>
   >     <OutputType>Exe</OutputType>
   >     <TargetFrameworks>net9.0;net8.0</TargetFrameworks>
   >   </PropertyGroup>
   > </Project>
   > ```

1. Navigate to the *dotnet-env* folder.

   ```console
   cd dotnet-env
   ```

## Add the code

1. Open the *Program.cs* file with your code editor.

1. Replace the contents with the following code:

   :::code language="csharp" source="./snippets/global-tools-how-to-create/csharp/Program.cs" id="full-program":::

   The program has two methods:

   - `Main` checks whether any arguments were passed. With no arguments, it calls `ShowInfo()`. With any argument, it prints the tool version.
   - `ShowInfo` displays three sections of information:
     - **Runtime** — the .NET version, framework description, and runtime identifier, using `Environment.Version` and `RuntimeInformation`.
     - **System** — OS description, architecture, machine name, and processor count.
     - **Environment Variables** — six key .NET-related variables (`DOTNET_ROOT`, `DOTNET_HOST_PATH`, `DOTNET_CLI_HOME`, `DOTNET_NOLOGO`, `NUGET_PACKAGES`, and `DOTNET_ENVIRONMENT`), showing `(not set)` for any that aren't configured.

   The `using System.Reflection` directive is required for `Assembly.GetEntryAssembly()` and `AssemblyInformationalVersionAttribute`. The `using System.Runtime.InteropServices` directive is required for `RuntimeInformation`.

1. Save your changes.

## Test the application

Run the project and see the output:

```dotnetcli
dotnet run
```

The output looks similar to the following example:

```console
dotnet-env v1.0.0
----------------------------------------

Runtime
  .NET Version          8.0.14
  Framework             .NET 8.0.14
  Runtime Identifier    win10-x64

System
  OS                    Microsoft Windows 10.0.22631
  Architecture          X64
  Machine Name          MY-MACHINE
  Processor Count       16

Environment Variables
  DOTNET_ROOT             (not set)
  DOTNET_HOST_PATH        (not set)
  DOTNET_CLI_HOME         (not set)
  DOTNET_NOLOGO           (not set)
  NUGET_PACKAGES          (not set)
  DOTNET_ENVIRONMENT      (not set)
```

> [!NOTE]
> The values shown depend on your machine and .NET installation. The output varies by platform.

## Package the tool

Before you can pack and distribute the application as a tool, you need to modify the project file.

1. Open the *dotnet-env.csproj* file and add three new XML nodes to the end of the `<PropertyGroup>` node:

   ```xml
   <PackAsTool>true</PackAsTool>
   <ToolCommandName>dotnet-env</ToolCommandName>
   <PackageOutputPath>./nupkg</PackageOutputPath>
   ```

   `<ToolCommandName>` is an optional element that specifies the command that will invoke the tool after it's installed. If this element isn't provided, the command name for the tool is the assembly name, which is typically the project file name without the *.csproj* extension.

   > [!NOTE]
   > Choose a unique value for `<ToolCommandName>`. Avoid using file extensions (like `.exe` or `.cmd`) because the tool is installed as an app host and the command should not include an extension. This helps prevent conflicts with existing commands and ensures a smooth installation experience.

   `<PackageOutputPath>` is an optional element that determines where the NuGet package will be produced. The NuGet package is what the .NET CLI uses to install your tool.

   The project file now looks like the following example:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>

       <OutputType>Exe</OutputType>
       <TargetFramework>net8.0</TargetFramework>

       <PackAsTool>true</PackAsTool>
       <ToolCommandName>dotnet-env</ToolCommandName>
       <PackageOutputPath>./nupkg</PackageOutputPath>

     </PropertyGroup>

   </Project>
   ```

1. Create a NuGet package by running the [dotnet pack](dotnet-pack.md) command:

   ```dotnetcli
   dotnet pack
   ```

   The *dotnet-env.1.0.0.nupkg* file is created in the folder identified by the `<PackageOutputPath>` value from the *dotnet-env.csproj* file, which in this example is the *./nupkg* folder.

   When you want to release a tool publicly, you can upload it to `https://www.nuget.org`. Once the tool is available on NuGet, developers can install the tool by using the [dotnet tool install](dotnet-tool-install.md) command. For this tutorial you install the package directly from the local *nupkg* folder, so there's no need to upload the package to NuGet.

## Troubleshoot

If you get an error message while following the tutorial, see [Troubleshoot .NET tool usage issues](troubleshoot-usage-issues.md).

## Next steps

In this tutorial, you created a console application and packaged it as a tool. To learn how to use the tool as a global tool, advance to the next tutorial.

> [!div class="nextstepaction"]
> [Install and use a global tool](global-tools-how-to-use.md)

If you prefer, you can skip the global tools tutorial and go directly to the local tools tutorial.

> [!div class="nextstepaction"]
> [Install and use a local tool](local-tools-how-to-use.md)

## See also

- [Create RID-specific and AOT .NET tools](rid-specific-tools.md)

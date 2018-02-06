---
title: .NET Core app deployment with Visual Studio
description: Learn .NET Core app deployment with Visual Studio
keywords: .NET, .NET Core, .NET Core deployment
author: rpetrusha
ms.author: ronpet
ms.date: 04/18/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 01049a21-fd50-4419-9ab2-0e4a2e091050
ms.workload: 
  - dotnetcore
---

# Deploying .NET Core apps with Visual Studio

You can deploy a .NET Core application either as a *framework-dependent deployment*, which includes your application binaries but depends on the presence of .NET Core on the target system, or as a *self-contained deployment*, which includes both your application and .NET Core binaries. For an overview of .NET Core application deployment, see [.NET Core Application Deployment](index.md).

The following sections show how to use Microsoft Visual Studio to create the following kinds of deployments:

- Framework-dependent deployment
- Framework-dependent deployment with third-party dependencies
- Self-contained deployment
- Self-contained deployment with third-party dependencies

For information on using Visual Studio to develop .NET Core applications, see [Prerequisites for .NET Core on Windows](../windows-prerequisites.md#prerequisites-with-visual-studio-2017).

## Framework-dependent deployment

Deploying a framework-dependent deployment with no third-party dependencies simply involves building, testing, and publishing the app. A simple example written in C# illustrates the process.  

1. Create the project.

   Select **File** > **New** > **Project**. In the **New Project** dialog, select **.NET Core** in the **Installed** project types pane, and select the **Console App (.NET Core)** template in the center pane. Enter a project name, such as "FDD", in the **Name** text box. Select the **OK** button.

1. Add the application's source code.

   Open the *Program.cs* file in the editor and replace the auto-generated code with the following code. It prompts the user to enter text and displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!code-csharp[deployment#1](../../../samples/snippets/core/deploying/deployment-example.cs)]

1. Create a Debug build of your app.

   Select **Build** > **Build Solution**. You can also compile and run the Debug build of your application by selecting **Debug** > **Start Debugging**.

1. Deploy your app.

   After you've debugged and tested the program, create the files to be deployed with your app. To publish from Visual Studio, do the following:

      1. Change the solution configuration from **Debug** to **Release** on the toolbar to build a Release (rather than a Debug) version of your app.

      1. Right-click on the project (not the solution) in **Solution Explorer**, and select **Publish**.

      1. In the **Publish** tab, select **Publish**. Visual Studio writes the files that comprise your application to the local file system.

      1. The **Publish** tab now shows a single profile, **FolderProfile**. The profile's configuration settings are shown in the **Summary** section of the tab.

   The resulting files are placed in a directory named `PublishOutput` that is in a subdirectory of your project's *.\bin\release* subdirectory.

Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions. You can choose not to package it with your application's files. You should, however, save it in the event that you want to debug the Release build of your app.

Deploy the complete set of application files in any way you like. For example, you can package them in a Zip file, use a simple `copy` command, or deploy them with any installation package of your choice. Once installed, users can then execute your application by using the `dotnet` command and providing the application filename, such as `dotnet fdd.dll`.

In addition to the application binaries, your installer should also either bundle the shared framework installer or check for it as a prerequisite as part of the application installation.  Installation of the shared framework requires Administrator/root access since it is machine-wide.

## Framework-dependent deployment with third-party dependencies

Deploying a framework-dependent deployment with one or more third-party dependencies requires that any dependencies be available to your project. The following additional steps are required before you can build your app:

1. Use the **NuGet Package Manager** to add a reference to a NuGet package to your project; and if the package is not already available on your system, install it. To open the package manager, select **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**.

1. Confirm that `Newtonsoft.Json` is installed on your system and, if it is not, install it. The **Installed** tab lists NuGet packages installed on your system. If `Newtonsoft.Json` is not listed there, select the **Browse** tab and enter "Newtonsoft.Json" in the search box. Select `Newtonsoft.Json` and, in the right pane, select your project before selecting **Install**.

1. If `Newtonsoft.Json` is already installed on your system, add it to your project by selecting your project in the right pane of hte **Manage Packages for Solution** tab.

Note that a framework-dependent deployment with third-party dependencies is only as portable as its third-party dependencies. For example, if a third-party library only supports macOS, the app isn't portable to Windows systems. This happens if the third-party dependency itself depends on native code. A good example of this is [Kestrel server](http://docs.microsoft.com/aspnet/core/fundamentals/servers/kestrel), which requires a native dependency on [libuv](https://github.com/libuv/libuv). When an FDD is created for an application with this kind of third-party dependency, the published output contains a folder for each [Runtime Identifier (RID)](../rid-catalog.md) that the native dependency supports (and that exists in its NuGet package).

## <a name="simpleSelf"></a> Self-contained deployment without third-party dependencies

Deploying a self-contained deployment with no third-party dependencies involves creating the project, modifying the *csproj* file, building, testing, and publishing the app. A simple example written in C# illustrates the process. 

1. Create the project.

   Select **File** > **New** > **Project**. In the **Add New Project** dialog, select **.NET Core** in the **Installed** project types pane, and select the **Console App (.NET Core)** template in the center pane. Enter a project name, such as "SCD", in the **Name** text box, and select the **OK** button.

1. Add the application's source code.

   Open the *Program.cs* file in your editor, and replace the auto-generated code with the following code. It prompts the user to enter text and displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!code-csharp[deployment#1](../../../samples/snippets/core/deploying/deployment-example.cs)]

1. Define the platforms that your app will target.

   1. Right-click on your project (not the solution) In **Solution Explorer**, and select **Edit SCD.csproj**.

   1. Create a `<RuntimeIdentifiers>` tag in the `<PropertyGroup>` section of your *csproj* file that defines the platforms your app targets, and specify the runtime identifier (RID) of each platform that you target. Note that you also need to add a semicolon to separate the RIDs. See [Runtime IDentifier catalog](../rid-catalog.md) for a list of runtime identifiers. 

   For example, the following example indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.11 operating system.

```xml
<PropertyGroup>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
</PropertyGroup>
```
   Note that the `<RuntimeIdentifiers>` element can go into any `<PropertyGroup>` that you have in your *csproj* file. A complete sample *csproj* file appears later in this section.

1. Create a Debug build of your app.

   Select **Build** > **Build Solution**. You can also compile and run the Debug build of your application by selecting **Debug** > **Start Debugging**.

1. Publish your app.

   After you've debugged and tested the program, create the files to be deployed with your app for each platform that it targets.

   To publish your app from Visual Studio, do the following:

      1. Change the solution configuration from **Debug** to **Release** on the toolbar to build a Release (rather than a Debug) version of your app.

      1. Right-click on the project (not the solution) in **Solution Explorer** and select **Publish**. 

      1. In the **Publish** tab, select **Publish**. Visual Studio writes the files that comprise your application to the local file system.

      1. The **Publish** tab now shows a single profile, **FolderProfile**. The profile's configuration settings are shown in the **Summary** section of the tab. **Target Runtime** identifies which runtime has been published, and **Target Location** identifies where the files for the self-contained deployment were written.

      1. Visual Studio by default writes all published files to a single directory. For convenience, it's best to create separate profiles for each target runtime and to place published files in a platform-specific directory. This involves creating a separate publishing profile for each target platform. So now rebuild the application for each platform by doing the following:

         1. Select **Create new profile** in the **Publish** dialog.

         1. In the **Pick a publish target** dialog, change the **Choose a folder** location to *bin\Release\PublishOutput\win10-x64*. Select **OK**.

         1. Select the new profile (**FolderProfile1**) in the list of profiles, and make sure that the **Target Runtime** is `win10-x64`. If it isn't, select **Settings**. In the **Profile Settings** dialog, change the **Target Runtime** to `win10-x64` and select **Save**. Otherwise, select **Cancel**.

         1. Select **Publish** to publish your app for 64-bit Windows 10 platforms.

         1. Follow the previous steps again to create a profile for the `osx.10.11-x64` platform. The **Target Location** is *bin\Release\PublishOutput\osx.10.11-x64*, and the **Target Runtime** is `osx.10.11-x64`. The name that Visual Studio assigns to this profile is **FolderProfile2**.

      Note that each target location contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions. You can choose not to package it with your application's files. You should, however, save it in the event that you want to debug the Release build of your app.

Deploy the published files in any way you like. For example, you can package them in a Zip file, use a simple `copy` command, or deploy them with any installation package of your choice.

The following is the complete *csproj* file for this project.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1</TargetFramework>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
</Project>
```

## Self-contained deployment with third-party dependencies

Deploying a self-contained deployment with one or more third-party dependencies involves adding the dependencies. The following additional steps are required before you can build your app:

1. Use the **NuGet Package Manager** to add a reference to a NuGet package to your project; and if the package is not already available on your system, install it. To open the package manager, select **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**.

1. Confirm that `Newtonsoft.Json` is installed on your system and, if it is not, install it. The **Installed** tab lists NuGet packages installed on your system. If `Newtonsoft.Json` is not listed there, select the **Browse** tab and enter "Newtonsoft.Json" in the search box. Select `Newtonsoft.Json` and, in the right pane, select your project before selecting **Install**.

1. If `Newtonsoft.Json` is already installed on your system, add it to your project by selecting your project in the right pane of the **Manage Packages for Solution** tab.

The following is the complete *csproj* file for this project:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1</TargetFramework>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="10.0.2" />
  </ItemGroup>
</Project>
```

When you deploy your application, any third-party dependencies used in your app are also contained with your application files. Third-party libraries aren't required on the system on which the app is running.

Note that you can only deploy a self-contained deployment with a third-party library to platforms supported by that library. This is similar to having third-party dependencies with native dependencies in your framework-dependent deployment, where the native dependencies won't exist on the target platform unless they were previously installed there.

# See also
[.NET Core Application Deployment](index.md)   
[.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)   

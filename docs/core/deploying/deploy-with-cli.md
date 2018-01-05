---
title: .NET Core app deployment with CLI tools
description: Learn .NET Core app deployment with command-line interface (CLI) tools
keywords: .NET, .NET Core, .NET Core deployment
author: rpetrusha
ms.author: ronpet
ms.date: 04/18/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 82ebe16d-5e1c-46cc-91e8-71974296429c
ms.workload: 
  - dotnetcore
---

# Deploying .NET Core apps with command-line interface (CLI) tools

You can deploy a .NET Core application either as a *framework-dependent deployment*, which includes your application binaries but depends on the presence of .NET Core on the target system, or as a *self-contained deployment*, which includes both your application and the .NET Core binaries. For an overview, see [.NET Core Application Deployment](index.md).

The following sections show how to use [.NET Core command-line interface tools](../tools/index.md) to create the following kinds of deployments:

- Framework-dependent deployment
- Framework-dependent deployment with third-party dependencies
- Self-contained deployment
- Self-contained deployment with third-party dependencies

When working from the command line, you can use a program editor of your choice. If your program editor is [Visual Studio Code](https://code.visualstudio.com), you can open a command console inside your Visual Studio Code environment by selecting **View** > **Integrated Terminal**.

## Framework-dependent deployment

Deploying a framework-dependent deployment with no third-party dependencies simply involves building, testing, and publishing the app. A simple example written in C# illustrates the process. 

1. Create a project directory.

   Create a directory for your project and make it your current directory.

1. Create the project.

   From the command line, type [dotnet new console](../tools/dotnet-new.md) to create a new C# console project in that directory.

1. Add the application's source code.

   Open the *Program.cs* file in your editor and replace the auto-generated code with the following code. It prompts the user to enter text and displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!code-csharp[deployment#1](../../../samples/snippets/core/deploying/deployment-example.cs)]

1. Update the project's dependencies and tools.
 
   Run the [dotnet restore](../tools/dotnet-restore.md) ([see note](#dotnet-restore-note)) command to restore the dependencies specified in your project.

1. Create a Debug build of your app.

   Use the [dotnet build](../tools/dotnet-build.md) command to build your application or the [dotnet run](../tools/dotnet-run.md) command to build and run it.

1. Deploy your app.

   After you've debugged and tested the program, create the deployment by using the following command:

      ```console
      dotnet publish -f netcoreapp1.1 -c Release
      ```
   This creates a Release (rather than a Debug) version of your app. The resulting files are placed in a directory named *publish* that's in a subdirectory of your project's *bin* directory.

Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions. You can choose not to distribute it with your application's files. You should, however, save it in the event that you want to debug the Release build of your app.

You can deploy the complete set of application files in any way you like. For example, you can package them in a Zip file, use a simple `copy` command, or deploy them with any installation package of your choice. Once installed, users can execute your application by using the `dotnet` command and providing the application filename, such as `dotnet fdd.dll`.

In addition to the application binaries, your installer should also either bundle the shared framework installer or check for it as a prerequisite as part of the application installation.  Installation of the shared framework requires Administrator/root access.

## Framework-dependent deployment with third-party dependencies

Deploying a framework-dependent deployment with one or more third-party dependencies requires that those dependencies be available to your project. Two additional steps are required before you can run the `dotnet restore` ([see note](#dotnet-restore-note)) command:

1. Add references to required third-party libraries to the `<ItemGroup>` section of your *csproj* file. The following `<ItemGroup>` section contains a dependency on [Json.NET](http://www.newtonsoft.com/json) as a third-party library:

      ```xml
      <ItemGroup>
        <PackageReference Include="Newtonsoft.Json" Version="10.0.2" />
      </ItemGroup>
      ```

1. If you haven't already, download the NuGet package containing the third-party dependency. To download the package, execute the `dotnet restore` ([see note](#dotnet-restore-note)) command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

Note that a framework-dependent deployment with third-party dependencies is only as portable as its third-party dependencies. For example, if a third-party library only supports macOS, the app isn't portable to Windows systems. This happens if the third-party dependency itself depends on native code. A good example of this is [Kestrel server](/aspnet/core/fundamentals/servers/kestrel), which requires a native dependency on [libuv](https://github.com/libuv/libuv). When an FDD is created for an application with this kind of third-party dependency, the published output contains a folder for each [Runtime Identifier (RID)](../rid-catalog.md) that the native dependency supports (and that exists in its NuGet package).

## <a name="simpleSelf"></a> Self-contained deployment without third-party dependencies

Deploying a self-contained deployment without third-party dependencies involves creating the project, modifying the *csproj* file, building, testing, and publishing the app. A simple example written in C# illustrates the process. The example shows how to create a self-contained deployment using the [dotnet utility](../tools/dotnet.md) from the command line.

1. Create a directory for the project.

   Create a directory for your project, and make it your current directory.

1. Create the project.

   From the command line, type [dotnet new console](../tools/dotnet-new.md) to create a new C# console project in that directory.

1. Add the application's source code.

   Open the *Program.cs* file in your editor and replace the auto-generated code with the following code. It prompts the user to enter text and displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!code-csharp[deployment#1](../../../samples/snippets/core/deploying/deployment-example.cs)]

1. Define the platforms that your app will target.

   Create a `<RuntimeIdentifiers>` tag in the `<PropertyGroup>` section of your *csproj* file that defines the platforms your app targets and specify the runtime identifier (RID) for each platform that you target. Note that you also need to add a semicolon to separate the RIDs. See [Runtime IDentifier catalog](../rid-catalog.md) for a list of runtime identifiers. 

   For example, the following `<PropertyGroup>` section indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.11 operating system.

     ```xml
     <PropertyGroup>
         <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
     </PropertyGroup>
     ```

   Note that the `<RuntimeIdentifiers>` element can appear in any `<PropertyGroup>` in your *csproj* file. A complete sample *csproj* file appears later in this section.

1. Update the project's dependencies and tools.

   Run the [dotnet restore](../tools/dotnet-restore.md) ([see note](#dotnet-restore-note)) command to restore the dependencies specified in your project.

1. Create a Debug build of your app.

   From the command line, use the [dotnet build](../tools/dotnet-build.md) command.

1. After you've debugged and tested the program, create the files to be deployed with your app for each platform that it targets.

   Use the `dotnet publish` command for both target platforms as follows:

      ```console
      dotnet publish -c Release -r win10-x64
      dotnet publish -c Release -r osx.10.11-x64
      ```

   This creates a Release (rather than a Debug) version of your app for each target platform. The resulting files are placed in a subdirectory named *publish* that's in a subdirectory of your project's *.\bin\Release\netcoreapp1.1\<runtime_identifier>* subdirectory. Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

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

Deploying a self-contained deployment with one or more third-party dependencies involves adding the dependencies. Two additional steps are required before you can run the `dotnet restore` ([see note](#dotnet-restore-note)) command:

1. Add references to any third-party libraries to the `<ItemGroup>` section of your *csproj* file. The following `<ItemGroup>` section uses Json.NET as a third-party library.

    ```xml
      <ItemGroup>
        <PackageReference Include="Newtonsoft.Json" Version="10.0.2" />
      </ItemGroup>
    ```

1. If you haven't already, download the NuGet package containing the third-party dependency to your system. To make the dependency available to your app, execute the `dotnet restore` ([see note](#dotnet-restore-note)) command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

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

Note that you can only deploy a self-contained deployment with a third-party library to platforms supported by that library. This is similar to having third-party dependencies with native dependencies in a framework-dependent deployment, where the native dependencies must be compatible with the platform to which the app is deployed.

<a name="dotnet-restore-note"></a>
[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

# See also

[.NET Core Application Deployment](index.md)   
[.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)   


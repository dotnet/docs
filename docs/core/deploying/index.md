---
title: .NET Core Application Deployment | Microsoft Docs
description: .NET Core Application Deployment 
keywords: .NET, .NET Core, .NET Core deployment
author: rpetrusha
ms.author: ronpet
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: da7a31a0-8072-4f23-82aa-8a19184cb701
---

# .NET Core Application Deployment

You can create two types of deployments for .NET Core applications:

- Framework-dependent deployment. As the name implies, framework-dependent deployment (FDD) relies on a shared system-wide version of .NET Core to be present on the target system. Because .NET Core is already present, your app is also portable between installations of .NET Core. Your app contains only its own code and any third-party dependencies that are outside of the .NET Core libraries. FDDs contain .dll files that can be launched by using the [dotnet utility](../tools/dotnet.md) from the command line. For example, `dotnet app.dll` runs an application named `app`.

- Self-contained deployment. Unlike FDD, a self-contained deployment (SCD) does not rely on any shared components to be present on the target system. All components, including both .NET Core libraries and the .NET Core runtime, are included with the application and are isolated from other .NET Core applications. SCDs include an executable (such as `app.exe` on Windows platforms for an application named `app`), which is  a renamed version of the platform-specific .NET Core host, and a .dll file (such as `app.dll`), which is the actual application.

## Framework-dependent deployments (FDD)

For an FDD, you deploy only your app and any third-party dependencies. You do not have to deploy .NET Core, since your app will use the version of .NET Core that's present on the target system. This is the default deployment model for .NET Core apps.

### Why create a framework-dependent deployment?

Deploying an FDD has a number of advantages:

- You do not have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries regardless of operating system, .NET Core can execute your app regardless of the underlying operating system. For more information on the PE file format, see [.NET Assembly File Format](../../standard/assembly-format.md).

- The size of your deployment package is small. You only have to deploy your app and its dependencies, not .NET Core itself.

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core that you target, or a later version, is already installed on the host system.

- It is possible for the .NET Core runtime and libraries to change without your knowledge in future releases. In rare cases, this may change the behavior of your app.

### Deploying a framework-dependent deployment

Deploying a framework-dependent deployment with no third-party dependencies simply involves building, testing, and publishing the app. A simple example written in C# illustrates the process. The example explains how to create a framework-dependent deployment by using the [dotnet utility](../tools/dotnet.md) from the command line, as well as by using Visual Studio 2017. If you are working from the command line, you can use a program editor of your choice. If your program editor is Visual Studio Code, you can open a command console inside your Visual Studio Code environment by selecting **View**, **Integrated Terminal**.

1. Create the project.

   **From the command line:** Create a directory for your project, and from the command line, type [dotnet new console](../tools/dotnet-new.md) to create a new C# console project.

   **In Visual Studio 2017:** Select **File**, **New**, **Project**. In the **Add New Project** dialog, select **.NET Core** in the **Installed** project types pane, and select the **Console App (.NET Core)** template in the center pane. Enter a project name, such as `FDD`, in the **Name** text box, and select the **OK** button.

1. Open the `Program.cs` file in your editor, and replace the auto-generated code with the following code. It prompts the user to enter text, and then displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!deploy-cs[deployment#1](../../../samples/snippets/core/deploying/deployment-example.cs#1)]

1. **From the command line only:** Run the [dotnet restore](../tools/dotnet-restore.md) command to restore the dependencies specified in your project.

1. Create a debug build of your app.

   **From the command line:** Use the [dotnet build](../tools/dotnet-build.md) command.

   **In Visual Studio 2017:** Select **Build**, **Build Solution**. You can also compile and run the debug build of your application by selecting **Debug**, **Start Debugging**.

1. After you've debugged and tested the program, you can create the files to be deployed with your app,

   **From the command line:** Use the `dotnet publish -f netcoreapp1.1 -c release` command. This creates a release (rather than a debug) version of your app.

   The resulting files are placed in a directory named `publish` that is in a subdirectory of your project's `.\bin\release\netcoreapp1.1` subdirectory.

   **In Visual Studio 2017:** To publish from Visual Studio, do the following:

      1. Change the solution configuration from **Debug** to **Release** on the toolbar to build a release (rather than a debug) version of your app.

      1. Right-click on the project (not the solution) in **Solution Explorer**, and select **Publish**.

      1. In the **Publish** tab, select **Publish**. Visual Studio will write the files that comprise your application to the local file system.

      1. The **Publish** tab now shows a single profile, **FolderProfile**. The profile's configuration settings are shown in the Summary section of the tab.

   The resulting files are placed in a directory named `PublishOutput` that is in a subdirectory of your project's `.\bin\release` subdirectory.

1. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions; you can choose not to package it with your application's files.  You should, however, save it in the event that you want to debug the release build of your app.

The complete set of application files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice. Once installed, users can then execute your application by using the `dotnet` command and providing the application filename, such as `dotnet fdd.dll`.

In addition to the application binaries, the installer should also either bundle the shared framework installer or check for it as a prerequisite as part of the application installation.  Installation of the shared framework requires Administrator/root access since it is machine-wide.

### Deploying a framework-dependent deployment with third-party dependencies

Deploying a framework-dependent deployment with one or more third-party dependencies requires that any dependencies be available to your project.

**From the command line,** two additional steps are required before you can run the `dotnet restore` command:

1. Add references to any third-party libraries to the `<ItemGroup>` section of your `csproj` file. The following `<ItemGroup>` section contains a dependency on Json.NET as a third-party library:

      ```xml
      <ItemGroup>
        <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
      </ItemGroup>
       ```

1. If you haven't already, download the NuGet package containing the third-party dependency. To download the package, execute the `dotnet restore` command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

**In Visual Studio 2017:**

1. Use the **NuGet Package Manager** to add a reference to a NuGet package to your project and, if the package is not already available on your system, install it. To open the package manager, select **Tools**, **NuGet Package Manager**, **Manage NuGet Packages for Solution**.

1. Confirm that Newtonsoft.Json is installed on your system and, if it is not, install it. The **Installed** tab lists NuGet packages installed on your system. If Newtonsoft.Json is not listed there, select the **Browse** tab and enter 'Newtonsoft.Json' in the search box. Select Newtonsoft.Json and, in the right pane, select your project before selecting **Install**.

1. If Newtonsoft.Json is already installed on your system, add it to your project by selecting your project in the right pane of hte **Manage Packages for Solution** tab.

Note that a framework-dependent deployment with third-party dependencies will only be as portable as its third-party dependencies. For example, if a third-party library only supports macOS, the app will not be portable to Windows systems. This can happen if the third-party dependency itself depends on native code. A good example of this is Kestrel server. When an FDD is created for an application with this kind of third-party dependency, the published output will contain a folder for each [Runtime Identifier (RID)](../rid-catalog.md#what-are-rids) that the native dependency supports (and that exists in its NuGet package).

## Self-contained deployments (SCD)

For a self-contained deployment, you deploy not only your app and any third-party dependencies, but the version of .NET Core that you build your app with. Creating an SCD does not, however, include the [native dependencies of .NET Core](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md) itself on various platforms (for example, OpenSSL on macOS), so these need to be installed before running the application.

### Why deploy a Self-contained deployment?

Deploying a Self-contained deployment has two major advantages:

- You have sole control of the version of .NET Core that is deployed with your app. .NET Core can be serviced only by you.

- You can be assured that the target system can run your .NET Core app, since you're providing the version of .NET Core that it will run on.

It also has a number of disadvantages:

- Because .NET Core is included in your deployment package, you must select the target platforms for which you build deployment packages in advance.

- The size of your deployment package is relatively large, since you have to include .NET Core as well as your app and its third-party dependencies.

- Deploying numerous self-contained .NET Core apps to a system can consume significant amounts of disk space, since each app duplicates .NET Core files.

### <a name="simpleSelf"></a> Deploying a simple self-contained deployment

Deploying a self-contained deployment with no third-party dependencies involves creating the project, modifying the .csproj file, building, testing, and publishing the app.  A simple example written in C# illustrates the process. The example explains how to create a self-contained deployment by using the [dotnet utility](../tools/dotnet.md) from the command line, as well as by using Visual Studio 2017. If you are using the command line, you can use a program editor of your choice. If your program editor is Visual Studio Code, you can open a command console inside your Visual Studio Code Environment by selecting **View**, **Integrated Terminal**.

1. Create the project.

   **From the command line:** Create a directory for your project, and from the command line, type [dotnet new console](../tools/dotnet-new.md) to create a new C# console project.

   **In Visual Studio 2017:** Select **File**, **New**, **Project**. In the **Add New Project** dialog, select **.NET Core** in the **Installed** project types pane, and select the **Console App (.NET Core)** template in the center pane. Enter a project name, such as `SCD`, in the **Name** text box, and select the **OK** button.

1. Open the `Program.cs` file in your editor, and replace the auto-generated code with the following code. It prompts the user to enter text, and then displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!deploy-cs[deployment#1](../../../samples/snippets/core/deploying/deployment-example.cs#1)]

1. Define the platforms that your app will target.

   **From the command line:**

   Create a `<RuntimeIdentifiers>` tag under the `<PropertyGroup>` section in your `csproj` file that defines the platforms your app targets, and specify the runtime identifier (RID) of each platform that you target. Note that you also need to add a semicolon to separate the RIDs. See [Runtime IDentifier catalog](../rid-catalog.md) for a list of runtime identifiers. For example, the following example indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.11 operating system.

       ```xml
        <PropertyGroup>
          <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
        </PropertyGroup>
       ```
   Note that the `<RuntimeIdentifier>` element can go into any `<PropertyGroup>` that you have in your `csproj` file. A complete sample `csproj` file appears later in this section.

   **From Visual Studio 2017:**

   1. Right-click on your project (not the solution) In **Solution Explorer**, and select **Edit SCD.csproj**.

   1. Follow the instructions in the **From the command line** section immediately above to add the `<RuntimeIdentifiers>` element to your `.csproj` file.

1. **From the command line only:** Run the [dotnet restore](../tools/dotnet-restore.md) command to restore the dependencies specified in your project.

1. Create a debug build of your app.

   **From the command line:** Use the [dotnet build](../tools/dotnet-build.md) command.

   **In Visual Studio 2017:** Select **Build**, **Build Solution**. You can also compile and run the debug build of your application by selecting **Debug**, **Start Debugging**.

1. After you've debugged and tested the program, you can create the files to be deployed with your app for each platform that it targets.

   **From the command line:** Use the `dotnet publish` command for both target platforms as follows:

      ```console
      dotnet publish -c release -r win10-x64
      dotnet publish -c release -r osx.10.11-x64
      ```

   This creates a release (rather than a debug) version of your app for each target platform. The resulting files are placed in a subdirectory named `publish` that is in a subdirectory of your project's `.\bin\release\netcoreapp1.1\<runtime_identifier>` subdirectory. Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

   **In Visual Studio 2017:** To publish from Visual Studio, do the following:

      1. Change the solution configuration from **Debug** to **Release** on the toolbar to build a release (rather than a debug) version of your app.

      1. Right-click on the project (not the solution) in **Solution Explorer**, and select **Publish**. Visual Studio will write the files that comprise your application to the local file system.

      1. The **Publish** tab now shows a single profile, **FolderProfile**. The profile's configuration settings are shown in the Summary section of the tab. **Target Runtime** identifies which runtime has been published, and **Target Location** identifies where the files for the self-contained deployment were written.

      1. Visual Studio by default writes all published files to a single directory. For convenience, it's best to place published files in a platform. So now rebuild the application for each platform by doing the following:

         1. Click on **Settings** in the **Publish** tab, and change the **Target Location** to `bin\Release\PublishOutput\win10-x64`. Select **Save**, and then select **Publish** to publish your app for 64-bit Windows 10 platforms.

         1. Click on the **Settings** in the **Publish** tab again. Change the **Target Runtime** to `osx.10.11-x64`, and change the **Target Location** to `bin\Release\PublishOutput\osx.10.11-x64`. Select **Save**, and then select **Publish** to publish your app for 64-bit OS X Version 10.11 platforms.

      Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

1. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions; you can choose not to package it with your application's files. You should, however, save it in the event that you want to debug the release build of your app.

The published files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice.

The following is the complete `csproj` file for this project.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1</TargetFramework>
    <VersionPrefix>1.0.0</VersionPrefix>
    <DebugType>Portable</DebugType>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
</Project>
```

### Deploying a self-contained deployment with third-party dependencies

Deploying a self-contained deployment with one or more third-party dependencies involves adding the dependencies.

**From the command line:**

1. Add references to any third-party libraries to the `<ItemGroup>` section of your `csproj` file. The following  `<ItemGroup>` section uses Json.NET as a third-party library.

    ```xml
      <ItemGroup>
        <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
      </ItemGroup>
    ```

1. If you haven't already, download the NuGet package containing the third-party dependency to your system. To make the dependency available to your app, execute the `dotnet restore` command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

**In Visual Studio 2017:**

1. Use the **NuGet Package Manager** to add a reference to a NuGet package to your project and, if the package is not already available on your system, install it. To open the package manager, select **Tools**, **NuGet Package Manager**, **Manage NuGet Packages for Solution**.

1. Confirm that Newtonsoft.Json is installed on your system and, if it is not, install it. The **Installed** tab lists NuGet packages installed on your system. If Newtonsoft.Json is not listed there, select the **Browse** tab and enter 'Newtonsoft.Json' in the search box. Select Newtonsoft.Json and, in the right pane, select your project before selecting **Install**.

1. If Newtonsoft.Json is already installed on your system, add it to your project by selecting your project in the right pane of hte **Manage Packages for Solution** tab.

The following is the complete csproj file for this project:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1</TargetFramework>
    <VersionPrefix>1.0.0</VersionPrefix>
    <DebugType>Portable</DebugType>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
  </ItemGroup>
</Project>
```

When you deploy your application, any third-party dependencies used in your app are also contained with your application files. Third-party libraries do not already have to be present on the system on which the app is running.

Note that you can only deploy a self-contained deployment with a third-party library to platforms supported by that library. This is similar to having third-party dependencies with native dependencies in your framework-dependent deployment.

### Deploying a self-contained deployment with a smaller footprint

If the availability of adequate storage space on target systems is likely to be an issue, you can reduce the overall footprint of your app by excluding some system components. To do this, you explicitly define the .NET Core components that your app includes in your `.csproj` file.

To create a self-contained deployment with a smaller footprint, start by following the first two steps for creating a self-contained deployment. From the command line, once you've run the `dotnet new console` command and added the C# source code to your app, open the `csproj` file. From Visual Studio 2017, once you've created the project and added the C# source code, right-click on the project in **Solution Explorer** and select **Edit <project-name>.csproj**. Then do the following:

1. Replace the `<TargetFramework>` element with the following:

  ```xml
  <TargetFramework>netstandard1.6</TargetFramework>
  ```

This indicates that, instead of using the entire `netcoreapp1.0` framework, which includes .NET Core CLR, the .NET Core Library, and a number of other system components, our app uses only the .NET Standard Library.

2. Add the following `<ItemGroup>` section to add package references to the project:

  ```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.NETCore.Runtime.CoreCLR" Version="1.0.2" />
    <PackageReference Include="Microsoft.NETCore.DotNetHostPolicy" Version="1.0.1" />
  </ItemGroup>
  ```

   This defines the system components used by our app. The system components packaged with our app include the .NET Standard Library, the .NET Core runtime, and the .NET Core host. This produces a self-contained deployment with a smaller footprint.

3. As you did in the [Deploying a simple self-contained deployment](#simpleSelf) example, create a `<RuntimeIdentifiers>` element within a `<PropertyGroup>` in your `csproj` file that defines the platforms your app targets and specify the runtime identifier of each platform that you target. See [Runtime IDentifier catalog](../rid-catalog.md) for a list of runtime identifiers. For example, the following example indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.11 operating system.

    ```xml
    <PropertyGroup>
      <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
    </PropertyGroup>
    ```

   A complete sample `csproj` file appears later in this section.

4. **From the command line only**, run the `dotnet restore` command to restore the dependencies specified in your project.

5. After you've debugged and tested the program, you can create the files to be deployed with your app for each platform that it targets.

   **From the command line:**

   Use the `dotnet publish` command for both target platforms as follows:

      ```console
      dotnet publish -c release -r win10-x64
      dotnet publish -c release -r osx.10.11-x64
      ```

   This creates a release (rather than a debug) version of your app for each target platform. The resulting files are placed in a subdirectory named `publish` that is in a subdirectory of your project's `.\bin\release\netstandard1.6\<runtime_identifier>` subdirectory. Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

   **In Visual Studio 2017:**

   1. Change the solution configuration from **Debug** to **Release** on the toolbar to build a release (rather than a debug) version of your app.

   1. Right-click on the project (not the solution) in **Solution Explorer**, and select **Publish**. Visual Studio will write the files that comprise your application to the local file system.

      1. The **Publish** tab now shows a single profile, **FolderProfile**. The profile's configuration settings are shown in the Summary section of the tab. **Target Runtime** identifies which runtime has been published, and **Target Location** identifies where the files for the self-contained deployment were written.

      1. Visual Studio by default writes all published files to a single directory. For convenience, it's best to place published files in a platform. So now rebuild the application for each platform by doing the following:

         1. Click on **Settings** in the **Publish** tab, and change the **Target Location** to `bin\Release\PublishOutput\win10-x64`. Select **Save**, and then select **Publish** to publish your app for 64-bit Windows 10 platforms.

         1. Click on the **Settings** in the **Publish** tab again. Change the **Target Runtime** to `osx.10.11-x64`, and change the **Target Location** to `bin\Release\PublishOutput\osx.10.11-x64`. Select **Save**, and then select **Publish** to publish your app for 64-bit OS X Version 10.11 platforms.

      Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

6. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions; you can choose not to package it with your application's files.  You should, however, save it in the event that you want to debug the release build of your app.

The published files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice.

The following is the complete `csproj` file for this project.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netstandard1.6</TargetFramework>
    <VersionPrefix>1.0.0</VersionPrefix>
    <DebugType>Portable</DebugType>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.NETCore.Runtime.CoreCLR" Version="1.0.2" />
    <PackageReference Include="Microsoft.NETCore.DotNetHostPolicy" Version="1.0.1" />
  </ItemGroup>
</Project>
```

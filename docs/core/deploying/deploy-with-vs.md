---
title: Deploy .NET Core apps with Visual Studio
description: Learn to deploy a .NET Core app with Visual Studio.
ms.date: 09/03/2018
dev_langs: 
  - "csharp"
  - "vb"
ms.custom: vs-dotnet
---
# Deploy .NET Core apps with Visual Studio

You can deploy a .NET Core application either as a *framework-dependent deployment*, which includes your application binaries but depends on the presence of .NET Core on the target system, or as a *self-contained deployment*, which includes both your application and .NET Core binaries. For an overview of .NET Core application deployment, see [.NET Core Application Deployment](index.md).

The following sections show how to use Microsoft Visual Studio to create the following kinds of deployments:

- Framework-dependent deployment
- Framework-dependent deployment with third-party dependencies
- Self-contained deployment
- Self-contained deployment with third-party dependencies

For information on using Visual Studio to develop .NET Core applications, see [.NET Core dependencies and requirements](../install/dependencies.md?tabs=netcore30&pivots=os-windows).

## Framework-dependent deployment

Deploying a framework-dependent deployment with no third-party dependencies simply involves building, testing, and publishing the app. A simple example written in C# illustrates the process.  

1. Create the project.

   Select **File** > **New** > **Project**. In the **New Project** dialog, expand your language's (C# or Visual Basic) project categories in the **Installed** project types pane, choose **.NET Core**, and then select the **Console App (.NET Core)** template in the center pane. Enter a project name, such as "FDD", in the **Name** text box. Select the **OK** button.

1. Add the application's source code.

   Open the *Program.cs* or *Program.vb* file in the editor and replace the auto-generated code with the following code. It prompts the user to enter text and displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!code-csharp[deployment#1](~/samples/snippets/core/deploying/cs/deployment-example.cs)]
   [!code-vb[deployment#1](~/samples/snippets/core/deploying/vb/deployment-example.vb)]

1. Create a Debug build of your app.

   Select **Build** > **Build Solution**. You can also compile and run the Debug build of your application by selecting **Debug** > **Start Debugging**.

1. Deploy your app.

   After you've debugged and tested the program, create the files to be deployed with your app. To publish from Visual Studio, do the following:

      1. Change the solution configuration from **Debug** to **Release** on the toolbar to build a Release (rather than a Debug) version of your app.

      1. Right-click on the project (not the solution) in **Solution Explorer** and select **Publish**.

      1. In the **Publish** tab, select **Publish**. Visual Studio writes the files that comprise your application to the local file system.

      1. The **Publish** tab now shows a single profile, **FolderProfile**. The profile's configuration settings are shown in the **Summary** section of the tab.

   The resulting files are placed in a directory named `Publish` on Windows and `publish` on Unix systems that is in a subdirectory of your project's *.\bin\release\netcoreapp2.1* subdirectory.

Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions. You can choose not to package it with your application's files. You should, however, save it in the event that you want to debug the Release build of your app.

Deploy the complete set of application files in any way you like. For example, you can package them in a Zip file, use a simple `copy` command, or deploy them with any installation package of your choice. Once installed, users can then execute your application by using the `dotnet` command and providing the application filename, such as `dotnet fdd.dll`.

In addition to the application binaries, your installer should also either bundle the shared framework installer or check for it as a prerequisite as part of the application installation.  Installation of the shared framework requires Administrator/root access since it is machine-wide.

## Framework-dependent deployment with third-party dependencies

Deploying a framework-dependent deployment with one or more third-party dependencies requires that any dependencies be available to your project. The following additional steps are required before you can build your app:

1. Use the **NuGet Package Manager** to add a reference to a NuGet package to your project; and if the package is not already available on your system, install it. To open the package manager, select **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**.

1. Confirm that your third-party dependencies (for example, `Newtonsoft.Json`) are installed on your system and, if they aren't, install them. The **Installed** tab lists NuGet packages installed on your system. If `Newtonsoft.Json` is not listed there, select the **Browse** tab and enter "Newtonsoft.Json" in the search box. Select `Newtonsoft.Json` and, in the right pane, select your project before selecting **Install**.

1. If `Newtonsoft.Json` is already installed on your system, add it to your project by selecting your project in the right pane of the **Manage Packages for Solution** tab.

Note that a framework-dependent deployment with third-party dependencies is only as portable as its third-party dependencies. For example, if a third-party library only supports macOS, the app isn't portable to Windows systems. This happens if the third-party dependency itself depends on native code. A good example of this is [Kestrel server](https://docs.microsoft.com/aspnet/core/fundamentals/servers/kestrel), which requires a native dependency on [libuv](https://github.com/libuv/libuv). When an FDD is created for an application with this kind of third-party dependency, the published output contains a folder for each [Runtime Identifier (RID)](../rid-catalog.md) that the native dependency supports (and that exists in its NuGet package).

## <a name="simpleSelf"></a> Self-contained deployment without third-party dependencies

Deploying a self-contained deployment with no third-party dependencies involves creating the project, modifying the *csproj* file, building, testing, and publishing the app. A simple example written in C# illustrates the process. You begin by creating, coding, and testing your project just as you would a framework-dependent deployment:

1. Create the project.

   Select **File** > **New** > **Project**. In the **New Project** dialog, expand your language's (C# or Visual Basic) project categories in the **Installed** project types pane, choose **.NET Core**, and then select the **Console App (.NET Core)** template in the center pane. Enter a project name, such as "SCD", in the **Name** text box, and select the **OK** button.

1. Add the application's source code.

   Open the *Program.cs* or *Program.vb* file in your editor, and replace the auto-generated code with the following code. It prompts the user to enter text and displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

   [!code-csharp[deployment#1](~/samples/snippets/core/deploying/cs/deployment-example.cs)]
   [!code-vb[deployment#1](~/samples/snippets/core/deploying/vb/deployment-example.vb)]

1. Determine whether you want to use globalization invariant mode.

   Particularly if your app targets Linux, you can reduce the total size of your deployment by taking advantage of [globalization invariant mode](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md). Globalization invariant mode is useful for applications that are not globally aware and that can use the formatting conventions, casing conventions, and string comparison and sort order of the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture).

   To enable invariant mode, right-click on your project (not the solution) in **Solution Explorer**, and select **Edit SCD.csproj** or **Edit SCD.vbproj**. Then add the following highlighted lines to the file:

   [!code-xml[globalization-invariant-mode](~/samples/snippets/core/deploying/xml/invariant.csproj?highlight=6-8)]

1. Create a Debug build of your application.

   Select **Build** > **Build Solution**. You can also compile and run the Debug build of your application by selecting **Debug** > **Start Debugging**. This debugging step lets you identify problems with your application when it's running on your host platform. You still will have to test it on each of your target platforms.

   If you've enabled globalization invariant mode, be particularly sure to test whether the absence of culture-sensitive data is suitable for your application.

Once you've finished debugging, you can publish your self-contained deployment:

<!-- markdownlint-disable MD025 -->

# [Visual Studio 15.6 and earlier](#tab/vs156)

After you've debugged and tested the program, create the files to be deployed with your app for each platform that it targets.

To publish your app from Visual Studio, do the following:

1. Define the platforms that your app will target.

   1. Right-click on your project (not the solution) in **Solution Explorer** and select **Edit SCD.csproj**.

   1. Create a `<RuntimeIdentifiers>` tag in the `<PropertyGroup>` section of your *csproj* file that defines the platforms your app targets, and specify the runtime identifier (RID) of each platform that you target. Note that you also need to add a semicolon to separate the RIDs. See [Runtime IDentifier catalog](../rid-catalog.md) for a list of runtime identifiers.

   For example, the following example indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.11 operating system.

   ```xml
   <PropertyGroup>
      <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
   </PropertyGroup>
   ```

   Note that the `<RuntimeIdentifiers>` element can go into any `<PropertyGroup>` that you have in your *csproj* file. A complete sample *csproj* file appears later in this section.

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
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
</Project>
```

# [Visual Studio 15.7 and later](#tab/vs157)

After you've debugged and tested the program, create the files to be deployed with your app for each platform that it targets. This involves creating a separate profile for each target platform.

For each platform that your application targets, do the following:

1. Create a profile for your target platform.

   If this is the first profile you've created, right-click on the project (not the solution) in **Solution Explorer** and select **Publish**.

   If you've already created a profile, right-click on the project to open the **Publish** dialog if it isn't already open. Then select **New Profile**.

   The **Pick a Publish Target** dialog box opens.
  
1. Select the location where Visual Studio publishes your application.

   If you're only publishing to a single platform, you can accept the default value in the **Choose a folder** text box; this publishes the framework dependent deployment of your application to the *\<project-directory>\bin\Release\netcoreapp2.1\publish* directory.

   If you're publishing to more than one platform, append a string that identifies the target platform. For example, if you append the string "linux" to the file path, Visual Studio publishes the framework dependent deployment of your application to the *\<project-directory>\bin\Release\netcoreapp2.1\publish\linux* directory.

1. Create the profile by selecting the drop-down list icon next to the **Publish** button and selecting **Create Profile**. Then select the **Create Profile** button to create the profile.

1. Indicate that you are publishing a self-contained deployment and define a platform that your app will target.

   1. In the **Publish** dialog, select the **Configure** link to open the **Profile Settings** dialog.

   1. Select **Self-contained** in the **Deployment Mode** list box.

   1. In the **Target Runtime** list box, select one of the platforms that your application targets.

   1. Select **Save** to accept your changes and close the dialog.

1. Name your profile.

   1. Select **Actions** > **Rename Profile** to name your profile.

   2. Assign your profile a name that identifies the target platform, then select **Save*.

Repeat these steps to define any additional target platforms that your application targets.

You've configured your profiles and are now ready to publish your app. To do this:

   1. If the **Publish** window isn't currently open, right-click on the project (not the solution) in **Solution Explorer** and select **Publish**.

   2. Select the profile that you'd like to publish, then select **Publish**. Do this for each profile to be published.

   Note that each target location (in the case of our example, bin\release\netcoreapp2.1\publish\\*profile-name* contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions. You can choose not to package it with your application's files. You should, however, save it in the event that you want to debug the Release build of your app.

Deploy the published files in any way you like. For example, you can package them in a Zip file, use a simple `copy` command, or deploy them with any installation package of your choice.

The following is the complete *csproj* file for this project.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>
  </PropertyGroup>
</Project>
```

In addition, Visual Studio creates a separate publishing profile (\*.pubxml) for each platform that you target. For example, the file for our linux profile (linux.pubxml) appears as follows:

```xml
<?xml version="1.0" encoding="utf-8"?>
<!--
https://go.microsoft.com/fwlink/?LinkID=208121. 
-->
<Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <PublishProtocol>FileSystem</PublishProtocol>
    <Configuration>Release</Configuration>
    <Platform>Any CPU</Platform>
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <PublishDir>bin\Release\netcoreapp2.1\publish\linux</PublishDir>
    <RuntimeIdentifier>win-x86</RuntimeIdentifier>
    <SelfContained>true</SelfContained>
    <_IsPortable>false</_IsPortable>
  </PropertyGroup>
</Project>
```

---

## Self-contained deployment with third-party dependencies

Deploying a self-contained deployment with one or more third-party dependencies involves adding the dependencies. The following additional steps are required before you can build your app:

1. Use the **NuGet Package Manager** to add a reference to a NuGet package to your project; and if the package is not already available on your system, install it. To open the package manager, select **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**.

1. Confirm that your third-party dependencies (for example, `Newtonsoft.Json`) are installed on your system and, if they aren't, install them. The **Installed** tab lists NuGet packages installed on your system. If `Newtonsoft.Json` is not listed there, select the **Browse** tab and enter "Newtonsoft.Json" in the search box. Select `Newtonsoft.Json` and, in the right pane, select your project before selecting **Install**.

1. If `Newtonsoft.Json` is already installed on your system, add it to your project by selecting your project in the right pane of the **Manage Packages for Solution** tab.

The following is the complete *csproj* file for this project:

# [Visual Studio 15.6 and earlier](#tab/vs156)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="10.0.2" />
  </ItemGroup>
</Project>
```

# [Visual Studio 15.7 and later](#tab/vs157)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="10.0.2" />
  </ItemGroup>
</Project>
```

---

When you deploy your application, any third-party dependencies used in your app are also contained with your application files. Third-party libraries aren't required on the system on which the app is running.

Note that you can only deploy a self-contained deployment with a third-party library to platforms supported by that library. This is similar to having third-party dependencies with native dependencies in your framework-dependent deployment, where the native dependencies won't exist on the target platform unless they were previously installed there.

## See also

- [.NET Core Application Deployment](index.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)

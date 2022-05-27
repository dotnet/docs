---
title: Upgrade Windows Forms apps to .NET 6
description: Use the .NET Upgrade Assistant to upgrade an existing .NET Framework Windows Forms app to .NET 6. The .NET Upgrade Assistant is a CLI tool that helps migrating an app from .NET Framework to .NET 6.
author: adegeo
ms.date: 01/25/2022
---
# Upgrade a Windows Forms App to .NET 6 with the .NET Upgrade Assistant

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with upgrading .NET Framework Windows Forms apps to .NET 6. This article provides:

- A demonstration of how to run the tool against a .NET Framework Windows Forms app
- Troubleshooting tips

For more information on how to install the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

## Demo app

You can use the [Basic Windows Forms Sample][winforms-sample] project to test upgrading with the Upgrade Assistant.

## Analyze your app

The .NET Upgrade Assistant tool includes an analyze mode that performs a simplified dry run of upgrading your app. It may provide insights as to what changes may be required before the upgrade is started. Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant analyze` command, passing in the name of the project or solution you're upgrading.

For example, running the analyze mode with the [Basic Windows Forms Sample][winforms-sample] app produces the following output, indicating that there aren't any changes to be made before upgrading:

```console
> upgrade-assistant analyze .\MatchingGame.sln

16:18:52 INF] Loaded 5 extensions
[16:18:53 INF] Using MSBuild from C:\Program Files\dotnet\sdk\6.0.200-preview.22055.15\
[16:18:53 INF] Using Visual Studio install from C:\Program Files\Microsoft Visual Studio\2022\Preview [v17]
[16:18:55 INF] Recommending Windows TFM net6.0-windows because the project either has Windows-specific dependencies or builds to a WinExe
[16:18:56 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.3.261602) needs to be added
[16:18:57 INF] Adding Microsoft.Windows.Compatibility 6.0.0
[16:18:57 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.3.261602) needs to be added
[16:18:57 INF] Running analyzers on MatchingGame
[16:18:59 INF] Identified 0 diagnostics in project MatchingGame
[16:18:59 INF] Running analyzers on MatchingGame.Logic
[16:18:59 INF] Identified 0 diagnostics in project MatchingGame.Logic
[16:18:59 WRN] HighDpiMode needs to set in Main() instead of app.config or app.manifest - Application.SetHighDpiMode(HighDpiMode.<setting>). It is recommended to use SystemAware as the HighDpiMode option for better results.
```

There's quite a bit of internal diagnostic information in the output, but some information is helpful. Notice that the analyze mode indicates that the upgrade will recommend that the project target the `net6.0-windows` target framework moniker ([TFM](../../standard/frameworks.md)). This is because the projects referenced by the solution are Windows Forms projects, a Windows-only technology. A console application would probably get the recommendation to upgrade to TFM `net6.0` directly, unless it used some Windows-specific libraries.

If any errors or warnings are reported, take care of them before you start an upgrade.

## Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant upgrade` command, passing in the name of the project or solution you're upgrading.

When a project is provided, the upgrade process starts on that project immediately. If a solution is provided, you'll select which project you normally run, known as the [upgrade entrypoint](#select-the-entrypoint). Based on that project, a dependency graph is created and a suggestion as to which order you should upgrade the projects is provided.

```console
upgrade-assistant upgrade .\MatchingGame.sln
```

The tool runs and shows you a list of the steps it will do. As each step is completed, the tool provides a set of commands allowing the user to apply or skip the next step or some other option such as:

- Get more information about the step.
- Change projects.
- Adjust logging settings.
- Stop the upgrade and quit.

Pressing <kbd>Enter</kbd> without choosing a number selects the first item in the list.

As each step initializes, it may provide information about what it thinks will happen if you apply the step.

### Select the Entrypoint

The first step in upgrading the [example app][winforms-sample] is choosing which project in the solution serves as the entrypoint project.

```
Upgrade Steps

1. [Next step] Select an entrypoint
2. Select project to upgrade

Choose a command:
   1. Apply next step (Select an entrypoint)
   2. Skip next step (Select an entrypoint)
   3. See more step details
   4. Configure logging
   5. Exit
```

Choose **command 1** to start that step. The results are displayed:

```
[16:32:05 INF] Applying upgrade step Select an entrypoint
Please select the project you run. We will then analyze the dependencies and identify the recommended order to upgrade projects.
   1. MatchingGame
   2. MatchingGame.Logic
```

There are two projects listed: The main Windows Forms app (MatchingGame) and the library project (MatchingGame.Logic). Select the MatchingGame project for the entrypoint, which is **item 1**.

### Select a project to upgrade

After the entrypoint is determined, the next step is to choose which project to upgrade first. In this example, the tool determined that the library project (MatchingGame.Logic) should be upgraded first since the main Windows Forms app project depends on it.

```
[16:36:20 INF] Applying upgrade step Select project to upgrade
Here is the recommended order to upgrade. Select enter to follow this list, or input the project you want to start with.
   1. MatchingGame.Logic
   2. MatchingGame
```

The recommended path here, is to first upgrade the **MatchingGame.Logic** project first, since the **MatchingGame** project depends on it. It's best to follow the recommended upgrade path.

Upgrading the **MatchingGame.Logic** is a simple project and doesn't present any post-upgrade problems. Therefore, this article continues on as if that project has already been upgraded and the next project to upgrade is **MatchingGame**.

### Upgrade the project

Once a project is selected, a list of upgrade steps the tool will take is listed.

> [!IMPORTANT]
> For the purposes of this example, the **MatchingGame** project is described. It's assumed that the **MatchingGame.Logic** project was successfully upgraded. The reason for demonstrating the **MatchingGame** project is that it contains more of the common issues you'll run into when upgrading an app.
>
> Based on the project you're upgrading, you may or may not see every step listed in this example.

The following output describes the steps involved in upgrading the project:

```
[16:38:44 INF] Initializing upgrade step Back up project

Upgrade Steps

Entrypoint: C:\code\Work\temp\Migration\winforms\net45cs\MatchingGame\MatchingGame.csproj
Current Project: C:\code\Work\temp\Migration\winforms\net45cs\MatchingGame\MatchingGame.csproj

1. [Next step] Back up project
2. Convert project file to SDK style
3. Clean up NuGet package references
4. Update TFM
5. Update NuGet Packages
6. Add template files
7. Update Winforms Project
    a. Default Font API Alert
    b. Winforms Source Updater
8. Upgrade app config files
    a. Convert Application Settings
    b. Convert Connection Strings
    c. Disable unsupported configuration sections
9. Update source code
    a. Apply fix for UA0002: Types should be upgraded
    b. Apply fix for UA0012: 'UnsafeDeserialize()' does not exist
10. Move to next project

Choose a command:
   1. Apply next step (Back up project)
   2. Skip next step (Back up project)
   3. See more step details
   4. Select different project
   5. Configure logging
   6. Exit
```

> [!NOTE]
> For the rest of this article, the upgrade steps aren't explicitly shown unless there is something important to call out. The results of each step are still shown.

#### Create a backup

In this example of upgrading the project, you'll apply each step. The first step, **command 1**, is backing up the project:

```
[16:43:22 INF] Applying upgrade step Back up project
Please choose a backup path
   1. Use default path [C:\code\Work\temp\Migration\winforms\net45cs.backup]
   2. Enter custom path
```

The tool chooses a default backup path named after the current folder, but with `.backup` appended to it. You can choose a custom path as an alternative to the default path. For each upgraded project, the folder of the project is copied to the backup folder. In this example, the `MatchingGame` folder is copied from _net45cs\MatchingGame_ to _net45cs.backup\MatchingGame_ during the backup step:

```
[16:43:37 INF] Backing up C:\code\Work\temp\Migration\winforms\net45cs\MatchingGame to C:\code\Work\temp\Migration\winforms\net45cs.backup\MatchingGame
[16:43:37 INF] Project backed up to C:\code\Work\temp\Migration\winforms\net45cs.backup\MatchingGame
[16:43:37 INF] Upgrade step Back up project applied successfully
Please press enter to continue...
```

#### Upgrade the project file

The project is upgraded from the .NET Framework project format to the .NET SDK project format.

```
[16:44:31 INF] Applying upgrade step Convert project file to SDK style
[16:44:31 INF] Converting project file format with try-convert, version 0.3.261602+8aa571efd8bac422c95c35df9c7b9567ad534ad0
[16:44:31 INF] Recommending Windows TFM net6.0-windows because the project either has Windows-specific dependencies or builds to a WinExe
C:\code\Work\temp\Migration\winforms\net45cs\MatchingGame\MatchingGame.csproj contains an App.config file. App.config is replaced by appsettings.json in .NET Core. You will need to delete App.config and migrate to appsettings.json if it's applicable to your project.
[16:44:32 INF] Converting project C:\code\Work\temp\Migration\winforms\net45cs\MatchingGame\MatchingGame.csproj to SDK style
[16:44:32 INF] Project file converted successfully! The project may require additional changes to build successfully against the new .NET target.
[16:44:33 INF] Upgrade step Convert project file to SDK style applied successfully
Please press enter to continue...
```

Pay attention to the output of each step. Notice that the example output indicates that you'll have a manual step to complete after the upgrade:

> App.config is replaced by appsettings.json in .NET Core. You will need to delete App.config and migrate to appsettings.json if it's applicable to your project.

As part of this upgrade step, the NuGet packages referenced by the _packages.config_ are migrated to the project file.

#### Clean up NuGet references

Once the project format has been updated, the next step is to clean up the NuGet package references.

In addition to the packages referenced by your app, the _packages.config_ file contains references to the dependencies of those packages. For example, if you added reference to package **A** which depends on package **B**, both packages would be referenced in the _packages.config_ file. In the new project system, only the reference to package **A** is required. This step analyzes the package references and removes those that aren't required.

```
[16:46:06 INF] Applying upgrade step Clean up NuGet package references
[16:46:06 INF] Removing outdated package reference: MetroFramework.Design, Version=1.2.0.3
[16:46:06 INF] Removing outdated package reference: MetroFramework.Fonts, Version=1.2.0.3
[16:46:06 INF] Removing outdated package reference: MetroFramework.RunTime, Version=1.2.0.3
[16:46:06 INF] Adding package reference: Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, Version=0.3.261602
[16:46:08 INF] Upgrade step Clean up NuGet package references applied successfully
Please press enter to continue...
```

Your app is still referencing .NET Framework assemblies. Some of those assemblies may be available as NuGet packages. This step analyzes those assemblies and references the appropriate NuGet package.

#### Handle the TFM

The tool next changes the [TFM](../../standard/frameworks.md) from .NET Framework to the suggested SDK. In this example, it's `net6.0-windows`.

```
[16:47:16 INF] Applying upgrade step Update TFM
[16:47:16 INF] Recommending Windows TFM net6.0-windows because the project either has Windows-specific dependencies or builds to a WinExe
[16:47:18 INF] Updated TFM to net6.0-windows
[16:47:18 INF] Upgrade step Update TFM applied successfully
Please press enter to continue...
```

#### Upgrade NuGet packages

Next, the tool updates the project's NuGet packages to the versions that support the updated TFM, `net6.0-windows`.

```
[16:47:47 INF] Applying upgrade step Update NuGet Packages
[16:47:47 INF] Removing outdated package reference: Microsoft.CSharp, Version=4.7.0
[16:47:47 INF] Removing outdated package reference: System.Data.DataSetExtensions, Version=4.5.0
[16:47:47 INF] Adding package reference: Microsoft.Windows.Compatibility, Version=6.0.0
[16:47:49 INF] Upgrade step Update NuGet Packages applied successfully
Please press enter to continue...
```

The next few steps may be skipped automatically by the tool if the tool determines there isn't anything to do for your project.

#### Windows Forms project specific updates

The first Windows Forms specific upgrade is to actually notify you that the default font in Windows Forms has changed. The default font has changed from **Microsoft Sans Serif, 8.25pt** (.NET Framework) to **Segoe UI, 9pt** (.NET 6 or later). For more information, see [What's new in Windows Forms: Default font](/dotnet/desktop/winforms/whats-new/net60?view=netdesktop-6.0&preserve-view=true#change-the-default-font). Because of this change, you'll want to review all of your forms and user controls. Changing the default font may affect the layout of the controls on your forms.

```
[16:48:45 INF] Applying upgrade step Default Font API Alert
[16:48:45 WRN] Default font in Windows Forms has been changed from Microsoft Sans Serif to Seg Segoe UI, in order to change the default font use the API - Application.SetDefaultFont(Font font). For more details see here - https://devblogs.microsoft.com/dotnet/whats-new-in-windows-forms-in-net-6-0-preview-5/#application-wide-default-font.
[16:48:45 INF] Upgrade step Default Font API Alert applied successfully
Please press enter to continue...
```

The next change for Windows Forms is to update the app startup logic to call the <xref:System.Windows.Forms.Application.SetHighDpiMode%2A> method, which sets the DPI mode of the Windows Forms application. Previously this was set in the _app.config_ or _app.manifest_ file. This too may affect the layout of the controls on your forms.

```
[16:49:05 INF] Applying upgrade step Winforms Source Updater
[16:49:05 WRN] HighDpiMode needs to set in Main() instead of app.config or app.manifest - Application.SetHighDpiMode(HighDpiMode.<setting>). It is recommended to use SystemAware as the HighDpiMode option for better results.
[16:49:05 INF] Updated Program.cs file at C:\code\Work\temp\Migration\winforms\net45cs\MatchingGame\Program.cs with HighDPISetting set to SystemAware
[16:49:05 INF] Upgrade step Winforms Source Updater applied successfully
[16:49:05 INF] Applying upgrade step Update Winforms Project
[16:49:05 INF] Upgrade step Update Winforms Project applied successfully
Please press enter to continue...
```

#### Config and code files

Next, the _app.config_ file needs to be migrated. There aren't any connection strings or settings to migrate to the new _appsettings.json_ file. If you examine the output of the example project, notice that the **Initializing** entry was displayed three times, each with a different step. If a step has nothing to do, it's skipped, as is the case with the "Upgrade app config files" and "Update source code" steps:

```
[07:35:56 INF] Initializing upgrade step Upgrade app config files
[07:35:56 INF] Found 0 app settings for upgrade:
[07:35:56 INF] Found 0 connection strings for upgrade:
[07:35:56 INF] Initializing upgrade step Update source code
[07:35:56 INF] Running analyzers on MatchingGame
[07:35:57 INF] Identified 0 diagnostics in project MatchingGame
[07:35:57 INF] Initializing upgrade step Move to next project
```

#### Completing the upgrade

If there are any more projects to migrate, the tool lets you select which project to upgrade next. When there are no more projects to upgrade, the tool brings you to the "Finalize upgrade" step:

```
1. [Next step] Finalize upgrade

Choose a command:
   1. Apply next step (Finalize upgrade)
   2. Skip next step (Finalize upgrade)
   3. See more step details
   4. Configure logging
   5. Exit
```

Once the upgrade is complete, the migrated Windows Forms project looks like the following XML:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net6.0-windows</TargetFramework>
    <OutputType>WinExe</OutputType>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <UseWindowsForms>true</UseWindowsForms>
    <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\MatchingGame.Logic\MatchingGame.Logic.csproj" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="MetroFramework" Version="1.2.0.3" />
    <PackageReference Include="Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers" Version="0.3.261602">
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.Windows.Compatibility" Version="6.0.0" />
  </ItemGroup>
</Project>
```

Notice that the .NET Upgrade Assistant also adds analyzers to the project that assist with continuing the upgrade process, such as the `Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers` NuGet package.

## Visual Basic projects

If you're using Visual Basic to code your project, the .NET Upgrade Assistant may contain additional steps, such as migrating the `My` namespace. You should only see these steps added when your project is using these features. With the example app, the code in the **MatchingGame.Logic** uses the `My` namespace to access the registry. This project will have a step related to `My`:

```
7. Update Visual Basic project
    a. Update vbproj to support "My." namespace
```

## After upgrading

After you upgrade your projects, you'll need to compile and test them. Most certainly you'll have more work to do in finishing the upgrade. It's possible that the .NET Framework version of your app contained library references that your project isn't actually using. You'll need to analyze each reference and determine whether or not it's required. The tool may have also added or upgraded a NuGet package reference to wrong version.

At the time this article was published, **MatchingGame.Logic** project fails to compile. This project is using the Windows Registry, which isn't provided directly by .NET 6 as it was with .NET Framework. To access the Windows Registry, add the NuGet package **Microsoft.Win32.Registry** to the project.

```xml
<PackageReference Include="Microsoft.Win32.Registry" Version="5.0.0" />
```

Once that item is fixed, the example app compiles and runs.

## Troubleshooting tips

There are several known problems that can occur when using the .NET Upgrade Assistant. In some cases, these are problems with the [try-convert tool](https://github.com/dotnet/try-convert) that the .NET Upgrade Assistant uses internally.

[The tool's GitHub repository](https://github.com/dotnet/upgrade-assistant#troubleshooting-common-issues) has more troubleshooting tips and known issues.

## See also

- [Upgrade a WPF App to .NET 6](upgrade-assistant-wpf-framework.md)
- [Upgrade an ASP.NET MVC App to .NET 6](upgrade-assistant-aspnetmvc.md)
- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)

[winforms-sample]: https://github.com/dotnet/samples/tree/main/windowsforms/matching-game

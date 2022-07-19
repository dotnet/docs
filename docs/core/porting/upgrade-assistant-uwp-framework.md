---
title: Upgrade UWP apps to .NET 6
description:  Use the .NET Upgrade Assistant to upgrade an existing .NET Framework UWP app to .NET 6. Your project will be migrated to the Windows App SDK, and WinUI 3. The .NET Upgrade Assistant is a CLI tool that helps migrating an app from .NET Framework to WinUI3.
author: adegeo
ms.date: 05/23/2022
---
# Migrate UWP apps to Windows App SDK with the .NET Upgrade Assistant

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with upgrading .NET Framework UWP apps to .NET 6. Your project will be migrated to the Windows App SDK, and use Windows UI (WinUI) 3. This article provides:

- What to expect
- Things to know before starting
- A demonstration of how to run the tool against a UWP app
- Troubleshooting tips

For more information on how to install the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

## What to expect

This tool migrates your app by:

- Backing up your project.
- Converts your project to the latest SDK format and cleans up your NuGet package references.
- Targets .NET 6 and Windows App SDK.
- Upgrades from WinUI 2 to WinUI 3.
- Adds new template files such as _App.Xaml_, _MainWindow.Xaml_ and publish profiles.
- Update namespaces and adds **MainPage** navigation.
- Attempts to detect and fix APIs that have changed, and marks APIs that are no longer supported, with `//TODO` code comments.

We aim to provide migration guidance in form of warning messages within the tool and TODO comments within your project as the tool tries to migrate the project. In this way, you'll always be in control of your migration. And for the APIs where complete automation isn't possible, plan is to add `//TODO` comments for the developers to know where the work will be needed. A typical `//TODO` comment will also include a link to our existing migration documentation. Check the Task list within the Visual Studio to see all the action items as TODO comments.

> [!NOTE]
> After a successful run of the tool, you may choose to do the following if needed: move your code from _App.xaml.old.cs_ to _App.xaml.cs_ and move AssemblyInfo.cs from backup

## Things to know before starting

This tool currently supports C#, and in most cases the app will require more effort to complete the migration. The goal of the tool is to convert your project and code, so that it can compile. Some features require you to investigate and fix, and have `//TODO` code comments. For more information about what to consider before migrating, see [What is supported when migrating from UWP to WinUI 3](/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/what-is-supported).

Additionally, you may choose to wait for the next version of .NET Upgrade Assistant tool before you start migrating your app, because of the current limitations of the tool:

- `ApplicationView` APIs aren't supported.
- `AppWindow` related APIs aren't supported.

  The upgrade tries to generate a warning where possible, and deliberately breaks your code so it doesn't compile until you adjust your code.

- Custom views aren't supported.

  For example, you won't receive a warning or a fix for a `CustomDialog` that extends `MessageDialog` and calls an API incorrectly.

- WinRT Components aren't supported.
- Multi window apps might not convert correctly.
- Apps that follow a nonstandard file structure (Such as _App.xaml_, _App.xaml.cs_ missing from the root folder) might not be converted correctly.

This release is currently in preview, and is receiving frequent updates. If you discover problems using the tool, report them in the tool's [GitHub repository](https://github.com/dotnet/upgrade-assistant). Use the **UWP** area tag so that all UWP related issues can be redirected to us.

> [!NOTE]
> You may also refer UWP migration guide [here](/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/migrate-to-windows-app-sdk-ovw) that will tell you more about the changes from UWP APIs to the new Windows App SDK supported APIs and capabilities.  

## A demonstration of how to run the tool against a UWP app

You can use the [PhotoLab UWP Sample app](https://github.com/microsoft/Windows-appsample-photo-lab.git) project to test upgrading with the Upgrade Assistant.

> [!NOTE]
> You may also want to see the manual migration of PhotoLab sample app as a case study documented [here](/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/case-study-1).

For the demo, we have a UWP sample app called "PhotoLab", which is an app for viewing and editing image files, demonstrating XAML layout, data binding, and UI customization features. The app will require more effort to complete the migration. This should be familiar if you've used .NET Upgrade Assistant in the past to migrate a WPF or WinForms app from .NET Framework to .NET 6. Now, run it against the PhotoLab app, which is .NET Native UWP project, and follow the steps one-by-one.

## Analyze your app

> [!NOTE]
> At the time of publishing this document, Analyze command is not working as it should. We are working to resolve the same. You may use the upgrade command without skipping the backup step.

The .NET Upgrade Assistant tool includes an analyze mode that performs a simplified dry run of upgrading your app. It may provide insights as to what changes may be required before the upgrade is started. Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant analyze` command, passing in the name of the project or solution you're upgrading.

For example, running the analyze mode with the [PhotoLab UWP Sample app](https://github.com/microsoft/Windows-appsample-photo-lab.git) produces the following output, indicating that there aren't any changes to be made before upgrading:

```console
> upgrade-assistant analyze .\PhotoLab.sln
 
[23:08:38 INF] Loaded 7 extensions
[23:08:53 INF] Using MSBuild from C:\Program Files\dotnet\sdk\6.0.200\
[23:08:53 INF] Using Visual Studio install from C:\Program Files\Microsoft Visual Studio\2022\Preview [v17]
[23:09:04 INF] Writing output to .\AnalysisReport.sarif
[23:09:04 INF] Skip minimum dependency check because Windows App SDK cannot work with targets lower than already recommended TFM.
[23:09:04 INF] Recommending Windows TFM net6.0-windows because the project either has Windows-specific dependencies or builds to a WinExe
[23:09:04 INF] Marking package Microsoft.NETCore.UniversalWindowsPlatform for removal based on package mapping configuration UWP
[23:09:04 INF] Adding package Microsoft.WindowsAppSDK based on package mapping configuration UWP
[23:09:04 INF] Adding package CommunityToolkit.WinUI.UI.Animations based on package mapping configuration UWP
[23:09:04 INF] Adding package Microsoft.Graphics.Win2D based on package mapping configuration UWP
[23:09:04 INF] Marking package Microsoft.Toolkit.Uwp.UI.Animations for removal based on package mapping configuration UWP
[23:09:04 INF] Marking package Microsoft.UI.Xaml for removal based on package mapping configuration UWP
[23:09:06 WRN] No version of Microsoft.Toolkit.Uwp.UI.Animations found that supports ["net6.0-windows"]; leaving unchanged
[23:09:07 INF] Package Microsoft.UI.Xaml, Version=2.4.2 does not support the target(s) net6.0-windows but a newer version (2.7.1) does.
[23:09:09 INF] Package Microsoft.WindowsAppSDK, Version=1.0.0 does not support the target(s) net6.0-windows but a newer version (1.0.3) does.
[23:09:10 WRN] No version of CommunityToolkit.WinUI.UI.Animations found that supports ["net6.0-windows"]; leaving unchanged
[23:09:11 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.3.326103) needs to be added
[23:09:13 INF] Adding Microsoft.Windows.Compatibility 6.0.0 helps with speeding up the upgrade process for Windows-based APIs
[23:09:14 WRN] Unable to find a supported WinUI nuget package for Microsoft.Toolkit.Uwp.UI.Animations. Skipping this package.
[23:09:16 INF] Running analyzers on PhotoLab
[23:09:25 INF] Identified 7 diagnostics in project PhotoLab
[23:09:25 INF] Diagnostic UA307 with the message Detect UWP back button generated
[23:09:25 INF] Diagnostic UA307 with the message Detect UWP back button generated
[23:09:25 INF] Diagnostic UA309 with the message Detect content dialog api generated
[23:09:25 INF] Diagnostic UA307 with the message Detect UWP back button generated
[23:09:25 INF] Diagnostic UA307 with the message Detect UWP back button generated
[23:09:25 INF] Diagnostic UA309 with the message Detect content dialog api generated
[23:09:25 INF] Diagnostic UA310 with the message Tries to detect the creation of known classes that implement IInitializeWithWindow generated
[23:09:25 INF] Analysis Complete, the report is available at .\AnalysisReport.sarif
```

There's quite a bit of internal diagnostic information in the output, but some information is helpful. Notice that the analyze mode indicates that the upgrade will recommend that the project target the `net6.0-windows` target framework moniker ([TFM](../../standard/frameworks.md)). A console application would probably get the recommendation to upgrade to TFM `net6.0` directly, unless it used some Windows-specific libraries.

If any errors or warnings are reported, take care of them before you start an upgrade.

## Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant upgrade` command, passing in the name of the project or solution you're upgrading.

When a project is provided, the upgrade process starts on that project immediately. If a solution is provided, you'll select which project you normally run, known as the upgrade entrypoint. Based on that project, a dependency graph is created and a suggestion as to which order you should upgrade the projects is provided.

```console
upgrade-assistant upgrade .\PhotoLab.sln
```

The tool runs and shows you a list of the steps it will do. As each step is completed, the tool provides a set of commands allowing the user to apply or skip the next step or some other option such as:

- Get more information about the step.
- Change projects.
- Adjust logging settings.
- Stop the upgrade and quit.

Pressing <kbd>Enter</kbd> without choosing a number selects the first item in the list.

As each step initializes, it may provide information about what it thinks will happen if you apply the step.

### Select the entrypoint and project to upgrade

The first step in upgrading the [PhotoLab UWP Sample app](https://github.com/microsoft/Windows-appsample-photo-lab.git) is choosing which project in the solution serves as the entrypoint project. You may notice that there's only one entrypoint, this is because there's only one project in this solution.

```
[23:29:49 INF] Loaded 7 extensions
[23:29:52 INF] Using MSBuild from C:\Program Files\dotnet\sdk\6.0.200\
[23:29:52 INF] Using Visual Studio install from C:\Program Files\Microsoft Visual Studio\2022\Preview [v17]
[23:30:01 INF] Initializing upgrade step Select an entrypoint
[23:30:01 INF] Setting entrypoint to only project in solution: .\source\repos\Windows-appsample-photo-lab\PhotoLab\PhotoLab.csproj
[23:30:01 INF] Initializing upgrade step Select project to upgrade
[23:30:04 INF] Initializing upgrade step Back up project
Upgrade Steps

```

After the entrypoint is determined, the next step is to choose which project to upgrade first. However, in this example, the tool determined that there's only one project within the solution, and it should begin upgrading that project.

### Upgrade the project

Once a project is selected, a list of upgrade steps the tool will take is listed.

> [!IMPORTANT]
> Based on the project you're upgrading, you may or may not see every step listed in this example.

The following output describes the steps involved in upgrading the project:

```
[23:30:04 INF] Initializing upgrade step Back up project

Upgrade Steps

Entrypoint: .\source\repos\Windows-appsample-photo-lab\PhotoLab\PhotoLab.csproj
Current Project: .\source\repos\Windows-appsample-photo-lab\PhotoLab\PhotoLab.csproj

1. [Next step] Back up project
2. Convert project file to SDK style
3. Clean up NuGet package references
    a. Duplicate reference analyzer
    b. Package map reference analyzer
    c. Target compatibility reference analyzer
    d. Upgrade assistant reference analyzer
    e. Windows Compatibility Pack Analyzer
    f. MyDotAnalyzer reference analyzer
    g. Newtonsoft.Json reference analyzer
    h. Windows App SDK package analysis
    i. Transitive reference analyzer
4. Update TFM
5. Update NuGet Packages
    a. Duplicate reference analyzer
    b. Package map reference analyzer
    c. Target compatibility reference analyzer
    d. Upgrade assistant reference analyzer
    e. Windows Compatibility Pack Analyzer
    f. MyDotAnalyzer reference analyzer
    g. Newtonsoft.Json reference analyzer
    h. Windows App SDK package analysis
    i. Transitive reference analyzer
6. Add template files
7. Update Windows Desktop Project
    a. Update WinUI namespaces
    b. Update WinUI Project Properties
    c. Update package.appxmanifest
    d. Remove unnecessary files
    e. Update animations xaml
    f. Insert back button in XAML
8. Update source code
    a. Apply fix for UA0002: Types should be upgraded
    b. Apply fix for UA0012: 'UnsafeDeserialize()' does not exist
    c. Apply fix for UA0014: .NET MAUI projects should not reference Xamarin.Forms namespaces
    d. Apply fix for UA0015: .NET MAUI projects should not reference Xamarin.Essentials namespaces
    e. Apply fix for [UA306_A1, UA306_A2, UA306_A3, UA306_A4, UA306_B, UA306_C, UA306_D, UA306_E, UA306_F, UA306_G, UA306_H, UA306_I]: Replace usage of Windows.UI.Core.CoreDispatcher, Replace usage of Window.Current.Dispatcher, Replace usage of App.Window.Dispatcher, Replace usage of Window.Dispatcher, Replace usage of Windows.Media.Capture.CameraCaptureUI, Replace usage of Micorsoft.UI.Xaml.Controls.InkCanvas, Replace usage of Microsoft.UI.Xaml.Controls.Maps.MapControl, Replace usage of Microsoft.UI.Xaml.Controls.MediaElement, Replace usage of Windows.Graphics.Printing.PrintManager, Replace usage of Windows.Security.Authentication.Web.WebAuthenticationBroker, Replace usage of Windows.UI.Xaml.Media.AcrylicBrush.BackgroundSource, Replace usage of Windows.UI.Shell.TaskbarManager
    f. Apply fix for UA307: Custom back button implementation is needed
    g. Apply fix for UA309: ContentDialog API needs to set XamlRoot
    h. Apply fix for UA310: Classes that implement IInitializeWithWindow need to be initialized with Window Handle
    i. Apply fix for UA311: Classes that implement IDataTransferManager should use IDataTransferManagerInterop.ShowShareUIForWindow
    j. Apply fix for UA312: Interop APIs should use the window handle
    k. Apply fix for [UA313, UA314]: MRT to MRT core migration, MRT to MRT core migration
    l. Apply fix for [UA315_A, UA315_C, UA315_B]: Windows App SDK apps should use Microsoft.UI.Windowing.AppWindow, Windows App SDK apps should use Microsoft.UI.Windowing.AppWindow, Windows App SDK apps should use Microsoft.UI.Windowing.AppWindow
9. Move to next project

Choose a command:
   1. Apply next step (Back up project)
   2. Skip next step (Back up project)
   3. See more step details
   4. Configure logging
   5. Exit
```

#### Upgrade the project file

The project is upgraded from the .NET Framework project format to the .NET SDK project format.

```
[02:14:51 INF] Applying upgrade step Convert project file to SDK style
[02:14:52 INF] Converting project file format with try-convert, version 0.9.0-dev
[02:14:54 INF] Skip minimum dependency check because Windows App SDK cannot work with targets lower than already recommended TFM.
[02:14:54 INF] Recommending Windows TFM net6.0-windows because the project either has Windows-specific dependencies or builds to a WinExe
[02:14:56 INF] Converting project .\source\repos\Windows-appsample-photo-lab\PhotoLab\PhotoLab.csproj to SDK style
[02:14:58 INF] Project file converted successfully! The project may require additional changes to build successfully against the new .NET target.
[02:15:01 INF] Upgrade step Convert project file to SDK style applied successfully
```

Pay attention to the output of each step. The tool will indicate a message and you may need to make changes manually from this step onwards.

#### Clean up NuGet references

Once the project format has been updated, the next step is to clean up the NuGet package references.

In addition to the packages referenced by your app, the _packages.config_ file contains references to the dependencies of those packages. For example, if you added reference to package **A** which depends on package **B**, both packages would be referenced in the _packages.config_ file. In the new project system, only the reference to package **A** is required. This step analyzes the package references and removes those that aren't required.

```
[02:18:32 INF] Initializing upgrade step Clean up NuGet package references
[02:18:32 INF] Initializing upgrade step Duplicate reference analyzer
[02:18:32 INF] No package updates needed
[02:18:32 INF] Initializing upgrade step Package map reference analyzer
[02:18:32 INF] Marking package Microsoft.NETCore.UniversalWindowsPlatform for removal based on package mapping configuration UWP
[02:18:32 INF] Adding package Microsoft.WindowsAppSDK based on package mapping configuration UWP
[02:18:32 INF] Adding package CommunityToolkit.WinUI.UI.Animations based on package mapping configuration UWP
[02:18:32 INF] Adding package Microsoft.Graphics.Win2D based on package mapping configuration UWP
[02:18:32 INF] Marking package Microsoft.Toolkit.Uwp.UI.Animations for removal based on package mapping configuration UWP
[02:18:32 INF] Marking package Microsoft.UI.Xaml for removal based on package mapping configuration UWP

[02:19:04 INF] Applying upgrade step Remove package 'Microsoft.NETCore.UniversalWindowsPlatform'
[02:19:04 INF] Removing outdated package reference: Microsoft.NETCore.UniversalWindowsPlatform, Version=5.3.3
[02:19:04 INF] Upgrade step Remove package 'Microsoft.NETCore.UniversalWindowsPlatform' applied successfully


[02:20:34 INF] Applying upgrade step Remove package 'Microsoft.Toolkit.Uwp.UI.Animations'
[02:20:34 INF] Removing outdated package reference: Microsoft.Toolkit.Uwp.UI.Animations, Version=1.5.1
[02:20:34 INF] Upgrade step Remove package 'Microsoft.Toolkit.Uwp.UI.Animations' applied successfully

[02:21:38 INF] Removing outdated package reference: Microsoft.UI.Xaml, Version=2.4.2
[02:21:38 INF] Upgrade step Remove package 'Microsoft.UI.Xaml' applied successfully

[02:22:13 INF] Adding package reference: Microsoft.WindowsAppSDK, Version=1.0.0
[02:22:13 INF] Upgrade step Add package 'Microsoft.WindowsAppSDK' applied successfully

[02:22:13 INF] Adding package reference: Microsoft.WindowsAppSDK, Version=1.0.0
[02:22:13 INF] Upgrade step Add package 'Microsoft.WindowsAppSDK' applied successfully
Please press enter to continue...

[02:23:04 INF] Adding package reference: CommunityToolkit.WinUI.UI.Animations, Version=7.1.2
[02:23:04 INF] Upgrade step Add package 'CommunityToolkit.WinUI.UI.Animations' applied successfully

[02:23:42 INF] Adding package reference: Microsoft.Graphics.Win2D, Version=1.0.0.30
[02:23:42 INF] Upgrade step Add package 'Microsoft.Graphics.Win2D' applied successfully

[02:23:42 INF] Applying upgrade step Package map reference analyzer
[02:23:42 INF] Upgrade step Package map reference analyzer applied successfully

[02:24:22 INF] Initializing upgrade step Target compatibility reference analyzer
[02:24:22 INF] No package updates needed
[02:24:22 INF] Initializing upgrade step Upgrade assistant reference analyzer
[02:24:23 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.3.326103) needs to be added
[02:24:23 INF] Initializing upgrade step Add package 'Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers'

[02:28:38 INF] Applying upgrade step Add package 'Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers'
[02:28:38 INF] Adding package reference: Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, Version=0.3.326103
[02:28:38 INF] Upgrade step Add package 'Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers' applied successfully
[02:28:38 INF] Applying upgrade step Upgrade assistant reference analyzer
[02:28:38 INF] Upgrade step Upgrade assistant reference analyzer applied successfully
[02:28:52 INF] Applying upgrade step Add package 'Microsoft.Windows.Compatibility'
[02:28:52 INF] Adding package reference: Microsoft.Windows.Compatibility, Version=6.0.0
[02:28:52 INF] Upgrade step Add package 'Microsoft.Windows.Compatibility' applied successfully
[02:28:52 INF] Applying upgrade step Windows Compatibility Pack Analyzer
[02:28:52 INF] Upgrade step Windows Compatibility Pack Analyzer applied successfully
[02:29:06 INF] Initializing upgrade step MyDotAnalyzer reference analyzer
[02:29:06 INF] No package updates needed
[02:29:06 INF] Initializing upgrade step Newtonsoft.Json reference analyzer
[02:29:06 INF] No package updates needed
[02:29:06 INF] Initializing upgrade step Windows App SDK package analysis
[02:29:06 INF] No package updates needed
[02:29:06 INF] Initializing upgrade step Transitive reference analyzer
[02:29:06 INF] No package updates needed
[02:29:06 INF] Applying upgrade step Clean up NuGet package references
[02:29:06 INF] Upgrade step Clean up NuGet package references applied successfully
```

Your app is still referencing .NET Framework assemblies. Some of those assemblies may be available as NuGet packages. This step analyzes those assemblies and references the appropriate NuGet package.

In this example, a user may also see app specific reference such as Microsoft.Toolkit.Uwp.UI.Animations, `CommunityToolkit.WinUI.UI.Animations` and `Microsoft.Graphics.Win2D`.

#### Handle the TFM

The tool next changes the [TFM](../../standard/frameworks.md) from .NET Framework to the suggested SDK. In this example, it's `net6.0-windows`.

```
[02:29:06 INF] Initializing upgrade step Update TFM
[02:29:06 INF] Skip minimum dependency check because Windows App SDK cannot work with targets lower than already recommended TFM.
[02:29:06 INF] Recommending Windows TFM net6.0-windows10.0.19041 because the project either has Windows-specific dependencies or builds to a WinExe
```

#### Upgrade NuGet packages

Next, the tool updates the project's NuGet packages to the versions that support the updated TFM, `net6.0-windows`.

```
[02:29:06 INF] Initializing upgrade step Update NuGet Packages
[02:29:06 INF] Initializing upgrade step Duplicate reference analyzer
[02:29:06 INF] No package updates needed
[02:29:06 INF] Initializing upgrade step Package map reference analyzer
[02:29:06 INF] No package updates needed
[02:29:06 INF] Initializing upgrade step Target compatibility reference analyzer
[02:29:06 INF] No package updates needed
[02:29:06 INF] Initializing upgrade step Upgrade assistant reference analyzer
[02:29:06 INF] No package updates needed
[02:29:06 INF] Initializing upgrade step Windows Compatibility Pack Analyzer
[02:29:07 INF] No package updates needed
[02:29:07 INF] Initializing upgrade step MyDotAnalyzer reference analyzer
[02:29:07 INF] No package updates needed
[02:29:07 INF] Initializing upgrade step Newtonsoft.Json reference analyzer
[02:29:07 INF] No package updates needed
[02:29:07 INF] Initializing upgrade step Windows App SDK package analysis
[02:29:07 INF] No package updates needed
[02:29:07 INF] Initializing upgrade step Transitive reference analyzer
[02:29:07 INF] No package updates needed
[02:29:07 INF] Applying upgrade step Update NuGet Packages
[02:29:07 INF] Upgrade step Update NuGet Packages applied successfully
```

#### Templates, config, and code files

The next few steps may be skipped automatically by the tool if the tool determines there isn't anything to do for your project.

Once the packages are updated, the next step is to update any template files. In this example, the tool automatically adds necessary publish profiles, _App.xaml.cs_, _MainWindow.xaml.cs_, _MainWindow.xaml_ etc.

```
[02:32:44 INF] Applying upgrade step Add template files
[02:32:44 INF] Added template file app.manifest
[02:32:44 INF] Added template file Properties\launchSettings.json
[02:32:44 INF] Added template file Properties\PublishProfiles\win10-arm64.pubxml
[02:32:44 INF] Added template file Properties\PublishProfiles\win10-x64.pubxml
[02:32:44 INF] Added template file Properties\PublishProfiles\win10-x86.pubxml
[02:32:44 INF] File already exists, moving App.xaml.cs to App.xaml.old.cs
[02:32:44 INF] Added template file App.xaml.cs
[02:32:44 INF] Added template file MainWindow.xaml.cs
[02:32:44 INF] Added template file MainWindow.xaml
[02:32:44 INF] Added template file UWPToWinAppSDKUpgradeHelpers.cs
[02:32:44 INF] 9 template items added
[02:32:44 INF] Upgrade step Add template files applied successfully
```

#### UWP specific changes

The next step for the tool is to update the UWP app to the new Windows Desktop Project.

> [!IMPORTANT]
> You may choose to skip the step for back button insertion as per your wish. Inserting back button may cause the UI to behave differently. If this happens, remove the stack panel that is inserted as a parent of the back button and reposition the back button where it seems .

```
[02:36:53 INF] Applying upgrade step Update WinUI namespaces
[02:36:53 INF] Upgrade step Update WinUI namespaces applied successfully

[02:38:45 INF] Applying upgrade step Update WinUI Project Properties
[02:38:46 INF] Upgrade step Update WinUI Project Properties applied successfully

[02:39:11 INF] Applying upgrade step Update package.appxmanifest
[02:39:11 INF] Upgrade step Update package.appxmanifest applied successfully

[02:39:11 INF] Applying upgrade step Update package.appxmanifest
[02:39:11 INF] Upgrade step Update package.appxmanifest applied successfully

[02:39:37 INF] Applying upgrade step Remove unnecessary files
[02:39:37 INF] Deleting .\source\repos\Windows-appsample-photo-lab\PhotoLab\Properties\AssemblyInfo.cs as it is not required for Windows App SDK projects.
[02:39:37 INF] Upgrade step Remove unnecessary files applied successfully

[02:40:22 INF] Applying upgrade step Update animations xaml
[02:40:22 INF] Upgrade step Update animations xaml applied successfully

[02:40:42 INF] Applying upgrade step Insert back button in XAML
[02:40:42 INF] Upgrade step Insert back button in XAML applied successfully
[02:40:42 INF] Applying upgrade step Update Windows Desktop Project
[02:40:42 INF] Upgrade step Update Windows Desktop Project applied successfully
```

#### Updating the source code

In this step, the tool will try to migrate your code and perform source specific code changes.

Code migration for the PhotoLab sample app includes:

- Changes to Content Dialog and File Save picker APIs.
- Xaml update for Animations package.
- Showing warning messages and adding TODO comments in _DetailPage.xaml_ and _DetailPage.xaml.cs_ and _MainPage.xaml.cs_ for custom back button.
- Implementing the back button functionality and adding a TODO comment to customize XAML button.
- A documentation link can be accessed from the CLI tool to study more about for back button implementation.

```
[02:41:34 INF] Applying upgrade step Apply fix for UA307: Custom back button implementation is needed
[02:41:34 WRN] .\source\repos\Windows-appsample-photo-lab\PhotoLab\MainPage.xaml.cs
            TODO UA307 Default back button in the title bar does not exist in WinUI3 apps.
            The tool has generated a custom back button "UAGeneratedBackButton" in the XAML file.
            Feel free to edit its position, behavior and use the custom back button instead.
            Read: https://aka.ms/UA-back-button
[02:41:34 INF] Diagnostic UA307 fixed in .\source\repos\Windows-appsample-photo-lab\PhotoLab\MainPage.xaml.cs
[02:41:34 WRN] .\source\repos\Windows-appsample-photo-lab\PhotoLab\DetailPage.xaml.cs
            TODO UA307 Default back button in the title bar does not exist in WinUI3 apps.
            The tool has generated a custom back button "UAGeneratedBackButton" in the XAML file.
            Feel free to edit its position, behavior and use the custom back button instead.
            Read: https://aka.ms/UA-back-button
[02:41:34 INF] Diagnostic UA307 fixed in .\source\repos\Windows-appsample-photo-lab\PhotoLab\DetailPage.xaml.cs
[02:41:34 INF] Running analyzers on PhotoLab
[02:41:37 INF] Identified 4 diagnostics in project PhotoLab
[02:41:37 WRN] .\source\repos\Windows-appsample-photo-lab\PhotoLab\DetailPage.xaml.cs
            TODO UA307 Default back button in the title bar does not exist in WinUI3 apps.
            The tool has generated a custom back button "UAGeneratedBackButton" in the XAML file.
            Feel free to edit its position, behavior and use the custom back button instead.
            Read: https://aka.ms/UA-back-button
[02:41:37 INF] Diagnostic UA307 fixed in .\source\repos\Windows-appsample-photo-lab\PhotoLab\DetailPage.xaml.cs
[02:41:37 INF] Running analyzers on PhotoLab
[02:41:39 INF] Identified 3 diagnostics in project PhotoLab
[02:41:39 INF] Upgrade step Apply fix for UA307: Custom back button implementation is needed applied successfully

[02:45:20 INF] Applying upgrade step Apply fix for UA309: ContentDialog API needs to set XamlRoot
[02:45:20 INF] Diagnostic UA309 fixed in .\source\repos\Windows-appsample-photo-lab\PhotoLab\DetailPage.xaml.cs
[02:45:20 INF] Diagnostic UA309 fixed in .\source\repos\Windows-appsample-photo-lab\PhotoLab\MainPage.xaml.cs
[02:45:20 INF] Running analyzers on PhotoLab
[02:45:23 INF] Identified 1 diagnostics in project PhotoLab
[02:45:23 INF] Upgrade step Apply fix for UA309: ContentDialog API needs to set XamlRoot applied successfully

[02:45:52 INF] Applying upgrade step Apply fix for UA310: Classes that implement IInitializeWithWindow need to be initialized with Window Handle
[02:45:52 INF] Diagnostic UA310 fixed in ..\source\repos\Windows-appsample-photo-lab\PhotoLab\DetailPage.xaml.cs
[02:45:52 INF] Running analyzers on PhotoLab
[02:45:54 INF] Identified 0 diagnostics in project PhotoLab
[02:45:54 INF] Applying upgrade step Update source code
[02:46:00 INF] Upgrade step Update source code applied successfully
[02:46:00 INF] Upgrade step Apply fix for UA310: Classes that implement IInitializeWithWindow need to be initialized with Window Handle applied successfully
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
>
[02:47:13 INF] Applying upgrade step Finalize upgrade
[02:47:13 INF] Upgrade step Finalize upgrade applied successfully
```

Ideally, after successfully running the tool, the user should be able to F5 and run their new WinUI3 desktop project of PhotoLab app. Once the upgrade is complete, the migrated UWP project looks like the following XML:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net6.0-windows10.0.19041.0</TargetFramework>
    <Platform Condition=" '$(Platform)' == '' ">x86</Platform>
    <OutputType>WinExe</OutputType>
    <DefaultLanguage>en-US</DefaultLanguage>
    <TargetPlatformMinVersion>10.0.17763.0</TargetPlatformMinVersion>
    <RuntimeIdentifiers>win10-x86;win10-x64;win10-arm64</RuntimeIdentifiers>
    <UseWinUI>true</UseWinUI>
    <ApplicationManifest>app.manifest</ApplicationManifest>
    <EnablePreviewMsixTooling>true</EnablePreviewMsixTooling>
    <Platforms>x86;x64;arm64</Platforms>
    <PublishProfile>win10-$(Platform).pubxml</PublishProfile>
  </PropertyGroup>
  <ItemGroup>
    <AppxManifest Include="Package.appxmanifest">
      <SubType>Designer</SubType>
    </AppxManifest>
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.WindowsAppSDK" Version="1.0.0" />
    <PackageReference Include="CommunityToolkit.WinUI.UI.Animations" Version="7.1.2" />
    <PackageReference Include="Microsoft.Graphics.Win2D" Version="1.0.0.30" />
    <PackageReference Include="Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers" Version="0.3.326103">
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.Windows.Compatibility" Version="6.0.0" />
  </ItemGroup>
  <ItemGroup>
    <Compile Remove="App.xaml.old.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.xaml.old.cs" />
  </ItemGroup>
</Project>
```

Notice that the .NET Upgrade Assistant also adds analyzers to the project that assist with continuing the upgrade process, such as the `Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers` NuGet package.

Also notice that it's using Windows App SDK, WinUI3, and .NET 6. And now, you can take advantage of all new features that modern apps have to offer and grow your app with the platform.

## After upgrading

After you upgrade your projects, you'll need to compile and test them. Most certainly you'll have more work to do in finishing the upgrade. All TODO comments and action items can be seen on the Task List inside the Visual Studio. To open the Task List, press **View** > **TaskList**. It's possible that the .NET Framework version of your app contained library references that your project isn't actually using. You'll need to analyze each reference and determine whether or not it's required. The tool may have also added or upgraded a NuGet package reference to wrong version.

## Troubleshooting tips

There are several known problems that can occur when using the .NET Upgrade Assistant. In some cases, these problems are with the [try-convert tool](https://github.com/dotnet/try-convert) that the .NET Upgrade Assistant uses internally.

[The tool's GitHub repository](https://github.com/dotnet/upgrade-assistant#troubleshooting-common-issues) has more troubleshooting tips and known issues.

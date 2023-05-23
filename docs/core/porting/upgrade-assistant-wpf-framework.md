---
title: Upgrade WPF apps to .NET 7
description: Use the .NET Upgrade Assistant to upgrade an existing .NET Framework WPF app to .NET 7. The .NET Upgrade Assistant is a CLI tool that helps migrating an app from .NET Framework to .NET 7.
author: adegeo
ms.date: 03/04/2023
---
# Upgrade a WPF App to .NET 7 with the .NET Upgrade Assistant

> [!IMPORTANT]
> This article was written before the release of the Upgrade Asstant extension for Visual Studio. The CLI version of the tool used in this article may be out of date. The article will be updated after the Microsoft Build 2023 conference.

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with upgrading .NET Framework WPF apps to .NET 7. This article provides:

- An overview of how the tool works with WPF projects
- A sample app for you to download and upgrade
- Troubleshooting tips

For more information on how to install the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

> [!TIP]
> The .NET Upgrade Assistant is receiving frequent updates. If you discover problems using the tool, report them in the tool's [GitHub repository](https://github.com/dotnet/upgrade-assistant).

## Demo app

You can use the [Basic WPF Sample][wpf-sample] project to test upgrading with the Upgrade Assistant.

## Analyze your app

The .NET Upgrade Assistant tool includes an analyze mode that performs a simplified dry run of upgrading your app. It may provide insights as to what changes may be required before the upgrade is started. Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant analyze` command, passing in the name of the project or solution you're upgrading.

For example, running the analyze mode with the [Basic WPF Sample][wpf-sample] app produces the following output, indicating that there aren't any changes to be made before upgrading:

```console
> upgrade-assistant analyze .\WebSiteRatings.sln

[15:39:00 INF] Loaded 9 extensions
[15:39:02 INF] Using MSBuild from C:\Program Files\dotnet\sdk\7.0.201\
[15:39:02 INF] Using Visual Studio install from C:\Program Files\Microsoft Visual Studio\2022\Preview [v17]
[15:39:05 INF] Writing output to C:\code\migration\AnalysisReport.sarif
[15:39:06 INF] Recommending Windows TFM net7.0-windows for project WebSiteRatings.csproj because the project either has Windows-specific dependencies or builds to a WinExe
[15:39:06 INF] Marking assembly reference System.Configuration for removal based on package mapping configuration System.Configuration
[15:39:06 INF] Adding package System.Configuration.ConfigurationManager based on package mapping configuration System.Configuration
[15:39:08 INF] Package EntityFramework, Version=6.2.0 does not support the target(s) net7.0-windows but a newer version (6.4.4) does.
[15:39:09 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.4.410601) needs to be added
[15:39:10 INF] Adding Microsoft.Windows.Compatibility 7.0.0 helps with speeding up the upgrade process for Windows-based APIs
[15:39:13 INF] Recommending Windows TFM net7.0-windows for project StarVoteControl.csproj because the project either has Windows-specific dependencies or builds to a WinExe
[15:39:13 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.4.410601) needs to be added
[15:39:13 INF] Adding Microsoft.Windows.Compatibility 7.0.0 helps with speeding up the upgrade process for Windows-based APIs
[15:39:13 INF] Running analyzers on WebSiteRatings
[15:39:14 INF] Identified 0 diagnostics in project WebSiteRatings
[15:39:14 INF] Running analyzers on StarVoteControl
[15:39:15 INF] Identified 0 diagnostics in project StarVoteControl
[15:39:15 INF] Analysis Complete, the report is available at C:\code\migration\AnalysisReport.sarif
```

There's quite a bit of internal diagnostic information in the output, but some information is helpful. Notice that the analyze mode indicates that the upgrade recommends that the project target the `net7.0-windows` target framework moniker ([TFM](../../standard/frameworks.md)). This recommendation is made because the projects referenced by the solution are WPF projects, a Windows-only technology. A console application would probably get the recommendation to upgrade to TFM `net7.0` directly, unless it used some Windows-specific libraries.

If any errors or warnings are reported, take care of them before you start an upgrade.

## Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant upgrade` command, passing in the name of the project or solution you're upgrading.

When you upgrade a solution that contains multiple projects, you must select which project in the solution is the **entrypoint**. Based on the **entrypoint** project, a dependency graph is created to determine which projects to upgrade and in what order. If the solution contains projects that aren't a part of the dependency graph, they're ignored and you'll need to upgrade these projects separately.

Dependencies are upgraded first, then the **entrypoint** project.

Using the [Basic WPF Sample][wpf-sample] app, upgrade the solution file:

```console
upgrade-assistant upgrade .\WebSiteRatings.sln
```

The tool runs and displays a list of steps it will perform. As each step is completed, the tool provides a set of commands allowing the user to apply or skip the next step or some other option such as:

- Get more information about the step.
- Change projects.
- Adjust logging settings.
- Stop the upgrade and quit.

Pressing <kbd>Enter</kbd> without choosing a number selects the first item in the list.

As each step initializes, it may provide information about what it thinks will happen if you apply the step. The next step is to choose which project to upgrade. You should see the following output:

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

> [!TIP]
> Pay attention to the output of each step, as it may contain information about something the tool can't upgrade. Depending on the complexity of your app, you may have more upgrade work to do after the tool is finished.

## Select a project to upgrade

After the entrypoint is determined, the next step is to choose which project to upgrade. With the [Basic WPF Sample][wpf-sample] app, the tool determined that the **StarVoteControl** project first, since the **WebSiteRatings** project depends on it. It's best to follow the recommended upgrade path.

```
[15:45:52 INF] Applying upgrade step Select project to upgrade
Here is the recommended order to upgrade. Select enter to follow this list, or input the project you want to start with.
   1. StarVoteControl
   2. WebSiteRatings
```

## Upgrade the project

Once a project is selected, a list of upgrade steps the tool takes is listed. The first step is selected, which is to back up the project. The list of steps looks similar to the following snippet:

```
[15:50:50 INF] Initializing upgrade step Back up project

Upgrade Steps

Entrypoint: C:\code\migration\WebSiteRatings\WebSiteRatings.csproj
Current Project: C:\code\migration\WebSiteRatings\WebSiteRatings.csproj

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
7. Update WCF service to CoreWCF (Preview)
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

Each step details first what it's going to do, then prompts you to do it. For example, the previous snippet was at step **1. [Next step] Back up project**. Any step that doesn't apply, is skipped. For example, if the tool processes **7. Update WCF service to CoreWCF (Preview)**, but your app doesn't define a WCF service, it's skipped and step 8 is processed. In turn, if step 8 doesn't apply, it's skipped too. You may see many steps skipped as the tool tries to find the next step that applies.

## Complete the upgrade

Once the project has been upgraded, the tool prompts you to select the next project in the dependency graph to upgrade. Once all projects are upgraded, the tool you to the "Finalize upgrade" step, which completes the upgrade

```
1. [Next step] Finalize upgrade

Choose a command:
   1. Apply next step (Finalize upgrade)
   2. Skip next step (Finalize upgrade)
   3. See more step details
   4. Configure logging
   5. Exit
```

Once the upgrade is complete, the migrated WPF project looks like the following XML:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net7.0-windows</TargetFramework>
    <OutputType>WinExe</OutputType>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <UseWPF>true</UseWPF>
    <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>
  </PropertyGroup>
  <ItemGroup>
    <None Update="sqlite.db">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\StarVoteControl\StarVoteControl.csproj" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="System.Data.DataSetExtensions" Version="4.5.0" />
    <PackageReference Include="System.Configuration.ConfigurationManager" Version="5.0.0" />
    <PackageReference Include="Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers" Version="0.4.410601">
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="EntityFramework" Version="6.4.4" />
  </ItemGroup>
  <ItemGroup>
    <Service Include="{508349B6-6B84-4DF5-91F0-309BEEBAD82D}" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="MahApps.Metro" Version="2.4.9" />
    <PackageReference Include="Microsoft.Data.Sqlite" Version="1.0.0" />
    <PackageReference Include="SQLite" Version="3.12.3" />
  </ItemGroup>
  <ItemGroup>
    <Content Include="appsettings.json" />
  </ItemGroup>
</Project>
```

Notice that the .NET Upgrade Assistant also adds analyzers to the project that assist with continuing the upgrade process, such as the `Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers` NuGet package.

## After upgrading

After you upgrade your projects, you'll need to compile and test them. Most likely there is more work to do to finish the upgrade. It's possible that the .NET Framework version of your app contained library references that your project isn't actually using. Analyze each reference and determine whether or not it's required. The tool may have also added or upgraded a NuGet package reference to wrong version.

At the time this article was published, the following updates are needed to complete the upgrade of the example project:

- Upgrade the `System.Configuration.ConfigurationManager` NuGet package to version **7.0.0**.

  The wrong version (**5.0.0**) was selected by the upgrade tool:

  ```xml
  <PackageReference Include="System.Configuration.ConfigurationManager" Version="7.0.0" />
  ```

- Upgrade the `Microsoft.Data.Sqlite` NuGet package to version **7.0.3**.

  Upgrading this package isn't required. However, version **1.0.0** was selected, which is the last version supporting .NET Framework directly, and supports .NET Standard 1.3. This package has a dependency on the `SQLite` package, and is currently deprecated. If `Microsoft.Data.Sqlite` is upgraded to **7.0.3**, that dependency is removed and the project is using a supported package version.

  After the `Microsoft.Data.Sqlite` package is upgraded to **7.0.3**, you can remove the `SQLite` package from the project.

## Modernize: appsettings.json

.NET Framework uses the _App.config_ file to load settings for your app, such as connection strings and logging providers. .NET now uses the _appsettings.json_ file for app settings. The upgrade tool tries its best to migrate settings and connections strings from the _App.config_ file to the _appsettings.json_ file, but make sure you compare them and verify that everything is correct.

Even though _appsettings.json_ is the modern way to store and retrieve settings and connection strings, your code isn't using it and is still relying on the _App.config_ file. _App.config_ files are supported in .NET through the `System.Configuration.ConfigurationManager` NuGet package, and support for _appsettings.json_ is provided by the `Microsoft.Extensions.Configuration` NuGet package.

As other libraries upgrade to .NET, they modernize by supporting _appsettings.json_ instead of _App.config_. For example, logging providers in .NET Framework that have been upgraded for .NET 6+ no longer use _App.config_ for settings. It's good for you to follow their direction and also move away from using _App.config_.

### Use appsettings.json with the WPF sample app

As an example, after upgrading the [WPF sample app][wpf-sample], remove the dependency on `System.Configuration.ConfigurationManager` and move to _appsettings.json_ for the connection string used by the local database.

01. Remove the `System.Configuration.ConfigurationManager` NuGet package.
01. Add the `Microsoft.Extensions.Configuration.Json` NuGet package.
01. Delete the _App.config_ file from the project.

    In the example app, this file only contained a single connection string, which was migrated to the _appsettings.json_ file by the upgrade tool.

01. Set the _appsettings.json_ file to copy to the output directory.

    Set this through Visual Studio using the **Properties** pane, or edit the project directly and add the following `ItemGroup`:

    ```xml
      <ItemGroup>
        <Content Include="appsettings.json">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
      </ItemGroup>
    ```

01. Edit the _App.xaml.cs_ file, setting up a configuration object that loads the _appsettings.json_ file, the added lines are highlighted:

    :::code language="csharp" source="./snippets/upgrade-assistant-wpf-framework/csharp/WebSiteRatings/App.xaml.cs" highlight="2,11,15-17":::

01. In the _.\\Models\\Database.cs_ file, change the `OpenConnection` method to use the new `App.Config` property. This requires importing the `Microsoft.Extensions.Configuration` namespace:

    :::code language="csharp" source="./snippets/upgrade-assistant-wpf-framework/csharp/WebSiteRatings/Models/Database.cs" range="1-12" highlight="3,9-10" :::

    `GetConnectionString` is an extension method provided by the `Microsoft.Extensions.Configuration` namespace.

## Modernize: Web browser control

The <xref:System.Windows.Controls.WebBrowser> control referenced by the [WPF sample app][wpf-sample] is based on Internet Explorer, which is out-of-date. WPF for .NET includes a new browser control based on Microsoft Edge. Complete the following steps to upgrade to the new <xref:Microsoft.Web.WebView2.Wpf.WebView2> web browser control:

01. Add the `Microsoft.Web.WebView2` NuGet package.
01. In the _MainWindow.xaml_ file:

    01. Import the control to the **wpfControls** namespace in the root element:

        :::code language="xaml" source="./snippets/upgrade-assistant-wpf-framework/csharp/WebSiteRatings/MainWindow.xaml" range="1-13" highlight="10" :::

    01. Down where the `<Border>` element is declared, remove the `WebBrowser` control and replace it with the `wpfControls:WebView2` control:

        :::code language="xaml" source="./snippets/upgrade-assistant-wpf-framework/csharp/WebSiteRatings/MainWindow.xaml" range="51-53" :::

01. Edit the _MainWindow.xaml.cs_ code behind file. Update the `ListBox_SelectionChanged` method to set the `browser.Source` property to a valid <xref:System.Uri>. This code previously passed in the website URL as a string, but the <xref:Microsoft.Web.WebView2.Wpf.WebView2> control requires a `Uri`.

    :::code language="csharp" source="./snippets/upgrade-assistant-wpf-framework/csharp/WebSiteRatings/MainWindow.xaml.cs" range="38-46" highlight="43" :::

Depending on which version of Windows a user of your app is running, they may need to install the WebView2 runtime. For more information, see [Get started with WebView2 in WPF apps](/microsoft-edge/webview2/get-started/wpf).

## Visual Basic projects

If you're using Visual Basic to code your project, the Upgrade Assistant may contain extra steps, such as migrating the `My` namespace. You should only see these steps added when your project is using these features.

```
7. Update Visual Basic project
    a. Update vbproj to support "My." namespace
```

## See also

- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)
- [Upgrade a Windows Forms App to .NET 6](upgrade-assistant-winforms-framework.md)
- [Upgrade an ASP.NET MVC App to .NET 6](/aspnet/core/migration/mvc)
- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)

[wpf-sample]: https://github.com/dotnet/samples/tree/main/wpf/WebSiteBrowser/

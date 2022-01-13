---
title: Upgrade WPF apps to .NET 6
description: Use the .NET Upgrade Assistant to upgrade an existing .NET Framework WPF app to .NET 6. The .NET Upgrade Assistant is a CLI tool that helps migrating an app from .NET Framework to .NET 6.
author: adegeo
ms.date: 01/13/2022
---
# Upgrade a WPF App to .NET 6 with the .NET Upgrade Assistant

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with upgrading .NET Framework WPF apps to .NET 6. This article provides:

- A demonstration of how to run the tool against a .NET Framework WPF app
- Troubleshooting tips

For more information on how to install the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

## Demo app

You can use the [Basic WPF Sample][wpf-sample] project to test upgrading with the Upgrade Assistant.

## Analyze your app

The .NET Upgrade Assistant tool includes an analyze mode that represents a dry run of upgrading your app. It may provide insights into what you may be required of you to prepare your app for upgrade. For example, running the analyze mode with the [Basic WPF Sample][wpf-sample] app produces the following output, indicating that there aren't any changes to be made before upgrading:

```console
> upgrade-assistant upgrade .\WebSiteRatings.sln

[09:50:56 INF] Loaded 5 extensions
[09:50:57 INF] Using MSBuild from C:\Program Files\dotnet\sdk\6.0.101\
[09:50:57 INF] Using Visual Studio install from C:\Program Files\Microsoft Visual Studio\2022\Preview [v17]
[09:50:59 INF] Recommending executable TFM net6.0 because the project builds to a web app
[09:50:59 INF] Recommending Windows TFM net6.0-windows because the project either has Windows-specific dependencies or builds to a WinExe
[09:50:59 INF] Marking assembly reference System.Configuration for removal based on package mapping configuration System.Configuration
[09:50:59 INF] Adding package System.Configuration.ConfigurationManager based on package mapping configuration System.Configuration
[09:50:59 INF] Marking assembly reference System.Web for removal based on package mapping configuration ASP.NET
[09:50:59 INF] Adding framework reference Microsoft.AspNetCore.App based on package mapping configuration ASP.NET
[09:50:59 INF] Marking assembly reference System.Web.Extensions for removal based on package mapping configuration ASP.NET
[09:51:00 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.3.261602) needs to be added
[09:51:01 INF] Adding Microsoft.Windows.Compatibility 6.0.0
[09:51:01 INF] Recommending Windows TFM net6.0-windows because the project either has Windows-specific dependencies or builds to a WinExe
[09:51:01 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.3.261602) needs to be added
[09:51:01 INF] Adding Microsoft.Windows.Compatibility 6.0.0
[09:51:01 INF] Running analyzers on WebSiteRatings
[09:51:02 INF] Identified 0 diagnostics in project WebSiteRatings
[09:51:02 INF] Running analyzers on StarVoteControl
[09:51:02 INF] Identified 0 diagnostics in project StarVoteControl
```

There's quite a bit of internal diagnostic information in the output, but some information is helpful. Notice that the analyze mode indicates that the upgrade will recommend that the project target the `net6.0-windows` target framework moniker (TFM). This is because the projects referenced by the solution are WPF projects, a Windows-only technology. A console application would probably get the recommendation to upgrade to TFM `net6.0` directly, unless it used some Windows-specific libraries.

If any errors or warnings are reported, take care of them before you start an upgrade.

## Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant upgrade` command, passing in the name of the project or solution you're targeting.

When a project is provided, the upgrade process starts on that project immediately. If a solution is provided, you'll select which project you normally run. Based on that project, a dependency graph is created and a suggestion as to which order you should upgrade the projects is provided.

```console
upgrade-assistant upgrade .\WebSiteRatings.sln
```

The tool runs and shows you a list of the steps it will do. As each step is completed, the tool provides a set of commands allowing the user to apply or skip the next step or some other option such as:

- Get more information about the step.
- Change projects.
- Adjust logging settings.
- Stop the upgrade and quit.

Pressing <kbd>Enter</kbd> will start the next step.

As each step initializes, it may provide information about what it thinks will happen if you apply the step.

### Select the Entrypoint

The first step in upgrading a solution is selecting which project serves as the entrypoint project.

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

Choose **command 1** to start that step. There are two projects listed, the main WPF app (WebSiteRatings) and the user control project (StarVoteControl). Select the WebSiteRatings project.

```
[13:28:49 INF] Applying upgrade step Select an entrypoint
Please select the project you run. We will then analyze the dependencies and identify the recommended order to upgrade projects.
   1. StarVoteControl
   2. WebSiteRatings
```

In this example, select project 2.

### Select a project to upgrade

After the entrypoint is determined, the next step is to choose which project to upgrade. In this example, the tool determined that the WPF UserControl project should be upgraded first since the main WPF app project has a dependency on the control.

```
[13:44:47 INF] Applying upgrade step Select project to upgrade
Here is the recommended order to upgrade. Select enter to follow this list, or input the project you want to start with.
   1. StarVoteControl
   2. WebSiteRatings
```

The recommended path here, is to first upgrade the **StarVoteControl** project first, since the **WebSiteRatings** project depends on it. It's best to follow the recommended upgrade path.

### Upgrade the project

Once a project is selected, a list of upgrade steps the tool will take is listed.

> [!IMPORTANT]
> For the purposes of this example, the **WebSiteRatings** project is described. It's assumed that the **StarVoteControl** project was successfully upgraded. The reason for demonstrating the **WebSiteRatings** project is that it contains more of the common issues you'll run into when upgrading an app.
>
> Based on the project you're upgrading, you may or may not see every step listed in this example.

```
[16:09:24 INF] Initializing upgrade step Back up project

Upgrade Steps

Entrypoint: C:\code\Work\temp\Migration\wpf\newApp\WebSiteRatings\WebSiteRatings.csproj
Current Project: C:\code\Work\temp\Migration\wpf\newApp\WebSiteRatings\WebSiteRatings.csproj

1. [Next step] Back up project
2. Convert project file to SDK style
3. Clean up NuGet package references
4. Update TFM
5. Update NuGet Packages
6. Add template files
7. Upgrade app config files
    a. Convert Application Settings
    b. Convert Connection Strings
    c. Disable unsupported configuration sections
8. Update source code
    a. Apply fix for UA0002: Types should be upgraded
    b. Apply fix for UA0012: 'UnsafeDeserialize()' does not exist
9. Move to next project

Choose a command:
   1. Apply next step (Back up project)
   2. Skip next step (Back up project)
   3. See more step details
   4. Select different project
   5. Configure logging
   6. Exit
```

> [!NOTE]
> For the rest of this article, the upgrade steps aren't explicitly shown, unless there is something important to call out. The results of each step are still shown.

#### Create a backup

In this example of upgrading the project, you'll apply each step. The first step, **command 1**, is backing up the project:

```
[16:10:42 INF] Applying upgrade step Back up project
Please choose a backup path
   1. Use default path [C:\code\Work\temp\Migration\wpf\newApp.backup]
   2. Enter custom path
```

The tool chooses a default backup path named after the current folder, but with `.backup` appended to it. You can choose a custom path as an alternative to the default path. Each folder containing a project will be copied to the backup folder. In this example, the `WebSiteRatings` folder is copied during the backup step:

```
[16:10:44 INF] Backing up C:\code\Work\temp\Migration\wpf\newApp\WebSiteRatings to C:\code\Work\temp\Migration\wpf\newApp.backup\WebSiteRatings
[16:10:45 INF] Project backed up to C:\code\Work\temp\Migration\wpf\newApp.backup\WebSiteRatings
[16:10:45 INF] Upgrade step Back up project applied successfully
Please press enter to continue...
```

#### Upgrade the project file

The project file must be upgraded from a .NET Framework project format to the .NET SDK project format.

```
[16:10:51 INF] Applying upgrade step Convert project file to SDK style
[16:10:51 INF] Converting project file format with try-convert, version 0.3.261602+8aa571efd8bac422c95c35df9c7b9567ad534ad0
[16:10:51 INF] Recommending TFM net6.0-windows because of dependency on project C:\code\Work\temp\Migration\wpf\newApp\StarVoteControl\StarVoteControl.csproj
C:\code\Work\temp\Migration\wpf\newApp\WebSiteRatings\WebSiteRatings.csproj contains a reference to System.Web, which is not supported on .NET Core. You may have significant work ahead of you to fully port this project.
C:\code\Work\temp\Migration\wpf\newApp\WebSiteRatings\WebSiteRatings.csproj contains an App.config file. App.config is replaced by appsettings.json in .NET Core. You will need to delete App.config and migrate to appsettings.json if it's applicable to your project.
[16:10:52 INF] Converting project C:\code\Work\temp\Migration\wpf\newApp\WebSiteRatings\WebSiteRatings.csproj to SDK style
[16:10:53 INF] Project file converted successfully! The project may require additional changes to build successfully against the new .NET target.
[16:10:55 INF] Upgrade step Convert project file to SDK style applied successfully
Please press enter to continue...
```

Pay attention to the output of each step. Notice that in this case it indicates that you'll have a manual step to complete after the upgrade:

> App.config is replaced by appsettings.json in .NET Core. You will need to delete App.config and migrate to appsettings.json if it's applicable to your project.

#### Move NuGet references

Once the project format has been updated, the next step is to move the NuGet package references from the _packages.config_ file to the project file.

```
[16:55:18 INF] Applying upgrade step Clean up NuGet package references
[16:55:18 INF] Removing outdated assembly reference: System.Configuration
[16:55:18 INF] Removing outdated package reference: ControlzEx, Version=4.4.0
[16:55:18 INF] Removing outdated package reference: Microsoft.Xaml.Behaviors.Wpf, Version=1.1.19
[16:55:18 INF] Removing outdated package reference: SQLite.Native, Version=3.12.3
[16:55:18 INF] Adding package reference: System.Configuration.ConfigurationManager, Version=5.0.0
[16:55:18 INF] Adding package reference: Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, Version=0.3.261602
[16:55:21 WRN] No version of System.Configuration.ConfigurationManager found that supports ["net452"]; leaving unchanged
[16:55:21 INF] Upgrade step Clean up NuGet package references applied successfully
Please press enter to continue...
```

#### Handle the TFM

The tool next changes the [TFM][] from .NET Framework to the suggested SDK. In this example, it's `net6.0-windows`.

```
[16:56:36 INF] Applying upgrade step Update TFM
[16:56:36 INF] Recommending TFM net6.0-windows because of dependency on project C:\code\Work\temp\Migration\wpf\newApp\StarVoteControl\StarVoteControl.csproj
[16:56:40 INF] Updated TFM to net6.0-windows
[16:56:40 INF] Upgrade step Update TFM applied successfully
Please press enter to continue...
```

#### Upgrade NuGet packages

Next, the tool updates the project's NuGet packages.

```
[16:58:06 INF] Applying upgrade step Update NuGet Packages
[16:58:06 INF] Removing outdated assembly reference: System.Web
[16:58:06 INF] Removing outdated assembly reference: System.Web.Extensions
[16:58:06 INF] Removing outdated package reference: Microsoft.CSharp, Version=4.7.0
[16:58:06 INF] Removing outdated package reference: System.Data.DataSetExtensions, Version=4.5.0
[16:58:06 INF] Removing outdated package reference: EntityFramework, Version=6.2.0
[16:58:06 INF] Adding package reference: EntityFramework, Version=6.4.4
[16:58:06 INF] Adding framework reference: Microsoft.AspNetCore.App
[16:58:11 INF] Upgrade step Update NuGet Packages applied successfully
Please press enter to continue...
```

#### Templates, config, and code files

The next few steps may be skipped automatically by the tool if the tool determines there isn't anything to do in your project.

Once the packages are updated, the next step is to update any template files. In this example, there are no template files that need to be updated or added to the project. This step is skipped and the next step is automatically started: Upgrade app config files. This step only needs to convert the connection strings:

```
[17:02:52 INF] Applying upgrade step Convert Connection Strings
[17:02:53 INF] Upgrade step Convert Connection Strings applied successfully
[17:02:53 INF] Applying upgrade step Upgrade app config files
[17:02:53 INF] Upgrade step Upgrade app config files applied successfully
```

The final step before moving to the next project or completing the upgrade is updating any out-of-date code references. Based on the type of project you're upgrading, a list of known code fixes is displayed for this step. Some of the fixes may not apply to you.

```
8. Update source code
    a. Apply fix for UA0001: ASP.NET Core projects should not reference ASP.NET namespaces
    b. Apply fix for UA0002: Types should be upgraded
    c. Apply fix for UA0005: Do not use HttpContext.Current
    d. Apply fix for UA0006: HttpContext.DebuggerEnabled should be replaced with System.Diagnostics.Debugger.IsAttached
    e. Apply fix for UA0007: HtmlHelper should be replaced with IHtmlHelper
    f. Apply fix for UA0008: UrlHelper should be replaced with IUrlHelper
    g. Apply fix for UA0010: Attributes should be upgraded
    h. Apply fix for UA0012: 'UnsafeDeserialize()' does not exist
```

In this case, none of the suggested fixes apply to the example project, and this step automatically completes immediately after the previous step was completed.

```
[17:02:58 INF] Initializing upgrade step Update source code
[17:02:58 INF] Running analyzers on WebSiteRatings
[17:02:59 INF] Identified 0 diagnostics in project WebSiteRatings
[17:02:59 INF] Initializing upgrade step Move to next project
```

#### Completing the upgrade

If there are any more projects to migrate, the tool lets you select which project to next upgrade. When there are no more projects to upgrade, the tool brings you to the "Finalize upgrade" step:

```
1. [Next step] Finalize upgrade

Choose a command:
   1. Apply next step (Finalize upgrade)
   2. Skip next step (Finalize upgrade)
   3. See more step details
   4. Configure logging
   5. Exit
```

Once this process has completed, the migrated WPF project will look something like this:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net6.0-windows</TargetFramework>
    <OutputType>WinExe</OutputType>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <UseWPF>true</UseWPF>
    <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System.Security" />
  </ItemGroup>
  <ItemGroup>
    <None Update="sqlite.db">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\StarVoteControl\StarVoteControl.csproj" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="System.ComponentModel.Annotations" Version="5.0.0" />
    <PackageReference Include="System.Configuration.ConfigurationManager" Version="5.0.0" />
    <PackageReference Include="Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers" Version="0.3.261602">
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
    <FrameworkReference Include="Microsoft.AspNetCore.App" />
  </ItemGroup>
  <ItemGroup>
    <Content Include="appsettings.json" />
  </ItemGroup>
</Project>
```

Notice that the .NET Upgrade Assistant also adds analyzers to the project that assist with continuing the upgrade process, such as the `Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers` NuGet package.

## After upgrading

After you upgrade your projects, you'll need to compile and test them. Most certainly you'll have more work to do in finishing the upgrade. It's possible that the .NET Framework version of your app contained library references that your project isn't actually using. You would want to analyze each reference and determine whether or not it's required. The tool may have also added or upgraded a NuGet package reference to wrong version.

At the time of writing this article, the following updates are needed to complete the upgrade of the example project:

01. Remove reference to the `Microsoft.AspNetCore.App` framework. Remove the following entry from the _WebSiteRatings.csproj_ file:

    ```xml
      <ItemGroup>
        <FrameworkReference Include="Microsoft.AspNetCore.App" />
      </ItemGroup>
    ```

01. Upgrade the `System.Configuration.ConfigurationManager` NuGet package to version **6.0.0**. The wrong version was selected by the upgrade tool:

    ```xml
    <PackageReference Include="System.Configuration.ConfigurationManager" Version="6.0.0" />
    ```

01. Remove reference to the `System.Security` library. This project doesn't use this library and the upgrade tool didn't need to add it to the project.

    ```xml
      <ItemGroup>
        <Reference Include="System.Security" />
      </ItemGroup>
    ```

Once those items are addressed, the example app compiles and runs. However, there are more things that could be analyzed, for example, this app is using the `Microsoft.Data.Sqlite 1.0.0` NuGet package, which has a dependency on the `SQLite` package. If `Microsoft.Data.Sqlite` is upgraded for `6.0.0`

## Modernize: appsettings.json

.NET Framework uses the _App.config_ file to load settings for your app, such as connection strings and logging providers, among other settings. .NET now uses the _appsettings.json_ file for app settings.

_App.config_ files are supported in .NET through the `System.Configuration.ConfigurationManager` NuGet package, and support for _appsettings.json_ is provided by the `Microsoft.Extensions.Hosting` NuGet package.

As other libraries upgrade to .NET, they'll modernize by supporting _appsettings.json_ instead of _App.config_. For example, logging providers in .NET Framework that have been upgraded for .NET 6 no longer use _App.config_ for settings. It's good for you to follow their direction and also move away from using _App.config_.

With the WPF example app upgraded in the preceding section, we can remove the dependency on `System.Configuration.ConfigurationManager` and move to _appsettings.json_ for the connection string used by the local database.

01. Remove the `System.Configuration.ConfigurationManager` NuGet package.
01. Add the `Microsoft.Extensions.Hosting` NuGet package.
01. Delete the _App.config_ file from the project.
01. Set the _appsettings.json_ file to copy to the output directory. Set this through Visual Studio using the **Properties** pane, or edit the project directly and add the following `ItemGroup`:

    ```xml
      <ItemGroup>
        <Content Include="appsettings.json">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
      </ItemGroup>    
    ```

01. Edit the _App.xaml.cs_ file, setting up a configuration object that loads the _appsettings.json_ file, the added lines are highlighted:

    ```csharp
    using System.Windows;
    using Microsoft.Extensions.Configuration;
    
    namespace WebSiteRatings
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            public static IConfiguration Config { get; private set; }
    
            public App()
            {
                Config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();
            }
        }
    }
    ```

01. In the _.\\Models\\Database.cs_ file, change the `OpenConnection` method to use the new `App.Config` property. This requires importing the `Microsoft.Extensions.Configuration` namespace:

    ```csharp
    using Microsoft.Data.Sqlite;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;
    
    namespace WebSiteRatings.Models
    {
        internal class Database
        {
            public static SqliteConnection OpenConnection() =>
                new SqliteConnection(App.Config.GetConnectionString("database"));
    
        // other code...
    ```

    `GetConnectionString` is an extension method provided by the `Microsoft.Extensions.Configuration` namespace.

## Modernize: Web browser control

The <xref:System.Windows.Controls.WebBrowser> control referenced by the project is based on Internet Explorer, which is out-of-date. WPF for .NET includes a new browser control based on Microsoft Edge. Complete the following steps to upgrade to the new **WebView2** web browser control:

01. Add reference to the `Microsoft.Web.WebView2` NuGet package.
01. In the _MainWindow.xaml_ file:

    01. Import the control to the **wpfControls** namespace in the root element:

        ```xml
        <mah:MetroWindow x:Class="WebSiteRatings.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:mah="clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro"
                xmlns:local="clr-namespace:WebSiteRatings"
                xmlns:vm="clr-namespace:WebSiteRatings.ViewModels"
                xmlns:VoteControl="clr-namespace:StarVoteControl;assembly=StarVoteControl"
                xmlns:wpfControls="clr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf"
                Loaded="MetroWindow_Loaded"
                mc:Ignorable="d"
                Title="My Sites" Height="650" Width="1000">
        ```

    01. Down where the `<Border>` element is declared, remove the `WebBrowser` control and replace it with the `wpfControls:WebView2` control:

        ```xaml
        <Border Grid.Row="2" Grid.Column="1" Grid.ColumnSpan="2" BorderThickness="1" BorderBrush="Black" Margin="5">
            <wpfControls:WebView2 x:Name="browser" ScrollViewer.CanContentScroll="True" />
        </Border>
        ```

01. Edit the _MainWindow.xaml.cs_ code behind file. Update the `ListBox_SelectionChanged` method to set the `browser.Source` property to a valid <xref:System.Uri>. This code was previously passing in the website URL as a string, but the new <xref:Microsoft.Web.WebView2.Wpf.WebView2> control requires a `Uri`.

    ```csharp
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var siteCollection = (ViewModels.SiteCollection)DataContext;
    
        if (siteCollection.SelectedSite != null)
            browser.Source = new Uri(siteCollection.SelectedSite.Url);
        else
            browser.NavigateToString("<body></body>");
    }
    ```

Depending on the operating system of your user, they may need to install the WebView2 runtime. For more information, see [Get started with WebView2 in WPF apps](/microsoft-edge/webview2/get-started/wpf).

## Troubleshooting tips

There are several known problems that can occur when using the .NET Upgrade Assistant. In some cases, these are problems with the [try-convert tool](https://github.com/dotnet/try-convert) that the .NET Upgrade Assistant uses internally.

[The tool's GitHub repository](https://github.com/dotnet/upgrade-assistant#troubleshooting-common-issues) has more troubleshooting tips and known issues.

## See also

- [Upgrade a Windows Forms App to .NET 6](upgrade-assistant-winforms-framework.md)
- [Upgrade an ASP.NET MVC App to .NET 6](upgrade-assistant-aspnetmvc.md)
- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)

[wpf-sample]: https://github.com

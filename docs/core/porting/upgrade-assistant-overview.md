---
title: Overview of the .NET Upgrade Assistant
description: Introducing the .NET Upgrade Assistant tool that helps upgrade .NET or .NET Framework apps to the latest version of .NET.
author: adegeo
ms.date: 05/16/2023
no-loc: ["appsettings.json", "App.config"]
---
# Overview of the .NET Upgrade Assistant

New versions of .NET are released throughout the year, with a major release once a year. The .NET Upgrade Assistant helps you upgrade apps from previous versions of .NET and .NET Framework to the latest version.

The .NET Upgrade Assistant is a Visual Studio extension and command-line tool that's designed to assist with upgrading apps to the latest version of .NET.

Issues related to the .NET Upgrade Assistant can be filed in the [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant).

## Install the Upgrade Assistant

The .NET Upgrade Assistant can be installed as a Visual Studio extension or as a .NET command-line tool. For more information, see [Install the .NET Upgrade Assistant](upgrade-assistant-install.md).

## Supported languages

The following code languages are supported:

- C#
- Visual Basic

## Supported projects

The following types of projects are supported:

- ASP.NET
- Azure Functions
- Windows Presentation Foundation
- Windows Forms
- Class libraries
- Console apps
- .NET Native UWP
- Xamarin Forms
- .NET MAUI

## Upgrade paths

The following upgrade paths are supported:

- .NET Framework to .NET
- .NET Core to .NET
- Previous .NET version to the latest .NET version
- Azure Functions v1-v3 to v4 isolated
- Xamarin Forms to .NET MAUI
  - XAML file transformations only support upgrading namespaces. For more comprehensive transformations, use Visual Studio 2022 version 17.6 or later.

## Upgrade a project

After the Update Assistant is installed, you can upgrade a project.

### Upgrade with the Visual Studio extension

After you've [installed the .NET Upgrade Assistant extension](upgrade-assistant-install.md#install-the-visual-studio-extension), right-click on the project in the **Solution Explorer** window, and select **Upgrade**.

:::image type="content" source="media/upgrade-assistant-overview/visual-studio-upgrade.png" alt-text="The .NET Upgrade Assistant's Upgrade menu item in Visual Studio.":::

> [!IMPORTANT]
> At this time, upgrading solutions isn't supported.

A tab is opened which provides, based on your project type, different styles of upgrade:

- In-place project upgrade

  This option upgrades your project without making a copy.

- Side-by-side project upgrade

  Copies your project and upgrades the copy, leaving your original project alone.

- Side-by-side incremental

  A good choice for complicated web apps. Upgrading from ASP.NET to ASP.NET Core requires quite a bit of work and at times manual refactoring. This mode puts a .NET project next to your existing .NET Framework project, and routes endpoints that are implemented in the .NET project, while all other calls are sent to .NET Framework application.

  This mode lets you slowly upgrade your ASP.NET or Library app piece-by-piece.

Once your app has been upgraded, a status screen is displayed which shows all of the artifacts related to your project that were associated with the upgrade. Each upgrade artifact can be expanded to read more information about the status. The following list describes the status icons:

- **Filled green checkmark**: The artifact was upgraded and completed successfully.
- **Unfilled green checkmark**: The tool didn't find anything about the artifact to upgrade.
- **Yellow warning sign**: The artifact was upgraded, but there's important information you should consider.
- **Red _X_**: The artifact was to be upgraded, but the upgrade failed.

:::image type="content" source="media/upgrade-assistant-overview/visual-studio-upgrade-results.png" alt-text="The .NET Upgrade Assistant's Upgrade results tab in Visual Studio.":::

After upgrading your project, you'll need to test it throughout, and most likely, you'll have some compiler errors you must fix.

### Upgrade with the CLI tool

With the CLI tool, you can upgrade either a solution or project.

After you've [installed the .NET Upgrade Assistant CLI tool](upgrade-assistant-install.md#install-the-net-global-tool), open a terminal window and navigate to the directory that contains the project or solution you want to upgrade.

The tool has two modes, **analyze** and **upgrade**. Analyze can quickly identify incompatibilities that you can fix prior to running the upgrade. To analyze your app, run the `upgrade-assistant analyze <project-file>` command, where `<project-file>` is the name of the project or solution you're analyzing. To start an upgrade, run `upgrade-assistant analyze <project-file>`.

When you start upgrading a project or solution, the tool shows you a list of the steps it's going to do. As each step is completed, the tool provides a set of commands allowing the user to apply the next step, skip the next step, or some other option such as:

- Get more information about the step.
- Change projects.
- Adjust logging settings.
- Stop the upgrade and quit.

Pressing <kbd>Enter</kbd> without choosing a number selects the first item in the list.

As each step initializes, it may provide information about what it thinks will happen if you apply the step.

After upgrading your project, you'll need to test it throughout, and most likely, you'll have some compiler errors you must fix.

#### Example output

Once you've started upgrading a project, the tool outputs a large set of steps that are to be performed on the whole project. Some steps may expand into more steps. For example, here's the output displayed when upgrading a Windows Forms application:

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

## .NET Framework modernization

When upgrading a .NET Framework app, you'll most likely have some incompatibilities. For example, .NET doesn't provide APIs to access the Windows Registry like .NET Framework did. Support for the Windows Registry is provided by the `Microsoft.Win32.Registry` NuGet package. Many the .NET Framework-specific libraries have been ported to .NET or .NET Standard, and are hosted on NuGet. If you find a missing reference in your project, search NuGet.

Your app can also be modernized to take advantage of new APIs and libraries. The following sections describe a few of these modernization points.

### Web browser control

Projects that target a Windows desktop technology, such as Windows Presentation Foundation or Windows Forms, may include a web browser control. The web browser control provided was most likely designed prior to HTML5 and other modern web technologies and is considered obsolete. Microsoft publishes the [`Microsoft.Web.WebView2` NuGet package](https://www.nuget.org/packages/Microsoft.Web.WebView2) as modern web browser control replacement.

### appsettings.json

.NET Framework uses the _App.config_ file to load settings for your app, such as connection strings and log providers. Modern .NET uses the _appsettings.json_ file for app settings. The CLI version of the Upgrade Assistant handles converting _App.config_ files to _appsettings.json_, but the Visual Studio extension doesn't.

> [!TIP]
> If you don't want to use the _appsettings.json_ file, you can add the `System.Configuration.ConfigurationManager` NuGet package to your app and your code will compile and use the _App.config_ file.

Even though _appsettings.json_ is the modern way to store and retrieve settings and connection strings, your app still has code that uses the _App.config_ file. When your app was migrated, the `System.Configuration.ConfigurationManager` NuGet package was added to the project so that your code using the _App.config_ file continues to compile.

As libraries upgrade to .NET, they modernize by supporting _appsettings.json_ instead of _App.config_. For example, logging providers in .NET Framework that have been upgraded for .NET 6+ no longer use _App.config_ for settings. It's good for you to follow their direction and also move away from using _App.config_.

Support for _appsettings.json_ is provided by the `Microsoft.Extensions.Configuration` NuGet package.

Perform the following steps to use the _appsettings.json_ file as your configuration provider:

01. Remove the `System.Configuration.ConfigurationManager` NuGet package or library if referenced by your upgraded app.
01. Add the `Microsoft.Extensions.Configuration.Json` NuGet package.
01. Delete the _App.config_ file from the project.

    > [!CAUTION]
    > Make sure that all the settings have migrated correctly.

01. Create a file named _appsettings.json_.

    Skip this step if your upgrade generated an _appsettings.json_ file.

    01. Right-click on the project file in the **Solution Explorer** window and select **Add** > **New Item...**.
    01. In the search box, enter `json`.
    01. Select the **JavaScript JSON Configuration File** template and set the **Name** to _appsettings.json_.
    01. Press **Add** to add the new file to the project.

01. Set the _appsettings.json_ file to copy to the output directory.

    In the **Solution Explorer** window, find the _appsettings.json_ file and set the following **Properties**:

    - **Build Action**: Content
    - **Copy to Output Directory**: Copy always

01. In the startup code of your app, you need to load the settings file.

    The startup code for your app varies based on your project type. For example, a WPF app uses the `App.xaml.cs` file for global setup and a Windows Forms app uses the `Program.Main` method for startup. Regardless, you need to do two things at startup:

    - Create a `static` (`Shared` in Visual Basic) member that can be accessed from anywhere in your app.
    - During startup, assign an instance to that member.

    The following example creates a member named `Config`, assigns it an instance in the `Main` method, and loads a connection string:

    ```csharp
    using Microsoft.Extensions.Configuration;
    
    internal class Program
    {
        internal static IConfiguration Config { get; private set; }
    
        private static void Main(string[] args)
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
    
            // Use the config file to get a connection string
            string? myConnectionString = Config.GetConnectionString("database");
    
            // Run the rest of your app
        }
    }
    ```

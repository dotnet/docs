---
title: How to use the legacy .NET Upgrade Assistant
description: This article describes how to install the old .NET Upgrade Assistant tool.
author: adegeo
topic: how-to
ms.date: 05/22/2023
---
# Install the .NET Upgrade Assistant (legacy)

Learn how to install the old version of the .NET Upgrade Assistant command-line interface (CLI) tool.

Starting with version 0.5.2, the code base for the .NET Upgrade Assistant CLI tool was rebased on the Visual Studio extension. This means that there are effectively two different CLI tools, the version prior to 0.5.2, referred to as the legacy version, and the 0.5.2+ version.

The legacy version upgrades a lot more components, depending on your project type, than the current 0.5.2 version. Therefore, you may want to use it until the current version increases in capability and scope.

> [!TIP]
> The legacy version of the tool can upgrade solution files.

## Install the legacy version

The legacy version of the tool is installed the same way as the current version, except that you specify version `0.4.421302`:

```dotnetcli
dotnet tool install upgrade-assistant -g --version 0.4.421302
```

> [!IMPORTANT]
> Installing this tool may fail if you've configured additional NuGet feed sources. Use the `--ignore-failed-sources` parameter to treat those failures as warnings instead of errors:
>
> ```dotnetcli
> dotnet tool install upgrade-assistant -g --ignore-failed-sources --version 0.4.421302
> ```

## Analyze your app

The legacy version of the tool includes an analyze mode that performs a simplified dry run of upgrading your app. It may provide insights as to what changes may be required before the upgrade is started. Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant analyze` command, passing in the name of the project or solution you're upgrading.

For example, here's the output after running the analyze mode with the .NET Framework WPF app:

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

There's quite a bit of internal diagnostic information in the output, but some information is helpful. Notice that the analyze mode indicates that during an upgrade the project's target framework moniker ([TFM](../../standard/frameworks.md)) is going to be set to `net7.0-windows`  instead of `net7.0`. This recommendation is made because the projects referenced by the solution are WPF projects, a Windows-only technology. A console application would probably be upgraded directly to TFM `net7.0`, unless it used some Windows-specific library or code.

## Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant upgrade` command, passing in the name of the project or solution you're upgrading.

When the tool runs, it displays a list of steps it performs to upgrade the project. As each step is completed, the tool provides a set of numbered commands allowing the user to apply or skip the next step. It may provide other options such as:

- Get more information about the step.
- Change projects.
- Adjust logging settings.
- Stop the upgrade and quit.

Pressing <kbd>Enter</kbd> without choosing a number selects the first item in the list.

As each step initializes, the tool may provide information about what it thinks will happen if you apply the step.

### Upgrade a solution

When you upgrade a solution that contains multiple projects, you must select which project in the solution is the **entrypoint**. Based on the **entrypoint** project, a dependency graph is created to determine which projects to upgrade and in what order. If the solution contains projects that aren't a part of the dependency graph, they're ignored and you must upgrade these projects separately. Dependencies are upgraded first, then the **entrypoint** project.

The next step is to choose which project to upgrade. You should see output similar to the following snippet:

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

## Upgrade the project

Once a project is selected, a list of upgrade steps is displayed. The first step is selected, which is to back up the project. The list of steps looks similar to the following snippet:

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

Each step first details what it's going to do, then prompts you to do it. Any step that doesn't apply, is skipped when the tool arrives to the step. For example, if the tool processes **7. Update WCF service to CoreWCF (Preview)**, but your app doesn't define a WCF service, it's skipped and step 8 is processed. In turn, if step 8 doesn't apply, it's skipped too. You may see many steps skipped as the tool tries to find the next step that applies.

## Final steps

After you upgrade your projects, you'll need to compile and test them. Most likely there's more work to do to finish the upgrade. It's possible that the .NET Framework version of your app contained library references that your project isn't actually using, and they were carried over. Analyze each reference and determine whether or not it's required. The tool may have also added or upgraded a NuGet package reference to wrong version.

Finally, look for ways to modernize your app. For examples, see [Modernizations after upgrading to .NET from .NET Framework](modernize.md)

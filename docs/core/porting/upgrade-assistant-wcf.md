---
title: Upgrade WCF Server-side Project to use CoreWCF on .NET 6
description: Use the .NET Upgrade Assistant to upgrade an existing WCF Server-side project on .NET Framework to use CoreWCF services on .NET 6.
author: Simona Liao
ms.date: 09/01/2022
---
# Upgrade a WCF Server-side Project to use CoreWCF on .NET 6

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with upgrading an existing WCF Server-side project on .NET Framework to use CoreWCF services on .NET 6. This article provides:

- Things to know before starting
- A demonstration of how to run the tool against a WCF Server-side project on .NET Framework
- Troubleshooting tips

For more information on how to install the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

## Things to know before starting

This tool currently supports C#, and uses [CoreWCF services](https://devblogs.microsoft.com/dotnet/corewcf-v1-released/) to port self-hosted WCF Server-side project.

Here are some requirements for the WCF project to be applicable for this upgrade:
- Includes a .cs file that references `System.ServiceModel` and creates new `ServiceHost`.
    - If the WCF project has multiple `ServiceHost`, all hosts need to be created in the same method.
- Includes a .config file that stores `System.ServiceModel` properties

This tool does not support WCF projects hosted via .svc file yet. 
> [!NOTE]
> If your project is not applicable for this tool yet, we recommend you to check out the [CoreWCF walkthrough guide](https://github.com/CoreWCF/CoreWCF) and 
[BeanTrader Sample demo](https://devblogs.microsoft.com/dotnet/upgrading-a-wcf-service-to-dotnet-6/) and manually update the project.

## Demo app

You can use the [Basic Calculator Sample](wcf-sample) project to test upgrading with the Upgrade Assistant, which is also the demo used in this documentation. 

If you want to try out a more complicated sample, please check out the [BeanTrader Sample](https://github.com/dotnet/windows-desktop/tree/main/Samples/BeanTrader) created by Mike Rousos.

## Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant upgrade` command, passing in the name of the project or solution you're upgrading.

When a project is provided, the upgrade process starts on that project immediately. If a solution is provided, you'll select which project you normally run, known as the [upgrade entrypoint](#select-the-entrypoint). Based on that project, a dependency graph is created and a suggestion as to which order you should upgrade the projects is provided.

```console
upgrade-assistant upgrade .\CalculatorSample.sln
```

The tool runs and shows you a list of the steps it will do. As each step is completed, the tool provides a set of commands allowing the user to apply or skip the next step or some other option such as:

- Get more information about the step.
- Change projects.
- Adjust logging settings.
- Stop the upgrade and quit.

Pressing <kbd>Enter</kbd> without choosing a number selects the first item in the list.

As each step initializes, it may provide information about what it thinks will happen if you apply the step.

### Select the entrypoint and project to upgrade

The first step in upgrading the [Basic Calculator Sample](wcf-sample) is choosing which project in the solution serves as the entrypoint project.

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
[10:25:42 INF] Applying upgrade step Select an entrypoint
Please select the project you run. We will then analyze the dependencies and identify the recommended order to upgrade projects.
   1. CalculatorClient
   2. CalculatorService
```

There are 2 projects listed. Because our tool upgrades the server-side project, we will choose **command 2** to select the service project as the entrypoint.

### Upgrade the project

Once a project is selected, a list of upgrade steps the tool will take is listed.

> [!IMPORTANT]
> Based on the project you're upgrading, you may or may not see every step listed in this example.

The following output describes the steps involved in upgrading the project:

```
Upgrade Steps

Entrypoint: C:\Users\Desktop\CalculatorSample\CalculatorService\CalculatorService.csproj
Current Project: C:\Users\Desktop\CalculatorSample\CalculatorService\CalculatorService.csproj

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
    c. Apply fix for UA0014: .NET MAUI projects should not reference Xamarin.Forms namespaces
    d. Apply fix for UA0015: .NET MAUI projects should not reference Xamarin.Essentials namespaces
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

In this example of upgrading the BeanTraderServer project, you'll apply each step. The first step, **command 1**, is backing up the project:

```
[10:25:52 INF] Applying upgrade step Back up project
Please choose a backup path
   1. Use default path [C:\Users\Desktop\CalculatorSample.backup]
   2. Enter custom path
```

The tool chooses a default backup path named after the current folder, but with `.backup` appended to it. You can choose a custom path as an alternative to the default path. For each upgraded project, the folder of the project is copied to the backup folder. In this example, the `CalculatorService` folder is copied from _CalculatorSample\CalculatorService_ to _CalculatorSample.backup\CalculatorService_ during the backup step:

```
[10:25:53 INF] Backing up C:\Users\Desktop\CalculatorSample\CalculatorService to C:\Users\t-simonaliao\OneDrive - Microsoft\Desktop\CalculatorSample.backup\CalculatorService
[10:25:53 INF] Project backed up to C:\Users\Desktop\CalculatorSample.backup\CalculatorService
[10:25:53 INF] Upgrade step Back up project applied successfully
Please press enter to continue...
```

#### Upgrade the project file

The project is upgraded from the .NET Framework project format to the .NET SDK project format.

```
[10:25:56 INF] Applying upgrade step Convert project file to SDK style
[10:25:56 INF] Converting project file format with try-convert, version 0.4.0-dev
[10:25:56 INF] Recommending executable TFM net6.0 because the project builds to an executable
C:\Users\Desktop\CalculatorSample\CalculatorService\CalculatorService.csproj contains an App.config file. App.config is replaced by appsettings.json in .NET Core. You will need to delete App.config and migrate to appsettings.json if it's applicable to your project.
[10:25:58 INF] Converting project C:\Users\CalculatorSample\CalculatorService\CalculatorService.csproj to SDK style
[10:25:58 INF] Project file converted successfully! The project may require additional changes to build successfully against the new .NET target.
[10:26:00 INF] Upgrade step Convert project file to SDK style applied successfully
```

Pay attention to the output of each step. Notice that the example output indicates that you'll have a manual step to complete after the upgrade:

> App.config is replaced by appsettings.json in .NET Core. You will need to delete App.config and migrate to appsettings.json if it's applicable to your project.

In this sample, the WCF update step will create a new _wcf.config_ based on the `system.serviceModel` section in _App.config_. We won't need to migrate to appsettings.json.

#### Clean up NuGet references

Once the project format has been updated, the next step is to clean up the NuGet package references.

In addition to the packages referenced by your app, the _packages.config_ file contains references to the dependencies of those packages. For example, if you added reference to package **A** which depends on package **B**, both packages would be referenced in the _packages.config_ file. In the new project system, only the reference to package **A** is required. This step analyzes the package references and removes those that aren't required.

```
[10:26:01 INF] Initializing upgrade step Clean up NuGet package references
[10:26:01 INF] Initializing upgrade step Duplicate reference analyzer
[10:26:01 INF] No package updates needed
[10:26:01 INF] Initializing upgrade step Package map reference analyzer
[10:26:01 INF] Marking assembly reference System.configuration for removal based on package mapping configuration System.Configuration
[10:26:01 INF] Adding package System.Configuration.ConfigurationManager based on package mapping configuration System.Configuration
[10:26:01 INF] Marking assembly reference System.ServiceModel for removal based on package mapping configuration System.ServiceModel
[10:26:01 INF] Adding package System.ServiceModel.Primitives based on package mapping configuration System.ServiceModel
[10:26:01 INF] Adding package System.ServiceModel.Http based on package mapping configuration System.ServiceModel
[10:26:01 INF] Adding package System.ServiceModel.Duplex based on package mapping configuration System.ServiceModel
[10:26:01 INF] Adding package System.ServiceModel.NetTcp based on package mapping configuration System.ServiceModel
[10:26:01 INF] Adding package System.ServiceModel.Security based on package mapping configuration System.ServiceModel
[10:26:01 INF] Adding package System.ServiceModel.Federation based on package mapping configuration System.ServiceModel

[10:26:01 INF] Initializing upgrade step Remove reference 'System.configuration'
[10:26:03 INF] Applying upgrade step Remove reference 'System.configuration'
[10:26:03 INF] Removing outdated assembly reference: System.configuration
[10:26:03 INF] Upgrade step Remove reference 'System.configuration' applied successfully

[10:26:05 INF] Initializing upgrade step Remove reference 'System.ServiceModel'
[10:26:06 INF] Applying upgrade step Remove reference 'System.ServiceModel'
[10:26:06 INF] Removing outdated assembly reference: System.ServiceModel
[10:26:06 INF] Upgrade step Remove reference 'System.ServiceModel' applied successfully

[10:26:07 INF] Initializing upgrade step Add package 'System.Configuration.ConfigurationManager'
[10:26:09 INF] Applying upgrade step Add package 'System.Configuration.ConfigurationManager'
[10:26:09 INF] Adding package reference: System.Configuration.ConfigurationManager, Version=5.0.0
[10:26:09 INF] Upgrade step Add package 'System.Configuration.ConfigurationManager' applied successfully
[10:26:09 INF] Applying upgrade step Package map reference analyzer
[10:26:09 INF] Upgrade step Package map reference analyzer applied successfully

[10:26:10 INF] Initializing upgrade step Target compatibility reference analyzer
[10:26:10 INF] No package updates needed
[10:26:10 INF] Initializing upgrade step Upgrade assistant reference analyzer
[10:26:11 INF] Reference to .NET Upgrade Assistant analyzer package (Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, version 0.4.336902) needs to be added
[10:26:11 INF] Initializing upgrade step Add package 'Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers'
[10:26:13 INF] Applying upgrade step Add package 'Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers'
[10:26:13 INF] Adding package reference: Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers, Version=0.4.336902
[10:26:13 INF] Upgrade step Add package 'Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers' applied successfully
[10:26:13 INF] Applying upgrade step Upgrade assistant reference analyzer
[10:26:14 INF] Upgrade step Upgrade assistant reference analyzer applied successfully

[10:26:15 INF] Initializing upgrade step Windows Compatibility Pack Analyzer
[10:26:15 INF] No package updates needed
[10:26:15 INF] Initializing upgrade step MyDotAnalyzer reference analyzer
[10:26:15 INF] No package updates needed
[10:26:15 INF] Initializing upgrade step Newtonsoft.Json reference analyzer
[10:26:15 INF] No package updates needed
[10:26:15 INF] Initializing upgrade step Windows App SDK package analysis
[10:26:15 INF] No package updates needed
[10:26:15 INF] Initializing upgrade step Transitive reference analyzer
[10:26:15 INF] No package updates needed
[10:26:15 INF] Applying upgrade step Clean up NuGet package references
[10:26:15 INF] Upgrade step Clean up NuGet package references applied successfully
```

Your app is still referencing .NET Framework assemblies. Some of those assemblies may be available as NuGet packages. This step analyzes those assemblies and references the appropriate NuGet package.

In this example, the package updater detects the CalculatorService as a server-only project and there is no need to add `System.ServiceModel` packages. Even though they were added to the list based on package mapping configuration, those steps were not applied.

#### Handle the TFM

The tool next changes the [TFM](../../standard/frameworks.md) from .NET Framework to the suggested SDK. In this example, it's `net6.0-windows`.

```
[10:26:17 INF] Applying upgrade step Update TFM
[10:26:17 INF] Recommending executable TFM net6.0 because the project builds to an executable
[10:26:19 INF] Updated TFM to net6.0
[10:26:19 INF] Upgrade step Update TFM applied successfully
```

#### Upgrade NuGet packages

Next, the tool updates the project's NuGet packages to the versions that support the updated TFM, `net6.0-windows`.

```
[10:26:20 INF] Initializing upgrade step Update NuGet Packages
[10:26:20 INF] Initializing upgrade step Duplicate reference analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step Package map reference analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step Target compatibility reference analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step Upgrade assistant reference analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step Windows Compatibility Pack Analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step MyDotAnalyzer reference analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step Newtonsoft.Json reference analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step Windows App SDK package analysis
[10:26:20 INF] No package updates needed
[10:26:20 INF] Initializing upgrade step Transitive reference analyzer
[10:26:20 INF] No package updates needed
[10:26:20 INF] Applying upgrade step Update NuGet Packages
[10:26:20 INF] Upgrade step Update NuGet Packages applied successfully
```

#### Add template files

Once the packages are updated, the next step is to update any template files. In this example, there are no template files that need to be updated or added to the project. This step is skipped and the next step is automatically started.

```
[10:26:20 INF] Initializing upgrade step Add template files
[10:26:20 INF] 0 expected template items needed
```

#### Update WCF service to CoreWCF (Preview)

By the time this documentation was written, the WCF updater extension is under Preview and receiving feedbacks from the community. If you have any feedbacks for the Preview version, please open an issue in the [Upgrade Assistant GitHub repository](https://github.com/dotnet/upgrade-assistant/issues).

The upgrade assistant will first initialize the step and checks if the project is applicable for WCF update.

```
[10:26:20 INF] Initializing upgrade step Update WCF service to CoreWCF (Preview)
[10:26:20 INF] This config file is applicable for upgrade: C:\Users\Desktop\CalculatorSample\CalculatorService\App.config. System.serviceModel/services elements were found.
[10:26:20 INF] This  file is applicable for upgrade: C:\Users\Desktop\CalculatorSample\CalculatorService\service.cs. ServiceHost object was found.
[10:26:20 INF] This project file is applicable for upgrade: C:\Users\Desktop\CalculatorSample\CalculatorService\CalculatorService.csproj. Reference to System.serviceModel was found.
[10:26:20 INF] This project is applicable for updating to CoreWCF. Initializing the update step...
[10:26:20 INF] Updaters are successfully constructed. Ready to start update.

Choose a command:
   1. Apply next step (Update WCF service to CoreWCF (Preview))
   2. Skip next step (Update WCF service to CoreWCF (Preview))
   3. See more step details
   4. Select different project
   5. Configure logging
   6. Exit
```

The step checks the configuration file, source code, and project file separately to decide if the project is applicable for WCF update. If the project is not applicable (such as not using WCF, or not meeting the requirements stated at the beginning of the article), the logging message would describe which file was not applicable and what was missing. Then, the step would be skipped and the next step would be automatically started.

In this sample, CalculatorSample is applicable for WCF update, and we will choose **command 1** to apply the step.

```
[10:26:23 INF] Applying upgrade step Update WCF service to CoreWCF (Preview)
[10:26:23 INF] Finish updating project file.
[10:26:23 WRN] The mex endpoint is removed from .config file, and service metadata behavior is configured in the source code instead.
[10:26:23 INF] Finish updating configuration files.
[10:26:23 WRN] Changing void Main() to async Task Main() to enable awaiting starting and stopping the ASP.NET Core host.
[10:26:23 INF] Finish updating source code.
[10:26:23 INF] Finish writing changes to project file.
[10:26:23 INF] Finish writing changes to configuration files.
[10:26:23 INF] Finish writing changes to the source code to replace the ServiceHost instance(s).
[10:26:23 INF] Project was successfully updated to use CoreWCF services. Please review changes.
[10:26:23 INF] Upgrade step Update WCF service to CoreWCF (Preview) applied successfully
```

This step creates the updates and writes them into the original files individually. Pay attention to the output which may notify you about removal from original files or manual updates to complete after the upgrade.

#### Config and code files update

These steps may be skipped automatically by the tool if the tool determines there isn't anything to do for your project.

After the WCF update is complete, the next step is to update app config files. In this example, there is not anything needs to be upgraded in the app config files. The WCF step already updated the configuration files so this step will not complain about the usage of unsupported `system.serviceModel`. This step is skipped and the next step is automatically started.

```
[10:26:43 INF] Initializing upgrade step Upgrade app config files
[10:26:43 INF] Found 0 app settings for upgrade:
[10:26:43 INF] Found 0 connection strings for upgrade:
[10:26:43 INF] 0 web page namespace imports need upgraded:
```

The final step before this project's upgrade is completed, is to update any out-of-date code references. Based on the type of project you're upgrading, a list of known code fixes is displayed for this step. Some of the fixes may not apply to your project.

```
9. Update source code
    a. Apply fix for UA0002: Types should be upgraded
    b. Apply fix for UA0012: 'UnsafeDeserialize()' does not exist
    c. Apply fix for UA0014: .NET MAUI projects should not reference Xamarin.Forms namespaces
    d. Apply fix for UA0015: .NET MAUI projects should not reference Xamarin.Essentials namespaces
```

In this case, none of the suggested fixes apply to the example project, and this step automatically completes immediately after the previous step was completed.

```
[10:26:44 INF] Initializing upgrade step Update source code
[10:26:44 INF] Running analyzers on CalculatorService
[10:26:48 INF] Identified 0 diagnostics in project CalculatorService
[10:26:51 INF] Initializing upgrade step Move to next project
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
[10:27:15 INF] Applying upgrade step Finalize upgrade
[10:27:15 INF] Upgrade step Finalize upgrade applied successfully
```

Ideally, after successfully running the tool, these modified files should look similar. Please check out the updated version of [CalculatorService.csproj](https://github.com/dotnet/docs/tree/main/docs/core/porting/snippets/upgrade-assistant-wcf-framework/CalculatorSample.Upgraded/CalculatorService/CalculatorService.csproj), [app.config](https://github.com/dotnet/docs/tree/main/docs/core/porting/snippets/upgrade-assistant-wcf-framework/CalculatorSample.Upgraded/CalculatorService/App.config), [wcf.config](https://github.com/dotnet/docs/tree/main/docs/core/porting/snippets/upgrade-assistant-wcf-framework/CalculatorSample.Upgraded/CalculatorService/wcf.config), [CalculatorSample/service.cs](https://github.com/dotnet/docs/tree/main/docs/core/porting/snippets/upgrade-assistant-wcf-framework/CalculatorSample.Upgraded/CalculatorService/service.cs).

Notice that if you want to run both CalculatorClient and CalculatorService, you would need to upgrade CalculatorClient with the tool as well. Because CalculatorService targets .Net6.0 after upgrade, it cannot be referenced by CalculatorClient which still targets .NETFramework. 

## After upgrading

After you upgrade your projects, you'll need to compile and test them. Most certainly you'll have more work to do in finishing the upgrade. It's possible that the .NET Framework version of your app contained library references that your project isn't actually using. You'll need to analyze each reference and determine whether or not it's required. The tool may have also added or upgraded a NuGet package reference to wrong version.

## Troubleshooting tips

There are several known problems that can occur when using the .NET Upgrade Assistant. In some cases, these problems are with the [try-convert tool](https://github.com/dotnet/try-convert) that the .NET Upgrade Assistant uses internally.

[The tool's GitHub repository](https://github.com/dotnet/upgrade-assistant#troubleshooting-common-issues) has more troubleshooting tips and known issues.

## See also

- [Upgrading a WCF service to .NET 6 with CoreWCF](https://devblogs.microsoft.com/dotnet/upgrading-a-wcf-service-to-dotnet-6/)
- [CoreWCF 1.0 has been Released, WCF for .NET Core and .NET 5+](https://devblogs.microsoft.com/dotnet/corewcf-v1-released/)
- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)

[wcf-sample]: https://github.com/dotnet/docs/tree/main/docs/core/porting/snippets/upgrade-assistant-wcf-framework/CalculatorSample

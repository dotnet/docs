---
title: Upgrade Windows Forms apps to .NET 6
description: Use the .NET Upgrade Assistant to upgrade an existing .NET Framework Windows Forms app to .NET 6. The .NET Upgrade Assistant is a CLI tool that helps migrating an app from .NET Framework to .NET 6.
author: adegeo
ms.date: 11/08/2021
---
# Upgrade a Windows Forms App to .NET 6 with the .NET Upgrade Assistant

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with upgrading .NET Framework Windows Forms (WinForms) apps to .NET 6. This article provides:

- A demonstration of how to run the tool against a .NET Framework Windows Forms app
- Troubleshooting tips

## Upgrade .NET Framework Windows Forms apps

This section demonstrates running the .NET Upgrade Assistant against a newly created Windows Forms app targeting .NET Framework 4.6.1. For more information on how to install the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

### Initial demo setup

If you're running the .NET Upgrade Assistant against your own .NET Framework app, you can skip this step. If you just want to try it out to see how it works, this step shows you how to set up a sample .NET Windows Forms project to use.

Using Visual Studio, create a new Windows Forms project using .NET Framework.

:::image type="content" source="media/upgrade-assistant-winforms-framework/vs-new-project-winforms.png" alt-text="New Windows Forms project in Visual Studio":::

Name the project **WinformsTest**. Configure the project to use **.NET Framework 4.6.1**.

:::image type="content" source="media/upgrade-assistant-winforms-framework/vs-configure-project-winforms.png" alt-text="Configure Windows Forms project in Visual Studio":::

Review the created project and its files, especially its project file(s).

### Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant` command, passing in the name of the project you're targeting (you can run the command from anywhere, as long as the path to the project file is valid).

```console
upgrade-assistant upgrade .\WinformsTest.csproj
```

The tool runs and shows you a list of the steps it will do.

:::image type="content" source="media/upgrade-assistant-winforms-framework/step1.png" alt-text=".NET Upgrade Assistant initial screen":::

As each step is completed, the tool provides a set of commands allowing the user to apply or skip the next step, see more details, configure logging, or exit the process. If the tool detects that a step will perform no actions, it automatically skips that step and continues to the next step until it reaches one that has actions to do. Pressing <kbd>Enter</kbd> will start the next step if no other selection is made.

In this example, the apply step is chosen each time. The first step is to back up the project.

:::image type="content" source="media/upgrade-assistant-winforms-framework/backup-project.png" alt-text=".NET Upgrade Assistant back up project":::

The tool prompts for a custom path for the backup, or to use the default, which will place the project backup in the same folder with a `.backup` extension. The next step the tool does is to convert the project file to SDK style.

:::image type="content" source="media/upgrade-assistant-winforms-framework/convert-project.png" alt-text=".NET Upgrade Assistant convert project to SDK style":::

Once the project format has been updated, the next step is to update the TFM of the project.

:::image type="content" source="media/upgrade-assistant-winforms-framework/update-tfm.png" alt-text=".NET Upgrade Assistant update TFM":::

Next, the tool updates the project's NuGet packages.

:::image type="content" source="media/upgrade-assistant-winforms-framework/update-nuget-packages.png" alt-text=".NET Upgrade Assistant update NuGet packages":::

Once the packages are updated, the next step is to add template files, if any. In this case, there are no template files that need to be added. This step continues and migrates app config files and updates C# source to apply fixes, as shown below. This project didn't need any config file or source code changes, so these steps proceeded automatically.

:::image type="content" source="media/upgrade-assistant-winforms-framework/add-template-files.png" alt-text=".NET Upgrade Assistant add template files and migrate config":::

Since this is the last project, the next step, "Move to next project", prompts to complete the process of migrating the entire solution.

:::image type="content" source="media/upgrade-assistant-winforms-framework/complete-solution.png" alt-text=".NET Upgrade Assistant completing the solution":::

Once this process has completed, the migrated Windows Forms project will look something like this:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net5.0-windows</TargetFramework>
    <OutputType>WinExe</OutputType>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.CSharp" Version="4.7.0" />
    <PackageReference Include="Microsoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers" Version="0.2.211730">
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.Windows.Compatibility" Version="5.0.2" />
  </ItemGroup>
</Project>
```

Notice that the .NET Upgrade Assistant also adds analyzers to the project that assist with continuing the upgrade process.

## Troubleshooting tips

There are several known problems that can occur when using the .NET Upgrade Assistant. In some cases, these are problems with the [try-convert tool](https://github.com/dotnet/try-convert) that the .NET Upgrade Assistant uses internally.

[The tool's GitHub repository](https://github.com/dotnet/upgrade-assistant#troubleshooting-common-issues) has more troubleshooting tips and known issues.

## See also

- [Upgrade a WPF App to .NET 6](upgrade-assistant-wpf-framework.md)
- [Upgrade an ASP.NET MVC App to .NET 6](upgrade-assistant-aspnetmvc.md)
- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)

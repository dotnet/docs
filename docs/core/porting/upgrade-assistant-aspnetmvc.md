---
title: Upgrade ASP.NET MVC apps to .NET 6
description: Use the .NET Upgrade Assistant to upgrade an existing .NET Framework ASP.NET MVC app to .NET 6. The .NET Upgrade Assistant is a CLI tool that helps migrate an app from .NET Framework to .NET 6.
author: adegeo
ms.date: 11/08/2021
---
# Upgrade an ASP.NET MVC app to .NET 6 with the .NET Upgrade Assistant

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can assist with upgrading .NET Framework ASP.NET MVC apps to .NET 6. This article provides:

- A demonstration of how to run the tool against a .NET Framework ASP.NET MVC app
- Troubleshooting tips

## Upgrade .NET Framework ASP.NET MVC apps

This section demonstrates running the .NET Upgrade Assistant against a newly created ASP.NET MVC app targeting .NET Framework 4.6.1. For more information on how to install the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

### Initial demo setup

If you're running the .NET Upgrade Assistant against your own .NET Framework app, you can skip this step. If you just want to try it out to see how it works, this step shows you how to set up a sample ASP.NET MVC and Web API (.NET Framework) project to use.

Using Visual Studio, create a new ASP.NET Web Application project using .NET Framework.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/new-project.png" alt-text="New ASP.NET Web Application project in Visual Studio":::

Name the project **AspNetMvcTest**. Configure the project to use **.NET Framework 4.6.1**.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/configure-project.png" alt-text="Configure ASP.NET project in Visual Studio":::

In the next dialog, choose **MVC** application, then select **Create**.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/create-mvc-webapi.png" alt-text="Create an ASP.NET MVC project in Visual Studio":::

Review the created project and its files, especially its project file(s).

### Run upgrade-assistant

Open a terminal and navigate to the folder where the target project or solution is located. Run the `upgrade-assistant` command, passing in the name of the project you're targeting (you can run the command from anywhere, as long as the path to the project file is valid).

```console
upgrade-assistant upgrade .\AspNetMvcTest.csproj
```

The tool runs and shows you a list of the steps it will do.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/initial-run.png" alt-text=".NET Upgrade Assistant initial screen":::

As each step is completed, the tool provides a set of commands allowing the user to apply or skip the next step, see more details, configure logging, or exit the process. If the tool detects that a step will perform no actions, it automatically skips that step and continues to the next step until it reaches one that has actions to do. Pressing <kbd>Enter</kbd> will start the next step if no other selection is made.

In this example, the apply step is chosen each time. The first step is to back up the project.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/backup-project.png" alt-text=".NET Upgrade Assistant back up project":::

The tool prompts for a custom path for the backup, or to use the default, which will place the project backup in the same folder with a `.backup` extension. The next step the tool does is to convert the project file to SDK style.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/convert-project.png" alt-text=".NET Upgrade Assistant convert project to SDK style":::

Once the project format has been updated, the next step is to update the TFM of the project.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/update-tfm.png" alt-text=".NET Upgrade Assistant update TFM":::

Next, the tool updates the project's NuGet packages. Several packages need updates, and a new analyzer package is added.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/update-nuget-packages.png" alt-text=".NET Upgrade Assistant update NuGet packages":::

Once the packages are updated, the next step is to add template files, if any. The tool notes there are four expected template items that must be added, and then adds them. The following is a list of the template files:

- `Program.cs`
- `Startup.cs`
- `appsettings.json`
- `appsettings.Development.json`

These files are used by ASP.NET Core for [app startup](/aspnet/core/fundamentals/startup) and [configuration](/aspnet/core/fundamentals/configuration).

:::image type="content" source="media/upgrade-assistant-aspnetmvc/add-template-files.png" alt-text=".NET Upgrade Assistant add template files":::

Next, the tool migrates config files. The tool identifies app settings and disables unsupported configuration sections, then migrates the `appSettings` configuration values.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/migrate-config.png" alt-text=".NET Upgrade Assistant migrate config":::

The tool completes the migration of config files by migrating `system.web.webPages.razor/pages/namespaces`.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/migrate-config2.png" alt-text=".NET Upgrade Assistant migrate config completed":::

The tool applies known fixes to migrate C# references to their new counterparts.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/update-csharp.png" alt-text=".NET Upgrade Assistant update C# source":::

Since this is the last project, the next step, "Move to next project", prompts to complete the process of migrating the entire solution.

:::image type="content" source="media/upgrade-assistant-aspnetmvc/complete-solution.png" alt-text=".NET Upgrade Assistant completing the solution":::

Once this process has completed, open the project file and review it. Look for static files like these:

```xml
  <ItemGroup>
    <Content Include="fonts\glyphicons-halflings-regular.woff2" />
    <Content Include="fonts\glyphicons-halflings-regular.woff" />
    <Content Include="fonts\glyphicons-halflings-regular.ttf" />
    <Content Include="fonts\glyphicons-halflings-regular.eot" />
    <Content Include="Content\bootstrap.min.css.map" />
    <Content Include="Content\bootstrap.css.map" />
    <Content Include="Content\bootstrap-theme.min.css.map" />
    <Content Include="Content\bootstrap-theme.css.map" />
    <Content Include="Scripts\jquery-3.4.1.slim.min.map" />
    <Content Include="Scripts\jquery-3.4.1.min.map" />
  </ItemGroup>
```

Static files that should be served by the web server should be moved to an appropriate folder within a root level folder named `wwwroot`. See [Static files in ASP.NET Core](/aspnet/core/fundamentals/static-files) for details. Once the files have been moved, the `<Content>` elements in the project file corresponding to these files can be deleted. In fact, all `<Content>` elements and their containing groups can be removed. Also, any `<PackageReference>` to a client-side library like `bootstrap` or `jQuery` should be removed.

By default, the project will be converted as a class library. Change the first line's `Sdk` attribute to `Microsoft.NET.Sdk.Web` and set the `<TargetFramework>` to `net5.0`. Compile the project. At this point, the number of errors should be fairly small. When porting a new ASP.NET 4.6.1 MVC project, the remaining errors refer to files in the `App_Start` folder:

- BundleConfig.cs
- FilterConfig.cs
- RouteConfig.cs

These files, and the entire `App_Start` folder, can be deleted. Likewise, the `Global.asax` and `Global.asax.cs` files can be removed.

At this point the only errors that remain are related to bundling. There are [several ways to configure bundling and minification in ASP.NET Core](/aspnet/core/migration/mvc#configure-bundling-and-minification). Choose whatever makes the most sense for your project.

## Troubleshooting tips

There are several known problems that can occur when using the .NET Upgrade Assistant. In some cases, these are problems with the [try-convert tool](https://github.com/dotnet/try-convert) that the .NET Upgrade Assistant uses internally.

[The tool's GitHub repository](https://github.com/dotnet/upgrade-assistant#troubleshooting-common-issues) has more troubleshooting tips and known issues.

## See also

- [Upgrade a WPF App to .NET 6](upgrade-assistant-wpf-framework.md)
- [Upgrade a Windows Forms App to .NET 6](upgrade-assistant-winforms-framework.md)
- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [.NET Upgrade Assistant GitHub Repository](https://github.com/dotnet/upgrade-assistant)

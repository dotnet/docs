---
title: Analyze dependencies to port code to .NET Core
description: Learn how to analyze external dependencies in order to port your project from .NET Framework to .NET Core.
author: cartermp
ms.date: 09/23/2019
ms.custom: seodec18
---
# Analyze your dependencies to port code to .NET Core

To port your code to .NET Core or .NET Standard, you must understand your dependencies. External dependencies are the [NuGet packages](#analyze-referenced-nuget-packages-in-your-projects) or [DLLs](#analyze-dependencies-that-arent-nuget-packages) you reference in your project, but that you don't build yourself.

## Migrate your packages to `PackageReference`

.NET Core uses [PackageReference](/nuget/consume-packages/package-references-in-project-files) to specify package dependencies. If you're using [packages.config](/nuget/reference/packages-config) to specify your packages in your project, you need to convert it to the `PackageReference` format because `packages.config` isn't supported in .NET Core.

To learn how to migrate, see the [Migrate from packages.config to PackageReference](/nuget/reference/migrate-packages-config-to-package-reference) article.

## Upgrade your NuGet packages

After your migrating your project to the `PackageReference` format, you need to verify if your packages are compatible with .NET Core.

First, upgrade your packages to the latest version that you can. This can be done with the NuGet Package Manager UI in Visual Studio. It's likely that newer versions of your package dependencies are already compatible with .NET Core.

## Analyze your package dependencies

If you haven't already verified that your converted and upgraded package dependencies work on .NET Core, there are a few ways that you can achieve that:

### Analyze NuGet packages using nuget.org

You can see the Target Framework Monikers (TFMs) that each package supports on [nuget.org](https://www.nuget.org/) under the **Dependencies** section of the package page.

Although using the site is an easier method to verify the compatibility, **Dependencies** information isn't available on the site for all packages.

### Analyze NuGet packages using NuGet Package Explorer

A NuGet package is itself a set of folders that contain platform-specific assemblies. So you need to check if there's a folder that contains a compatible assembly inside the package.

The easiest way to inspect NuGet Package folders is to use the [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer) tool. After installing it, use the following steps to see the folder names:

1. Open the NuGet Package Explorer.
2. Click **Open package from online feed**.
3. Search for the name of the package.
4. Select the package name from the search results and click **open**.
5. Expand the *lib* folder on the right-hand side and look at folder names.

Look for a folder with names using one the following patterns: `netstandardX.Y` or `netcoreappX.Y`.

These values are the [Target Framework Monikers (TFMs)](../../standard/frameworks.md) that map to versions of the [.NET Standard](../../standard/net-standard.md), .NET Core, and traditional Portable Class Library (PCL) profiles that are compatible with .NET Core.

> [!IMPORTANT]
> When looking at the TFMs that a package supports, note that `netcoreapp*`, while compatible, is for .NET Core projects only and not for .NET Standard projects.
> A library that only targets `netcoreapp*` and not `netstandard*` can only be consumed by other .NET Core apps.

### .NET Framework compatibility mode

After analyzing the NuGet packages, you might find that they only target the .NET Framework, as most NuGet packages do.

Starting with .NET Standard 2.0, the .NET Framework compatibility mode was introduced. This compatibility mode allows .NET Standard and .NET Core projects to reference .NET Framework libraries. Referencing .NET Framework libraries doesn't work for all projects, such as if the library uses Windows Presentation Foundation (WPF) APIs, but it does unblock many porting scenarios.

When you reference NuGet packages that target the .NET Framework in your project, such as [Huitian.PowerCollections](https://www.nuget.org/packages/Huitian.PowerCollections), you get a package fallback warning ([NU1701](/nuget/reference/errors-and-warnings/nu1701)) similar to the following example:

`NU1701: Package ‘Huitian.PowerCollections 1.0.0’ was restored using ‘.NETFramework,Version=v4.6.1’ instead of the project target framework ‘.NETStandard,Version=v2.0’. This package may not be fully compatible with your project.`

That warning is displayed when you add the package and every time you build to make sure you test that package with your project. If your project is working as expected, you can suppress that warning by editing the package properties in Visual Studio or by manually editing the project file in your favorite code editor.

To suppress the warning by editing the project file, find the `PackageReference` entry for the package you want to suppress the warning for and add the `NoWarn` attribute. The `NoWarn` attribute accepts a comma-separated list of all the warning IDs. The following example shows how to suppress the `NU1701` warning for the `Huitian.PowerCollections` package by editing your project file manually:

```xml
<ItemGroup>
  <PackageReference Include="Huitian.PowerCollections" Version="1.0.0" NoWarn="NU1701" />
</ItemGroup>
```

For more information on how to suppress compiler warnings in Visual Studio, see [Suppressing warnings for NuGet packages](/visualstudio/ide/how-to-suppress-compiler-warnings#suppress-warnings-for-nuget-packages).

## What to do when your NuGet package dependency doesn't run on .NET Core

There are a few things you can do if a NuGet package you depend on doesn't run on .NET Core:

1. If the project is open source and hosted somewhere like GitHub, you can engage the developers directly.
2. You can contact the author directly on [nuget.org](https://www.nuget.org/). Search for the package and click **Contact Owners** on the left-hand side of the package's page.
3. You can search for another package that runs on .NET Core that accomplishes the same task as the package you were using.
4. You can attempt to write the code the package was doing yourself.
5. You could eliminate the dependency on the package by changing the functionality of your app, at least until a compatible version of the package becomes available.

Remember that open-source project maintainers and NuGet package publishers are often volunteers. They contribute because they care about a given domain, do it for free, and often have a different daytime job. So be mindful of that when contacting them to ask for .NET Core support.

If you can't resolve your issue with any of the above, you may have to port to .NET Core at a later date.

The .NET Team would like to know which libraries are the most important to support with .NET Core. You can send an email to dotnet@microsoft.com about the libraries you'd like to use.

## Analyze dependencies that aren't NuGet packages

You may have a dependency that isn't a NuGet package, such as a DLL in the file system. The only way to determine the portability of that dependency is to run the [.NET Portability Analyzer](https://github.com/Microsoft/dotnet-apiport) tool. The tool can analyze assemblies that target the .NET Framework and identify APIs that aren't portable to other .NET platforms such as .NET Core. You can run the tool as a console application or as a [Visual Studio extension](../../standard/analyzers/portability-analyzer.md).

>[!div class="step-by-step"]
>[Next](libraries.md)

---
title: Porting to .NET Core - Analyzing your Third-Party Party Dependencies
description: Porting to .NET Core - Analyzing your Third-Party Dependencies
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: b446e9e0-72f6-48f6-92c6-70ad0ce3f86a
---

# Porting to .NET Core - Analyzing your Third-Party Party Dependencies

The first step in the porting process is to understand your third party dependencies.  You need to figure out which of them, if any, don't yet run on .NET Core, and develop a contingency plan for those which don't run on .NET Core.

## Prerequisites

This article will assume you are using Windows and Visual Studio, and that you have code which runs on the .NET Framework today.

## Analyzing NuGet Packages

Analyzing NuGet packages for portability is very easy.  Because a NuGet package is itself a set of folders which contain platform-specific assemblies, all you have to do is check to see if there is a folder which contains a .NET Core assembly.

Inspecting NuGet Package folders is easiest with the [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer) tool.  Here's how to do it.

1. Download and open the NuGet Package Explorer.
2. Click "Open package from online feed".
3. Search for the name of the package.
4. Expand the "lib" folder on the right-hand side and look at folder names.

You can also see what a package supports on [nuget.org](https://www.nuget.org/) under the **Dependencies** section of the page for that package.

In either case, you'll need to look for a folder or entry on [nuget.org](https://www.nuget.org/) with any of the following names:

```
netstandard1.0
netstandard1.1
netstandard1.2
netstandard1.3
netstandard1.4
netstandard1.5
netstandard1.6
netcoreapp1.0
portable-net45-win8
portable-win8-wpa8
portable-net451-win81
portable-net45-win8-wpa8-wpa81
```

These are the Target Framework Monikers (TFM) which map to versions of [The .NET Standard Library](../../standard/library.md) and traditional Portable Class Library (PCL) profiles which are compatible with .NET Core.  Note that `netcoreapp1.0`, while compatible, is for applications and not libraries.  Although there's nothing wrong with using a library which is `netcoreapp1.0`-based, that library may not be intended for anything *other* than consumption by other `netcoreapp1.0` applications.

There are also some legacy TFMs used in pre-release versions of .NET Core that may also be compatible:

```
dnxcore50
dotnet5.0
dotnet5.1
dotnet5.2
dotnet5.3
dotnet5.4
dotnet5.5
```

**While these will likely work with your code, there is no guarantee of compatibility**.  Packages with these TFMs were built with pre-release .NET Core packages.  Take note of when (or if) packages like this are updated to be `netstandard`-based.

> [!NOTE]
> To use a package targeting a traditional PCL or pre-release .NET Core target, you must use the `imports` directive in your `project.json` file.

### What to do when your NuGet package dependency doesn't run on .NET Core

There are a few things you can do if a NuGet package you depend on won't run on .NET Core.

1. If the project is open source and hosted somewhere like GitHub, you can engage the developer(s) directly.
2. You can contact the author directly on [nuget.org](https://www.nuget.org/) by searching for the package and clicking "Contact Owners" on the left hand side of the package's page.
3. You can look for another package that runs on .NET Core which accomplishes the same task as the package you were using.
4. You can attempt to write the code the package was doing yourself.
5. You could eliminate the dependency on the package by changing the functionality of your app, at least until a compatible version of the package becomes available.

Please remember that open source project maintainers and NuGet package publishers are often volunteers who contribute because they care about a given domain, do it for free, and often have a different daytime job. If you do reach out, you might start with a positive statement about the library before asking about .NET Core support.

If you're unable to resolve your issue with any of the above, you may have to port to .NET Core at a later date.

The .NET Team would like to know which libraries are the most important to support next with .NET Core. You can also send us mail at dotnet@microsoft.com about the libraries you'd like to use.

## Analyzing Dependencies which aren't NuGet Packages

You may have a dependency that isn't a NuGet package, such as a DLL in the filesystem.  The only way to determine the portability of that dependency is to run the [ApiPort tool](https://github.com/Microsoft/dotnet-apiport/blob/master/docs/HowTo/).

## Next steps

If you're porting a library, check out [Porting your Libraries](libraries.md).

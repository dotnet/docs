---
title: Using Package Management with F# for Azure
description: Use Paket or Nuget to manage F# Azure dependencies
keywords: visual f#, f#, functional programming, .NET, .NET Core, Azure
author: sylvanc
ms.author: phcart
ms.date: 09/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: dd32ef9c-5416-467e-9fa3-c9ee3bb08456
---

# Package Management for F# Azure Dependencies

Obtaining packages for Azure development is easy when you use a package manager. The two options are [Paket](https://fsprojects.github.io/Paket/) and [NuGet](https://www.nuget.org/).

## Using Paket

If you're using [Paket](https://fsprojects.github.io/Paket/) as your dependency manager, you can use the `paket.exe` tool to add Azure dependencies. For example:

    > paket add nuget WindowsAzure.Storage

Or, if you're using [Mono](https://www.mono-project.com/) for cross-platform .NET development:

    > mono paket.exe add nuget WindowsAzure.Storage

This will add `WindowsAzure.Storage` to your set of package dependencies for the project in the current directory, modify the `paket.dependencies` file, and download the package. If you have previously set up dependencies, or are working with a project where dependencies have been set up by another developer, you can resolve and install dependencies locally like this:

    > paket install

Or, for Mono development:

    > mono paket.exe install

You can update all your package dependencies to the latest version like this:

    > paket update

Or, for Mono development:

    > mono paket.exe update

## Using Nuget

If you're using [NuGet](https://www.nuget.org/) as your dependency manager, you can use the `nuget.exe` tool to add Azure dependencies. For example:

    > nuget install WindowsAzure.Storage -ExcludeVersion

Or, for Mono development:

    > mono nuget.exe install WindowsAzure.Storage -ExcludeVersion

This will add `WindowsAzure.Storage` to your set of package dependencies for the project in the current directory, and download the package. If you have previously set up dependencies, or are working with a project where dependencies have been set up by another developer, you can resolve and install dependencies locally like this:

    > nuget restore 

Or, for Mono development:

    > mono nuget.exe restore

You can update all your package dependencies to the latest version like this:

    > nuget update

Or, for Mono development:

    > mono nuget.exe update

## Referencing Assemblies

In order to use your packages in your F# script, you need to reference the assemblies included in the packages using a `#r` directive. For example:

    > #r "packages/WindowsAzure.Storage/lib/net40/Microsoft.WindowsAzure.Storage.dll"

As you can see, you'll need to specify the relative path to the DLL and the full DLL name, which may not be exactly the same as the package name. The path will include a framework version and possibly a package version number. To find all the installed assemblies, you can use something like this on a Windows command line:

    > cd packages/WindowsAzure.Storage
    > dir /s/b *.dll

Or in a Unix shell, something like this:

    > find packages/WindowsAzure.Storage -name "*.dll"

This will give you the paths to the installed assemblies. From there, you can select the correct path for your framework version.

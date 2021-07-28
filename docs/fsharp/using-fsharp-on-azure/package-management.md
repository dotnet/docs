---
title: Using Package Management with F# for Azure
description: Use Paket or NuGet to manage F# Azure dependencies
author: sylvanc
ms.date: 09/20/2016
ms.custom: "devx-track-fsharp"
---
# Package Management for F# Azure Dependencies

Obtaining packages for Azure development is easy when you use a package manager. The two options are [Paket](https://fsprojects.github.io/Paket/) and [NuGet](https://www.nuget.org/).

## Using Paket

If you're using [Paket](https://fsprojects.github.io/Paket/) as your dependency manager:

Install .NET Core 3.0 or higher, If you don't have it already, you'll need to [download and install the latest .NET Core](https://dotnet.microsoft.com/download).

Install and restore Paket as a local tool in the root of your codebase:

```.NET CLI
> dotnet new tool-manifest
> dotnet tool install paket
> dotnet tool restore
```

Initialize Paket by creating a dependencies file:

```.NET CLI
> dotnet paket init
```

Make the dependencies file look like this to continue:

```paket.dependencies
source https://api.nuget.org/v3/index.json

nuget Azure.Storage.Blobs
```

This will add `Azure.Storage.Blobs` to your set of package dependencies for the project in the current directory, modify the `paket.dependencies` file, and download the package. If you have previously set up dependencies, or are working with a project where dependencies have been set up by another developer, you can resolve and install dependencies locally like this:

```.NET CLI
> dotnet paket install
```

You can update all your package dependencies to the latest version like this:

```.NET CLI
> dotnet paket update
```

## Using NuGet

If you're using [NuGet](https://www.nuget.org/) as your dependency manager:

```.NET CLI
> dotnet add package Azure.Storage.Blobs --version <VERSION>
```

This will add `Azure.Storage.Blobs` to your set of package dependencies for the project in the current directory, and download the package. If you have previously set up dependencies, or are working with a project where dependencies have been set up by another developer, you can resolve and install dependencies locally like this:

```.NET CLI
> dotnet restore
```

You can update all your package dependencies to the latest version like this:

```.NET CLI
> dotnet add package
```

NuGet installs the latest version of the package when you use the `dotnet add package` command unless you specify the package version (`-v` switch).

## Referencing Assemblies

In order to use your packages in your F# script, you need to reference the assemblies included in the packages using a `#r` directive. For example:

```fsharp
> #r "packages/Azure.Storage.Blobs/lib/netstandard2.0/Azure.Storage.Blobs.dll"
```

As you can see, you'll need to specify the relative path to the DLL and the full DLL name, which may not be exactly the same as the package name. The path will include a framework version and possibly a package version number. To find all the installed assemblies, you can use something like this on a Windows command line:

```console
> cd packages/Azure.Storage.Blobs
> dir /s/b *.dll
```

Or in a Unix shell, something like this:

```console
> find packages/Azure.Storage.Blobs -name "*.dll"
```

This will give you the paths to the installed assemblies. From there, you can select the correct path for your framework version.

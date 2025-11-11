---
title: dotnet package download command
description: Learn about the 'dotnet package download' command that downloads a NuGet package.
author: Nigusu-Allehu
ms.date: 11/06/2025
ai-usage: ai-assisted
---
# dotnet package download

> Applies to: ✔️ .NET 10 SDK and later versions.

## Name

`dotnet package download` — Download one or more NuGet packages to disk.

## Synopsis

```
dotnet package download [<packages>...]
    [--output <path>]
    [--configfile <path> ]
    [--prerelease]
    [--source <package source>]
    [--allow-insecure-connections]
    [--interactive]
    [--verbosity <level>]

dotnet package download -h|--help
```

## Description

`dotnet package download` downloads NuGet packages to a local directory. It **does not** add or update `PackageReference` entries in project files and **does not** build or restore a project.
By default, the command downloads only the packages you specify (no transitive dependencies) to the current working directory.

## Arguments

* **`packages`**

  One or more package IDs to download.
  Each package can optionally include a version with `@`.
  If a package version isn't specified, the latest version of the package is downloaded.
  For example, `dotnet package download Contoso.Utilities` or `dotnet package download Contoso.Utilities@3.2.1`.
  
## Options

* **`--allow-insecure-connections`**

     Allows downloading from HTTP sources. Without this flag, insecure sources cause the command to error per [HTTPS-everywhere](https://aka.ms/nuget-https-everywhere) guidance.

* **`--configfile <path>`**

     Path to a NuGet.config to use.

* **`--interactive`**

     Enables interactive authentication if required.

* **`-o, --output <path>`**

     Directory where the package will be placed. Defaults to the current working directory.

* **`--prerelease`**

     Allows downloading prerelease versions.

* **`-s --source <package source>`**

     Specifies the NuGet package source to use.

* **`-v, --verbosity <level>`**

     Set the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.
  
[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

### Download a single package at a specific version

```ps1
dotnet package download Contoso@13.0.3 --output My/Destination/For/packages
```

### Download multiple packages to a custom folder

```ps1
dotnet package download Contoso@3.1.2 Contoso.Utility@6.12.0 --output My/Destination/For/packages
```

---
title: How to Manage Package Dependency Versions for .NET Core 1.0
description: Learn about package dependency version management for your .NET Core libraries and apps.
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 4424a947-bdf9-4775-8d48-dc350a4e0aee
ms.workload: 
  - dotnetcore
---

# How to Manage Package Dependency Versions for .NET Core 1.0

This article covers what you need to know about package versions for your .NET Core libraries and apps.

## Glossary

**Fix** - Fixing dependencies means you are using the same "family" of packages released on NuGet for .NET Core 1.0.

**Metapackage** - A NuGet package that represents a set of NuGet packages.

**Trimming** - The act of removing the packages you do not depend on from a metapackage.  This is something relevant for NuGet package authors.  See [Reducing Package Dependencies with project.json](../deploying/reducing-dependencies.md) for more information. 

## Fix your dependencies to .NET Core 1.0

To reliably restore packages and write reliable code, it's important that you fix your dependencies to the versions of packages shipping alongside .NET Core 1.0.  This means every package should have a single version with no additional qualifiers.

**Examples of packages fixed to 1.0**

`"System.Collections":"4.0.11"`

`"NETStandard.Library":"1.6.0"`

`"Microsoft.NETCore.App":"1.0.0"`

**Examples of packages that are NOT fixed to 1.0**

`"Microsoft.NETCore.App":"1.0.0-rc4-00454-00"`

`"System.Net.Http":"4.1.0-*"`

`"System.Text.RegularExpressions":"4.0.10-rc3-24021-00"`

### Why does this matter?

We guarantee that if you fix your dependencies to what ships alongside .NET Core 1.0, those packages will all work together. There is no such guarantee if you use packages which aren't fixed in this way.

### Scenarios

Although there is a big list of all packages and their versions released with .NET Core 1.0, you may not have to look through it if your code falls under certain scenarios.

**Are you depending only on** `NETStandard.Library`**?**

If so, you should fix your `NETStandard.Library` package to version `1.6`.  Because this is a curated metapackage, its package closure is also fixed to 1.0.

**Are you depending only on** `Microsoft.NETCore.App`**?**

If so, you should fix your `Microsoft.NETCore.App` package to version `1.0.0`.  Because this is a curated metapackage, its package closure is also fixed to 1.0.

**Are you [trimming](../deploying/reducing-dependencies.md) your** `NETStandard.Library` **or** `Microsoft.NETCore.App` **metapackage dependencies?**

If so, you should ensure that the metapackage you start with is fixed to 1.0.  The individual packages you depend on after trimming are also fixed to 1.0.

**Are you depending on packages outside the** `NETStandard.Library` **or** `Microsoft.NETCore.App` **metapackages?**

If so, you need to fix your other dependencies to 1.0.  See the correct package versions and build numbers at the end of this article.

### A note on using a splat string (\*) when versioning

You may have adopted a versioning pattern which uses a splat (\*) string like this:
`"System.Collections":"4.0.11-*"`.

**You should not do this**.  Using the splat string could result in restoring packages from different builds, some of which may be further along than .NET Core 1.0.  This could then result in some packages being incompatible.

## Packages and Version Numbers organized by Metapackage

[List of all .NET Standard packages and their versions for 1.0](https://github.com/dotnet/versions/blob/master/build-info/dotnet/corefx/release/1.0.0/Latest_Packages.txt).

[List of all runtime packages and their versions for 1.0](https://github.com/dotnet/versions/blob/master/build-info/dotnet/coreclr/release/1.0.0/LKG_Packages.txt).

[List of all .NET Core application packages and their versions for 1.0](https://github.com/dotnet/versions/blob/master/build-info/dotnet/core-setup/release/1.0.0/Latest_Packages.txt).

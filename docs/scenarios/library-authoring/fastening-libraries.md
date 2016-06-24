---
title: How to manage package dependency versions for .NET Core 1.0
description: How to manage package dependency versions for .NET Core 1.0
keywords: .NET, .NET Core
author: cartermp
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 4424a947-bdf9-4775-8d48-dc350a4e0aee
---

# How to manage package dependency versions for .NET Core 1.0

This article covers what you need to know about package versions for authoring libraries for .NET Core.

## Glossary

**Fasten** - In the context of authoring libraries, fastening dependencies means you are using the same "family" of packages released on NuGet for .NET Core 1.0.

**Metapackage** - A NuGet package that represents a set of NuGet packages.  They're organized in a way that makes sense for general library and app development.

**Trimming** - The act of removing the packages you do not depend on from a metapackage.  The end result is that your library only depends on packages it uses.  See guidance in [How to trim your package dependencies](trimming.md).

## Fasten your dependencies to 1.0

When creating libraries with .NET Core 1.0, it's important that you fasten your dependencies to 1.0.  This means every package should have a single version with no additional qualifiers.

**Examples of packages fastened to 1.0**

`"System.Collections":"4.0.11"`

`"NETStandard.Library":"1.6.0"`

`"Microsoft.NETCore.App":"1.0.0"`

**Examples of packages that are NOT fastened to 1.0**

`"Microsoft.NETCore.App":"1.0.0-rc4-00454-00"`

`"System.Net.Http":"4.1.0-rc2-24008"`

`"System.Text.RegularExpressions":"4.0.10-rc3-24021-00"`

### Why does this matter?

We guarantee that if you fasten your dependencies to 1.0, those packages will all work together.  There is no such guarantee if you use packages which aren't fastened to 1.0.

### Scenarios

Although there is a big list of all packages and their versions released with .NET Core 1.0, you may not have to look through it if your library falls under certain scenarios.

**Are you depending only on** `NETStandard.Library`**?**

If so, you should fasten your `NETStandard.Library` package to version `1.6`.  Because this is a curated metapackage, its package closure is also fastened to 1.0.

**Are you depending only on** `Microsoft.NETCore.App`**?**

If so, you should fasten your `Microsoft.NETCore.App` package to version `1.0.0`.  Because this is a curated metapackage, its package closure is also fastened to 1.0.

**Are you [trimming](trimming.md) your** `NETStandard.Library` **or** `Microsoft.NETCore.App` **metapackage dependencies?**

If so, you should ensure that the metapackage you start with is fastened to 1.0.  The individual packages you depend on after trimming are also fastened to 1.0.

**Are you depending on packages outside the** `NETStandard.Library` **or** `Microsoft.NETCore.App` **metapackages?**

If so, you need to fasten your other dependencies to 1.0.  See the correct package versions and build numbers at the end of this article.

### A note on using a splat string (\*) when versioning

You may have adopted a versioning pattern which uses a splat (\*) string like this:
`"System.Collections":"4.0.11.-*"`.

**You should not do this**.  Using the splat string could result in restoring packages from different builds, some of which may be further along than .NET Core 1.0.  This could then result in some packages being incompatible.

## Packages and Version Numbers organized by Metapackage

[List of all library packages and their versions for 1.0](https://github.com/dotnet/versions/blob/master/build-info/dotnet/corefx/release/1.0.0/Latest_Packages.txt).

[List of all runtime packages and their versions for 1.0](https://github.com/dotnet/versions/blob/master/build-info/dotnet/coreclr/release/1.0.0/LKG_Packages.txt).

[List of all .NET Core application packages and their versions for 1.0](https://github.com/dotnet/versions/blob/master/build-info/dotnet/core-setup/release/1.0.0/Latest_Packages.txt).
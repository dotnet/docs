---
title: "Breaking change: Directory.Packages.props files is imported by default"
description: Learn about the breaking change in .NET 5 where NuGet's .props files automatically import a file named Directory.Packages.props if it's found in the project folder.
ms.date: 09/17/2020
---
# Directory.Packages.props files is imported by default

NuGet's *.props* files automatically import a file named *Directory.Packages.props* if it's found in the project folder or any of its ancestors.

## Version introduced

5.0

## Change description

In previous .NET versions, you could have a file named *Directory.Packages.props* in your project file and it wouldn't be automatically imported by NuGet's *.props* file at build time.

Starting in .NET 5, such a file *is* automatically imported if it exists in the project folder or any of its ancestors. If you have a file with this name in your project folder, this automatic import could change behavior of the build. For example, the file will be imported but it wasn't before, or the order of when it's imported could change if you specifically import it.

## Reason for change

This change was made in order to support [central package versioning](https://github.com/NuGet/Home/wiki/Centrally-managing-NuGet-package-versions) for NuGet.

## Recommended action

Rename the existing *Directory.Packages.props* file if it should not be imported automatically.

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

MSBuild

-->

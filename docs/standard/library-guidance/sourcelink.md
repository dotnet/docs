---
title: SourceLink and .NET libraries
description: Best practice recommendations for using SourceLink to improve debugging for .NET libraries.
author: jamesnk
ms.author: mairaw
ms.date: 10/02/2018
---
# SourceLink

SourceLink is a technology that enables source code debugging of .NET assemblies from NuGet by developers. SourceLink executes when creating the NuGet package, and embeds source control metadata inside assemblies and the package. Developers who download the package, and have SourceLink enabled in Visual Studio, can step into its source code. SourceLink provides source control metadata to create a great debugging experience.

## SourceLink Demo

> [!VIDEO https://www.youtube.com/embed/gyRGhCQPkB4?start=61]

## Using SourceLink

Instructions for using SourceLink can be found on the [SourceLink GitHub repository](https://github.com/dotnet/sourcelink/blob/master/README.md).

You can use [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer) to confirm SourceLink metadata has been successfully embedded in the package. Check the  `Repository` metadata is present with a comment identifier and that .pdb files are located with each target's .dll.

![SourceLink in NuGet Package Explorer](./media/nuget-package-explorer-sourcelink.png "SourceLink in NuGet Package Explorer")

**✔️ CONSIDER** using SourceLink to add source control metadata to your assemblies and NuGet package.

**✔️ CONSIDER** including PDB files in the NuGet package.

>[!div class="step-by-step"]
[Previous](./dependencies.md)
[Next](./publish-nuget-package.md)
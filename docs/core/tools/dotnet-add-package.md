---
title: dotnet add package command - .NET Core CLI
description: The 'dotnet add package' command provides a convenient option to add a NuGet package reference to a project.
author: mairaw
ms.author: mairaw
ms.date: 05/25/2018
---
# dotnet add package

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet add package` - Adds a package reference to a project file.

## Synopsis

`dotnet add [<PROJECT>] package <PACKAGE_NAME> [-h|--help] [-f|--framework] [-n|--no-restore] [--package-directory] [-s|--source] [-v|--version] [--interactive]`

## Description

The `dotnet add package` command provides a convenient option to add a package reference to a project file. After running the command, there's a compatibility check to ensure the package is compatible with the frameworks in the project. If the check passes, a `<PackageReference>` element is added to the project file and [dotnet restore](dotnet-restore.md) is run.

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

For example, adding `Newtonsoft.Json` to *ToDo.csproj* produces output similar to the following example:

```console
  Writing C:\Users\mairaw\AppData\Local\Temp\tmp95A8.tmp
info : Adding PackageReference for package 'Newtonsoft.Json' into project 'C:\projects\ToDo\ToDo.csproj'.
log  : Restoring packages for C:\projects\ToDo\ToDo.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json 235ms
info : Package 'Newtonsoft.Json' is compatible with all the specified frameworks in project 'C:\projects\ToDo\ToDo.csproj'.
info : PackageReference for package 'Newtonsoft.Json' version '10.0.3' added to file 'C:\projects\ToDo\ToDo.csproj'.
```

The *ToDo.csproj* file now contains a [`<PackageReference>`](/nuget/consume-packages/package-references-in-project-files) element for the referenced package.

```xml
<PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
```

## Arguments

`PROJECT`

Specifies the project file. If not specified, the command searches the current directory for one.

`PACKAGE_NAME`

The package reference to add.

## Options

`-h|--help`

Prints out a short help for the command.

`-f|--framework <FRAMEWORK>`

Adds a package reference only when targeting a specific [framework](../../standard/frameworks.md).

`-n|--no-restore`

Adds a package reference without performing a restore preview and compatibility check.

`--package-directory <PACKAGE_DIRECTORY>`

Restores the package to the specified directory.

`-s|--source <SOURCE>`

Uses a specific NuGet package source during the restore operation.

`-v|--version <VERSION>`

Version of the package.

`--interactive`

Allows the command to stop and wait for user input or action (for example to complete authentication). Since .NET Core 2.1.400.

## Examples

Add `Newtonsoft.Json` NuGet package to a project:

`dotnet add package Newtonsoft.Json`

Add a specific version of a package to a project:

`dotnet add ToDo.csproj package Microsoft.Azure.DocumentDB.Core -v 1.0.0`

Add a package using a specific NuGet source:

`dotnet add package Microsoft.AspNetCore.StaticFiles -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json`

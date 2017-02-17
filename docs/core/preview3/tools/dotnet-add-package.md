---
title: dotnet-add package command | Microsoft Docs
description: The dotnet-add package command provides a convenient option to add NuGet package reference to a project.
keywords: dotnet-add , CLI, CLI command, .NET Core
author: spboyer
ms.author: mairaw
ms.date: 02/16/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 88e0da69-a5ea-46cc-8b46-5493242b7af9
---
# dotnet-add package

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name

`dotnet-add package` - Adds a package reference to a project file. After running the command, there is a compatibility check to ensure the package attempting to be added is compatible with all of the frameworks in the project. If the check passes, a restore is run and the `<PackageReference>` fragment is added to the project file.

For example, adding Newtonsoft.Json to ToDo.csproj produces the following output:

```
Microsoft (R) Build Engine version 15.1.545.13942
Copyright (C) Microsoft Corporation. All rights reserved.

  Writing /var/folders/gj/1mgg_4jx7mbdqbhw1kgcpcjr0000gn/T/tmpm0kTMD.tmp
info : Adding PackageReference for package 'Newtonsoft.Json' into project 'ToDo.csproj'.
log  : Restoring packages for ToDo.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/index.json 119ms
info :   GET https://api.nuget.org/v3-flatcontainer/newtonsoft.json/9.0.1/newtonsoft.json.9.0.1.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/newtonsoft.json/9.0.1/newtonsoft.json.9.0.1.nupkg 27ms
info : Package 'Newtonsoft.Json' is compatible with all the specified frameworks in project 'ToDo.csproj'.
info : PackageReference for package 'Newtonsoft.Json' version '9.0.1' added to file 'ToDo.csproj'.
```

The ToDo.csproj file now contains `<PackageReference>` fragment for the referenced package.

```xml
<PackageReference Include="Newtonsoft.Json">
    <Version>9.0.1</Version>
</PackageReference>
```

## Synopsis

```
dotnet add [<PROJECT>] package <PACKAGE_NAME> [-v|--version] [-f|--framework] [-s|--source] [--package-directory] [-h|--help]
dotnet add package [-h|--help]
```

## Description

The `dotnet add package` command provides a convenient option to add a NuGet package reference to a project.

## Arguments

`PROJECT`

Project file to be modified. If not specified, the command searches the current directory for one.

`PACKAGE_NAME`

The package reference to add.

## Options

`-h|--help`

Prints out a short help for the command or argument.

`-v|--version <VERSION>`

Version of the package.

`-f|--framework <FRAMEWORK>`

Add a package reference only when targetting a specific framework.

`-n|--no-restore`

Add a package reference without performing restore preview and compatibility check.

`-s|--source`

Use specific NuGet package sources to use during the restore.

`--package-directory`

Restore the packages to this directory.

## Examples

Add Newtonsoft.Json NuGet package to a project:

`dotnet add package Newtonsoft.Json`

Add a specific version of a package to a project:

`dotnet add ToDo.csproj package Microsoft.Azure.DocumentDB.Core -v 1.0.0`

Specify NuGet source for package.

`dotnet add package Microsoft.AspNetCore.StaticFiles -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json`
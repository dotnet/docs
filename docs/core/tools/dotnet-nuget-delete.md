---
title: dotnet nuget delete command
description: The 'dotnet nuget delete' command deletes or unlists a package from the server. 
keywords: dotnet nuget delete, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 6ddffde4-c789-4e90-990e-d35f6a6565d4
---

# dotnet nuget delete

## Name

`dotnet nuget delete` - Deletes or unlists a package from the server.

## Synopsis

`dotnet nuget delete [<PACKAGE_NAME> <PACKAGE_VERSION>] [--force-english-output] [-h|--help] [-k|--api-key] [--non-interactive] [-s|--source]`

## Description

The `dotnet nuget delete` command deletes or unlists a package from the server. For [NuGet.org](https://www.nuget.org/), the action is to unlist the package (See NOTE).

> [!NOTE]
> It isn't possible to permanently delete a package from NuGet.org; you can only *unlist* a package. For more information, see the [Deleting packages](https://docs.microsoft.com/nuget/policies/deleting-packages) topic in the NuGet documentation.

## Arguments

`PACKAGE_NAME`

The package to delete.

`PACKAGE_VERSION`

The version of the package to delete.

## Options

`--force-english-output`

Forces command-line output in English.

`-h|--help`

Shows help information.

`-k|--api-key <API_KEY>`

The API key for the server.

`--non-interactive`

Don't prompt for user input or confirmations.

`-s|--source <SOURCE>`

Specifies the server URL. Supported URLs for [NuGet.org](https://www.nuget.org/) include `http://www.nuget.org`, `http://www.nuget.org/api/v3`, and `http://www.nuget.org/api/v2/package`. For private feeds, use the host name for `SOURCE` (for example, `%hostname%/api/v3`).

## Examples

Delete version 1.0 of package `Microsoft.AspNetCore.Mvc`:

`dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0` 

Delete version 1.0 of package `Microsoft.AspNetCore.Mvc` and don't prompt the user for credentials or other input:

`dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0 --non-interactive`

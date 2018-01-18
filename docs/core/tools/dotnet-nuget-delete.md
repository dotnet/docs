---
title: dotnet nuget delete command - .NET Core CLI
description: The dotnet-nuget-delete command deletes or unlists a package from the server.
author: karann-msft
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet nuget delete

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet nuget delete` - Deletes or unlists a package from the server.

## Synopsis

`dotnet nuget delete [<PACKAGE_NAME> <PACKAGE_VERSION>] [-s|--source] [--non-interactive] [-k|--api-key] [--force-english-output] [-h|--help]`

## Description

The `dotnet nuget delete` command deletes or unlists a package from the server. For [nuget.org](https://www.nuget.org/), the action is to unlist the package.

## Arguments

`PACKAGE_NAME`

Package to delete.

`PACKAGE_VERSION`

Version of the package to delete.

## Options

`-h|--help`

Prints out a short help for the command.

`-s|--source <SOURCE>`

Specifies the server URL. Supported URLs for nuget.org include `http://www.nuget.org`, `http://www.nuget.org/api/v3`, and `http://www.nuget.org/api/v2/package`. For private feeds, substitute the host name (for example, `%hostname%/api/v3`).

`--non-interactive`

Doesn't prompt for user input or confirmations.

`-k|--api-key <API_KEY>`

The API key for the server.

`--force-english-output`

Forces command-line output in English.

## Examples

Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`:

`dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0` 

Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`, not prompting user for credentials or other input:

`dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0 --non-interactive`
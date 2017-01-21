---
title: dotnet-nuget-delete command | Microsoft Docs
description: The dotnet-nuget-delete command deletes or unlists a package from the server. 
keywords: dotnet-nuget-delete, CLI, CLI command, .NET Core
author: karann-msft
ms.author: mairaw
ms.date: 11/11/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 6ddffde4-c789-4e90-990e-d35f6a6565d4
---

#dotnet-nuget-delete

[!INCLUDE[preview-warning](../../../includes/warning.md)]

## Name 
`dotnet-nuget-delete` - Deletes or unlists a package from the server. 

## Synopsis

`dotnet nuget delete [<package_name> <package_version>] 
    [--help] [--source] [--non-interactive] 
    [--api-key] [--force-english-output] [--verbosity] [--config-file]`

## Description

The `dotnet nuget delete` command deletes or unlists a package from the server. For NuGet.org, the action is to unlist the package.

## Options

`-h|--help`

Prints out a short help for the command.  

`-s|--source <SOURCE>`

Specifies the server URL. Supported URL's for nuget.org include `http://www.nuget.org`, `http://www.nuget.org/api/v3` and `http://www.nuget.org/api/v2/package`. 
For private feeds, substitute the host name (for example, `%hostname%/api/v3`).

`--non-interactive`

Does not prompt for user input or confirmations.

`-k|--api-key <API_KEY>`

The API key for the server.

`--force-english-output`

Forces command-line output to be in English.

`--verbosity <LEVEL>`

Displays this amount of details in the output. Level can be `normal`, `quiet`, or `detailed`.

`--config-file <FILE>`

A NuGet configuration file used specifically for this command, replacing other config files found by the standard config file discovery and chaining process. 
The path can be absolute or relative.
For more information on config files, see [Configuring NuGet Behavior](https://docs.microsoft.com/nuget/consume-packages/configuring-nuget-behavior).

## Examples

Deletes version 1.0 of package MyPackage:

`dotnet nuget delete MyPackage 1.0` 

Deletes version 1.0 of package MyPackage, not prompting user for credentials or other input:

`dotnet nuget delete MyPackage 1.0 --non-interactive`

Deletes version 1.0 of package MyPackage, specifying a custom config file *./config/My.Config*:

`dotnet nuget delete MyPackage 1.0 --config-file ./config/My.Config`

Deletes version 1.0 of package MyPackage, with maximum verbosity:

`dotnet nuget delete MyPackage 1.0 --verbosity detailed`

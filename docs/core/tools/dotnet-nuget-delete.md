---
title: dotnet nuget delete command - .NET Core CLI
description: The dotnet-nuget-delete command deletes or unlists a package from the server.
author: karann-msft
ms.author: mairaw
ms.date: 06/01/2018
---
# dotnet nuget delete

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet nuget delete` - Deletes or unlists a package from the server.

## Synopsis

# [.NET Core 2.1](#tab/netcore21)
```
dotnet nuget delete [<PACKAGE_NAME> <PACKAGE_VERSION>] [--force-english-output] [-k|--api-key] [--no-service-endpoint]
    [--non-interactive] [-s|--source]
dotnet nuget delete [-h|--help]
```
# [.NET Core 2.0](#tab/netcore20)
```
dotnet nuget delete [<PACKAGE_NAME> <PACKAGE_VERSION>] [--force-english-output] [-k|--api-key] [--non-interactive]
    [-s|--source]
dotnet nuget delete [-h|--help]
```
# [.NET Core 1.x](#tab/netcore1x)
```
dotnet nuget delete [<PACKAGE_NAME> <PACKAGE_VERSION>] [--force-english-output] [-k|--api-key] [--non-interactive]
    [-s|--source]
dotnet nuget delete [-h|--help]
```
---

## Description

The `dotnet nuget delete` command deletes or unlists a package from the server. For [nuget.org](https://www.nuget.org/), the action is to unlist the package.

## Arguments

`PACKAGE_NAME`

Name/ID of the package to delete.

`PACKAGE_VERSION`

Version of the package to delete.

## Options

# [.NET Core 2.1](#tab/netcore21)

`--force-english-output`

 Forces the application to run using an invariant, English-based culture.

`-h|--help`

Prints out a short help for the command.

`-k|--api-key <API_KEY>`

The API key for the server.

`--no-service-endpoint`
Doesn't append "api/v2/package" to the source URL.

`--non-interactive`

Doesn't prompt for user input or confirmations.

`-s|--source <SOURCE>`

Specifies the server URL. Supported URLs for nuget.org include `https://www.nuget.org`, `https://www.nuget.org/api/v3`, and `https://www.nuget.org/api/v2/package`. For private feeds, replace the host name (for example, `%hostname%/api/v3`).

# [.NET Core 2.0](#tab/netcore20)

`--force-english-output`

 Forces the application to run using an invariant, English-based culture.

`-h|--help`

Prints out a short help for the command.

`-k|--api-key <API_KEY>`

The API key for the server.

`--non-interactive`

Doesn't prompt for user input or confirmations.

`-s|--source <SOURCE>`

Specifies the server URL. Supported URLs for nuget.org include `https://www.nuget.org`, `https://www.nuget.org/api/v3`, and `https://www.nuget.org/api/v2/package`. For private feeds, replace the host name (for example, `%hostname%/api/v3`).

# [.NET Core 1.x](#tab/netcore1x)

`--force-english-output`

 Forces the application to run using an invariant, English-based culture.

`-h|--help`

Prints out a short help for the command.

`-k|--api-key <API_KEY>`

The API key for the server.

`--non-interactive`

Doesn't prompt for user input or confirmations.

`-s|--source <SOURCE>`

Specifies the server URL. Supported URLs for nuget.org include `https://www.nuget.org`, `https://www.nuget.org/api/v3`, and `https://www.nuget.org/api/v2/package`. For private feeds, replace the host name (for example, `%hostname%/api/v3`).

---

## Examples

Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`:

`dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0`

Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`, not prompting user for credentials or other input:

`dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0 --non-interactive`

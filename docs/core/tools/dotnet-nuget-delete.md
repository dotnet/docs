---
title: dotnet nuget delete command
description: The dotnet-nuget-delete command deletes or unlists a package from the server.
author: karann-msft
ms.date: 03/21/2023
---
# dotnet nuget delete

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet nuget delete` - Deletes or unlists a package from the server.

## Synopsis

```dotnetcli
dotnet nuget delete [<PACKAGE_NAME> <PACKAGE_VERSION>] [--force-english-output]
    [--interactive] [-k|--api-key <API_KEY>] [--no-service-endpoint]
    [--non-interactive] [-s|--source <SOURCE>]

dotnet nuget delete -h|--help
```

## Description

The `dotnet nuget delete` command deletes or unlists a package from the server. For [nuget.org](https://www.nuget.org/), the action is to unlist the package.

## Arguments

* **`PACKAGE_NAME`**

  Name/ID of the package to delete.

* **`PACKAGE_VERSION`**

  Version of the package to delete.

## Options

* **`--force-english-output`**

  Forces the application to run using an invariant, English-based culture.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

* **`-k|--api-key <API_KEY>`**

  The API key for the server.

* **`--no-service-endpoint`**

  By default, the command appends "/api/v2/package" to the URL specified This option is for custom feeds that must use the source URL as it's specified with the `--source` option. For more information, see the `--source` option later in this article.

* **`--non-interactive`**

  Doesn't prompt for user input or confirmations.

* **`-s|--source <SOURCE>`**

  Specifies the server URL. The URL specified by using this option can be either V2 (`https://www.nuget.org/api/v2/`) or V3 (`https://api.nuget.org/v3/index.json`). For private feeds, replace the host name (for example, `%hostname%/api/v3/index.json`).

## Examples

* Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`:

  ```dotnetcli
  dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0
  ```

* Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`, not prompting user for credentials or other input:

  ```dotnetcli
  dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0 --non-interactive
  ```

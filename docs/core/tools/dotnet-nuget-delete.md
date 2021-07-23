---
title: dotnet nuget delete command
description: The dotnet-nuget-delete command deletes or unlists a package from the server.
author: karann-msft
ms.date: 06/26/2019
---
# dotnet nuget delete

**This article applies to:** ✔️ .NET Core 1.x SDK and later versions

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

<!-- markdownlint-disable MD012 -->

* **`--force-english-output`**

  Forces the application to run using an invariant, English-based culture.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

* **`-k|--api-key <API_KEY>`**

  The API key for the server.

* **`--no-service-endpoint`**

  Doesn't append "api/v2/package" to the source URL. Option available since .NET Core 2.1 SDK.

* **`--non-interactive`**

  Doesn't prompt for user input or confirmations.

* **`-s|--source <SOURCE>`**

  Specifies the server URL. Supported URLs for nuget.org include `https://www.nuget.org`, `https://www.nuget.org/api/v3`, and `https://www.nuget.org/api/v2/package`. For private feeds, replace the host name (for example, `%hostname%/api/v3`).

## Examples

* Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`:

  ```dotnetcli
  dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0
  ```

* Deletes version 1.0 of package `Microsoft.AspNetCore.Mvc`, not prompting user for credentials or other input:

  ```dotnetcli
  dotnet nuget delete Microsoft.AspNetCore.Mvc 1.0 --non-interactive
  ```

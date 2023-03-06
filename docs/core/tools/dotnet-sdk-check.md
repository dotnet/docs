---
title: dotnet sdk check command
description: The 'dotnet sdk check' command tells you what is the latest available version of the .NET SDK and .NET Runtime.
ms.date: 06/30/2021
---
# dotnet sdk check

**This article applies to:** ✔️ .NET 6 and later versions

## Name

`dotnet sdk check` - Lists the latest available version of the .NET SDK and .NET Runtime, for each feature band.

## Synopsis

```dotnetcli
dotnet sdk check

dotnet sdk check -h|--help
```

## Description

The `dotnet sdk check` command makes it easier to track when new versions of the SDK and Runtimes are available. Within each feature band it tells you:

* The latest available version of the .NET SDK and .NET Runtime.
* Whether your installed versions are up-to-date or out of support.

Here's an example of output from the command:

```output
.NET SDKs:
3.1.426      .NET 3.1 is out of support.
7.0.103      Up to date.
7.0.200      Patch 7.0.201 is available.

.NET Runtimes:
Name                              Version      Status
--------------------------------------------------------------------------
Microsoft.AspNetCore.App          5.0.17       .NET 5.0 is out of support.
Microsoft.NETCore.App             5.0.17       .NET 5.0 is out of support.
Microsoft.WindowsDesktop.App      5.0.17       .NET 5.0 is out of support.
Microsoft.NETCore.App             6.0.10       Patch 6.0.14 is available.
Microsoft.NETCore.App             6.0.11       Patch 6.0.14 is available.
Microsoft.NETCore.App             6.0.13       Patch 6.0.14 is available.
Microsoft.AspNetCore.App          7.0.3        Up to date.
Microsoft.NETCore.App             7.0.3        Up to date.
Microsoft.WindowsDesktop.App      7.0.3        Up to date.

The latest versions of .NET can be installed from https://aka.ms/dotnet-core-download. For more information about .NET lifecycles, see https://aka.ms/dotnet-core-support.
```

## Options

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Show up-to-date status of installed .NET SDKs and .NET Runtimes.

  ```dotnetcli
  dotnet sdk check
  ```

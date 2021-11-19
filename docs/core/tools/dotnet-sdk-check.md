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
Version                         Status
-----------------------------------------------------------
2.1.816                         Up to date.
2.2.401                         .NET 2.2 is out of support.
3.1.410                         Up to date.
5.0.204                         Up to date.
5.0.301                         Up to date.

.NET Runtimes:
Name                              Version                       Status
-------------------------------------------------------------------------------------------
Microsoft.AspNetCore.All          2.1.28                        Up to date.
Microsoft.AspNetCore.App          2.1.28                        Up to date.
Microsoft.NETCore.App             2.1.28                        Up to date.
Microsoft.AspNetCore.All          2.2.6                         .NET 2.2 is out of support.
Microsoft.AspNetCore.App          2.2.6                         .NET 2.2 is out of support.
Microsoft.NETCore.App             2.2.6                         .NET 2.2 is out of support.
Microsoft.AspNetCore.App          3.1.16                        Up to date.
Microsoft.NETCore.App             3.1.16                        Up to date.
Microsoft.WindowsDesktop.App      3.1.16                        Up to date.
Microsoft.AspNetCore.App          5.0.7                         Up to date.
Microsoft.NETCore.App             5.0.7                         Up to date.
Microsoft.WindowsDesktop.App      5.0.7                         Up to date.
```

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Show up-to-date status of installed .NET SDKs and .NET Runtimes.

  ```dotnetcli
  dotnet sdk check
  ```

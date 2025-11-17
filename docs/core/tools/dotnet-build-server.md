---
title: dotnet build-server command
description: The dotnet build-server command interacts with servers started by a build.
ms.date: 10/28/2025
---
# dotnet build-server

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet build-server` - Interacts with servers started by a build.

## Synopsis

```dotnetcli
dotnet build-server shutdown [--msbuild] [--razor] [--vbcscompiler]

dotnet build-server shutdown -h|--help

dotnet build-server -h|--help
```

## Commands

- **`shutdown`**

  Shuts down build servers that are started from dotnet. By default, all servers are shut down.

## Options

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--msbuild`**

  Shuts down the MSBuild build server.

- **`--razor`**

  Shuts down the Razor build server.

- **`--vbcscompiler`**

  Shuts down the VB/C# compiler build server.

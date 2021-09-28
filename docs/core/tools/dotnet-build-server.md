---
title: dotnet build-server command
description: The dotnet build-server command interacts with servers started by a build.
ms.date: 02/14/2020
---
# dotnet build-server

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

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

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--msbuild`**

  Shuts down the MSBuild build server.

- **`--razor`**

  Shuts down the Razor build server.

- **`--vbcscompiler`**

  Shuts down the VB/C# compiler build server.

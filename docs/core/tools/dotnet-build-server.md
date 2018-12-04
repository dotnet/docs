---
title: dotnet build-server command - .NET Core CLI
description: The dotnet build-server command interacts with servers started by a build.
ms.date: 12/04/2018
---
# dotnet build-server

[!INCLUDE [topic-appliesto-net-core-21plus](../../../includes/topic-appliesto-net-core-21plus.md)]

## Name

`dotnet build-server` - Interacts with servers started by a build.

## Synopsis

```
dotnet build-server shutdown [--msbuild] [--razor] [--vbcscompiler]
dotnet build-server shutdown [-h|--help]
dotnet build-server [-h|--help]
```

## Commands

* **`shutdown`**

  Shuts down build servers that are started from dotnet. By default, all servers are shut down.

## Options

* **`-h|--help`**

  Prints out a short help for the command.

* **`--msbuild`**

  Shuts down the MSBuild build server.

* **`--razor`**

  Shuts down the Razor build server.

* **`--vbcscompiler`**

  Shuts down the VB/C# compiler build server.
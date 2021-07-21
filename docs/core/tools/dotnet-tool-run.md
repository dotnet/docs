---
title: dotnet tool run command
description: The dotnet tool run command invokes a local tool.
ms.date: 02/14/2020
---
# dotnet tool run

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

## Name

`dotnet tool run` - Invokes a local tool.

## Synopsis

```dotnetcli
dotnet tool run <COMMAND NAME>

dotnet tool run -h|--help
```

## Description

The `dotnet tool run` command searches tool manifest files that are in scope for the current directory. When it finds a reference to the specified tool, it runs the tool. For more information, see [Invoke a local tool](global-tools.md#invoke-a-local-tool).

## Arguments

- **`COMMAND_NAME`**

  The command name of the tool to run.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Example

- **`dotnet tool run dotnetsay`**

  Runs the `dotnetsay` local tool.

## See also

- [.NET tools](global-tools.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)

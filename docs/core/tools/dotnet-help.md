---
title: dotnet help command
description: The dotnet help command shows more detailed documentation online for the specified command.
ms.date: 02/14/2020
---
# dotnet help reference

**This article applies to:** ✔️ .NET Core 2.0 SDK and later versions

## Name

`dotnet help` - Shows more detailed documentation online for the specified command.

## Synopsis

```dotnetcli
dotnet help <COMMAND_NAME> [-h|--help]
```

## Description

The `dotnet help` command opens up the reference page for more detailed information about the specified command at docs.microsoft.com.

## Arguments

- **`COMMAND_NAME`**

  Name of the .NET CLI command. For a list of the valid CLI commands, see [CLI commands](index.md#cli-commands).

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Opens the documentation page for the [dotnet new](dotnet-new.md) command:

  ```dotnetcli
  dotnet help new
  ```
